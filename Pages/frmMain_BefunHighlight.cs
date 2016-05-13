using BefunHighlight;
using System;
using System.Windows.Forms;

namespace BefunGen.Pages
{
	public partial class frmMain_BefunHighlight : UserControl
	{
		public frmMain_BefunHighlight()
		{
			InitializeComponent();
		}

		private void btnHighlight_Click(object sender, EventArgs e)
		{
			string eh = edHighlightCode.Text;

			int w;
			int h;
			BeGraphCommand[,] cmds = BeGraphHelper.parse(eh, out w, out h);

			BeGraph graph = new BeGraph(w, h);

			graph.Calculate(0, 0, BeGraphDirection.LeftRight, cmds);

			string dh = graph.toDebugString();

			edHighlighted.Text = dh;
			tcHighlight.SelectedIndex = 1;
		}
	}
}
