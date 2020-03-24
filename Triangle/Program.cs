using System;

namespace Triangle
{
    class triangle
    {
        //необходимые данные;
        public double pointXA, pointYA, pointXB, pointYB;
        public double pointXC, pointYC;
        public double sideAB, sideBC, sideAC;

        public double area, perimeter, half_perimeter;
        public double angleA, angleB, angleC;
        public int count = 0;

        public void Measurements(int size, triangle[] arr)
        {
            //находим периметр, площадь и углы;
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
                arr[i].angleA = Math.Abs(arr[i].angleA);

                arr[i].angleB = (arr[i].sideAB * arr[i].sideAB + arr[i].sideBC * arr[i].sideBC - arr[i].sideAC * arr[i].sideAC) / (2 * arr[i].sideAB * arr[i].sideBC) * 180 / Math.PI;
                arr[i].angleB = Math.Abs(arr[i].angleB);

                arr[i].angleC = 180 - (arr[i].angleA + arr[i].angleB);
            }

            Console.WriteLine();

            Similarity(size, arr);
        }
        
        public void Similarity(int size, triangle[] arr)
        {
            if (size > 1)
            {
                int count2 = 0;
                Console.Write("Подобными треугольниками являются: ");

                //находим подобные треугольники;
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 1; j < arr.Length; j++)
                    {

                        //проверка по трем сторонам;
                        if (arr[i].sideAB > arr[j].sideAB && arr[i].sideBC > arr[j].sideBC && arr[i].sideAC > arr[j].sideAC && i != j)
                        {
                            double difference = arr[i].sideAB - arr[j].sideAB, a = arr[i].sideAB / difference, a1 = arr[j].sideAB / difference;
                            double difference1 = arr[i].sideBC - arr[j].sideBC, b = arr[i].sideBC / difference1, b1 = arr[j].sideBC / difference1;
                            double difference2 = arr[i].sideAC - arr[j].sideAC, c = arr[i].sideAC / difference2, c1 = arr[j].sideAC / difference2;
                            if (a == (int)a && a1 == (int)a1 && b == (int)b && b1 == (int)b1 && c == (int)c && c1 == (int)c1)
                            {
                                Console.Write($"{i} и {j} ; ");
                                count2++;
                            }
                        }

                        if (arr[i].sideAB < arr[j].sideAB && arr[i].sideBC < arr[j].sideBC && arr[i].sideAC < arr[j].sideAC && i != j)
                        {
                            double difference = arr[j].sideAB - arr[i].sideAB, a = arr[i].sideAB / difference, a1 = arr[j].sideAB / difference;
                            double difference1 = arr[j].sideBC - arr[i].sideBC, b = arr[i].sideBC / difference1, b1 = arr[j].sideBC / difference1;
                            double difference2 = arr[j].sideAC - arr[i].sideAC, c = arr[i].sideAC / difference2, c1 = arr[j].sideAC / difference2;
                            if (a == (int)a && a1 == (int)a1 && b == (int)b && b1 == (int)b1 && c == (int)c && c1 == (int)c1)
                            {
                                Console.Write($"{i} и {j} ; ");
                                count2++;
                            }
                        }

                        //по 2 углам;
                        if((arr[i].angleA > arr[j].angleA && arr[i].angleB > arr[j].angleB) || (arr[i].angleB > arr[j].angleB && arr[i].angleC > arr[j].angleC) || (arr[i].angleA > arr[j].angleA && arr[i].angleC > arr[j].angleC))
                        {
                            double difference = arr[i].angleA - arr[j].angleA, a = arr[i].angleA/difference, a1 = arr[j].angleA/difference;
                            double difference1 = arr[i].angleB - arr[j].angleB, b = arr[i].angleB / difference1, b1 = arr[j].angleB / difference1;
                            double difference2 = arr[i].angleC - arr[j].angleC, c = arr[i].angleC / difference2, c1 = arr[j].angleC / difference2;
                            if((a == (int)a && a1 ==(int)a1 && b == (int)b && b1 == (int)b1) || (b == (int)b && b1 == (int)b1 && c == (int)c && c1 == (int)c1) || (a == (int)a && a1 == (int)a1 && c == (int)c && c1 == (int)c1))
                            {
                                Console.Write($"{i} и {j} ; ");
                                count2++;
                            }
                        }

                        if ((arr[i].angleA < arr[j].angleA && arr[i].angleB < arr[j].angleB) || (arr[i].angleB < arr[j].angleB && arr[i].angleC < arr[j].angleC) || (arr[i].angleA < arr[j].angleA && arr[i].angleC < arr[j].angleC))
                        {
                            double difference = arr[j].angleA - arr[i].angleA, a = arr[j].angleA / difference, a1 = arr[i].angleA / difference;
                            double difference1 = arr[j].angleB - arr[i].angleB, b = arr[j].angleB / difference1, b1 = arr[i].angleB / difference1;
                            double difference2 = arr[j].angleC - arr[i].angleC, c = arr[j].angleC / difference2, c1 = arr[i].angleC / difference2;
                            if ((a == (int)a && a1 == (int)a1 && b == (int)b && b1 == (int)b1) || (b == (int)b && b1 == (int)b1 && c == (int)c && c1 == (int)c1) || (a == (int)a && a1 == (int)a1 && c == (int)c && c1 == (int)c1))
                            {
                                Console.Write($"{i} и {j} ; ");
                                count2++;
                            }
                        }

                        if (count2 == 0 && i == arr.Length - 1 && j == arr.Length - 1)
                        {
                            Console.Write("нет подобных треугольников");
                        }
                    }
                }
            }

            else
            {
                Console.WriteLine("Так как треугольник всего 1 подобных ему существовать не может");
            }

            Console.WriteLine();

            Output(size, arr);
        }

        public void Output(int size, triangle[] arr)
        {
            Console.WriteLine();

            for(int i = 0; i < arr.Length; i++)
            {
                int max_area = 0;

                //находим равнобедренный треугольние с максимальной площадью;
                if((arr[i].sideAB == arr[i].sideBC) || (arr[i].sideAB == arr[i].sideAC) || (arr[i].sideBC == arr[i].sideAC))
                {
                    if(arr[i].area > arr[max_area].area)
                    {
                        max_area = i;
                    }

                    count++;
                }

                if ((i == arr.Length - 1) && (count > 0))
                {
                    Console.WriteLine($"Всего равнобедренных треугольников: {count}");
                    Console.WriteLine($"Найбольшая площадь у равнобедренного треугольника под номером {max_area + 1}: " + arr[max_area].area);
                    Console.WriteLine();
                }

                if ((i == size - 1) && (count == 0))
                {
                    Console.WriteLine("Равнобедренного треугольника среди данных не существует");
                    Console.WriteLine();
                }
            }

            //вывод информации о треугольниках;
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Треугольник под номером {i + 1}");
                Console.WriteLine($"Сторона АB = {arr[i].sideAB}, BC = {arr[i].sideBC}, AC = {arr[i].sideAC}");
                Console.WriteLine($"Площадь = {arr[i].area}, Периметр = {arr[i].perimeter}");
                Console.WriteLine($"Угол А = {arr[i].angleA}, B = {arr[i].angleB}, C = {arr[i].angleC}");
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int size;

            Console.Write("Введите количество треугольников, данные которых вы хотите ввести: ");

            size = Convert.ToInt32(Console.ReadLine());

            triangle[] arr = new triangle[size];

            triangle number = new triangle();

            int count1;

            for (int i = 0; i < arr.Length; i++)
            {
                do
                {
                    count1 = 0;

                    arr[i] = new triangle();

                    //вводим координаты точек;
                    Console.WriteLine();
                    Console.Write($"Введите координату X {i + 1} треугольника для угла А: ");
                    arr[i].pointXA = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine();
                    Console.Write($"Введите координату Y {i + 1} треугольника для угла А: ");
                    arr[i].pointYA = Convert.ToDouble(Console.ReadLine());

                    //циклы для проверки ввода координат - координаты точек не могут совпадать
                    do {
                        Console.WriteLine();
                        Console.Write($"Введите координату X {i + 1} треугольника для угла B: ");
                        arr[i].pointXB = Convert.ToDouble(Console.ReadLine());
                    } while (arr[i].pointXB == arr[i].pointXA);

                    do {
                        Console.WriteLine();
                        Console.Write($"Введите координату Y {i + 1} треугольника для угла B: ");
                        arr[i].pointYB = Convert.ToDouble(Console.ReadLine());
                    } while (arr[i].pointYB == arr[i].pointYA);

                    do
                    {
                        do
                        {
                            Console.WriteLine();
                            Console.Write($"Введите координату X {i + 1} треугольника для угла C: ");
                            arr[i].pointXC = Convert.ToDouble(Console.ReadLine());
                        } while (arr[i].pointXC == arr[i].pointXA);
                    } while (arr[i].pointXC == arr[i].pointXB);

                    do {
                        do {
                            Console.WriteLine();
                            Console.Write($"Введите координату Y {i + 1} треугольника для угла C: ");
                            arr[i].pointYC = Convert.ToDouble(Console.ReadLine());
                        } while (arr[i].pointYC == arr[i].pointYA);
                    } while (arr[i].pointYC == arr[i].pointYB);

                    //находим длины сторон по углам;
                    double A = arr[i].pointXB - arr[i].pointXA;
                    double B = arr[i].pointYB - arr[i].pointYA;
                    double B1 = arr[i].pointXC - arr[i].pointXB;
                    double C = arr[i].pointYC - arr[i].pointYB;
                    double A1 = arr[i].pointXC - arr[i].pointXA;
                    double C1 = arr[i].pointYC - arr[i].pointYA;

                    arr[i].sideAB = Math.Sqrt(A * A + B * B);
                    arr[i].sideAB = Math.Abs(arr[i].sideAB);
                    arr[i].sideBC = Math.Sqrt(B1 * B1 + C * C);
                    arr[i].sideBC = Math.Abs(arr[i].sideBC);
                    arr[i].sideAC = Math.Sqrt(A1 * A1 + C1 * C1);
                    arr[i].sideAC = Math.Abs(arr[i].sideAC);

                    //проверяем условия существования треугольника;
                    //сумма двух меньших сторон должна быть больше чем большая сторона;
                    if ((arr[i].sideAB > arr[i].sideBC) && (arr[i].sideAB > arr[i].sideAC) && (arr[i].sideBC + arr[i].sideAC > arr[i].sideAB))
                    {
                        count1++;
                    }

                    if ((arr[i].sideBC > arr[i].sideAB) && (arr[i].sideBC > arr[i].sideAC) && (arr[i].sideAB + arr[i].sideAC > arr[i].sideBC))
                    {
                        count1++;
                    }

                    if ((arr[i].sideAC > arr[i].sideAB) && (arr[i].sideAC > arr[i].sideBC) && (arr[i].sideAB + arr[i].sideBC > arr[i].sideAC))
                    {
                        count1++;
                    }

                    //если условие выполняется - треугольник либо равнобедренный, либо равносторонний;
                    //для этого требуется равенство двух сторон либо всех трех;
                    if ((arr[i].sideAB == arr[i].sideBC) || (arr[i].sideBC == arr[i].sideAC) || (arr[i].sideAB == arr[i].sideAC) || ((arr[i].sideAB == arr[i].sideBC) && (arr[i].sideAB == arr[i].sideAC)))
                    {
                        count1++;
                    }

                    if (count1 == 0)
                    {
                        Console.WriteLine($"Треугольника с длинной сторон {arr[i].sideAB} , {arr[i].sideBC} , {arr[i].sideAC} не может существовать");
                    }

                } while (count1 == 0);
            }

            number.Measurements(size, arr);
                
            Console.ReadLine();
        }
    }
}
