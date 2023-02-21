using System;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        { 
            TPTriangle triangle = new TPTriangle();
            TPPiramid piramid = new TPPiramid();
           
            while (true)
            {
                MenuItems();
                uint variant = CheckedInput.InputUInt();
                switch (variant)
                {
                    case 1:
                        Console.Clear();
                        triangle.InputCathetus();
                        triangle.PrintInfo();
                        break;
                    case 2:
                        Console.Clear();
                        if (triangle.IsEmpty()) { Console.WriteLine("!Non assigned triangle!"); break; }
                        Console.WriteLine("Perimeter: {0:F}", triangle.FindPerimeter());
                        break;
                    case 3:
                        Console.Clear();
                        if (triangle.IsEmpty()) { Console.WriteLine("!Non assigned triangle!"); break; }
                        Console.WriteLine("Square: {0:F}", triangle.FindSquare());
                        break;
                    case 4:
                        Console.Clear();
                        if (triangle.IsEmpty()) { Console.WriteLine("!Non assigned triangle!"); break; }
                        TPTriangle triangle1 = new TPTriangle();
                        triangle1.InputCathetus();
                        triangle.CheckIsEqual(triangle1);
                        break;
                    case 5:
                        Console.Clear();
                        if (triangle.IsEmpty()) { Console.WriteLine("!Non assigned triangle!"); break; }
                        TPTriangle newTriang = new TPTriangle(3, 4);
                        TPTriangle resTriang = triangle + newTriang;
                        Console.WriteLine("First triangle");
                        triangle.PrintInfo();
                        Console.WriteLine("\nSecond triangle(new)");
                        newTriang.PrintInfo();
                        Console.WriteLine("\nResult (addition)");
                        resTriang.PrintInfo();
                        break;
                    case 6:
                        Console.Clear();
                        if (triangle.IsEmpty()) { Console.WriteLine("!Non assigned triangle!"); break; }
                        TPTriangle copTriang = new TPTriangle(triangle);
                        copTriang.InputCathetus();            
                        TPTriangle subResTriang = triangle - copTriang;
                        if(subResTriang == null) { Console.WriteLine("!Result less than zero!"); break; }
                        Console.WriteLine("First triangle");
                        triangle.PrintInfo();
                        Console.WriteLine("\nSecond triangle(copied and changed)");
                        copTriang.PrintInfo();
                        Console.WriteLine("\nResult (subtraction)");
                        subResTriang.PrintInfo();
                        break;
                    case 7:
                        Console.Clear();
                        if (triangle.IsEmpty()) { Console.WriteLine("!Non assigned triangle!"); break; }
                        Console.WriteLine("Enter a number");
                        uint num = CheckedInput.InputUInt();
                        TPTriangle mulResTriang = triangle * num;
                        Console.WriteLine("First triangle");
                        triangle.PrintInfo();
                        Console.WriteLine("\nResult (multiplication)");
                        mulResTriang.PrintInfo();
                        break;
                    case 8:
                        Console.Clear();
                        piramid.InputData();
                        piramid.PrintInfo();
                        break;
                    case 9:
                        Console.Clear();
                        if (piramid.IsEmpty()) { Console.WriteLine("!Non assigned piramid!"); break; }
                        Console.WriteLine("Volume: {0:F}", piramid.FindVolume());
                        break;
                    case 10:
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
            Console.WriteLine("\n------triangle-------------------------");
            Console.WriteLine("1 - input the catheti");
            Console.WriteLine("2 - find perimeter");
            Console.WriteLine("3 - find square");
            Console.WriteLine("4 - compare to other triangle");
            Console.WriteLine("5 - add triangles");
            Console.WriteLine("6 - subtract triangles");
            Console.WriteLine("7 - multiply the triangle by the number");
            Console.WriteLine("\n-----piramid--------------------------");
            Console.WriteLine("8 - input the edges");
            Console.WriteLine("9 - find volume");
            Console.WriteLine("\n10 - exit\n");
        }
    }
    class TPTriangle
    {
        private double cathetus1;
        private double cathetus2;
        private double hypotenuse;
        public double Cathetus1
        {
            get { return cathetus1; }
            set
            {
                if (value > 0)
                    cathetus1 = value;
                hypotenuse = Math.Sqrt(Math.Pow(value, 2) + Math.Pow(cathetus2, 2));
            }
        }

        public double Cathetus2
        {
            get { return cathetus2; }
            set
            {
                if (value > 0)
                    cathetus2 = value;
                hypotenuse = Math.Sqrt(Math.Pow(value, 2) + Math.Pow(cathetus1, 2));
            }
        }

        public double Hypotenuse { get; }

        public TPTriangle() { }

        public TPTriangle(double cathetus1, double cathetus2)
        {
            this.cathetus1 = cathetus1;
            this.cathetus2 = cathetus2;

            hypotenuse = Math.Sqrt(Math.Pow(cathetus1, 2) + Math.Pow(cathetus2, 2));
        }

        public TPTriangle(TPTriangle triangle)
        {
            this.cathetus1 = triangle.Cathetus1;
            this.cathetus2 = triangle.Cathetus2;
            this.hypotenuse = triangle.Hypotenuse;
        }


        public virtual void PrintInfo()
        {
            Console.WriteLine(String.Format("Cathetus 1: {0:F}\nCathetus 2: {1:F}\nHypotenuse: {2:F}", cathetus1, cathetus2, hypotenuse));
        }

        public void InputCathetus()
        {
            Console.WriteLine("Please, enter the first cathetus");
            this.cathetus1 = CheckedInput.CheckPosDouble();
            Console.WriteLine("Please, enter the second cathetus");
            this.cathetus2 = CheckedInput.CheckPosDouble();
            hypotenuse = Math.Sqrt(Math.Pow(cathetus1, 2) + Math.Pow(cathetus2, 2));
        }

        public double FindSquare()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Oops...\nSeem you haven`t assigned all catheti values");
                return double.NaN;
            }
            return 0.5 * this.cathetus1 * this.cathetus2;
        }

        public double FindPerimeter()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Oops...\nSeem you haven`t assigned all catheti values");
                return double.NaN;
            }
            return this.cathetus1 + this.cathetus2 + this.hypotenuse;
        }

        public virtual void CheckIsEqual(TPTriangle triangle)
        {
            if (IsEmpty() || triangle.IsEmpty())
            {
                Console.WriteLine("Oops...\nSeem you haven`t assigned all catheti values");
                return;
            }
            if ((triangle.cathetus1 == cathetus1 && triangle.cathetus2 == cathetus2) || (triangle.cathetus2 == cathetus1 && triangle.cathetus1 == cathetus2))
            {
                Console.WriteLine("Triangles are equal");
            }
            else if (triangle.FindSquare() > FindSquare())
            {
                Console.WriteLine("The triangle with the catheti {0:F} and {1:F} is bigger than the current one", triangle.cathetus1, triangle.cathetus2);
            }
            else
            {
                Console.WriteLine("The triangle with the catheti {0:F} and {1:F} is smaller than the current one", triangle.cathetus1, triangle.cathetus2);
            }
        }

        public virtual bool IsEmpty()
        {
            return cathetus1 == 0 || cathetus2 == 0;
        }

        public static TPTriangle operator +(TPTriangle triangle1, TPTriangle triangle2)
        {
            TPTriangle resTriangle = new TPTriangle();
            resTriangle.Cathetus1 = triangle1.cathetus1 + triangle2.cathetus1;
            resTriangle.Cathetus2 = triangle1.cathetus2 + triangle2.cathetus2;
            return resTriangle;
        }

        public static TPTriangle operator -(TPTriangle triangle1, TPTriangle triangle2)
        {
            TPTriangle resTriangle = new TPTriangle();
            resTriangle.Cathetus1 = triangle1.cathetus1 - triangle2.cathetus1;
            resTriangle.Cathetus2 = triangle1.cathetus2 - triangle2.cathetus2;
            if (resTriangle.cathetus1 <= 0 || resTriangle.cathetus2 <= 0)
            {
                return null;
            }
            return resTriangle;
        }

        public static TPTriangle operator *(TPTriangle triangle1, double number)
        {
            TPTriangle resTriangle = new TPTriangle();
            resTriangle.Cathetus1 = triangle1.cathetus1 * number;
            resTriangle.Cathetus2 = triangle1.cathetus2 * number;
            return resTriangle;
        }
    }
    class TPPiramid : TPTriangle
    {
        private double edge1;
        private double edge2;
        private double altitude;

        public double Edge1
        {
            get { return edge1; }
            set { if (value > 0) this.edge1 = value; }
        }
        public double Edge2
        {
            get { return edge2; }
            set { if (value > 0) this.edge2 = value; }
        }
        public double Altitude
        {
            get { return altitude; }
            set { if (value > 0) this.altitude = value; }
        }

        public TPPiramid() { }

        public TPPiramid(double altitude, double edge1, double edge2)
        {
            this.altitude = altitude;
            this.edge1 = edge1;
            this.edge2 = edge2;
        }

        public double FindVolume()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Oops...\nSeem you haven`t assigned piramid values");
                return double.NaN;
            }
            return (double)1 / 6 * altitude * edge1 * edge2;
        }
        public override void PrintInfo()
        {
            Console.WriteLine(String.Format("Altitude: {0:F}\nEdge1: {1:F}\nEdge2: {2:F}", altitude, edge1, edge2));
        }

        public override bool IsEmpty()
        {
            return altitude == 0 || edge1 == 0 || edge2 == 0;
        }

        public void InputData()
        {
            Console.WriteLine("Please, enter a length of the first edge");
            this.edge1 = CheckedInput.CheckPosDouble();
            Console.WriteLine("Please, enter a length of the second edge");
            this.edge2 = CheckedInput.CheckPosDouble();
            Console.WriteLine("Please, enter a length of the altitude");
            this.altitude = CheckedInput.CheckPosDouble();
        }
    }
    static class CheckedInput
    {
        public static double CheckPosDouble()
        {
            double value;
            while (true)
            {
                double.TryParse(Console.ReadLine(), out value);
                if (value > 0)
                {
                    return value;
                }
                Console.WriteLine("Oops...Invalid format.\nThe value should be the positive number");
            }

        }
        public static uint InputUInt()
        {
            uint n;
            while (!uint.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Invalid input! Please try again");
            }
            return n;
        }
    }
}

