using Quantopus.Colors;
using System;
using System.Collections.Generic;
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

		protected override void ConstructTree()
		{
			foreach (int bit in originalBitmap.Bits)
			{
				AddColor(bit);
			}
			ReduceTree();
		}


		protected override void AddColor(int rgb)
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
	}
}
