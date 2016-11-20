using Quantopus.OctalTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quantopus
{
	public partial class Window : Form
	{
		private int widthOffest, heightOffset;
		private DirectBitmap originalBitmap;
		private DirectBitmap reducedBitmap;
		
		public Window()
		{
			InitializeComponent();
			widthOffest = Width - panel1.Width;
			heightOffset = Height - panel1.Height;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|"
	   + "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				Bitmap bitmap = new Bitmap(fileDialog.FileName);
				originalBitmap = DirectBitmap.FromBitmap(bitmap);
				panel1.BackgroundImage = originalBitmap.Bitmap;

				Width = originalBitmap.Width + widthOffest;
				Height = originalBitmap.Height + heightOffset;

				saveToolStripMenuItem.Enabled = true;
				editToolStripMenuItem.Enabled = true;
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileDialog fileDialog = new SaveFileDialog();
			fileDialog.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|"
	   + "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				reducedBitmap.Bitmap.Save(fileDialog.FileName);
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void qunatizeWithDynamicTreeReductionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int colorCount = (int)numericUpDown1.Value;
			new Task(() =>
			{
				reducedBitmap = DynamicOctree.Quantize(originalBitmap, colorCount);
				panel1.BackgroundImage = reducedBitmap.Bitmap;
			}).Start();
		}

		private void originalPaletteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			panel1.BackgroundImage = originalBitmap.Bitmap;
		}

		private void quantizeWithToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int colorCount = (int) numericUpDown1.Value;
			new Task(() =>
			{
				reducedBitmap = StaticOctree.Quantize(originalBitmap, colorCount);
				panel1.BackgroundImage = reducedBitmap.Bitmap;
			}).Start();	
		}
	}
}
