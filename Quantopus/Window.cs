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
		public Window()
		{
			InitializeComponent();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileDialog fileDialog = new OpenFileDialog();
			if(fileDialog.ShowDialog() == DialogResult.OK)
			{
				int colorNumber = (int)numericUpDown1.Value;
				DirectBitmap bitmap = DirectBitmap.FromBitmap(new Bitmap(fileDialog.FileName));
				DynamicOctree octree = new DynamicOctree(bitmap, colorNumber);
				DirectBitmap newBitmap = new DirectBitmap(bitmap.Width, bitmap.Height);
				for(int x = 0; x < newBitmap.Width; ++x)
				{
					for(int y = 0; y < newBitmap.Height; ++y)
					{
						newBitmap[x, y] = octree[bitmap[x, y]];
					}
				}
				panel1.BackgroundImage = newBitmap.Bitmap;
			}
		}
	}
}
