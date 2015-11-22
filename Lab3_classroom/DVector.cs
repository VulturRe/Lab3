using System;

namespace Lab3_classroom
{
    unsafe class DVector
    {
        public double*[] _vec { get; set; }
        public int _size { get; }

        public DVector(int size, double[] vecs)
        {
            _size = size;
            _vec = new double*[size];

            fixed (double* p = &vecs[0])
            {
                var p1 = p;
                for (var i = 0; i != size; i++)
                {
                    _vec[i] = p1;
                    p1++;
                }
            }
        }

        public double this[int i]
        {
            get { return *_vec[i]; }
            set { *_vec[i] = value; }
        }
    }

    class TestDVector
    {
        unsafe static void Main()
        {
            var size = Convert.ToInt32(Console.ReadLine());
            var vecs = new double[size];
            for (var i = 0; i != size; i++)
                vecs[i] = Convert.ToDouble(Console.ReadLine());

            var vec = new DVector(size, vecs);

            for (var i = 0; i != size; i++)
                Console.WriteLine(vec[i]);

            Console.ReadLine();
        }
    }
}
