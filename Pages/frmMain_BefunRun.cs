using BefunGen.BCTestData;
using BefunGen.Helper;
using BefunGen.ThreadRunner;
using System;
using System.IO;
using System.Windows.Forms;

namespace BefunGen.Pages
{
	public partial class frmMain_BefunRun : UserControl
	{
		private BefunRunInfoCollector infoCollector;

		public frmMain_BefunRun()
		{
			InitializeComponent();

			infoCollector = new BefunRunInfoCollector(tbInfoOutput, btnAllInfo);

			tabCtrlMain.SelectedIndex = 0;
			cbxErrorLevel.SelectedIndex = 0;
			edInputCode.Text = Properties.Resources.testdata_041;
		}

		private void GenericTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && (e.KeyCode == Keys.A))
			{
				(sender as TextBox)?.SelectAll();
				e.Handled = true;
			}
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			int errorlevel = cbxErrorLevel.SelectedIndex;
			int limit = (int) edLimit.Value;
			string code = edInputCode.Text;
			string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".b93");
			File.WriteAllText(path, code);

			var result = ProcessHelper.ProcExecute("BefunRun", $"\"{path}\" --errorlevel={errorlevel} --limit={limit}" + (cbInfoRun.Checked ? " --info" : ""));

			File.Delete(path);

			edReturnCode.Text = result.ExitCode.ToString();
			edStdOut.Text = result.StdOut;
			edStdErr.Text = result.StdErr;
		}

		private void btnAllInfo_Click(object sender, EventArgs e)
		{
			infoCollector.TriggerAction(BefunCompileTestData.Data);
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			base.OnHandleDestroyed(e);

			infoCollector.Stop();
		}
	}
}
