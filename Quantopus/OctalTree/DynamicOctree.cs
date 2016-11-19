using Quantopus.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantopus.OctalTree
{
	class DynamicOctree : IOctree
	{
		OctreeNode Head { get; }
		List<OctreeNode> BranchList { get; }
		List<OctreeNode> LeafList { get; }

		public DynamicOctree(DirectBitmap bitmap, int colorNumber)
		{
			Head = new OctreeNode(-1);
			BranchList = new List<OctreeNode>();
			LeafList = new List<OctreeNode>();

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
			foreach (int bit in bitmap.Bits)
			{
				AddColor(bit, colorNumber);
			}
		}

		private int GetColor(int argb)
		{
			OctreeNode currentNode = Head;
			int[] octTriples = RGB.OctTriples(argb);

			for (int i = 0; i < 8 && currentNode.Children != null; ++i)
			{
				if(currentNode.Children[octTriples[i]] != null)
				{
					currentNode = currentNode.Children[octTriples[i]];
				}
				else
				{
					break;
				}
			}
			return currentNode.RGBToInt();
		}

		private void AddColor(int rgb, int colorNumber)
		{
			int[] octTriples = RGB.OctTriples(rgb);
			OctreeNode currentNode = Head, childNode;

			currentNode.AddReference(rgb);
			for (int levelIndex = 0; levelIndex < 8; ++levelIndex)
			{
				int childIndex = octTriples[levelIndex];
				if (currentNode.Children == null)
				{
					currentNode.Children = new OctreeNode[8];
					if (!BranchList.Contains(currentNode))
					{
						BranchList.Add(currentNode);
					}
				}
				if (currentNode.Children[childIndex] == null)
				{
					childNode = new OctreeNode(levelIndex);
					currentNode.Children[childIndex] = childNode;
				}
				childNode = currentNode.Children[childIndex];
				childNode.AddReference(rgb);
				currentNode = childNode;
			}
			if (!LeafList.Contains(currentNode))
			{
				LeafList.Add(currentNode);
				if(LeafList.Count > colorNumber)
				{
					ReduceColors();
				}
			}
		}

		private void ReduceColors()
		{
			BranchList.Sort((n1, n2) =>
			{
				int refSubtraction = (int)(n1.ReferenceCount - n2.ReferenceCount);
				if (refSubtraction == 0)
					return n2.Level - n1.Level;
				return refSubtraction;
			});
			ReduceNode(BranchList[0]);
		}

		private void ReduceNode(OctreeNode node)
		{
			BranchList.Remove(node);
			foreach (OctreeNode child in node.Children)
			{
				if (child != null)
				{
					node.ReferenceCount += child.ReferenceCount;
					node.RGB += child.RGB;
					LeafList.Remove(child);
				}
			}
			node.Children = null;
			--node.Level;
			LeafList.Add(node);
		}
	}
}
