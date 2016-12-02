using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantopus.OctalTree
{
    interface IQuantizer
    {
		DirectBitmap Quantize(DirectBitmap originalBitmap, int colorCount);
    }
}
