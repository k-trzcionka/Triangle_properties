using System;

namespace Triangle_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle();
            Console.WriteLine("Obliczanie i sprawdzanie właściwości trójkąta");
            int[] getSides = triangle.GetSides();
            bool isTriangle = triangle.IsTriangle(getSides);
            double[] angles = triangle.CountAngles(getSides);
            string[] typ = triangle.CheckTriangle(getSides, angles);
            double[] height = triangle.CountHeights(getSides, typ);
            double area = triangle.Heron(getSides);
            int circuit = triangle.CountCircuit(getSides);


            if (isTriangle)
            {
                Console.WriteLine(triangle.ToString());
            }

            else Console.WriteLine("Nie można utworzyć trójkąta o wskazanych wymiarach");


        }

    }
}
