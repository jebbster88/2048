using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _2048.Utilities
{
    public static class ThemeManager
    {
        public static Dictionary<int, string> Backgrounds = new Dictionary<int, string>()
        {
            {  0,    "#CDC1B4" },
            {  2,    "#eee4da" },
            {  4,    "#ede0c8" },
            {  8,    "#f2b179" },
            {  16,   "#f59563" },
            {  32,   "#f67c5f" },
            {  64,   "#f65e3b" },
            {  128,  "#edcf72" },
            {  256,  "#edcc61" },
            {  512,  "#edc850" },
            {  1024, "#edc53f" },
            {  2048, "#edc22e" }
        };
        public static Dictionary<int, string> Text = new Dictionary<int, string>()
        {
            {  0,    "#776e65" },
            {  2,    "#776e65" },
            {  4,    "#776e65" },
            {  8,    "#f9f6f2" },
            {  16,   "#f9f6f2"},
            {  32,   "#f9f6f2" },
            {  64,   "#f9f6f2" },
            {  128,  "#f9f6f2" },
            {  256,  "#f9f6f2" },
            {  512,  "#f9f6f2" },
            {  1024, "#f9f6f2" },
            {  2048, "#f9f6f2" }
        };



        public static string defaultBackground = "#3c3a32";
        public static string defaultText = "#f9f6f2";

        public static SolidColorBrush GetBackground(int value)
        {
            string Colour = "";
            if (Backgrounds.ContainsKey(value))
            {
                Colour = Backgrounds[value];
            }
            else
            {
                Colour =  defaultBackground;
            }

            return (SolidColorBrush)(new BrushConverter().ConvertFrom(Colour));
        }
        public static SolidColorBrush GetText(int value)
        {
            string Colour = "";
            if (Text.ContainsKey(value))
            {
                Colour = Text[value];
            }
            else
            {
                Colour = defaultText;
            }

            return (SolidColorBrush)(new BrushConverter().ConvertFrom(Colour));
        }


        public static SolidColorBrush GetBorder(int value)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom("#bbada0"));
        }
    }

}
