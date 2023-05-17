using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написати програму, що реалізує векторний добуток, заданих як одновимірні масиви. У
програмі передбачити два методи: метод векторного добутку (на вхід два вектори, значення,
що повертається – вектор), метод виводу векторного добутку на екран. Завдання також
виконати за допомогою колекцій LinkedList<LinkedList<T>>.
*/
namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            var vectors = ReadFile("C:\\Users\\Zver\\Desktop\\8.txt");
            while (true)
            {
                MenuItems(vectors);
                int item1 = int.Parse(Console.ReadLine());//немає перевірки
                int item2 = int.Parse(Console.ReadLine());

                Vector cross = Vector.CrossProduct(vectors[item1 - 1], vectors[item2 - 1]);
                Vector.PrintCrossProduct(cross, vectors[item1 - 1], vectors[item2 - 1]);

                Console.WriteLine("\nAgain? y - yes, n - no");
                string opt = Console.ReadLine();
                if (opt == "n") { Environment.Exit(0); }
                else if (opt == "y") { Console.Clear(); continue; }
            }
        }
        static void MenuItems(List<Vector> vectors)
        {
            Console.WriteLine("Choose two vectors");
            int i = 1;
            foreach (Vector v in vectors)
            {
                Console.WriteLine("{0} - {1}", i, v);
                ++i;
            }
        }
        static List<Vector> ReadFile(string path) { 

            string text = File.ReadAllText(path);
            LinkedList<double> coord = new LinkedList<double>();
            List<Vector> vectorsList = new List<Vector>();
            string numbStr = "";

            foreach (char symb in text)
            {
                if (symb == '\n') 
                {
                    vectorsList.Add(new Vector(coord.Last.Previous.Previous.Value, coord.Last.Previous.Value, coord.Last.Value));
                    numbStr = ""; 
                    continue; 
                }
                if (symb == ' ' || symb == '\r') 
                {
                    coord.AddLast(double.Parse(numbStr));
                    numbStr = "";
                    continue;
                };
                numbStr += symb;
            }
            return vectorsList;
        }
    }
    class Vector
    {
        private LinkedList<double> coord;
        public LinkedList<double> Coord
        {
            get { return coord; }
            set { if (value.Count == 3) { coord = value; } }
        }
        public double X
        {
            get { return coord.First.Value; }
            set { coord.First.Value = value; }
        }
        public double Y
        {
            get { return coord.First.Next.Value; }
            set { coord.First.Next.Value = value; }
        }
        public double Z
        {
            get { return coord.Last.Value; }
            set { coord.Last.Value = value; }
        }

        public Vector()
        {
            coord = new LinkedList<double>();
            coord.AddFirst(0.0);
            coord.AddLast(0.0);
            coord.AddLast(0.0);
        }
        public Vector(double x, double y, double z)
        {
            coord = new LinkedList<double>();
            coord.AddFirst(x);
            coord.AddLast(y);
            coord.AddLast(z);
        }
        public static Vector CrossProduct(Vector a, Vector b)
        {
            if (a.IsNullVect() || b.IsNullVect())
            {
                Console.WriteLine("Can't calculate! Null vector!");
                return null;
            }
            double x = a.Y * b.Z - a.Z * b.Y;
            double y = a.Z * b.X - a.X * b.Z;
            double z = a.X * b.Y - a.Y * b.X;
            return new Vector(x, y, z);
        }
        public bool IsNullVect()
        {
            return X == 0 && Y == 0 && Z == 0;
        }
        public override string ToString()
        {
            string formatedStr = "";
            var indDict = new Dictionary<int, char>() { { 0, 'i' }, { 1, 'j' }, { 2, 'k' } };
            var coord = Coord.ToArray();
            for (int i = 0; i < 3; ++i)
            {
                formatedStr += coord[i] > 0 && i != 0 ? String.Format("+ {0}{1} ", coord[i], indDict[i]) : String.Format("{0}{1} ", coord[i], indDict[i]);
            }
            return formatedStr;
        }
        public static void PrintCrossProduct(Vector crossProduct, Vector a, Vector b)
        {
            Console.WriteLine("Vectors:\na - {0}\nb - {1}\n", a, b);
            Console.WriteLine("Cross product:\na × b = {0}", crossProduct);
        }
    }
    class VectorAr
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public VectorAr() { }
        public VectorAr(double[] coord)
        {
            X = coord[0];
            Y = coord[1];
            Z = coord[2];
        }
        public VectorAr(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double[] GetCoordArray()
        {
            return new double[] { X, Y, Z };
        }
        public static VectorAr CrossProduct(VectorAr a, VectorAr b)
        {
            if (a.IsEmpty() || b.IsEmpty())
            {
                Console.WriteLine("Can't count! Null vector!");
                return null;
            }
            double x = a.Y * b.Z - a.Z * b.Y;
            double y = a.Z * b.X - a.X * b.Z;
            double z = a.X * b.Y - a.Y * b.X;
            return new VectorAr(x, y, z);
        }
        public bool IsEmpty()
        {
            return X == 0 && Y == 0 && Z == 0;
        }
        public override string ToString()
        {
            string formatedStr = "";
            var indDict = new Dictionary<int, char>() { { 0, 'i' }, { 1, 'j' }, { 2, 'k' } };
            var coord = GetCoordArray();
            for (int i = 0; i < 3; ++i)
            {
                formatedStr += coord[i] > 0 && i != 0 ? String.Format("+ {0}{1} ", coord[i], indDict[i]) : String.Format("{0}{1} ", coord[i], indDict[i]);
            }
            return formatedStr;
        }
        public static void PrintCrossProduct(VectorAr crossProduct, VectorAr a, VectorAr b)
        {
            Console.WriteLine("Vectors:\na - {0}\nb - {1}\n", a, b);
            Console.WriteLine("Cross product:\na × b = {0}", crossProduct);
        }
    }
}
