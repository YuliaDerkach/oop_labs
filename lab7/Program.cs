using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Створити клас, що містить методи додавання, віднімання, множення та ділення
раціональних дробів та такі ж методи для роботи з комплексними числами. Для випадку
раціональних дробів та випадку комплексних чисел передбачити відповідні інтерфейси*/

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            RationalNumber numb1 = new RationalNumber();
            RationalNumber numb2 = new RationalNumber();
            ComplexNumber cnumb1 = new ComplexNumber();
            ComplexNumber cnumb2 = new ComplexNumber();
            while (true)
            {
                MenuItems();
                string variant = Console.ReadLine();
                switch (variant)
                {
                    case ("ir"):
                        Console.Clear();
                        Console.WriteLine("Enter the first number");
                        numb1.Number = CheckedInput.InputDouble();
                        Console.WriteLine("Enter the second number");
                        numb2.Number = CheckedInput.InputDouble();

                        PrintInfoRational(numb1, numb2);
                        break;
                    case ("ar"):
                        Console.Clear();
                        PrintInfoRational(numb1, numb2);

                        RationalNumber addOp = new RationalNumber();
                        Console.WriteLine("Result: {0}", addOp.Addition(numb1, numb2));
                        break;
                    case ("sr"):
                        Console.Clear();
                        PrintInfoRational(numb1, numb2);

                        RationalNumber subOp = new RationalNumber();
                        Console.WriteLine("Result: {0}", subOp.Subtraction(numb1, numb2));
                        break;
                    case ("mr"):
                        Console.Clear();
                        PrintInfoRational(numb1, numb2);

                        RationalNumber mulOp = new RationalNumber();
                        Console.WriteLine("Result: {0}", mulOp.Multiplication(numb1, numb2));
                        break;
                    case ("dr"):
                        Console.Clear();
                        PrintInfoRational(numb1, numb2);

                        RationalNumber divOp = new RationalNumber();
                        Console.WriteLine("Result: {0}", divOp.Division(numb1, numb2));
                        break;
                    case ("ic"):
                        Console.Clear();

                        Console.WriteLine("The first number\n");

                        Console.WriteLine("Enter the real part of the first number");
                        cnumb1.RealPart = CheckedInput.InputDouble();
                        Console.WriteLine("Enter the imagine part of the first number");
                        cnumb1.ImaginePart = CheckedInput.InputDouble();

                        Console.WriteLine("The second number\n");

                        Console.WriteLine("Enter the real part of the second number");
                        cnumb2.RealPart = CheckedInput.InputDouble();
                        Console.WriteLine("Enter the imagine part of the second number");
                        cnumb2.ImaginePart = CheckedInput.InputDouble();

                        PrintInfoComplex(cnumb1, cnumb2);
                        break;
                    case ("ac"):
                        Console.Clear();
                        PrintInfoComplex(cnumb1, cnumb2);

                        ComplexNumber addOpc = new ComplexNumber();
                        Console.WriteLine("Result: {0}", addOpc.Addition(cnumb1, cnumb2));
                        break;
                    case ("sc"):
                        Console.Clear();
                        PrintInfoComplex(cnumb1, cnumb2);

                        ComplexNumber subOpc = new ComplexNumber();
                        Console.WriteLine("Result: {0}", subOpc.Subtraction(cnumb1, cnumb2));
                        break;
                    case ("mc"):
                        Console.Clear();
                        PrintInfoComplex(cnumb1, cnumb2);

                        ComplexNumber mulOpc = new ComplexNumber();
                        Console.WriteLine("Result: {0}", mulOpc.Multiplication(cnumb1, cnumb2));
                        break;
                    case ("dc"):
                        Console.Clear();
                        PrintInfoComplex(cnumb1, cnumb2);

                        ComplexNumber divOpc = new ComplexNumber();
                        Console.WriteLine("Result: {0}", divOpc.Division(cnumb1, cnumb2));
                        break;
                    case ("e"):
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Choice the option below");
                        break;
                }
            }
        }


        public static void MenuItems()
        {
            Console.WriteLine("\nRational numbers"); 
            Console.WriteLine("ir - input numbers");
            Console.WriteLine("ar - add");
            Console.WriteLine("sr - subtract");
            Console.WriteLine("mr - multiply");
            Console.WriteLine("dr - divide");
            Console.WriteLine("\nComplex numbers");
            Console.WriteLine("ic - input numbers");
            Console.WriteLine("ac - add");
            Console.WriteLine("sc - subtract");
            Console.WriteLine("mc - multiply");
            Console.WriteLine("dc - divide\n");
            Console.WriteLine("e - exit\n");
        }
        public static void PrintInfoRational(RationalNumber numb1, RationalNumber numb2)
        {
            Console.WriteLine("Numbers: {0}; {1}", numb1.ToString(), numb2.ToString());
        }
        public static void PrintInfoComplex(ComplexNumber cnumb1, ComplexNumber cnumb2)
        {
            Console.WriteLine("Numbers: {0}; {1}", cnumb1.ToString(), cnumb2.ToString());
        }
    }
    class RationalNumber : RationalNumOperations
    {
        public double Number { get; set; }

        public RationalNumber() { }

        public RationalNumber(double n) 
        {
            Number = n;
        }
        public RationalNumber Addition(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Number + b.Number);
        }
        public RationalNumber Subtraction(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Number - b.Number);
        }
        public RationalNumber Multiplication(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Number * b.Number);
        }
        public RationalNumber Division(RationalNumber a, RationalNumber b)
        {
            if (b.Number == 0) { return null; }
            return new RationalNumber(a.Number / b.Number);
        }
        public override string ToString()
        {
            return String.Format("{0:N2}",Number);
        }

    }

    class ComplexNumber : ComplexNumOperations
    {
        public double RealPart { get; set; }
        public double ImaginePart { get; set; }
        public ComplexNumber() { }
        public ComplexNumber(double real, double imagine) 
        {
            RealPart = real;
            ImaginePart = imagine;
        }
        public bool IsEmpty()
        {
            return RealPart == 0 && ImaginePart == 0;
        }
        public override string ToString()
        {
            if (ImaginePart >= 0)
            {
                return String.Format("{0:N2} + {1:N2}i", RealPart, ImaginePart);
            }
            return String.Format("{0:N2} {1:N2}i",RealPart, ImaginePart);
        }

        public ComplexNumber Addition(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.RealPart + b.RealPart, a.ImaginePart + b.ImaginePart);
        }
        public ComplexNumber Subtraction(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.RealPart - b.RealPart, a.ImaginePart - b.ImaginePart);
        }
        public ComplexNumber Multiplication(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.RealPart * b.RealPart - a.ImaginePart * b.ImaginePart,
                a.RealPart * b.ImaginePart + b.RealPart * a.ImaginePart);
        }
        public ComplexNumber Division(ComplexNumber a, ComplexNumber b)
        {
            if (b.IsEmpty())
            {
                return null;
            }
            ComplexNumber number = new ComplexNumber();
            number.RealPart = a.RealPart * b.RealPart + a.ImaginePart * b.ImaginePart / Math.Pow(b.RealPart, 2) + Math.Pow(b.ImaginePart, 2);
            number.ImaginePart = a.ImaginePart * b.RealPart - a.RealPart * b.ImaginePart / Math.Pow(b.RealPart, 2) + Math.Pow(b.ImaginePart, 2);

            return number;

        }
    }

    interface ComplexNumOperations
    {
        ComplexNumber Addition(ComplexNumber a, ComplexNumber b);
        ComplexNumber Subtraction(ComplexNumber a, ComplexNumber b);
        ComplexNumber Multiplication(ComplexNumber a, ComplexNumber b);
        ComplexNumber Division(ComplexNumber a, ComplexNumber b);
    }

    interface RationalNumOperations
    {
        RationalNumber Addition(RationalNumber a, RationalNumber b);
        RationalNumber Subtraction(RationalNumber a, RationalNumber b);
        RationalNumber Multiplication(RationalNumber a, RationalNumber b);
        RationalNumber Division(RationalNumber a, RationalNumber b);
    }
}
