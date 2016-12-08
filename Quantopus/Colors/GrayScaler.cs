using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantopus.Colors
{
    class GrayScaler
    {
        public static DirectBitmap ToGray(DirectBitmap originalBitmap)
        {
            DirectBitmap resultBitmap = new DirectBitmap(originalBitmap.Width, originalBitmap.Height);
            for(int x = 0; x < originalBitmap.Width; ++x)
            {
                for(int y = 0; y < originalBitmap.Height; ++y)
                {
                    resultBitmap[x, y] = RGB.ToGray(originalBitmap[x, y]);
                }
            }
            return resultBitmap;
        }
    }
}
