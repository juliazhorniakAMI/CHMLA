using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvertMatrix
{
    class Program
    {
       
        static double[][] MatrixCreate(int n)
        {


            double[][] result = new double[n][];
            for (int i = 0; i < n; i++)
                result[i] = new double[n];
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter number of rows/cols:");
            int n = Convert.ToInt32(Console.ReadLine());

            double[][] matrix = MatrixCreate(n);
           



            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {


                    Console.Write($"Enter[{i}][{j}] value:");
                    double tmp = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n");
                    matrix[i][j] = tmp;
                }
            }

            double[][] Ematrix = MatrixCreate(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    if (i == j)
                    {
                        Ematrix[i][j] = 1;


                    }
                    else
                    {

                        Ematrix[i][j] = 0;
                    }
                }
            }
          
            try
            {
                for (int k = 0; k < n; k++)
                {
                    double max = matrix[k][k];
                    for (int j = k + 1; j < n; j++)
                    {
                        if (Math.Abs(matrix[j][k]) > Math.Abs(max))
                        {

                            max = matrix[j][k];

                            double[] tmp = matrix[j];
                            matrix[j] = matrix[k];
                            matrix[k] = tmp;

                            double[] tmp2 = Ematrix[j];
                            Ematrix[j] = Ematrix[k];
                            Ematrix[k] = tmp2;
                           

                        }
                    }
                 
                    double r = 1;


                    if (matrix[k][k] == 0 || double.IsInfinity(1.0 / matrix[k][k]))
                    {

                        throw new Exception("Nondegenerate matrix => Can not find the inverted matrix ");

                    }
                    else
                    {
                        r = 1 / matrix[k][k];

                    }



                    for (int j = 0; j < n; j++)
                    {

                        matrix[k][j] = matrix[k][j] * r; //multiply each elem of k row
                        Ematrix[k][j] = Ematrix[k][j] * r;
                    }

                    for (int i = k + 1; i < n; i++)
                    {

                        double res = matrix[i][k];

                        for (int z = 0; z < n; z++)
                        {
                            matrix[i][z] -= matrix[k][z] * res;
                            Ematrix[i][z] -= Ematrix[k][z] * res;

                        }
                    }



                }


                for (int k = n - 1; k >= 0; k--)
                {

                    for (int i = k - 1; i >= 0; i--)
                    {

                        double res = matrix[i][k];
                        for (int z = n - 1; z >= 0; z--)
                        {
                            matrix[i][z] -= matrix[k][z] * res;
                            Ematrix[i][z] -= Ematrix[k][z] * res;


                        }
                    }

                }
                Console.WriteLine("\n Inverted matrix: ");

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write($"{Math.Round(Ematrix[i][j], 2)}\t");
                    }
                    Console.WriteLine("\n");
                }

                Console.WriteLine("\n\nA*A^(-1):");

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write($"{Math.Round(matrix[i][j], 1)}\t");
                    }
                    Console.WriteLine("\n");
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }







            Console.ReadKey();
        }

       
    }
}



