using System;

namespace OOP
{
    // C# не допускает ковариантный вызов методов
    public class Office : Any
    {
        public void PrintWrapper(Printer printer)
        {
            printer.Perform();
        }
    }

    public abstract class Printer : General
    {
        public abstract void Perform();
    }

    public class LaserPrinter : Printer
    {
        public override void Perform()
        {
            Console.WriteLine("Лазерная печать…");
        }
    }

    public class InkPrinter : Printer
    {
        public override void Perform()
        {
            Console.WriteLine("Струйная печать…");
        }
    }

    public partial class Main
    {
        public void Run()
        {
            Printer laser = new LaserPrinter();
            Printer ink = new InkPrinter();
            Office office = new Office();

            office.PrintWrapper(laser);
            // Лазерная печать…
            office.PrintWrapper(ink);
            // Струйная печать…
        }
    }
}