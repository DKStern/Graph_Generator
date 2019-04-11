using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphGenerator
{
    class Program
    {
        static int N;
        static int m; //Кол рёбер
        static double d, Pmin, Pmax; //Шаг
        static double[,] Matrix;
        static List<Edge> list = new List<Edge>();

        static void Read()
        {   
            while(true)
            {
                Console.Write("Введите размерность матрицы: ");
                N = Convert.ToInt32(Console.ReadLine());
                if (N >= 2 && N <= 5000)
                    break;
                else
                    Console.WriteLine("Введено неверное значение, введите значение в диапозоне от 2 до 10000");
            }

            while (true)
            {
                Console.Write("Введите минимальную длину ребера матрицы: ");
                Pmin = Convert.ToInt32(Console.ReadLine());
                if (Pmin > 0 && N < 10000)
                    break;
                else
                    Console.WriteLine("Введено неверное значение, введите значение в интервале (0,100000)");
            }

            while (true)
            {
                Console.Write("Введите максимальную длину ребера матрицы: ");
                Pmax = Convert.ToInt32(Console.ReadLine());
                if (Pmax >= Pmin)
                    break;
                else
                    Console.WriteLine(string.Format("Введено неверное значение, введите значение большее или равное {0}", Pmin));
            }
        }

        static void Find()
        {
            m = N * (N - 1) / 2;
            d = (Pmax - Pmin) / (m - 1);
        }

        static void MakeList()
        {
            for (int i=1; i<=N;i++)
                for (int j=1; j<i;j++)
                {
                    var edge = new Edge(j, i);
                    list.Add(edge);
                }
        }

        static void MakeMatrix()
        {
            Random rnd = new Random();
            list = list.OrderBy(x => rnd.Next()).ToList();
            for (int i=0;i<m;i++)
            {
                var edge = list[i];
                Matrix[edge.First-1, edge.Second-1] = Pmin;
                Matrix[edge.Second - 1, edge.First - 1] = Pmin;
                Pmin += d;
            }
        }

        static void Write()
        {
            using (StreamWriter sw = new StreamWriter("Output.txt"))
            {
                sw.WriteLine(N);
                for (int i=0;i<N;i++)
                {
                    var str = "";
                    for (int j = 0; j < N; j++)
                    {
                        if (j != N - 1)
                            str += Matrix[i, j].ToString("0.000") + ' ';
                        else
                            str += Matrix[i, j].ToString("0.000");
                    }
                    str = str.Replace(',', '.');
                    sw.WriteLine(str);
                }
            }
        }

        static void Main(string[] args)
        {
            Read();
            Matrix = new double[N,N];
            Find();
            MakeList();
            MakeMatrix();
            Write();
        }
    }
}
