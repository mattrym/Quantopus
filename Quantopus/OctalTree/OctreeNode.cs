using Quantopus.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantopus.OctalTree
{
	class OctreeNode
	{
		public OctreeNode[] Children { get; set; }
		private ulong ReferenceCount { get; set; }
		private RGB RGB { get; set; }
		public bool Leaf { get; set; }

		public void AddReference(int _rgb)
		{
			ReferenceCount++;
			RGB += new RGB(_rgb);
		}		

		public int RGBToInt()
		{
			int r = (int)(RGB.R / ReferenceCount);
			int g = (int)(RGB.G / ReferenceCount);
			int b = (int)(RGB.B / ReferenceCount);
			return 255 << 24 | r << 16 | g << 8 | b; 
		}
	}
}
