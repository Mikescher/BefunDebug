using BefunDebug.BCTestData;
using BefunDebug.Helper;
using BefunDebug.ThreadRunner;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BefunDebug.Pages
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
			try
			{
				int errorlevel = cbxErrorLevel.SelectedIndex;
				int limit = (int)edLimit.Value;
				string code = edInputCode.Text.Replace('¤', 'E');
				string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".b93");
				File.WriteAllText(path, code, Encoding.ASCII);

				var result = ProcessHelper.ProcExecute("BefunRun", $"\"{path}\" --errorlevel={errorlevel} --limit={limit}" + (cbInfoRun.Checked ? " --info" : ""));

				File.Delete(path);

				edReturnCode.Text = result.ExitCode.ToString();
				edStdOut.Text = result.StdOut;
				edStdErr.Text = result.StdErr;
			}
			catch (Exception ex)
			{
				edStdErr.Text = ex.ToString();
				edReturnCode.Text = "INTERNAL ERR";
			}
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
