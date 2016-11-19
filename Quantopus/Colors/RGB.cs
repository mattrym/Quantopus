using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantopus.Colors
{
	public struct RGB
	{
		public static ulong uR(int rgb) => (ulong)(rgb >> 16) & 0xFF;       // red color from 23-16 bits
		public static ulong uG(int rgb) => (ulong)(rgb >> 8) & 0xFF;        // green color from 15-8 bits
		public static ulong uB(int rgb) => (ulong)(rgb & 0xFF);             // blue color form 7-0 bits

		public static int[] OctTriples(int rgb)
		{
			int r = (rgb >> 16) & 0xFF, g = (rgb >> 8) & 0xFF, b = rgb & 0xFF;
			int[] octTriples = new int[8];
			for (int i = 0; i < 8; ++i)
			{
				octTriples[7 - i] =
					(((r >> i) & 1) << 2) |     // getting i-th bit of r color
					(((g >> i) & 1) << 1) |     // getting i-th bit of g color
					((b >> i) & 1);             // getting i-th bit of c color
			}
			return octTriples;
		}

		public ulong R { get; private set; }
		public ulong G { get; private set; }
		public ulong B { get; private set; }

		public RGB(int rgb)
		{
			R = uR(rgb);
			G = uG(rgb);
			B = uB(rgb);
		}

		public static RGB operator +(RGB rgb1, RGB rgb2)
		{
			return new RGB()
			{
				R = rgb1.R + rgb2.R,
				G = rgb1.G + rgb2.G,
				B = rgb1.B + rgb2.B
			};
		}
	}
}
