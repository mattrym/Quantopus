using Quantopus.Colors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantopus.OctalTree
{
	class StaticOctree : IOctree
	{
		OctreeNode Head { get; }
		List<OctreeNode>[] BranchList { get; }
		List<OctreeNode> LeafList { get; }

		public StaticOctree(DirectBitmap bitmap, int colorNumber)
		{
			Head = new OctreeNode();
			BranchList = new List<OctreeNode>[8];
			LeafList = new List<OctreeNode>();

			for(int i = 0; i < 8; ++i)
			{
				BranchList[i] = new List<OctreeNode>();
			}

			ConstructTree(bitmap, colorNumber);
		}

		public int this[int argb]
		{
			get
			{
				return GetColor(argb);
			}
		}

		private void ConstructTree(DirectBitmap bitmap, int colorNumber)
		{
			//Parallel.ForEach(bitmap.Bits, bit => {
			//	AddColor(bit);
			//});
			foreach(int bit in bitmap.Bits)
			{
				AddColor(bit);
			}
			ReduceColors(colorNumber);
		}

		private int GetColor(int argb)
		{
			OctreeNode currentNode = Head;
			int[] octTriples = RGB.OctTriples(argb);

			for(int i = 0; i < 8 && currentNode.Children != null; ++i)
			{
				currentNode = currentNode.Children[octTriples[i]];
			}
			return currentNode.RGBToInt();
		}

		private void AddColor(int rgb)
		{
			int[] octTriples = RGB.OctTriples(rgb);
			OctreeNode childNode, currentNode = Head;

			currentNode.AddReference(rgb);
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
				childNode.AddReference(rgb);
				currentNode = childNode;
			}
		}

		private void ReduceColors(int colorCount)
		{
			int currentLevel = 7;
			while(LeafList.Count > colorCount)
			{
				if(BranchList[currentLevel].Count == 0)
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

		private void ReduceLevel(int currentLevel)
		{
			OctreeNode removedNode = BranchList[currentLevel][0];
			BranchList[currentLevel].Remove(removedNode);
			foreach(OctreeNode child in removedNode.Children)
			{
				if(child != null)
				{
					removedNode.ReferenceCount += child.ReferenceCount;
					removedNode.RGB += child.RGB;
					LeafList.Remove(child);
				}
			}
			removedNode.Children = null;
			LeafList.Add(removedNode);
		}
	}
}
