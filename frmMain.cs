using BefunCompile;
using BefunCompile.Graph;
using BefunCompile.Math;
using BefunGen.AST;
using BefunGen.AST.CodeGen;
using BefunGen.AST.CodeGen.NumberCode;
using BefunHighlight;
using BefunRep;
using BefunRep.FileHandling;
using BefunRep.OutputHandling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using BefunCompile.Graph.Vertex;

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