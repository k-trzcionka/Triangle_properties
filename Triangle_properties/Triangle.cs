using System;

namespace Triangle_properties
{
    class Triangle
    {
        public int[] sides;
        public double area;
        public int circuit;
        public double[] height;
        public double[] angles;
        public string[] typ;
        public Triangle(int[] Sides, double Area, int Circuit, double[] Height, double[] Angles)//Triangle fields
        {
            int[] side1 = Sides;
            double area = Area;
            int circuit = Circuit;
            double[] height = Height;
            double[] angles = Angles;

        }
        public Triangle()//Base constructor without params
        {

        }

        public int[] GetSides()//Get from triangle sides
        {


            int[] takenSides = { 0, 0, 0 };

            for (int i = 0; i < 3;)
            {
                int getNumber = 0;

                while (getNumber == 0)//Wrong input secure
                {
                    try
                    {
                        Console.WriteLine($"Podaj długość {i + 1} boku");
                        getNumber = Convert.ToInt32(Console.ReadLine());

                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Należy podać liczbę!");
                        getNumber = 0;
                    }
                }
                int side = getNumber;
                if (side > 0)//Wrong value secure
                {
                    takenSides[i] = side;
                    i++;
                }
                else
                {
                    Console.WriteLine("Długość boku nie może być mniejsza lub równa 0");

                }

            }
            this.sides = takenSides;
            return takenSides;
        }

        public bool IsTriangle(int[] sides)//Check if a triangle can be formed
        {
            int side1 = sides[0];
            int side2 = sides[1];
            int side3 = sides[2];
            bool triangle;
            if ((side1 + side2) > side3 && (side1 + side3) > side2 && (side2 + side3) > side1)
            {
                triangle = true;
            }
            else triangle = false;

            return triangle;
        }
        public int CountCircuit(int[] sides)//Count triangle circuit based on sides
        {
            int circuit = 0;
            foreach (int side in sides)
            {
                circuit += side;
            }
            this.circuit = circuit;
            return circuit;
        }

        public double[] CountAngles(int[] sides)//Count triangle angles
        {
            double side1 = sides[0];
            double side2 = sides[1];
            double side3 = sides[2];
            double[] angles = new double[3];
            if (side1 == side2 && side2 == side3)//If equilateral triangle
            {
                for (int i = 0; i < 3; i++)
                {
                    angles[i] = 60;
                }

            }
            else if (side1 == side2 || side2 == side3 || side1 == side3)//If isosceles triangle
            {
                if (side1 == side2)
                {
                    angles[0] = Math.Round(Math.Cos((side3 / 2) / side1) * 180 / Math.PI);
                    angles[1] = angles[0];
                    angles[2] = 180 - (2 * angles[0]);
                }
                else if (side2 == side3)
                {
                    angles[0] = Math.Round(Math.Cos(side2 / (side1 / 2)) * 180 / Math.PI);
                    angles[1] = angles[0];
                    angles[2] = 180 - (2 * angles[0]);

                }
                else
                {
                    angles[0] = Math.Round(Math.Cos(side3 / (side2 / 2)) * 180 / Math.PI);
                    angles[1] = angles[0];
                    angles[2] = 180 - (2 * angles[0]);
                }

            }
            else if ((Math.Pow(side1, 2) + Math.Pow(side2, 2) == Math.Pow(side3, 2)) || (Math.Pow(side1, 2) + Math.Pow(side3, 2) == Math.Pow(side2, 2)) || (Math.Pow(side3, 2) + Math.Pow(side2, 2) == Math.Pow(side1, 2)))//If Pythagorean triangle
            {
                angles[0] = 90;
                angles[1] = 60;
                angles[2] = 30;
            }
            this.angles = angles;
            return angles;
        }

        public double[] CountHeights(int[] sides, string[] typ)//Count triangle height or heights depending on type of it
        {
            int a = sides[0];
            int b = sides[1];
            int c = sides[2];
            double[] h = { 0, 0 };

            if (a == b && b == c)//If equilateral triangle
            {
                h[0] = a * Math.Sqrt(3) / 2;
            }
            else if (a == b || b == c || a == c)//If isosceles triangle
            {
                if (a == b)
                {
                    h[0] = c * Math.Sqrt(3) / 2;
                }
                else if (b == c)
                {
                    h[0] = a * Math.Sqrt(3) / 2;
                }
                else h[0] = b * Math.Sqrt(3) / 2;

            }
            else if (String.Compare(typ[1], "Prostokątny") == 1)//If rectangular triangle
            {
                if (a > b || a > c)
                {
                    h[0] = b;
                    h[1] = c;
                }
                else if (a > b || c > a)
                {
                    h[0] = a;
                    h[1] = b;
                }
                else
                {
                    h[0] = a;
                    h[1] = c;
                }
            }
            this.height = h;
            return h;
        }

        public double Heron(int[] sides)//Count area of triangle using Heron formula's
        {
            double side1 = sides[0];
            double side2 = sides[1];
            double side3 = sides[2];
            double factor = (side1 + side2 + side3) / 2;
            double area = Math.Sqrt(factor * (factor - side1) * (factor - side2) * (factor - side3));
            this.area = area;
            return area;
        }
        public string[] CheckTriangle(int[] sides, double[] angles)//Return type of triangle
        {
            int a = sides[0];
            int b = sides[1];
            int c = sides[2];
            string[] typ = new string[2];

            if (a == b && b == c)//Depending of sides
            {
                typ[0] = "Równoboczny";
            }
            else if (a == b || b == c || a == c)
            {
                typ[0] = "Równoramienny";
            }
            else typ[0] = "Różnoboczny";
            ////Depending of angles
            if (angles[0] == 90 || angles[1] == 90 || angles[2] == 90)
            {
                typ[1] = "Prostokątny";
            }
            else if (angles[0] > 90 || angles[1] > 90 || angles[2] > 90)
            {
                typ[1] = "Rozwartokątny";
            }
            else
            {
                typ[1] = "Ostrokątny";
            }
            this.typ = typ;
            return typ;

        }

        public override string ToString()//Print information about given triangle
        {
            Console.Clear();
            string h;
            if (height[1] != 0)
            {
                h = $"{height[0]}, {height[1]}";
            }
            else h = $"{height[0]}";

            string triangleTypes = $"{typ[0]} oraz {typ[1]} ";

            string countedAngles;
            if (angles[0] == 0)
            {
                countedAngles = "Nie można obliczyć kątów tego trójkąta";
            }
            else countedAngles = $"{angles[0]}, {angles[1]}, {angles[2]}";


            string obj = $"Długość boków:{this.sides[0]},{this.sides[1]},{this.sides[2]}\nWysokość: {h}\nPole: {this.area}\nObwód: {this.circuit}\nKaty: {countedAngles}\nRodzaj trójkąta: {triangleTypes}";
            return obj;
        }
    }
}
