using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Figgle;

namespace Capstone.Models
{
    class FiggleFun
    {
        static private ConsoleColor originalForegroundColor = Console.ForegroundColor;
        static private ConsoleColor originalBackgroundColor = Console.BackgroundColor;
       
        public void VendingDisplay()
        {
            SetColor(ConsoleColor.White);
            Console.WriteLine(Figgle.FiggleFonts.Starwars.Render("Welcome To..."));
            Console.ReadLine();
            SetColor(ConsoleColor.DarkBlue);
            Console.WriteLine(Figgle.FiggleFonts.Starwars.Render("Vending"));
            SetColor(ConsoleColor.DarkRed);
            Console.WriteLine(Figgle.FiggleFonts.Starwars.Render("Machine!!"));
            SetColor(ConsoleColor.Yellow);
            Console.WriteLine("                              __");
            Console.WriteLine("                            <(o )___");
            Console.WriteLine(@"                             ( ._> /");
            Console.WriteLine(@"                              `---' ");
            Console.ReadLine();
        }

        static public void SetColor(ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
        }

        static public void SetColor(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
        }

        static public void ResetColor()
        {
            Console.ForegroundColor = originalForegroundColor;
            Console.BackgroundColor = originalBackgroundColor;
        }
    }
}
