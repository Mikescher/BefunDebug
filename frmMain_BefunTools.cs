using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BefunGen
{
	public partial class frmMain_BefunTools : UserControl
	{
		public frmMain_BefunTools()
		{
			InitializeComponent();
		}

		private void btnReverse_Click(object sender, EventArgs e)
		{
			if (chkbxReverseAutoDirection.Checked)
				edReverseOut.Text = edReverseIn.Text
					.Replace("<", "##REPL_LEFT_##")
					.Replace(">", "<")
					.Replace("##REPL_LEFT_##", ">")
					.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
					.Select(p => string.Join("", p.ToCharArray().Reverse()))
					.Aggregate((a, b) => a + Environment.NewLine + b);
			else
				edReverseOut.Text = edReverseIn.Text
					.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
					.Select(p => string.Join("", p.ToCharArray().Reverse()))
					.Aggregate((a, b) => a + Environment.NewLine + b);
		}

		private void edReverse_TextChanged(object sender, EventArgs e)
		{
			if (edReverseIn.Text.Contains('_'))
			{
				lblReverseValidity.ForeColor = Color.Red;
				lblReverseValidity.Text = "UNKNOWN";

				edReverseOut.Text = string.Empty;
			}
			else
			{
				lblReverseValidity.ForeColor = Color.DarkGreen;
				lblReverseValidity.Text = "OK";

				btnReverse_Click(null, null);
			}
		}

		private void btnSquash_Click(object sender, EventArgs e)
		{
			SquashHelper sh = new SquashHelper(edSquashInputIn.Text);

			sh.Squash();

			edSquashInputOut.Text = sh.ToString();

		}
	}
}
