using Quantopus.Colors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantopus.OctalTree
{
	class DynamicOctree : OctreeQuantizer
	{
		public DynamicOctree(DirectBitmap _originalBitmap, int _colorCount) : base(_originalBitmap, _colorCount)
		{
		}

		public override void ConstructTree()
		{
			foreach (int bit in originalBitmap.Bits)
			{
				AddColor(bit);
				ReduceTree();
			}
		}

		public override void ConstructTreeWithProgressReporting(BackgroundWorker bgWorker)
		{
			int progress = 0;
			for (int i = 0; i < originalBitmap.Bits.Length; ++i)
			{
				AddColor(originalBitmap.Bits[i]);
				ReduceTree();
				if (i > (progress + 1) * originalBitmap.Bits.Length / 100)
				{
					bgWorker.ReportProgress(++progress);
				}
			}
			bgWorker.ReportProgress(++progress);
		}
	}
}
