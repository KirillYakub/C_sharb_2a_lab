using System;

namespace Triangle
{
    class triangle
    {
        //необходимые данные;
        public double[] pointXA = new double[3];
        public double[] pointYA = new double[3];
        public double[] pointXB = new double[3];
        public double[] pointYB = new double[3];
        public double[] pointXC = new double[3];
        public double[] pointYC = new double[3];
        public double[] sideAB = new double[3];
        public double[] sideBC = new double[3];
        public double[] sideAC = new double[3];
       
        public void Input ()
        {
            int size = 3;

            Console.WriteLine("У вас есть 3 треугольника, введите координаты их точек: ");
           
            double[] arr = new double[size];

            for(int i = 0; i < arr.Length; i++)
            {
                int Correct = 0;
                do
                {
                    Console.WriteLine();
                    Console.Write($"Введите координату X {i + 1} треугольника для угла А: ");
                    pointXA[i] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();
                    Console.Write($"Введите координату Y {i + 1} треугольника для угла А: ");
                    pointYA[i] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();
                    Console.Write($"Введите координату X {i + 1} треугольника для угла B: ");
                    pointXB[i] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();
                    Console.Write($"Введите координату Y {i + 1} треугольника для угла B: ");
                    pointYB[i] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();
                    Console.Write($"Введите координату X {i + 1} треугольника для угла C: ");
                    pointXC[i] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();
                    Console.Write($"Введите координату Y {i + 1} треугольника для угла C: ");
                    pointYC[i] = Convert.ToInt32(Console.ReadLine());

                    //находим длины сторон по углам;
                    double A = pointXB[i] - pointXA[i];
                    double B = pointYB[i] - pointYA[i];
                    double B1 = pointXC[i] = pointXB[i];
                    double C = pointYC[i] - pointYB[i];
                    double A1 = pointXC[i] - pointXA[i];
                    double C1 = pointYC[i] - pointYA[i];
                    sideAB[i] = Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));
                    sideBC[i] = Math.Sqrt(Math.Pow(B1, 2) + Math.Pow(C, 2));
                    sideAC[i] = Math.Sqrt(Math.Pow(A1, 2) + Math.Pow(C1, 2));

                    //проверяем условия существования треугольника;
                    //сумма двух меньших сторон должна быть больше чем большая сторона;
                    if (sideAB[i] > sideBC[i] & sideAB[i] > sideAC[i] & sideBC[i] + sideAC[i] > sideAB[i])
                    {
                        Correct++;
                    }

                    else if (sideBC[i] > sideAB[i] & sideBC[i] > sideAC[i] & sideAB[i] + sideAC[i] > sideBC[i])
                    {
                        Correct++;
                    }

                    else if (sideAC[i] > sideAB[i] & sideAC[i] > sideBC[i] & sideAB[i] + sideBC[i] > sideAC[i])
                    {
                        Correct++;
                    }

                    //если условие выполняется - треугольник либо равнобедренный, либо равносторонний;
                    //для этого требуется равенство двух сторон либо всех трех;
                    else if (sideAB[i] == sideBC[i] | sideAB[i] == sideAC[i] | sideBC[i] == sideAB[i] | (sideAB[i] == sideBC[i] & sideAB[i] == sideAC[i]))
                    {
                        Correct++;
                    }

                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Треугольник с такой длинной сторон невозможен, введите заново");
                    }

                } while (Correct == 0);
            }

            Measurements(size, arr);
        }

        public double[] area = new double[3];
        public double[] perimeter = new double[3];
        public double[] half_perimeter = new double[3];
        public double[] angleA = new double[3];
        public double[] angleB = new double[3];
        public double[] angleC = new double[3];
        public int count = 0;

        public void Measurements(int size, double[] arr)
        {
            //находим периметр, площадь и углы;
            for(int i = 0; i < arr.Length; i++)
            {
                perimeter[i] = sideAB[i] + sideBC[i] + sideAC[i];

                //находим полупериметр для площади;
                half_perimeter[i] = (sideAB[i] + sideBC[i] + sideAC[i]) / 2;

                //формула Герона для нахождения площади;
                area[i] = Math.Abs(Math.Sqrt(half_perimeter[i] * (half_perimeter[i] - sideAB[i]) * (half_perimeter[i] - sideBC[i]) * (half_perimeter[i] - sideAC[i])));

                //находим углы;
                angleA[i] = (Math.Pow(sideAB[i], 2) + Math.Pow(sideAC[i], 2) - Math.Pow(sideBC[i], 2)) / (2 * sideAB[i] * sideAC[i]);
                angleA[i] = Math.Cos(angleA[i]);

                angleB[i] = (Math.Pow(sideAB[i], 2) + Math.Pow(sideBC[i], 2) - Math.Pow(sideAC[i], 2)) / (2 * sideAB[i] * sideBC[i]);
                angleB[i] = Math.Cos(angleB[i]);

                angleC[i] = 180 - (angleA[i] + angleB[i]);
            }

            Console.WriteLine();

            Output(size, arr);
        }   

        public void Output(int size, double[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                int max_area = 0;

                //находим равнобедренный треугольние с максимальной площадью;
                if(sideAB[i] == sideBC[i] | sideAB[i] == sideAC[i] | sideBC[i] == sideAB[i])
                {
                    if(area[i] > area[max_area])
                    {
                        max_area = i;
                    }

                    count++;
                }

                if (i == arr.Length - 1 & count > 0)
                {
                    Console.WriteLine($"Найбольшая площадь у равнобедренного треугольника под номером {max_area + 1}: " + area[max_area]);
                    Console.WriteLine();
                }

                else if(i == size - 1 & count == 0)
                {
                    Console.WriteLine("Равнобедренного треугольника среди данных не существует");
                    Console.WriteLine();
                }
            }

            //вывод информации о треугольниках;
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Треугольник под номером {i + 1}");
                Console.WriteLine($"Сторона АB = {sideAB[i]}, BC = {sideBC[i]}, AC = {sideAC[i]}");
                Console.WriteLine($"Площадь = {area[i]}, Периметр = {perimeter[i]}");
                Console.WriteLine($"Угол А = {angleA[i]}, B = {angleB[i]}, C = {angleC[i]}");
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            //вызываем функцию для ввода координат;
            triangle number = new triangle();
            number.Input();

            Console.ReadLine();

        }
    }
}
