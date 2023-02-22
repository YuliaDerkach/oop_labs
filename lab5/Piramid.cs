using System;

namespace lab5
{
    class TPPiramid : TPTriangle
    {
        private double altitude;

        public double Altitude
        {
            get { return altitude; }
            set { if (value > 0) this.altitude = value; }
        }

        public TPPiramid() { }

        public TPPiramid(double altitude, double cathetus1, double cathetus2)
        {
            this.altitude = altitude;
            base.cathetus1 = cathetus1;
            base.cathetus2 = cathetus2;
        }

        public double FindVolume()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Oops...\nSeem you haven`t assigned piramid values");
                return double.NaN;
            }
            return (double)1 / 6 * altitude * cathetus1 * cathetus2;
        }
        public override void PrintInfo()
        {
            Console.WriteLine(String.Format("Altitude: {0:F}\nEdge1: {1:F}\nEdge2: {2:F}", altitude, cathetus1, cathetus2));
        }

        public override bool IsEmpty()
        {
            return altitude == 0 || cathetus2 == 0 || cathetus1 == 0;
        }

        public void InputData()
        {
            Console.WriteLine("Please, enter a length of the first edge");
            cathetus1 = CheckedInput.CheckPosDouble();
            Console.WriteLine("Please, enter a length of the second edge");
            cathetus2 = CheckedInput.CheckPosDouble();
            Console.WriteLine("Please, enter a length of the altitude");
            this.altitude = CheckedInput.CheckPosDouble();
        }

        public double FindFullSurfaceArea()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Oops...\nSeem you haven`t assigned piramid values");
                return double.NaN;
            }
            TPTriangle a = new TPTriangle(cathetus1, altitude);
            TPTriangle b = new TPTriangle(altitude, cathetus2);
            

            double baseSquare = GeronFormulas(a.Hypotenuse, b.Hypotenuse, base.Hypotenuse);
            return a.FindSquare() + b.FindSquare() + base.FindSquare() + baseSquare;

        }

        private double GeronFormulas(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public void CheckIsEqual(TPPiramid piramid)
        {
            if (IsEmpty() || piramid.IsEmpty())
            {
                Console.WriteLine("Oops...\nSeem you haven`t assigned piramid's values");
                return;
            }
            if (piramid.altitude == this.altitude && piramid.cathetus1 == this.cathetus1 && piramid.cathetus2 == this.cathetus2)
            {
                Console.WriteLine("Piramids are equal");
            }
            else if (piramid.FindVolume() > this.FindVolume())
            {
                Console.WriteLine(String.Format("The given piramid(v:{0:F}) is bigger than the current one(v:{1:F})", piramid.FindVolume(), this.FindVolume()));
            }
            else
            {
                Console.WriteLine(String.Format("The given piramid(v:{0:F}) is smaller than the current one(v:{1:F})", piramid.FindVolume(), this.FindVolume()));
            }
        }

    }
}