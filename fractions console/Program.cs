using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace fractions_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                double result;
                double a;
                double b;
                double a1, b1, a2, b2, NOD1, NOD2, NOD3;



                try
                {
                    // Ввод первой дроби
                    Console.WriteLine("Введите первое число первой дроби");
                    a1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите второе число первой дроби");
                    b1 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine($"Дробь: {a1}/{b1}");

                    // Ввод второй дроби
                    Console.WriteLine("Введите первое число первой дроби");
                    a2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите второе число первой дроби");
                    b2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"Дробь: {a2}/{b2}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите корректные значения");
                    return;
                }

                if (b1 == 0 || b2 == 0)
                {
                    Console.WriteLine("Деление на 0 невозможно");
                    return;
                }

                // Вычисление НОД
                NODcalculate(a1, b1, out NOD1);
                Console.WriteLine($"НОД первой дроби:{NOD1}");
                NODcalculate(a2, b2, out NOD2);
                Console.WriteLine($"НОД второй дроби:{NOD2}");

                // Сокращение дробей
                sokr(ref a1, ref b1, NOD1);
                sokr(ref a2, ref b2, NOD2);


                // Сумма дробейж
                sum(a1, b1, a2, b2, out a, out b);
                NODcalculate(a, b, out NOD3);
                sokr(ref a, ref b, NOD3);
                Console.WriteLine($"Сумма дробей: {a}/{b}");

                // Разность дробей
                minus(a1, b1, a2, b2, out a, out b);
                Console.WriteLine($"Разность дробей: {a}/{b}");

                // Разность дробей
                mul(a1, b1, a2, b2, out a, out b);
                NODcalculate(a, b, out NOD3);
                sokr(ref a, ref b, NOD3);
                Console.WriteLine($"Произведение дробей: {a}/{b}");

                // Разность дробей
                div(a1, b1, a2, b2, out a, out b);
                NODcalculate(a, b, out NOD3);
                sokr(ref a, ref b, NOD3);
                Console.WriteLine($"Деление дробей: {a}/{b}");

                Console.WriteLine("Повторить программу? Да(1), Нет(Любое значение)");
                int end = Convert.ToInt32(Console.ReadLine());
                if (end != 1)
                {
                    break;
                }

            }
            
        }

        static void sokr(ref double a, ref double b, double NOD)
        {
            a /= NOD;
            b /= NOD;
        }
        static void NODcalculate(double a, double b, out double result)
        {
            while (a != b)
            {
                if (a > b) 
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            result = a;
        }

        static void sum(double a1, double b1, double a2, double b2, out double a, out double b)
        {
            a = a1 * b2 + a2 * b1;
            b = b1 * b2;
        }

        static void minus(double a1, double b1, double a2, double b2, out double a, out double b)
        {
            a = a1 * b2 + -a2 * b1;
            b = b1 * b2;
        }

        static void mul(double a1, double b1, double a2, double b2, out double a, out double b)
        {
            a = a1 * a2;
            b = b1 * b2;
        }

        static void div(double a1, double b1, double a2, double b2, out double a, out double b)
        {
            a = a1 * b2;
            b = b1 * a2;
        }
    }
}
