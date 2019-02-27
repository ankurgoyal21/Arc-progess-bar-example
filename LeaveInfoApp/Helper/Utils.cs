using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LeaveInfoApp
{
    public sealed class Utils
    {
        private Utils()
        {
        }

        /// <summary>
        /// convert dp to px
        /// </summary>
        /// <param name="resources"></param>
        /// <param name="dp"></param>
        /// <returns></returns>
        public static float Dp2Px(Resources resources, float dp)
        {
            float scale = resources.DisplayMetrics.Density;
            return dp * scale + 0.5f;
        }

        /// <summary>
        /// convert sp to px
        /// </summary>
        /// <param name="resources"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static float Sp2Px(Resources resources, float sp)
        {
            float scale = resources.DisplayMetrics.ScaledDensity;
            return sp * scale;
        }
    }
}