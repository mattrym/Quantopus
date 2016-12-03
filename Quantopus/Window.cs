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
		private int colorCount = 16;
		private OctreeQuantizer quantizer;
		private DirectBitmap originalBitmap;
		private DirectBitmap reducedBitmap;
		
		public Window()
		{
			InitializeComponent();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff"
				+ "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|";
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
			fileDialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff"
				+ "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|";
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
			quantizer = new DynamicOctree(originalBitmap, colorCount);
			backgroundWorker1.RunWorkerAsync();
		}

        private void quantizeWithToolStripMenuItem_Click(object sender, EventArgs e)
		{
			quantizer = new StaticOctree(originalBitmap, colorCount);
			backgroundWorker1.RunWorkerAsync();
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			colorCount = (int) numericUpDown1.Value;
			trackBar1.Value = colorCount;
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			colorCount = trackBar1.Value;
			numericUpDown1.Value = colorCount;
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			quantizeProgressBar.Value = e.ProgressPercentage;
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			quantizer.ConstructTreeWithProgressReporting(backgroundWorker1);
			reducedBitmap = quantizer.Quantize();
			quantizedPictureBox.Image = reducedBitmap.Bitmap;
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			quantizeProgressBar.Value = 0;
		}
	}
}
