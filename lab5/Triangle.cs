using System;

namespace lab5
{
    class TPTriangle
    {
        protected double cathetus1;
        protected double cathetus2;
        protected double hypotenuse;
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

        public void CheckIsEqual(TPTriangle triangle)
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
}
