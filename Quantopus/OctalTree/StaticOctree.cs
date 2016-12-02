using Quantopus.Colors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantopus.OctalTree
{
	class StaticOctree
	{
		public static DirectBitmap Quantize(DirectBitmap bitmap, int colorCount)
		{
			StaticOctree octree = new StaticOctree(bitmap);
			DirectBitmap resultBitmap = new DirectBitmap(bitmap.Width, bitmap.Height);
			octree.Quantize(colorCount);

			for(int x = 0; x < resultBitmap.Width; ++x)
			{
				for(int y = 0; y < resultBitmap.Height; ++y)
				{
					resultBitmap[x, y] = octree.QuantizePixel(bitmap[x, y]);
				}
			}
			return resultBitmap;
		}

		OctreeNode Head { get; }
		List<OctreeNode>[] BranchList { get; }
		List<OctreeNode> LeafList { get; }

		private StaticOctree(DirectBitmap bitmap)
		{
			Head = new OctreeNode();
			BranchList = new List<OctreeNode>[8];
			for(int i = 0; i < 8; ++i)
			{
				BranchList[i] = new List<OctreeNode>();
			}
			LeafList = new List<OctreeNode>();

			ConstructTree(bitmap);
		}

		private void Quantize(int colorCount)
		{
			int currentLevel = 7;
			while (LeafList.Count > colorCount)
			{
				if (BranchList[currentLevel].Count == 0)
				{
					--currentLevel;
					BranchList[currentLevel].Sort((n1, n2) =>
					{
						return (int)(n1.ReferenceCount - n2.ReferenceCount);
					});
				}
				ReduceLevel(currentLevel);
			}
		}

		private int QuantizePixel(int argb)
		{
			OctreeNode currentNode = Head;
			int[] octTriples = RGB.OctTriples(argb);
			int aMask = argb | 0x00FFFFFF;

			for (int i = 0; i < 8 && currentNode.Children != null; ++i)
			{
				currentNode = currentNode.Children[octTriples[i]];
			}
			return aMask & currentNode.RGBToInt();
		}

		private void ConstructTree(DirectBitmap bitmap)
		{
			foreach(int bit in bitmap.Bits)
			{
				AddColor(bit);
			}
		}

		private void AddColor(int rgb)
		{
			int[] octTriples = RGB.OctTriples(rgb);
			OctreeNode childNode, currentNode = Head;

			for(int levelIndex = 0; levelIndex < 8; ++levelIndex)
			{
				int childIndex = octTriples[levelIndex];
				if (currentNode.Children == null)
				{
					currentNode.Children = new OctreeNode[8];
					BranchList[levelIndex].Add(currentNode);
				}
				if (currentNode.Children[childIndex] == null)
				{
					childNode = new OctreeNode();
					if(levelIndex == 7)
						LeafList.Add(childNode);
					currentNode.Children[childIndex] = childNode;
				}
				else
				{
					childNode = currentNode.Children[childIndex];
				}
				currentNode.AddReference(rgb);
				currentNode = childNode;
			}
			currentNode.AddReference(rgb);
		}

		private void ReduceLevel(int currentLevel)
		{
			OctreeNode removedNode = BranchList[currentLevel][0];
			BranchList[currentLevel].Remove(removedNode);

			foreach(OctreeNode child in removedNode.Children)
			{
				if(child != null)
				{
					//removedNode.ReferenceCount += child.ReferenceCount;
					//removedNode.RGB += child.RGB;
					LeafList.Remove(child);
				}
			}

			removedNode.Children = null;
			LeafList.Add(removedNode);
		}
	}
}
