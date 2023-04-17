using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5_2.Models
{
    class Matrix
    {
        private double[] data; // массив, в котором хранится информация о матрице
        private int order; // порядок матрицы

        // конструктор, создающий матрицу по умолчанию
        public Matrix(int n)
        {
            order = n;
            data = new double[order];
            for (int i = 0; i < order; i++)
            {
                // на главной диагонали элементы равны 1, в остальных - -0.5
                if (i == 0) data[i] = 1;
                else data[i] = -0.5;
            }
        }

        // конструктор, создающий матрицу по заданному массиву
        public Matrix(double[] arr)
        {
            if (arr.Length < 1) throw new ArgumentException("Массив не может быть пустым");
            if (Math.Sqrt(arr.Length) % 1 != 0) throw new ArgumentException("Количество элементов массива некорректно");

            order = (int)Math.Sqrt(arr.Length);
            data = arr;
        }

        // метод решения системы линейных уравнений AX = B
        public double[] Solve(double[] b)
        {
            if (b.Length != order) throw new ArgumentException("Размеры матрицы и вектора-столбца не совпадают");

            // преобразование вектор-столбца в вектор-строку
            double[] xT = b;
            // преобразование матрицы в поэлементный массив
            double[] c = new double[data.Length];
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    c[i * order + j] = data[(i - j + order) % order];
                }
            }

            // создание зеркальной копии массива c
            double[] r = new double[c.Length];
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    r[i * order + j] = c[((order - i) % order) * order + ((order - j) % order)];
                }
            }

            // умножение матрицы T на вектор-строку xT
            double[] y1 = new double[order];
            for (int k = 0; k < order; k++)
            {
                double sum = 0;
                for (int j = 0; j < order; j++)
                {
                    sum += c[k * order + j] * xT[j];
                }
                y1[k] = sum;
            }

            // умножение матрицы R на вектор-строку y1
            double[] y2 = new double[order];
            for (int k = 0; k < order; k++)
            {
                double sum = 0;
                for (int j = 0; j < order; j++)
                {
                    sum += r[k * order + j] * y1[j];
                }
                y2[k] = sum;
            }

            // преобразование вектор-строки y2 в вектор-столбец
            double[] x = y2;

            return x;
        }

        // перегруженная версия метода ToString()
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    str += String.Format("{0:0.00}", data[(i - j + order) % order]) + " ";
                }
                str += "\n";
            }
            return str;
        }
    }
}
