using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightRun
{
    class Program
    {
        public static bool Check(double[] A, double[] B, double[] C, double[] F, int n) {

            for (int i = 1; i < n - 1; i++)
            {

                if ((Math.Abs(C[0]) > Math.Abs(B[0])) || (Math.Abs(C[n - 1]) > Math.Abs(A[n - 2])) || (Math.Abs(C[i]) > Math.Abs(B[i]) + Math.Abs(A[i]))){


                    return true;
                }

            }
          
          
            for (int i = 0; i < n; i++) {

                if (!(Math.Abs(C[i]) >0)) {

                   
                    return false;
             
                }


            }
            for (int i = 0; i < n - 1; i++) {
                if (!(Math.Abs(A[i]) >= 0))
                {


                    return false;

                }

            }
            for (int i = 0; i < n - 1; i++)
            {
                if (!(Math.Abs(B[i]) >= 0))
                {


                    return false;

                }

            }


            if (!(Math.Abs(C[0]) >= Math.Abs(B[0]))) {

                return false;
            }
            if ( !(Math.Abs(C[n - 1]) >= Math.Abs(A[n - 2])))
            {

                return false;
            }

            for (int i = 1; i < n-1; i++)
            {

                if (!(Math.Abs(C[i]) >= Math.Abs(B[i]) + Math.Abs(A[i])) )
                {


                    return false;

                }


            }
            return true;

        }

        public static double[] Algorithm(double[] A, double[] B, double[] C, double[] F,int n) {
            int tmp = n - 1;
            double[] a = new double[tmp];
            double[] b = new double[tmp];
            double[] y = new double[n];
            a[0]= -(B[0] / C[0]);
            b[0] = F[0] / C[0];
           
            for (int i = 0; i <(n-2); i++) {
     

                a[i+1] = -((B[i+1]) / (C[i+1] + A[i] * a[i]));
                b[i+1] = ((F[i+1] - A[i] * b[i]) / (C[i+1] + A[i] * a[i]));
            
            
            }
            y[n - 1] = ((F[n - 1] - A[n - 2] * b[tmp-1]) / (C[n - 1] + A[n - 2] * a[tmp-1]));
            for (int i = n - 2; i >= 0; i--) {

                y[i] = a[i] * y[i + 1] + b[i];
            }

            Console.WriteLine("\n- - - - - --\nRight run method Dy=b:\n- - - - - - - \n");
            Console.Write("y=(");
            for (int i = 0; i < n; i++) {

                Console.Write($"{y[i]} ");
            }
            Console.Write(")");
            return y;
        }

        public static void Input( double[] A, double[] B, double[] C, double[] F,int n) {


            A[n - 2] = 0;
            B[0] = 0;
            for (int i = 0; i < n - 2; i++) {

                A[i] = 1;
            
            }
            for (int i = 1; i < n - 1; i++)
            {

                B[i] = 1;

            }
            C[0] = 1;
            C[n - 1] = 1;
            F[0] = 1;
            F[n - 1] = 3;

            double h = 1.0 / (n-1);
            for (int i = 1; i < n-1; i++)
            {

                C[i] = -2 - (1 + i * h) * Math.Pow(h,2);

            }
            for (int i = 1; i < n - 1; i++) {

                F[i] = Math.Pow(h,2)*(4 - (1 + i * h) * (2 * Math.Pow(i, 2) * Math.Pow(h, 2) + 1));
            
            }

            Print(A, B, C, F, n);
        }

        static void Print(double[] A, double[] B, double[] C, double[] F, int n) {

            Console.WriteLine("\n\nB vector: ");
            for (int i = 0; i < n - 1; i++)
            {

                Console.Write($"{B[i] } ");

            }
            Console.WriteLine("\n\nA vector:");
            for (int i = 0; i < n - 1; i++)
            {

                Console.Write($"{A[i] } ");

            }
            Console.WriteLine("\n\nC vector:");
            for (int i = 0; i < n; i++)
            {

                Console.Write($"{C[i] } ");

            }
            Console.WriteLine("\n\nF vector:");
            for (int i = 0; i < n; i++)
            {

                Console.Write($"{F[i] } ");

            }




        }
        public static void Norma(int n, double[] y) {
            double h=1.0/ (n-1);
            double[] ys = new double[n];
            for (int i = 0; i < n; i++) {
                ys[i] = 2 * Math.Pow(i, 2) * Math.Pow(h, 2) + 1;
            
            }
            double[] new_y = new double[n];
            for (int i = 0; i < n; i++)
            {
                new_y[i] =Math.Abs(y[i] - ys[i]);
            }

            Console.WriteLine($"\n\nNorma ||y-y*|| ={new_y.Max()}");
            
        }
        static double[][] MatrixCreate(int n)
        {


            double[][] result = new double[n][];
            for (int i = 0; i < n; i++)
                result[i] = new double[n];
            return result;
        }

        public static void Check_MultiplicationDY_F(double[]y, double[] F, int N, double[] C, double[] A, double[] B)
        { int indA = -1;
            int indB = -1;
            double[] ResMatrix = new double[N];
            double[][] Dmatrix = MatrixCreate(N);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {

                    if (i == j)
                    {

                        Dmatrix[i][j] = C[i];
                        
                    }
                    if ((i - j) == 1)
                    {


                        Dmatrix[i][j] = A[++indA];

                    }
                    if ((j - i) == 1)
                    {


                        Dmatrix[i][j] = B[++indB];

                    }

                }


            }

         
            double temp = 0;
          
            for (int i = 0; i < N; i++)
            {
                temp = 0;
                for (int j = 0; j < N; j++)
                {


                    temp += Dmatrix[i][j] * y[j];




                }
                ResMatrix[i] = temp;
            }
            Console.WriteLine("\n- - - - - --\nSimilar Multiplication Dy = F:\n- - - - - - - \n");
            Console.Write("D*y=(");
            for (int i = 0; i < N; i++)
            {

                Console.Write($"{ResMatrix[i]} ");
            }
            Console.Write(")");

            Console.Write("\nF=(");
            for (int i = 0; i < N; i++)
            {

                Console.Write($"{F[i]} ");
            }
            Console.Write(")");
        }
   
            static void Main(string[] args)
        {

            Console.Write("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());


            //double[] C = new double[n];
            //double[] B = new double[n - 1];
            //double[] A = new double[n - 1];
            //double[] F = new double[n];
            //Input(A, B, C, F, n);






            double[] B = new double[] { 1, -1, 3 };
            double[] C = new double[] { 2, 3, -1, -1 };
            double[] A = new double[] { 2, 1, 1 };
            double[] F = new double[] { 4, 9, 12, -4 };



            if (Check(A, B, C, F, n))
            {

                Console.WriteLine("\n\nStabillity is correct +\n");
            
               
                double[] y = Algorithm(A, B, C, F, n);
              Check_MultiplicationDY_F(y, F, n, C, A, B);
                Norma(n, y);

            }
            else {

                Console.WriteLine("\n\nStabillity is incorrect -\n");

            }
            
            Console.ReadKey();
        }
    }
}
