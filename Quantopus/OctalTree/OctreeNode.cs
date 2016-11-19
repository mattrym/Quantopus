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
		public ulong ReferenceCount { get; set; }
		public RGB RGB { get; set; }
		public int Level { get; set; }

		public OctreeNode(int level)
		{
			Level = level;
		}

		public void AddReference(int _rgb)
		{
			ReferenceCount++;
			RGB += new RGB(_rgb);
		}		

		public int RGBToInt()
		{
			int r = (int)((decimal)RGB.R / ReferenceCount);
			int g = (int)((decimal)RGB.G / ReferenceCount);
			int b = (int)((decimal)RGB.B / ReferenceCount);
			return 255 << 24 | r << 16 | g << 8 | b; 
		}
	}
}
