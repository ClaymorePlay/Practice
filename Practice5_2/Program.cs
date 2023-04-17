
using Practice5_2.Models;
using System.Collections;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

public class Program
{
    [DllImport("cpp_lib.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern double measure_time(int n, int repeats);

    [DllImport("cpp_lib.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern void Solve(Matrix A, double[] b, double[] x);

    static void Main(string[] args)
    {
        var matrix = new Matrix(3);
        Console.WriteLine(matrix.ToString());

        var result = matrix.Solve(new double[] {1, 5, 8, 9, 4, 5, 1, -5, 3});

    }
}

