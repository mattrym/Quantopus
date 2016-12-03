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
		private OctreeQuantizer quantizer;
		private DirectBitmap originalBitmap;
		
		public Window()
		{
			InitializeComponent();
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
                originalPictureBox.Image = bitmap;

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
				quantizer = new DynamicOctree(originalBitmap, colorCount);
                quantizedPictureBox.Image = quantizer.Quantize().Bitmap;
			}).Start();
		}

        private void quantizeWithToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int colorCount = (int) numericUpDown1.Value;
			new Task(() =>
			{
				quantizer = new StaticOctree(originalBitmap, colorCount);
				quantizedPictureBox.Image = quantizer.Quantize().Bitmap;
			}).Start();	
		}
	}
}
