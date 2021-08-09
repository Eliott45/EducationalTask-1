using UnityEngine;

namespace AxGrid.Main
{
    public static class EnumTypeExtension
    {
        public static Color GetColor(this EColors colors)
        {
            return colors switch
            {
                EColors.White => Color.white,
                EColors.Blue => Color.cyan,
                EColors.Green => Color.green,
                _ => Color.black
            };
        }
    }
}