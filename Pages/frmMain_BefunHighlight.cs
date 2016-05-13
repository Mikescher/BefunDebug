using BefunHighlight;
using System;
using System.Text;
using System.Windows.Forms;

namespace BefunGen.Pages
{
	public partial class frmMain_BefunHighlight : UserControl
	{
		public frmMain_BefunHighlight()
		{
			InitializeComponent();

			edHighlightCode.Text = Properties.Resources.testdata_043;
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

			edBigGraph.Text = CreateGraphString(graph);
		}

		private string CreateGraphString(BeGraph graph)
		{
			StringBuilder sb = new StringBuilder();

			for (int sby = 0; sby < graph.Height * 3; sby++)
			{
				for (int sbx = 0; sbx < graph.Width * 3; sbx++)
				{
					int x = sbx / 3;
					int y = sby / 3;

					int dx = sbx % 3;
					int dy = sby % 3;

					var f = graph.fields[x, y];

					var i_n = f.incoming_information_top;
					var i_e = f.incoming_information_right;
					var i_s = f.incoming_information_bottom;
					var i_w = f.incoming_information_left;

					var o_n = f.outgoing_information_top;
					var o_e = f.outgoing_information_right;
					var o_s = f.outgoing_information_bottom;
					var o_w = f.outgoing_information_left;

					var io_n = i_n || o_n;
					var io_e = i_e || o_e;
					var io_s = i_s || o_s;
					var io_w = i_w || o_w;

					if (dx == 0 && dy == 0)
					{
						// #OO
						// OOO
						// OOO

						sb.Append(' ');
					}
					else if (dx == 1 && dy == 0)
					{
						// O#O
						// OOO
						// OOO

						if (i_n && o_n) sb.Append('|');
						if (!i_n && o_n) sb.Append('^');
						if (i_n && !o_n) sb.Append('v');
						if (!i_n && !o_n) sb.Append(' ');
					}
					else if(dx == 2 && dy == 0)
					{
						// OO#
						// OOO
						// OOO

						sb.Append(' ');
					}
					else if (dx == 0 && dy == 1)
					{
						// OOO
						// #OO
						// OOO

						if (i_w && o_w) sb.Append('-');
						if (!i_w && o_w) sb.Append('<');
						if (i_w && !o_w) sb.Append('>');
						if (!i_w && !o_w) sb.Append(' ');
					}
					else if (dx == 1 && dy == 1)
					{
						// OOO
						// O#O
						// OOO
						
						if (f.is_jump)
						{
							sb.Append('#');
						}
						else
						{
							if (io_n && io_e && io_s && io_w) sb.Append('+');
							if (io_n && io_e && io_s && !io_w) sb.Append('+');
							if (io_n && io_e && !io_s && io_w) sb.Append('+');
							if (io_n && io_e && !io_s && !io_w) sb.Append('+');
							if (io_n && !io_e && io_s && io_w) sb.Append('+');
							if (io_n && !io_e && io_s && !io_w) sb.Append('|');
							if (io_n && !io_e && !io_s && io_w) sb.Append('+');
							if (io_n && !io_e && !io_s && !io_w) sb.Append('@');
							if (!io_n && io_e && io_s && io_w) sb.Append('+');
							if (!io_n && io_e && io_s && !io_w) sb.Append('+');
							if (!io_n && io_e && !io_s && io_w) sb.Append('-');
							if (!io_n && io_e && !io_s && !io_w) sb.Append('@');
							if (!io_n && !io_e && io_s && io_w) sb.Append('+');
							if (!io_n && !io_e && io_s && !io_w) sb.Append('@');
							if (!io_n && !io_e && !io_s && io_w) sb.Append('@');
							if (!io_n && !io_e && !io_s && !io_w) sb.Append(' ');
						}
					}
					else if (dx == 2 && dy == 1)
					{
						// OOO
						// OO#
						// OOO

						if (i_e && o_e) sb.Append('-');
						if (!i_e && o_e) sb.Append('>');
						if (i_e && !o_e) sb.Append('<');
						if (!i_e && !o_e) sb.Append(' ');
					}
					else if (dx == 0 && dy == 2)
					{
						// OOO
						// OOO
						// #OO

						sb.Append(' ');
					}
					else if (dx == 1 && dy == 2)
					{
						// OOO
						// OOO
						// O#O

						if (i_s && o_s) sb.Append('|');
						if (!i_s && o_s) sb.Append('v');
						if (i_s && !o_s) sb.Append('^');
						if (!i_s && !o_s) sb.Append(' ');
					}
					else if (dx == 2 && dy == 2)
					{
						// OOO
						// OOO
						// OO#

						sb.Append(' ');
					}
					else
					{
						return "ERR";
					}
				}
				sb.AppendLine();
			}

			return sb.ToString();
		}
	}
}
