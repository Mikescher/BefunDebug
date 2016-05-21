using BefunDebug.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BefunDebug.Pages
{
	public partial class frmMain_BefunTools : UserControl
	{
		public frmMain_BefunTools()
		{
			InitializeComponent();

			tabControl1.SelectedIndex = 0;
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
			SquashHelper sh = new SquashHelper(edMiscInput.Text);

			sh.Squash();

			edMiscOutput.Text = sh.ToString();
		}

		char[,] GetStringAsGrid(string text)
		{
			var lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
			int w = lines.Max(p => p.Length);
			int h = lines.Count();

			char[,] map = new char[w, h];
			for (int x = 0; x < w; x++)
				for (int y = 0; y < h; y++)
					map[x, y] = ' ';

			for (int y = 0; y < h; y++)
				for (int x = 0; x < lines[y].Length; x++)
					map[x, y] = lines[y][x];

			return map;
		}

		string GetGridAsString(char[,] map)
		{
			var w = map.GetLength(0);
			var h = map.GetLength(1);

			return Enumerable
				.Range(0, h)
				.Select(y => Enumerable.Range(0, w).Select(x => "" + map[x, y]).Aggregate(string.Concat).TrimEnd())
				.Aggregate((a, b) => a + Environment.NewLine + b);
		}

		private void btnFlip_Click(object sender, EventArgs e)
		{
			string text = edMiscInput.Text;
			if (string.IsNullOrWhiteSpace(text)) return;

			var map = GetStringAsGrid(text);
			var w = map.GetLength(0);
			var h = map.GetLength(1);
			var map2 = new char[h, w];

			for (int y = 0; y < w; y++)
				for (int x = 0; x < h; x++)
					map2[x, y] = map[y, x];

			edMiscOutput.Text = GetGridAsString(map2);
		}

		private void btnRotateL_Click(object sender, EventArgs e)
		{
			string text = edMiscInput.Text;
			if (string.IsNullOrWhiteSpace(text)) return;

			var map = GetStringAsGrid(text);
			var w = map.GetLength(0);
			var h = map.GetLength(1);
			var map2 = new char[h, w];

			for (int y = 0; y < w; y++)
				for (int x = 0; x < h; x++)
					map2[x, y] = map[w - y - 1, x];

			edMiscOutput.Text = GetGridAsString(map2);
		}

		private void btnRotateR_Click(object sender, EventArgs e)
		{
			string text = edMiscInput.Text;
			if (string.IsNullOrWhiteSpace(text)) return;

			var map = GetStringAsGrid(text);
			var w = map.GetLength(0);
			var h = map.GetLength(1);
			var map2 = new char[h, w];

			for (int y = 0; y < w; y++)
				for (int x = 0; x < h; x++)
					map2[x, y] = map[y, h - x - 1];

			edMiscOutput.Text = GetGridAsString(map2);
		}

		private void btnRotate180_Click(object sender, EventArgs e)
		{
			string text = edMiscInput.Text;
			if (string.IsNullOrWhiteSpace(text)) return;

			var map = GetStringAsGrid(text);
			var w = map.GetLength(0);
			var h = map.GetLength(1);
			var map2 = new char[w, h];

			for (int y = 0; y < h; y++)
				for (int x = 0; x < w; x++)
					map2[x, y] = map[w - x - 1, h - y - 1];

			edMiscOutput.Text = GetGridAsString(map2);
		}

		private void btnChooseIn_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();

			if (ofd.ShowDialog() == DialogResult.OK) edIn.Text = ofd.FileName;
		}

		private void btnChooseOut_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.DefaultExt = ".txt";

			if (sfd.ShowDialog() == DialogResult.OK) edOut.Text = sfd.FileName;
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			try
			{
				Generate();
			}
			catch (Exception ex)
			{
				edASCIIOut.Text = ex.ToString();
			}
		}

		static Color Grayscale(int g) { return Color.FromArgb(g % 256, g % 256, g % 256); }
		static Brush GrayscaleB(int g) { return new SolidBrush(Grayscale(g)); }
		static int Grayscale(Color g) { return (g.R + g.G + g.B) / 3; }
		static double Ratio(Rectangle r) { return r.Width * 1.0 / r.Height; }

		private void Generate()
		{
			int FIELD_WIDTH = (int)edFieldWidth.Value;
			int FIELD_HEIGHT = (int)edFieldHeight.Value;

			string IMAGE_PATH = edIn.Text;
			string EXPORT_PATH = edOut.Text;

			int PAD_LEFT = (int)edPaddingLeft.Value;
			int PAD_RIGHT = (int)edPaddingRight.Value;
			int PAD_TOP = (int)edPaddingTop.Value;
			int PAD_BOTTOM = (int)edPaddingBottom.Value;

			int BORDER_SIZE = (int)edBorderSize.Value;

			bool CONSIDER_CHAR_RATIO = cbConsiderCharRatio.Checked;

			char CHARACTER_PAD = edCharPad.Text.Length == 0 ? ' ' : edCharPad.Text[0];
			char CHARACTER_EMPTY = edCharEmpty.Text.Length == 0 ? ' ' : edCharEmpty.Text[0];
			char CHARACTER_BORDER = edCharBorder.Text.Length == 0 ? ' ' : edCharBorder.Text[0];

			int CHAR_RATIO_W = (int)edCharRatioWidth.Value;
			int CHAR_RATIO_H = (int)edCharRatioHeight.Value;
			
			Func<Color, char> GET_CHARMAP = (c) =>
			{
				return GetCharacterCList(c).OrderBy(p => p.Item2).First().Item3;
			};

			//##########################################################################

			Rectangle renderField;
			Rectangle sourceRect;
			Rectangle targetRect;
			Bitmap source;
			Bitmap result;

			ASCII_Init(FIELD_WIDTH, FIELD_HEIGHT, IMAGE_PATH, PAD_LEFT, PAD_RIGHT, PAD_TOP, PAD_BOTTOM, CONSIDER_CHAR_RATIO, CHAR_RATIO_W, CHAR_RATIO_H, out renderField, out sourceRect, out targetRect, out source);
			ASCII_Debug(FIELD_WIDTH, FIELD_HEIGHT, BORDER_SIZE, GET_CHARMAP, source, renderField, ref sourceRect, ref targetRect);
			ASCII_Generate(FIELD_WIDTH, FIELD_HEIGHT, BORDER_SIZE, CHARACTER_PAD, CHARACTER_EMPTY, CHARACTER_BORDER, GET_CHARMAP, source, renderField, sourceRect, targetRect, out result);
			ASCII_Output(FIELD_WIDTH, FIELD_HEIGHT, result);
		}

		private List<Tuple<Color, double, char>> GetCharacterCList(Color c)
		{
			char CHARACTER_CONV_R = edCharImgR.Text.Length == 0 ? ' ' : edCharImgR.Text[0];
			char CHARACTER_CONV_G = edCharImgG.Text.Length == 0 ? ' ' : edCharImgG.Text[0];
			char CHARACTER_CONV_B = edCharImgB.Text.Length == 0 ? ' ' : edCharImgB.Text[0];
			char CHARACTER_CONV_W = edCharImgW.Text.Length == 0 ? ' ' : edCharImgW.Text[0];
			char CHARACTER_CONV_K = edCharImgK.Text.Length == 0 ? ' ' : edCharImgK.Text[0];
			char CHARACTER_CONV_T = edCharImgK.Text.Length == 0 ? ' ' : edCharImgT.Text[0];

			return new List<Tuple<Color, double, char>>
			{
				Tuple.Create(Color.Red, CDist(c, Color.Red), CHARACTER_CONV_R),
				Tuple.Create(Color.Green, CDist(c, Color.Lime), CHARACTER_CONV_G),
				Tuple.Create(Color.Blue, CDist(c, Color.Blue), CHARACTER_CONV_B),
				Tuple.Create(Color.White, CDist(c, Color.White), CHARACTER_CONV_W),
				Tuple.Create(Color.Black, CDist(c, Color.Black), CHARACTER_CONV_K),
				Tuple.Create(Color.Transparent, CDist(c, Color.Transparent), CHARACTER_CONV_T),
			};
		}

		/// <summary>
		/// http://stackoverflow.com/a/13484101/1761622
		/// </summary>
		private double CDist(Color a, Color b)
		{
			var rd = a.R / 255.0 - b.R / 255.0;
			var gd = a.G / 255.0 - b.G / 255.0;
			var bd = a.B / 255.0 - b.B / 255.0;
			var aa = a.A / 255.0 - b.A / 255.0;

			var m1 = Math.Max(rd * rd, (rd - aa) * (rd - aa));
			var m2 = Math.Max(gd * gd, (gd - aa) * (gd - aa));
			var m3 = Math.Max(bd * bd, (bd - aa) * (bd - aa));

			return m1 + m2 + m3;
		}

		private void ASCII_Output(int FIELD_WIDTH, int FIELD_HEIGHT, Bitmap result)
		{
			StringBuilder builder = new StringBuilder();

			for (int y = 0; y < FIELD_HEIGHT; y++)
			{
				for (int x = 0; x < FIELD_WIDTH; x++)
				{
					builder.Append((char)Grayscale(result.GetPixel(x, y)));
				}
				builder.AppendLine();
			}

			edASCIIOut.Text = builder.ToString();
			edArea.Text = " = " + (FIELD_WIDTH * FIELD_HEIGHT);
		}

		private void ASCII_Generate(int FIELD_WIDTH, int FIELD_HEIGHT, int BORDER_SIZE, char CHARACTER_PAD, char CHARACTER_EMPTY, char CHARACTER_BORDER, Func<Color, char> GET_CHARMAP, Bitmap source, Rectangle renderField, Rectangle sourceRect, Rectangle targetRect, out Bitmap result)
		{
			result = new Bitmap(FIELD_WIDTH, FIELD_HEIGHT, PixelFormat.Format24bppRgb);
			using (Graphics g = Graphics.FromImage(result))
			{
				g.Clear(Grayscale(CHARACTER_PAD));
				g.FillRectangle(GrayscaleB(CHARACTER_EMPTY), renderField);

				double scaleX = sourceRect.Width * 1.0 / targetRect.Width;
				double scaleY = sourceRect.Height * 1.0 / targetRect.Height;

				for (int x = 0; x < targetRect.Width; x++)
				{
					for (int y = 0; y < targetRect.Height; y++)
					{
						var source_x = Math.Min(sourceRect.Width - 1, Math.Max(0, (int)Math.Round(x * scaleX)));
						var source_y = Math.Min(sourceRect.Height - 1, Math.Max(0, (int)Math.Round(y * scaleY)));
						char v = GET_CHARMAP(source.GetPixel(source_x, source_y));

						g.FillRectangle(GrayscaleB(v), targetRect.Left + x, targetRect.Top + y, 1, 1);
					}
				}

				if (BORDER_SIZE > 0)
				{
					g.FillRectangle(GrayscaleB(CHARACTER_BORDER), 0, 0, FIELD_WIDTH, BORDER_SIZE);
					g.FillRectangle(GrayscaleB(CHARACTER_BORDER), 0, 0, BORDER_SIZE, FIELD_HEIGHT);
					g.FillRectangle(GrayscaleB(CHARACTER_BORDER), FIELD_WIDTH - BORDER_SIZE, 0, BORDER_SIZE, FIELD_HEIGHT);
					g.FillRectangle(GrayscaleB(CHARACTER_BORDER), 0, FIELD_HEIGHT - BORDER_SIZE, FIELD_WIDTH, BORDER_SIZE);
				}
			}
			imgASCII.Image = result;
		}

		private void ASCII_Debug(int FIELD_WIDTH, int FIELD_HEIGHT, int BORDER_SIZE, Func<Color, char> GET_CHARMAP, Bitmap source, Rectangle renderField, ref Rectangle sourceRect, ref Rectangle targetRect)
		{
			Bitmap debug_image = new Bitmap(FIELD_WIDTH, FIELD_HEIGHT, PixelFormat.Format24bppRgb);
			using (Graphics g = Graphics.FromImage(debug_image))
			{
				g.Clear(Color.Cyan);
				g.FillRectangle(Brushes.Magenta, renderField);

				g.FillRectangle(Brushes.White, targetRect);
				double scaleX = sourceRect.Width * 1.0 / targetRect.Width;
				double scaleY = sourceRect.Height * 1.0 / targetRect.Height;
				for (int x = 0; x < targetRect.Width; x++)
				{
					for (int y = 0; y < targetRect.Height; y++)
					{
						var source_x = Math.Min(sourceRect.Width - 1, Math.Max(0, (int)(x * scaleX)));
						var source_y = Math.Min(sourceRect.Height - 1, Math.Max(0, (int)(y * scaleY)));

						var col = GetCharacterCList(source.GetPixel(source_x, source_y)).OrderBy(p => p.Item2).First().Item1;
						if (col == Color.Transparent) col = Color.Fuchsia;

						g.FillRectangle(new SolidBrush(col), targetRect.Left + x, targetRect.Top + y, 1, 1);
					}
				}

				if (BORDER_SIZE > 0)
				{
					g.FillRectangle(Brushes.BlueViolet, 0, 0, FIELD_WIDTH, BORDER_SIZE);
					g.FillRectangle(Brushes.BlueViolet, 0, 0, BORDER_SIZE, FIELD_HEIGHT);
					g.FillRectangle(Brushes.BlueViolet, FIELD_WIDTH - BORDER_SIZE, 0, BORDER_SIZE, FIELD_HEIGHT);
					g.FillRectangle(Brushes.BlueViolet, 0, FIELD_HEIGHT - BORDER_SIZE, FIELD_WIDTH, BORDER_SIZE);
				}
			}
			imgDebug.Image = debug_image;
		}

		private static void ASCII_Init(int FIELD_WIDTH, int FIELD_HEIGHT, string IMAGE_PATH, int PAD_LEFT, int PAD_RIGHT, int PAD_TOP, int PAD_BOTTOM, bool CONSIDER_CHAR_RATIO, int CHAR_RATIO_W, int CHAR_RATIO_H, out Rectangle renderField, out Rectangle sourceRect, out Rectangle targetRect, out Bitmap source)
		{
			source = new Bitmap(Image.FromFile(IMAGE_PATH));

			renderField = new Rectangle(PAD_LEFT, PAD_TOP, FIELD_WIDTH - PAD_LEFT - PAD_RIGHT, FIELD_HEIGHT - PAD_TOP - PAD_BOTTOM);

			if (CONSIDER_CHAR_RATIO)
				sourceRect = new Rectangle(0, 0, source.Width * CHAR_RATIO_H, source.Height * CHAR_RATIO_W);
			else
				sourceRect = new Rectangle(0, 0, source.Width, source.Height);

			if (Ratio(renderField) == Ratio(sourceRect))
			{
				targetRect = renderField;
			}
			else if (Ratio(renderField) < Ratio(sourceRect))
			{
				int h = (renderField.Width * sourceRect.Height) / sourceRect.Width;
				targetRect = new Rectangle(renderField.Left, renderField.Top + (renderField.Height - h) / 2, renderField.Width, h);
			}
			else /* if (Ratio(renderField) > Ratio(sourceRect)) */
			{
				int w = (renderField.Height * sourceRect.Width) / sourceRect.Height;
				targetRect = new Rectangle(renderField.Left + (renderField.Width - w) / 2, renderField.Top, w, renderField.Height);
			}

			sourceRect = new Rectangle(0, 0, source.Width, source.Height);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				Generate();

				File.WriteAllText(edOut.Text, edASCIIOut.Text);
			}
			catch (Exception ex)
			{
				edASCIIOut.Text = ex.ToString();
			}
		}

		private void btnGenerateEmpty_Click(object sender, EventArgs e)
		{
			int FIELD_WIDTH = (int)edFieldWidth.Value;
			int FIELD_HEIGHT = (int)edFieldHeight.Value;

			int BORDER_SIZE = (int)edBorderSize.Value;
			
			char CHARACTER_EMPTY = edCharEmpty.Text.Length == 0 ? ' ' : edCharEmpty.Text[0];
			char CHARACTER_BORDER = edCharBorder.Text.Length == 0 ? ' ' : edCharBorder.Text[0];

			StringBuilder b = new StringBuilder();

			for (int y = 0; y < FIELD_HEIGHT; y++)
			{
				for (int x = 0; x < FIELD_WIDTH; x++)
				{
					if (x < BORDER_SIZE ||y < BORDER_SIZE || FIELD_WIDTH - x <= BORDER_SIZE || FIELD_HEIGHT - y <= BORDER_SIZE)
						b.Append(CHARACTER_BORDER);
					else
						b.Append(CHARACTER_EMPTY);
				}
				b.AppendLine();
			}

			edASCIIOut.Text = b.ToString();
		}

		private void GenericTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && (e.KeyCode == Keys.A))
			{
				(sender as TextBox)?.SelectAll();
				e.Handled = true;
			}
		}
	}
}
