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
            return new Complex(c1.Real * c2.Real - c1.Imaginary * c2.Imaginary, c1.Real * c2.Imaginary + c1.Imaginary * c2.Real);
        }

        public static Complex operator /(Complex c1, Complex c2)
        {
            return new Complex((c1.Real * c2.Real + c1.Imaginary * c2.Imaginary)/(Math.Pow(c2.Real, 2) + Math.Pow(c2.Imaginary, 2)), (c2.Real * c1.Imaginary - c1.Real * c2.Imaginary)/(Math.Pow(c2.Real, 2) + Math.Pow(c2.Imaginary, 2)));
        }

        public static Complex operator ++(Complex c)
        {
            return new Complex(c.Real + 1, c.Imaginary + 1);
        }

        public override string ToString()
        {
            return ($"{Real} + {Imaginary}i");
        }
    }
}