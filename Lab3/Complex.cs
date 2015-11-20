using System;

namespace Lab3
{
    public struct Complex
    {
        public double Real;
        public double Imaginary;

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c1.Imaginary);
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.Real * c2.Real - c1.Imaginary * c2.Imaginary,
                c1.Real * c2.Imaginary + c1.Imaginary * c2.Real);
        }

        public static Complex operator /(Complex c1, Complex c2)
        {
            return new Complex((c1.Real * c2.Real + c1.Imaginary * c2.Imaginary)/(Math.Pow(c2.Real, 2) + Math.Pow(c2.Imaginary, 2)),
                (c2.Real * c1.Imaginary - c1.Real * c2.Imaginary)/(Math.Pow(c2.Real, 2) + Math.Pow(c2.Imaginary, 2)));
        }

        public static Complex operator ++(Complex c)
        {
            return new Complex(c.Real + 1, c.Imaginary + 1);
        }

        public double Argument()
        {
            return Math.Atan(Imaginary/Real);
        }

        public double Module()
        {
            return Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));
        }

        public Complex Root(double basee)
        {
            return new Complex(Math.Pow(Module(), 1/basee)*Math.Cos(Argument()/basee), 
                Math.Pow(Module(), 1/basee)*Math.Sin(Argument()/basee));
        }

        // Перегрузка метода ToString() для вывода комплексного числа
        // в традиционном формате
        public override string ToString() => ($"{Math.Round(Real, 3)} + {Math.Round(Imaginary, 3)}i");
    }

    class TestComplex
    {
        static void Main()
        {
            Console.WriteLine("Введите 1 комплексное число (сначала действительную, затем мнимую части).");
            var a = new Complex(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine("Введите 2 комплексное число");
            var b = new Complex(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine("Введите 3 комплексное число");
            var c = new Complex(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine("Введите 4 комплексное число");
            var d = new Complex(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
            Console.Clear();
            var r = a.Root(3) - (b + c)/a + b*d;
            Console.WriteLine("R = {0}", r);
            Console.WriteLine("Модуль числа R = {0}", r.Module());
            Console.WriteLine("Число R с увеличенными действительным и мнимой частями на 1 = {0}", ++r);
            Console.ReadLine();
        }
    }
}