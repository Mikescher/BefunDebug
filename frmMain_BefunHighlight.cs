using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BefunHighlight;

namespace BefunGen
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
