using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAb4
{
    class Program
    {
        public struct Product
        {
            public string Name;
            public double Price;
            public int Quantity;
            public string Producer;
            public double Weight;
            public Currency Cost;
            public struct Currency
            {
                public string Name;
                public double ExRate;
                public Currency(string name, double exRate)
                {
                    Name = name;
                    ExRate = exRate;
                }
            }
            public static Product[] ent;
            public static void ReadProductsArray()
            {
                Array.Resize(ref ent, ent.Length + 1);
                ent[ent.Length - 1] = new Product();
                ent[ent.Length - 1].ReadInfo();
            }
            public Product(string name, double price, int quantity, string producer, double weight, Currency cost)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
                Producer = producer;
                Weight = weight;
                Cost = cost;
            }

            public void ReadInfo()
            {
                bool f = true;
                Console.WriteLine("Введите имя товара:");
                Name = Console.ReadLine();
                do
                {
                    Console.Write("Введите цену:");
                    f = true;
                    if (!double.TryParse(Console.ReadLine(), out Price))
                    {
                        Console.WriteLine("Error");
                        f = false;
                    }
                } while (f == false);
                do
                {
                    Console.Write("Введите количество товара:");
                    f = true;
                    if (!int.TryParse(Console.ReadLine(), out Quantity))
                    {
                        Console.WriteLine("Error");
                        f = false;
                    }
                } while (f == false);
                Console.WriteLine("Введите имя производителя:");
                Producer = Console.ReadLine();
                do
                {
                    Console.Write("Введите вес товара:");
                    f = true;
                    if (!double.TryParse(Console.ReadLine(), out Weight))
                    {
                        Console.WriteLine("Error");
                        f = false;
                    }
                } while (f == false);
                Console.Write("Введите вид валюты: ");
                Cost.Name = Console.ReadLine();
                Console.Write("Введите курс: ");
                Cost.ExRate = Convert.ToDouble(Console.ReadLine());
            }


            public double GetPriceInUAH()
            {
                return Price;
            }
            public double GetTotalPriceInUAH()
            {
                double totalSum = (double)Quantity * Price;
                return totalSum;
            }
            public double GetTotalWeight()
            {
                double totalWeight = (double)Quantity * Weight;
                return totalWeight;
            }
            public void PrintInfo()
            {
                Console.WriteLine("Имя: {0}", Name);
                Console.WriteLine("Прайс:     {0}", Price);
                Console.WriteLine("Количиство:      {0}", Quantity);
                Console.WriteLine("Виробник:      {0}", Producer);
                Console.WriteLine("Вага:      {0}", Weight);
                Console.WriteLine("Валюта:      {0}", Cost.Name + " : " + Cost.ExRate);
                Console.WriteLine("_______________________________________");
            }
            public string GetProductsInfoMax(params Product[] list)
            {
                double max = -1e7;
                int k = 0;
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i].Price > max)
                    {
                        max = list[i].Price;
                        k = i;
                    }
                }
                return list[k].Name;
            }
            public string GetProductsInfoMin(params Product[] list)
            {
                double min = 1e7;
                int k = 0;
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i].Price < min)
                    {
                        min = list[i].Price;
                        k = i;
                    }
                }
                return list[k].Name;
            }
            
            public static void PrintProducts()
            {
                if (ent.Length == 0)
                {
                    Console.WriteLine("Помилка!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = 0; i < ent.Length; i++)
                    {
                        ent[i].PrintInfo();
                    }
                }
            }
            public static double GetProductsInfo(Product[] ent, out double maxprice, out double minprice, out int ki, out int fi)
            {
                double n = 0;
                ki = 0;
                fi = 0;
                double k = 0, f = 0;
                maxprice = -1e7;
                minprice = 1e7;
                for (int i = 0; i < ent.Length; i++)
                {
                    k = ent[i].Price;
                    if (k > maxprice)
                    {
                        maxprice = k;
                        ki = i;
                    }
                }
                for (int j = 0; j < ent.Length; j++)
                {
                    f = ent[j].Price;
                    if (f < minprice)
                    {
                        minprice = f;
                        fi = j;
                    }
                }
                return n;
            }
            public static int SortProductsByPrice(Product a, Product b)
            {

                if (a.Price > b.Price)
                {
                    return 1;
                }
                if (a.Price < b.Price)
                {
                    return -1;
                }
                return 0;
            }
            public static int SortProductssByName(Product a, Product b)
            {
                if (a.Name.CompareTo(b.Name) > 0)
                {
                    return 1;
                }
                if (a.Name.CompareTo(b.Name) < 0)
                {
                    return -1;
                }
                if (a.Name == b.Name)
                {
                    return SortProductsByPrice(a, b);
                }
                return 0;
            }
        }


       

        static void Main(string[] args)
        {
            Console.Title = "Лабораторна робота №4";
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.SetWindowSize(100, 30);
            bool t = true;
            int choose;
            do
            {
                do
                {
                    Console.Clear();
                    t = true;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Меню:");
                    Console.ResetColor();
                    Console.Write("1.Додати запис\n2.Вивести дані\n3.Самый дорогой продукт\n4.Самый дешёвый продукт\n5.Самая меньшая и самая большая цена\n6.Сортировка по возростанию цены\n7.Сортировка по названию\n0.Выход\nВыберите раздел:");
                    if (!int.TryParse(Console.ReadLine(), out choose))
                    {
                        Console.WriteLine("Помилка!");
                        t = false;
                    }
                    if (choose > 7)
                    {
                        Console.WriteLine("Помилка!");
                    }
                } while (t == false || choose > 7);
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        Product.ReadProductsArray();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Product.PrintProducts();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        if (Product.ent.Length == 0)
                        {
                            Console.WriteLine("Помилка!");
                        }
                        else
                        {
                            for (int i = 0; i < Product.ent.Length; i++)
                            {
                                Console.WriteLine("{0} = {1}", Product.ent[i].Name, Product.ent[i].GetProductsInfoMax());
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        if (Product.ent.Length == 0)
                        {
                            Console.WriteLine("Помилка!");
                        }
                        else
                        {
                            for (int i = 0; i < Product.ent.Length; i++)
                            {
                                Console.WriteLine("{0} = {1}", Product.ent[i].Name, Product.ent[i].GetProductsInfoMin());
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        if (Product.ent.Length == 0)
                        {
                            Console.WriteLine("Помилка!");
                        }
                        else
                        {
                            double n;
                            int fi, ki;
                            double maxprice, minprice;
                            n = Product.GetProductsInfo(Product.ent, out maxprice, out minprice, out ki, out fi);
                            Console.WriteLine("Наибольшая цена\n{0} = {1}\nНаименшая цена\n{2} = {3}", Product.ent[ki].Name, maxprice, Product.ent[fi].Name, minprice);
                        }
                        Console.ReadKey();
                        break;
                    case 6:
                        if (Product.ent.Length == 0)
                        {
                            Console.WriteLine("Помилка!");
                        }
                        else if (Product.ent.Length == 1)
                        {
                            Console.WriteLine("Помилка!");
                        }
                        else
                        {
                            Array.Sort(Product.ent, Product.SortProductsByPrice);
                            Product.PrintProducts();
                        }
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        if (Product.ent.Length == 0)
                        {
                            Console.WriteLine("Помилка!");
                        }
                        else if (Product.ent.Length == 1)
                        {
                            Console.WriteLine("Помилка!");
                        }
                        else
                        {
                            Array.Sort(Product.ent, Product.SortProductssByName);
                        }
                        Console.ReadKey();
                        break;
                    case 0: break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            } while (choose != 0);
        }
    }
}
