using Quantopus.Colors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantopus.OctalTree
{
	abstract class OctreeQuantizer
	{
		protected int colorCount;
		protected DirectBitmap originalBitmap;
		protected OctreeNode Head { get; }
		protected List<OctreeNode>[] BranchList { get; }
		protected List<OctreeNode> LeafList { get; }

		public OctreeQuantizer(DirectBitmap _originalBitmap, int _colorCount)
		{
			colorCount = _colorCount;
			originalBitmap = _originalBitmap;
			Head = new OctreeNode();
			BranchList = new List<OctreeNode>[8];
			LeafList = new List<OctreeNode>();

			for (int i = 0; i < 8; ++i)
			{
				BranchList[i] = new List<OctreeNode>();
			}
		}

		public abstract void ConstructTree();
		public abstract void ConstructTreeWithProgressReporting(BackgroundWorker bgWorker);

		protected void AddColor(int rgb)
		{
			int[] octTriples = RGB.OctTriples(rgb);
			OctreeNode childNode, currentNode = Head;

			for (int levelIndex = 0; levelIndex < 8; ++levelIndex)
			{
				int childIndex = octTriples[levelIndex];
				if (currentNode.Children == null)
				{
					if (!currentNode.Leaf)
					{
						currentNode.Children = new OctreeNode[8];
						BranchList[levelIndex].Add(currentNode);
					}
					else
					{
						break;
					}
				}
				if (currentNode.Children[childIndex] == null)
				{
					childNode = new OctreeNode();
					if (levelIndex == 7)
					{
						LeafList.Add(childNode);
						childNode.Leaf = true;
					}
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

		protected void ReduceTree()
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

		protected void ReduceLevel(int currentLevel)
		{
			OctreeNode removedNode = BranchList[currentLevel][0];   // retrieve the smallest node in the level
			BranchList[currentLevel].Remove(removedNode);           // and remove it from the level

			foreach (OctreeNode child in removedNode.Children)
			{
				if (child != null)
				{
					LeafList.Remove(child);                         // remove all the children nodes
				}                                                   // and nullize the children array
			}
			removedNode.Children = null;

			removedNode.Leaf = true;                                // make the node leaf
			LeafList.Add(removedNode);                              // and add it to the leaf container
		}

		protected int QuantizePixel(int argb)
		{
			OctreeNode currentNode = Head;
			int[] octTriples = RGB.OctTriples(argb);
			int aMask = argb | 0x00FFFFFF;

			for (int i = 0; !currentNode.Leaf; ++i)
			{
				currentNode = currentNode.Children[octTriples[i]];
			}
			return aMask & currentNode.RGBToInt();
		}

		public DirectBitmap Quantize()
		{
			DirectBitmap resultBitmap = new DirectBitmap(originalBitmap.Width, originalBitmap.Height);

			for (int x = 0; x < resultBitmap.Width; ++x)
			{
				for (int y = 0; y < resultBitmap.Height; ++y)
				{
					resultBitmap[x, y] = QuantizePixel(originalBitmap[x, y]);
				}
			}
			return resultBitmap;
		}
	}
}
