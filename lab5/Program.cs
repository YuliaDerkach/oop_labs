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
                        triangle.PrintInfo();
                        Console.WriteLine("\nPerimeter: {0:F}", triangle.FindPerimeter());
                        break;
                    case 3:
                        Console.Clear();
                        if (triangle.IsEmpty()) { Console.WriteLine("!Non assigned triangle!"); break; }
                        triangle.PrintInfo();
                        Console.WriteLine("\nSquare: {0:F}", triangle.FindSquare());
                        break;
                    case 4:
                        Console.Clear();
                        if (triangle.IsEmpty()) { Console.WriteLine("!Non assigned triangle!"); break; }
                        TPTriangle triangle1 = new TPTriangle();
                        triangle1.InputCathetus();
                        triangle.PrintInfo();
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
                        piramid.PrintInfo();
                        Console.WriteLine("\nVolume: {0:F}", piramid.FindVolume());
                        break;
                    case 10:
                        Console.Clear();
                        if (piramid.IsEmpty()) { Console.WriteLine("!Non assigned piramid!"); break; }
                        piramid.PrintInfo();
                        Console.WriteLine("\nFull surface area: {0:F}", piramid.FindFullSurfaceArea());
                        break;
                    case 11:
                        Console.Clear();
                        if (piramid.IsEmpty()) { Console.WriteLine("!Non assigned piramid!"); break; }
                        TPPiramid newPiramid = new TPPiramid(12,5,7);
                        piramid.CheckIsEqual(newPiramid);
                        break;
                    case 12:
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
            Console.WriteLine("8 - input data");
            Console.WriteLine("9 - find volume");
            Console.WriteLine("10 - find full surface area ");
            Console.WriteLine("11 - compare to other piramid");
            Console.WriteLine("\n12 - exit\n");
        }
    }
    
}

