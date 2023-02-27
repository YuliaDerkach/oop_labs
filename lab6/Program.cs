using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {

            while (true)
            {
                MenuItems();
                uint variant = CheckedInput.InputUInt();
                switch (variant)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter the number of elements");
                        Task11(CheckedInput.InputPosInt());
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter the vector's dimension");
                        Task12(CheckedInput.InputPosInt());

                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter the number of elements");
                        Task13(CheckedInput.InputPosInt());
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter dimension of the matrix ");
                        Task21(CheckedInput.InputPosInt());
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Enter the number of rows ");
                        int r = CheckedInput.InputPosInt();
                        Console.WriteLine("Enter the number of columns ");
                        int c = CheckedInput.InputPosInt();
                        Task22(r,c);
                        break;
                    case 6:
                        Console.Clear();
                        Task23();
                        break;
                    case 7:
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
            Console.WriteLine("\n1 - task 1.1");
            Console.WriteLine("2 - task 1.2");
            Console.WriteLine("3 - task 1.3");
            Console.WriteLine("4 - task 2.1");
            Console.WriteLine("5 - task 2.2");
            Console.WriteLine("6 - task 2.3");
            Console.WriteLine("7 - exit\n");
        }

        static void Task11(int n)//Дано n дійсних чисел. Знайти найменше серед додатних.
        {
            double[] array = new double[n];
            int i = 0;
            double min;

            RandFillDoubleArray(array, 10, -10);

            Console.WriteLine("Array");
            foreach (double x in array)
            {
                Console.Write("{0:F} ", x);
            }
            Console.WriteLine();

            while (true)
            {
                if (i > n - 1)
                {
                    Console.WriteLine("There are no positive numbers");
                    return;
                }
                if (array[i] > 0)
                    break;
                ++i;
            }

            min = array[i];
            foreach (double x in array)
            {
                if (x > 0 && x < min)
                    min = x;
            }

            Console.WriteLine("Min: {0:F} ",min);
        }
        static void PrintIArray(int[] a)
        {
            foreach (int x in a)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }
        static bool IsZeroVect(double[]vector)
        {
            int n = vector.Length;
            int i = 0;
            while (true)
            {
                if (i > n - 1)
                {
                    return true;
                }
                if (vector[i] != 0)
                {
                    return false;
                }
                ++i;
            }
        }
        static void FillIntArray(int[] array)
        {
            Random rnd = new Random();
            for(int i = 0; i < array.Length; ++i)
            {
                array[i] = rnd.Next(0,5);
            }
        }
        static void RandFillDoubleArray(double[] array,double max, double min)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = rnd.NextDouble() * (max - min) + min;
            }
        }
        static void FillDoubleArray(double[] array)
        {
            Console.WriteLine("Enter values");
            for(int i = 0; i < array.Length;++i)
            {
                array[i] = CheckedInput.InputDouble();
            }
        }
        static void Task12(int n)//Дано два вектори З’ясувати, чи паралельні вони
        {
            double[] vector1 = new double[n];
            double[] vector2 = new double[n];
            double k;
            int i = 0;


            FillDoubleArray(vector1);
            FillDoubleArray(vector2);

            if (IsZeroVect(vector1) || IsZeroVect(vector2))
            {
                Console.WriteLine("zero vector");
                return;
            }

            while (true)
            {
                   if (i > n - 1)
                   { 
                       return;
                   }
                   if (vector2[i] != 0)
                   {
                       k = vector1[i] / vector2[i];
                       break;
                   }
                   ++i;
            }

            i = 0;
            
            while (true)
               {
                   if (i > n - 1)
                   {
                       Console.WriteLine("Result: colinear");
                       break;
                   }

                if (vector1[i] != vector2[i] * k )
                   {
                       Console.WriteLine("Result: non colinear");
                       break; 
                   }

                   ++i;
               }
        }
        static void Task13(int n)// Перетворити масив таким чином, щоб спочатку розміщувались всі елементи рівні 0, а потім всі інші
        {
            int[] array = new int[n];
            FillIntArray(array);
            Console.WriteLine("Array");
            PrintIArray(array);

            int i = 0;
            while (true)
            {
                if (i > n - 1)
                {
                    break;
                }
                if (array[i] == 0)
                {
                    int j = i;
                    while (j != 0)
                    {
                        array[j] = array[j - 1];
                        array[j - 1] = 0;
                        --j;
                    }
                }
                ++i;
            }
            Console.WriteLine("Modified array");
            PrintIArray(array);
        }
        static void FillMatrix(int [,] matrix,int rows, int columns)
        {
            Random rnd = new Random();
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    matrix[i, j] = rnd.Next(-5,20);
                }
            }
        }
        static void PrintMatrix(int[,] matrix, int rows, int columns)
        {
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void Task21(int n)//Розмістити елементи непарних рядків у порядку спадання.
        {
            int[,] matrix = new int[n, n];
            FillMatrix(matrix,n,n);

            Console.WriteLine("Matrix");
            PrintMatrix(matrix, n, n);

            for (int i = 0; i < n; ++i)
            {
                if (i % 2 == 0)
                {
                    int[] sorted = new int[n];
                    sorted[0] = matrix[i, 0];

                    for (int j = 1; j < n; ++j)
                    {
                        sorted[j] = matrix[i, j];
                        int s = j;
                        while (s > 0 && sorted[s] >= sorted[s - 1])
                        {
                            int temp = sorted[s];
                            sorted[s] = sorted[s - 1];
                            sorted[s - 1] = temp;
                            --s;
                        }
                    }

                    for (int k = 0; k < n; ++k)
                    {
                        matrix[i, k] = sorted[k];
                    }

                }
            }
            Console.WriteLine("Modified matrix");
            PrintMatrix(matrix, n, n);
        }
        static void Task22(int rows, int columns)//Дана цілочислова прямокутна матриця. Визначити суму елементів в тих стовпцях, які містять хоча б один від’ємний елемент.
        {
            int[,] matrix = new int[rows, columns];

            FillMatrix(matrix, rows, columns);
            PrintMatrix(matrix, rows, columns);

            int[] sumArray = new int[columns];

            for (int i = 0; i < columns; ++i)
            {
                int sum = 0;
                bool hasNegative = false;
                for (int j = 0; j < rows; ++j)
                {
                    sum += matrix[j, i];
                    if(matrix[j,i] < 0) { hasNegative = true; }
                }
                if(hasNegative)
                    sumArray[i] = sum;
            }

            Console.WriteLine("\nColumn's index|\tSum");
            Console.WriteLine("----------------------");
            for (int i = 0; i < sumArray.Length; ++i)
            {
                if(sumArray[i] != 0)
                    Console.WriteLine(" {0}            |\t{1}",i,sumArray[i]);
            }
            

        }  
        static void Task23()//Дана цілочислова прямокутна матриця. Визначити номера рядків і стовпців всіх сідлових точок матриці.Матриця А має сідлову точку А0, якщо Aij є мінімальним елементом в і-у рядку і максимальним в j-у стовпці.
        {
            int[,] matrix = new int[,] { {-2,-2,4},
                                        { -5,0,-3},
                                        { 1,3,8},
                                        { -10,11,-5} };

            int rows = 4, columns = 3;
            PrintMatrix(matrix, rows, columns);

            List<int[]> saddlePoints = new List<int[]>();
              for (int i = 0; i < rows; ++i)
              {
                  int min = matrix[i, 0];
                  int indc = 0;
                  for (int j = 0; j < columns; ++j)
                  {
                      if (matrix[i, j] < min)
                      {
                          min = matrix[i, j];
                          indc = j;
                      }

                  }
                int k;
                for(k = 0; k < rows; ++k)
                {
                    if (min < matrix[k, indc])
                        break;
                }


                if(k == rows)
                    saddlePoints.Add(new int []{i, indc});

              }

            if (!saddlePoints.Any())
            {
                Console.WriteLine("There are no saddle points");
                return;
            }

            Console.WriteLine("Saddle points");
            foreach (var x in saddlePoints)
            {
                Console.WriteLine("r: {0}\tc: {1}", x[0] ,x[1]);
            }
        }

    }
}
