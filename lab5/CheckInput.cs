using System;

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