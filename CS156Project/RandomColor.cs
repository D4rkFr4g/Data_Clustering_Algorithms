using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;


namespace CS156Project
{

    public class RandomColor
    {
        List<SolidColorBrush> list;
        Random rand = new Random();

        public RandomColor()
        {
            list = new List<SolidColorBrush>();

            list.Add(Brushes.AliceBlue);
            list.Add(Brushes.AntiqueWhite);
            list.Add(Brushes.Aqua);
            list.Add(Brushes.Aquamarine);
            list.Add(Brushes.Azure);
            list.Add(Brushes.Beige);
            list.Add(Brushes.Bisque);
            //list.Add(Brushes.Black);
            list.Add(Brushes.BlanchedAlmond);
            list.Add(Brushes.Blue);
            list.Add(Brushes.BlueViolet);
            list.Add(Brushes.Brown);
            list.Add(Brushes.BurlyWood);
            list.Add(Brushes.CadetBlue);
            list.Add(Brushes.Chartreuse);
            list.Add(Brushes.Chocolate);
            list.Add(Brushes.Coral);
            list.Add(Brushes.CornflowerBlue);
            list.Add(Brushes.Cornsilk);
            list.Add(Brushes.Crimson);
            list.Add(Brushes.Cyan);
            list.Add(Brushes.DarkBlue);
            list.Add(Brushes.DarkCyan);
            list.Add(Brushes.DarkGoldenrod);
            list.Add(Brushes.DarkGray);
            list.Add(Brushes.DarkGreen);
            list.Add(Brushes.DarkKhaki);
            list.Add(Brushes.DarkMagenta);
            list.Add(Brushes.DarkOliveGreen);
            list.Add(Brushes.DarkOrange);
            list.Add(Brushes.DarkOrchid);
            list.Add(Brushes.DarkRed);
            list.Add(Brushes.DarkSalmon);
            list.Add(Brushes.DarkSeaGreen);
            list.Add(Brushes.DarkSlateBlue);
            list.Add(Brushes.DarkSlateGray);
            list.Add(Brushes.DarkTurquoise);
            list.Add(Brushes.DarkViolet);
            list.Add(Brushes.DeepPink);
            list.Add(Brushes.DeepSkyBlue);
            list.Add(Brushes.DimGray);
            list.Add(Brushes.DodgerBlue);
            list.Add(Brushes.Firebrick);
            list.Add(Brushes.FloralWhite);
            list.Add(Brushes.ForestGreen);
            list.Add(Brushes.Fuchsia);
            list.Add(Brushes.Gainsboro);
            list.Add(Brushes.GhostWhite);
            list.Add(Brushes.Gold);
            list.Add(Brushes.Goldenrod);
            list.Add(Brushes.Gray);
            list.Add(Brushes.Green);
            list.Add(Brushes.GreenYellow);
            list.Add(Brushes.Honeydew);
            list.Add(Brushes.HotPink);
            list.Add(Brushes.IndianRed);
            list.Add(Brushes.Indigo);
            list.Add(Brushes.Ivory);
            list.Add(Brushes.Khaki);
            list.Add(Brushes.Lavender);
            list.Add(Brushes.LavenderBlush);
            list.Add(Brushes.LawnGreen);
            list.Add(Brushes.LemonChiffon);
            list.Add(Brushes.LightBlue);
            list.Add(Brushes.LightCoral);
            list.Add(Brushes.LightCyan);
            list.Add(Brushes.LightGoldenrodYellow);
            list.Add(Brushes.LightGray);
            list.Add(Brushes.LightGreen);
            list.Add(Brushes.LightPink);
            list.Add(Brushes.LightSalmon);
            list.Add(Brushes.LightSeaGreen);
            list.Add(Brushes.LightSkyBlue);
            list.Add(Brushes.LightSlateGray);
            list.Add(Brushes.LightSteelBlue);
            list.Add(Brushes.LightYellow);
            list.Add(Brushes.Lime);
            list.Add(Brushes.LimeGreen);
            list.Add(Brushes.Linen);
            list.Add(Brushes.Magenta);
            list.Add(Brushes.Maroon);
            list.Add(Brushes.MediumAquamarine);
            list.Add(Brushes.MediumBlue);
            list.Add(Brushes.MediumOrchid);
            list.Add(Brushes.MediumPurple);
            list.Add(Brushes.MediumSeaGreen);
            list.Add(Brushes.MediumSlateBlue);
            list.Add(Brushes.MediumSpringGreen);
            list.Add(Brushes.MediumTurquoise);
            list.Add(Brushes.MediumVioletRed);
            list.Add(Brushes.MidnightBlue);
            list.Add(Brushes.MintCream);
            list.Add(Brushes.MistyRose);
            list.Add(Brushes.Moccasin);
            list.Add(Brushes.NavajoWhite);
            list.Add(Brushes.Navy);
            list.Add(Brushes.OldLace);
            list.Add(Brushes.Olive);
            list.Add(Brushes.OliveDrab);
            list.Add(Brushes.Orange);
            list.Add(Brushes.OrangeRed);
            list.Add(Brushes.Orchid);
            list.Add(Brushes.PaleGoldenrod);
            list.Add(Brushes.PaleGreen);
            list.Add(Brushes.PaleTurquoise);
            list.Add(Brushes.PaleVioletRed);
            list.Add(Brushes.PapayaWhip);
            list.Add(Brushes.PeachPuff);
            list.Add(Brushes.Peru);
            list.Add(Brushes.Pink);
            list.Add(Brushes.Plum);
            list.Add(Brushes.PowderBlue);
            list.Add(Brushes.Purple);
            list.Add(Brushes.Red);
            list.Add(Brushes.RosyBrown);
            list.Add(Brushes.RoyalBlue);
            list.Add(Brushes.SaddleBrown);
            list.Add(Brushes.Salmon);
            list.Add(Brushes.SandyBrown);
            list.Add(Brushes.SeaGreen);
            list.Add(Brushes.SeaShell);
            list.Add(Brushes.Sienna);
            list.Add(Brushes.Silver);
            list.Add(Brushes.SkyBlue);
            list.Add(Brushes.SlateBlue);
            list.Add(Brushes.SlateGray);
            list.Add(Brushes.Snow);
            list.Add(Brushes.SpringGreen);
            list.Add(Brushes.SteelBlue);
            list.Add(Brushes.Tan);
            list.Add(Brushes.Teal);
            list.Add(Brushes.Thistle);
            list.Add(Brushes.Tomato);
            //list.Add(Brushes.Transparent);
            list.Add(Brushes.Turquoise);
            list.Add(Brushes.Violet);
            list.Add(Brushes.Wheat);
            //list.Add(Brushes.White);
            list.Add(Brushes.WhiteSmoke);
            list.Add(Brushes.Yellow);
            list.Add(Brushes.YellowGreen);
        }

        public Color getColor()
        {
            //Using the full list of brushes this method returns a new brush each time and removes the brush that was used. This ensures no two identical brushes are used.
            if (list.Count > 0)
            {
                int temp = rand.Next(list.Count);

                Color c = list.ElementAt(temp).Color;
                list.RemoveAt(temp);
                
                return c;
            }
            //In the chance that the users uses up all the available brushes a random rgb brush is created.
            else
            {
                byte[] colorBytes = new byte[3];
                rand.NextBytes(colorBytes);
                return Color.FromRgb(colorBytes[0], colorBytes[1], colorBytes[2]);
            }
        }
    }
}
