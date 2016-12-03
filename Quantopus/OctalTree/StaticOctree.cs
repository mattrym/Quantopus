using Quantopus.Colors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantopus.OctalTree
{
	class StaticOctree : OctreeQuantizer
	{
		public StaticOctree(DirectBitmap _originalBitmap, int _colorCount) : base(_originalBitmap, _colorCount)
		{
		}

		public override void ConstructTree()
		{
			foreach (int bit in originalBitmap.Bits)
			{
				AddColor(bit);
			}
			ReduceTree();
		}

		public override void ConstructTreeWithProgressReporting(BackgroundWorker bgWorker)
		{
			int progress = 0;
			for (int i = 0; i < originalBitmap.Bits.Length; ++i)
			{
				AddColor(originalBitmap.Bits[i]);
				if (i > (progress + 1) * originalBitmap.Bits.Length / 100)
				{
					bgWorker.ReportProgress(++progress);
				}
			}
			ReduceTree();
			bgWorker.ReportProgress(++progress);
		}
	}
}
