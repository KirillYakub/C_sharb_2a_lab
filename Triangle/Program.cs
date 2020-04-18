using System;

namespace Triangle
{
    class Triangle
    {
        //необходимые данные;
        public double pointXA, pointYA, pointXB, pointYB, pointXC, pointYC, sideAB, sideBC, sideAC;
        public double area, perimeter, half_perimeter, angleA, angleB, angleC, A, B, B1, C, A1, C1;

        public double VariableA()
        {
            return A = pointXB - pointXA;
        }

        public double VariableB()
        {
            return B = pointYB - pointYA;
        }

        public double VariableB1()
        {
            return B1 = pointXC - pointXB;
        }

        public double VariableC()
        {
            return C = pointYC - pointYB;
        }

        public double VariableA1()
        {
            return A1 = pointXC - pointXA;
        }

        public double VariableC1()
        {
            return C1 = pointYC - pointYA;
        }

        //функция проверки условий существования треугольника;
        public bool isCorrect()
        {
            //сумма двух меньших сторон должна быть больше чем большая сторона;
            if ((sideAB > sideBC) && (sideAB > sideAC) && (sideBC + sideAC >= sideAB))
            {
                return true;
            }

            if ((sideBC > sideAB) && (sideBC > sideAC) && (sideAB + sideAC >= sideBC))
            {
                return true;
            }

            if ((sideAC > sideAB) && (sideAC > sideBC) && (sideAB + sideBC >= sideAC))
            {
                return true;
            }

            //если условие выполняется - треугольник либо равнобедренный, либо равносторонний;
            //для этого требуется равенство двух сторон либо всех трех;
            if ((sideAB == sideBC) || (sideBC == sideAC) || (sideAB == sideAC) || ((sideAB == sideBC) && (sideAB == sideAC)))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //функция ввода координат;
        public void Input(int size, Triangle[] arr)
        {
            Random random = new Random();

            Console.WriteLine("Координаты сгенерированы! Размерности треугольников: ");
            Console.WriteLine();

            for (int i = 0; i < arr.Length; i++)
            {
                do
                {
                    arr[i] = new Triangle();

                    arr[i].pointXA = random.Next(-10, 10);
                    pointXA = arr[i].pointXA;

                    arr[i].pointYA = random.Next(-10, 10);
                    pointYA = arr[i].pointYA;

                    //циклы для проверки ввода координат - координаты точек не могут совпадать
                    do
                    {

                        arr[i].pointXB = random.Next(-10, 10);
                        pointXB = arr[i].pointXB;

                    } while (arr[i].pointXB == arr[i].pointXA);

                    do
                    {

                        arr[i].pointYB = random.Next(-10, 10);
                        pointYB = arr[i].pointYB;

                    } while (arr[i].pointYB == arr[i].pointYA);

                    do
                    {

                        arr[i].pointXC = random.Next(-10, 10);
                        pointXC = arr[i].pointXC;

                    } while (arr[i].pointXC == arr[i].pointXB || arr[i].pointXC == arr[i].pointXA);

                    do
                    {

                        arr[i].pointYC = random.Next(-10, 10);
                        pointYC = arr[i].pointYC;

                    } while (arr[i].pointYC == arr[i].pointYB || arr[i].pointYC == arr[i].pointYA);

                    //находим длины сторон по углам;
                    sideAB = Math.Abs(Math.Sqrt((VariableA() * VariableA()) + (VariableB() * VariableB())));
                    sideBC = Math.Abs(Math.Sqrt((VariableB1() * VariableB1()) + (VariableC() * VariableC())));
                    sideAC = Math.Abs(Math.Sqrt((VariableA1() * VariableA1()) + (VariableC1() * VariableC1())));

                } while (!isCorrect());

                arr[i].sideAB = sideAB;
                arr[i].sideBC = sideBC;
                arr[i].sideAC = sideAC;
            }
        }

        //функция подсчета площади, периметра и углов;
        public void Calculate(int size, Triangle[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i].perimeter = arr[i].sideAB + arr[i].sideBC + arr[i].sideAC;

                //находим полупериметр для площади;
                arr[i].half_perimeter = (arr[i].sideAB + arr[i].sideBC + arr[i].sideAC) / 2;

                //формула Герона для нахождения площади;
                arr[i].area = Math.Sqrt(arr[i].half_perimeter * (arr[i].half_perimeter - arr[i].sideAB) * (arr[i].half_perimeter - arr[i].sideBC) * (arr[i].half_perimeter - arr[i].sideAC));
                arr[i].area = Math.Abs(arr[i].area);

                //находим углы;
                arr[i].angleA = (arr[i].sideAB * arr[i].sideAB + arr[i].sideAC * arr[i].sideAC - arr[i].sideBC * arr[i].sideBC) / (2 * arr[i].sideAB * arr[i].sideAC) * 180 / Math.PI;
                arr[i].angleA = Math.Abs(arr[i].angleA + 1);

                arr[i].angleB = (arr[i].sideAB * arr[i].sideAB + arr[i].sideBC * arr[i].sideBC - arr[i].sideAC * arr[i].sideAC) / (2 * arr[i].sideAB * arr[i].sideBC) * 180 / Math.PI;
                arr[i].angleB = Math.Abs(arr[i].angleB + 1);

                arr[i].angleC = 180 - (arr[i].angleA + arr[i].angleB);
            }
        }
        
        //функция поиска подобных треугольников;
        public void Pertain(int size, Triangle[] arr)
        {
            if (size > 1)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    int count = 0;
                    Console.Write($"Подобные {i + 1}-му: ");

                    for (int j = 1; j < arr.Length; j++)
                    {
                        //проверка по трем сторонам;
                        if ((arr[i].sideAB > arr[j].sideAB) && (arr[i].sideBC > arr[j].sideBC) && (arr[i].sideAC > arr[j].sideAC) && i != j)
                        {
                            double difference = arr[i].sideAB - arr[j].sideAB, a = arr[i].sideAB / difference, a1 = arr[j].sideAB / difference;
                            double difference1 = arr[i].sideBC - arr[j].sideBC, b = arr[i].sideBC / difference1, b1 = arr[j].sideBC / difference1;
                            double difference2 = arr[i].sideAC - arr[j].sideAC, c = arr[i].sideAC / difference2, c1 = arr[j].sideAC / difference2;
                            if ((a - (int)a < Double.Epsilon) && (a1 - (int)a1 < Double.Epsilon) && (b - (int)b < Double.Epsilon) && (b1 - (int)b1 < Double.Epsilon) && (c - (int)c < Double.Epsilon) && (c1 - (int)c1 < Double.Epsilon))
                            {
                                Console.Write($"{j + 1};");
                                count++;
                                continue;
                            }
                        }

                        if ((arr[i].sideAB < arr[j].sideAB) && (arr[i].sideBC < arr[j].sideBC) && (arr[i].sideAC < arr[j].sideAC) && i != j)
                        {
                            double difference = arr[j].sideAB - arr[i].sideAB, a = arr[i].sideAB / difference, a1 = arr[j].sideAB / difference;
                            double difference1 = arr[j].sideBC - arr[i].sideBC, b = arr[i].sideBC / difference1, b1 = arr[j].sideBC / difference1;
                            double difference2 = arr[j].sideAC - arr[i].sideAC, c = arr[i].sideAC / difference2, c1 = arr[j].sideAC / difference2;
                            if ((a - (int)a < Double.Epsilon) && (a1 - (int)a1 < Double.Epsilon) && (b - (int)b < Double.Epsilon) && (b1 - (int)b1 < Double.Epsilon) && (c - (int)c < Double.Epsilon) && (c1 - (int)c1 < Double.Epsilon))
                            {
                                Console.Write($"{j + 1};");
                                count++;
                                continue;
                            }
                        }

                        //проверка по двум углам;
                        if((arr[i].angleA > arr[j].angleA && arr[i].angleB > arr[j].angleB) || (arr[i].angleB > arr[j].angleB && arr[i].angleC > arr[j].angleC) || (arr[i].angleA > arr[j].angleA && arr[i].angleC > arr[j].angleC))
                        {
                            double difference = arr[i].angleA - arr[j].angleA, a = arr[i].angleA / difference, a1 = arr[j].angleA / difference;
                            double difference1 = arr[i].angleB - arr[j].angleB, b = arr[i].angleB / difference1, b1 = arr[j].angleB / difference1;
                            double difference2 = arr[i].angleC - arr[j].angleC, c = arr[i].angleC / difference2, c1 = arr[j].angleC / difference2;
                            if((a - (int)a < Double.Epsilon && a1 - (int)a1 < Double.Epsilon && b - (int)b < Double.Epsilon && b1 - (int)b1 < Double.Epsilon) || (b - (int)b < Double.Epsilon && b1 - (int)b1 < Double.Epsilon && c - (int)c < Double.Epsilon && c1 - (int)c1 < Double.Epsilon) || (a - (int)a < Double.Epsilon && a1 - (int)a1 < Double.Epsilon && c - (int)c < Double.Epsilon && c1 - (int)c1 < Double.Epsilon))
                            {
                                Console.Write($"{j + 1};");
                                count++;
                                continue;
                            }
                        }

                        if ((arr[i].angleA < arr[j].angleA && arr[i].angleB < arr[j].angleB) || (arr[i].angleB < arr[j].angleB && arr[i].angleC < arr[j].angleC) || (arr[i].angleA < arr[j].angleA && arr[i].angleC < arr[j].angleC))
                        {
                            double difference = arr[j].angleA - arr[i].angleA, a = arr[j].angleA / difference, a1 = arr[i].angleA / difference;
                            double difference1 = arr[j].angleB - arr[i].angleB, b = arr[j].angleB / difference1, b1 = arr[i].angleB / difference1;
                            double difference2 = arr[j].angleC - arr[i].angleC, c = arr[j].angleC / difference2, c1 = arr[i].angleC / difference2;
                            if ((a - (int)a < Double.Epsilon && a1 - (int)a1 < Double.Epsilon && b - (int)b < Double.Epsilon && b1 - (int)b1 < Double.Epsilon) || (b - (int)b < Double.Epsilon && b1 - (int)b1 < Double.Epsilon && c - (int)c < Double.Epsilon && c1 - (int)c1 < Double.Epsilon) || (a - (int)a < Double.Epsilon && a1 - (int)a1 < Double.Epsilon && c - (int)c < Double.Epsilon && c1 - (int)c1 < Double.Epsilon))
                            {
                                Console.Write($"{j + 1};");
                                count++;
                                continue;
                            }
                        }
                    }

                    if (count == 0)
                    {
                        Console.Write("Нет подобных");
                    }

                    Console.Write("\n");
                }
            }

            else
            {
                Console.WriteLine("Так как треугольник всего 1 подобных ему существовать не может");
            }

        }

        //функция поиска равнобедренного треугольника с максимальной площадью;
        public void beIsosceles(int size, Triangle[] arr)
        {
            int count = 0, count1 = 0;
            int max_area = 0;

            Console.WriteLine();

            for(int i = 0; i < arr.Length; i++)
            {
                if((arr[i].sideAB == arr[i].sideBC) || (arr[i].sideAB == arr[i].sideAC) || (arr[i].sideBC == arr[i].sideAC))
                {
                    if(count1 == 0)
                    {
                        max_area = i;
                        count1++;
                    }

                    if(arr[i].area > arr[max_area].area)
                    {
                        max_area = i;
                    }

                    count++;
                }

                if ((i == arr.Length - 1) && count > 0)
                {
                    Console.WriteLine($"Всего равнобедренных треугольников: {count}");
                    Console.WriteLine($"Найбольшая площадь у равнобедренного треугольника под номером {max_area + 1}: " + arr[max_area].area);
                    Console.WriteLine();
                }

                if ((i == arr.Length - 1) && (count == 0))
                {
                    Console.WriteLine("Равнобедренного треугольника среди данных не существует");
                    Console.WriteLine();
                }
            }

        }

        //функция вывода информации о треугольниках;
        public void Conclude(int size, Triangle[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Треугольник под номером {i + 1}");
                Console.WriteLine($"Сторона АB = {Math.Round(arr[i].sideAB, 3)}, BC = {Math.Round(arr[i].sideBC, 3)}, AC = {Math.Round(arr[i].sideAC, 3)}");
                Console.WriteLine($"Площадь = {Math.Round(arr[i].area, 3)}, Периметр = {Math.Round(arr[i].perimeter, 3)}");
                Console.WriteLine($"Угол А = {Math.Round(arr[i].angleA, 3)}, B = {Math.Round(arr[i].angleB, 3)}, C = {Math.Round(arr[i].angleC, 3)}");
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int size;

            Console.Write("Введите количество треугольников, данные которых вы хотите получить: ");

            size = Convert.ToInt32(Console.ReadLine());

            Triangle[] arr = new Triangle[size];

            Triangle number = new Triangle();

            number.Input(size, arr);

            number.Calculate(size, arr);

            number.Pertain(size, arr);

            number.beIsosceles(size, arr);

            number.Conclude(size, arr);

            Console.ReadLine();
        }
    }
}
