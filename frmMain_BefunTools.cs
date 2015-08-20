using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

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
		static int CDist(Color a, Color b) { return (a.R - b.R) * (a.R - b.R) + (a.G - b.G) * (a.G - b.G) + (a.B - b.B) * (a.B - b.B); }

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


			char CHARACTER_CONV_R = edCharImgR.Text.Length == 0 ? ' ' : edCharImgR.Text[0];
			char CHARACTER_CONV_G = edCharImgG.Text.Length == 0 ? ' ' : edCharImgG.Text[0];
			char CHARACTER_CONV_B = edCharImgB.Text.Length == 0 ? ' ' : edCharImgB.Text[0];
			char CHARACTER_CONV_W = edCharImgW.Text.Length == 0 ? ' ' : edCharImgW.Text[0];
			char CHARACTER_CONV_K = edCharImgK.Text.Length == 0 ? ' ' : edCharImgK.Text[0];

			Func<Color, char> GET_CHARMAP = (c) =>
			{
				var ls = new List<Tuple<int, char>>()
				{
					Tuple.Create(CDist(c, Color.Red),   CHARACTER_CONV_R),
					Tuple.Create(CDist(c, Color.Green), CHARACTER_CONV_G),
					Tuple.Create(CDist(c, Color.Blue),  CHARACTER_CONV_B),
					Tuple.Create(CDist(c, Color.White), CHARACTER_CONV_W),
					Tuple.Create(CDist(c, Color.Black), CHARACTER_CONV_K),
				};

				return ls.OrderBy(p => p.Item1).First().Item2;
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
			Random R = new Random(0);
			Color[] cmap = Enumerable.Range(0, 256).Select(p => Color.FromArgb(R.Next() % 256, R.Next() % 256, R.Next() % 256)).ToArray();

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
						char v = GET_CHARMAP(source.GetPixel(source_x, source_y));

						g.FillRectangle(new SolidBrush(cmap[v]), targetRect.Left + x, targetRect.Top + y, 1, 1);
					}
				}

				if (BORDER_SIZE > 0)
				{
					g.FillRectangle(Brushes.Red, 0, 0, FIELD_WIDTH, BORDER_SIZE);
					g.FillRectangle(Brushes.Red, 0, 0, BORDER_SIZE, FIELD_HEIGHT);
					g.FillRectangle(Brushes.Red, FIELD_WIDTH - BORDER_SIZE, 0, BORDER_SIZE, FIELD_HEIGHT);
					g.FillRectangle(Brushes.Red, 0, FIELD_HEIGHT - BORDER_SIZE, FIELD_WIDTH, BORDER_SIZE);
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
	}
}
