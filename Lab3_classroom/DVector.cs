using System;

namespace Lab3_classroom
{
    unsafe class DVector
    {
        public double*[] Vec;
        public int Size { get; }

        public DVector(int size, double[] vecs)
        {
            Size = size;
            Vec = new double*[size];

            fixed (double* p = &vecs[0])
            {
                var p1 = p;
                for (var i = 0; i != size; i++)
                {
                    Vec[i] = p1;
                    p1++;
                }
            }
        }

        public double this[int i]
        {
            get { return *Vec[i]; }
            set { *Vec[i] = value; }
        }

        public static DVector operator *(double c1, DVector c2)
        {
            var num = new double[c2.Size];
            for (var i = 0; i != c2.Size; i++)
                num[i] = c2[i]*c1;
            return new DVector(c2.Size, num);
        }

        public static DVector operator *(DVector c1, double c2)
        {
            var num = new double[c1.Size];
            for (var i = 0; i != c1.Size; i++)
                num[i] = c1[i]*c2;
            return new DVector(c1.Size, num);
        }

        public static DVector operator +(DVector c1, DVector c2)
        {
            var maxVec = c1.Size <= c2.Size;
            var maxSize = maxVec ? c2.Size : c1.Size;
            var minSize = maxVec ? c1.Size : c2.Size;
            var nums = new double[maxSize];
            for (var i = 0; i != minSize; i++)
                nums[i] = c1[i] + c2[i];
            if (!maxVec)
                for (var i = minSize; i != maxSize; i++)
                    nums[i] = c1[i];
            else
                for (var i = minSize; i != maxSize; i++)
                    nums[i] = c2[i];

            return new DVector(maxSize, nums);
        }

        public override string ToString()
        {
            var str = "";
            for (var i = 0; i != Size; i++)
            {
                str += Convert.ToString(*Vec[i]);
                if (i == Size - 1) continue;
                str += " ";
            }
            return ($"{str}");
        }
    }

    class TestDVector
    {
        static void Main()
        {
            Console.WriteLine("Введите элементы первого вектора.");
            var nums1 = Console.ReadLine().Split(' ');
            var size1 = nums1.Length;
            var vecs1 = new double[size1];
            for (var i = 0; i != size1; i++)
                vecs1[i] = Convert.ToDouble(nums1[i]);
            // Создание первого вектора
            var vec1 = new DVector(size1, vecs1);

            Console.WriteLine("\nВведите элементы второго вектора.");
            var nums2 = Console.ReadLine().Split(' ');
            var size2 = nums2.Length;
            var vecs2 = new double[size2];
            for (var i = 0; i != size2; i++)
                vecs2[i] = Convert.ToDouble(nums2[i]);
            // Создание второго вектора
            var vec2 = new DVector(size2, vecs2);
            
            Console.WriteLine("\nВведите число х.");
            var x = Convert.ToDouble(Console.ReadLine());
            var Y = x*vec1 + 2*vec2;
            var Z = vec1[1]*vec2 + vec2[1]*vec1;

            Console.WriteLine("\nY = {0}", Y);
            Console.WriteLine("Z = {0}", Z);

            Console.ReadLine();
        }
    }
}
