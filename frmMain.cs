using System;
using System.Windows.Forms;

namespace BefunGen
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
			
			tabMainControl.SelectedIndex = Program.GetConfigValue(this, "SelectedTab", 0);
		}
		
		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			control_BefunGen.frm_Closing(sender, e);
		}

		private void tabMainControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			Program.SetConfigValue(this, "SelectedTab", tabMainControl.SelectedIndex);
		}
	}
}

//TODO BefunTool : Compare two programs (graph compare, ignores NOP's and posiitons on grid)
//tODO Resharper Inspections (Solution-wide)

//TODO BefunGIF --> Generate FullRes Images and gifs from befunge-progs
//              --> (like BeunExec View)
//              --> (also BefunExec Debug View)
//              --> Show optional stack in gif
//              --> evtl create gfy 