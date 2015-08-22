using System.Windows.Forms;

namespace BefunGen
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
			
			tabMainControl.SelectedIndex = 0;
		}
		
		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			control_BefunGen.frm_Closing(sender, e);
		}
	}
}

//TODO BefunTool : Compare two programs (graph compare, ignores NOP's and posiitons on grid)
//tODO Resharper Inspections (Solution-wide)