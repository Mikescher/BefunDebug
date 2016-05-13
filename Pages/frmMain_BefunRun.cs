using BefunGen.Helper;
using System;
using System.IO;
using System.Windows.Forms;

namespace BefunGen.Pages
{
	public partial class frmMain_BefunRun : UserControl
	{
		public frmMain_BefunRun()
		{
			InitializeComponent();

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

			var result = ProcessHelper.ProcExecute("BefunRun", $"\"{path}\" --errorlevel={errorlevel} --limit={limit}");

			File.Delete(path);

			edReturnCode.Text = result.ExitCode.ToString();
			edStdOut.Text = result.StdOut;
			edStdErr.Text = result.StdErr;
		}
	}
}
