using System;
using System.Threading;
using System.Windows.Forms;

namespace BefunGen.ThreadRunner
{
	public abstract class ThreadRunner<T>
	{
		protected bool ForceStop = false;
		private bool running = false;
		private Thread runner = null;

		private readonly Button btnCaller;

		protected ThreadRunner(Button caller)
		{
			btnCaller = caller;
		}

		public void TriggerAction(T data)
		{
			if (!running)
			{
				btnCaller.Text = "Starting ...";

				runner = new Thread(Run);

				ForceStop = false;
				runner.Start(data);
			}
			else
			{
				btnCaller.Text = "Stopping";

				ForceStop = true;

				int i = 0;
				while (running)
				{
					i++;
					btnCaller.Text = new string('.', i % 4) + " Stopping " + new string('.', i % 4);
					btnCaller.Refresh();

					Thread.Sleep(200);
				}

				ForceStop = false;

				btnCaller.Text = GetButtonTextStart();
			}
		}

		private void Run(object odata)
		{
			var data = (T)odata;
			running = true;

			try
			{
				btnCaller.BeginInvoke(new Action(() => { btnCaller.Text = GetButtonTextStop(); }));

				RunAction(data);
			}
			finally
			{
				if (ForceStop) Thread.Sleep(2000);
				btnCaller.BeginInvoke(new Action(() => { btnCaller.Text = GetButtonTextStart(); }));

				running = false;
			}
		}

		protected abstract string GetButtonTextStart();
		protected abstract string GetButtonTextStop();
		
		protected abstract bool RunAction(T data);

		protected void Output(TextBox box, string line)
		{
			box.BeginInvoke(new Action(() =>
			{
				box.Text += line;
				box.SelectionStart = box.Text.Length;
				box.ScrollToCaret();
			}));
		}

		protected void OutputLine(TextBox box, string line = "")
		{
			box.BeginInvoke(new Action(() =>
			{
				box.Text += line + Environment.NewLine;
				box.SelectionStart = box.Text.Length;
				box.ScrollToCaret();
			}));
		}

		public void Stop()
		{
			ForceStop = true;
		}
	}
}
