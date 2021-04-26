using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTmatrix
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
        public static void Check_MultiplicationU_UT(double[][] Umat, double[][] Amatrix, int N) {

            double[][] tr = MatrixCreate(N);
            double[][] UUTmatrix = MatrixCreate(N);
            transpose(Umat, tr, N);
            double temp;
            bool b = true;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    temp = 0;
                    for (int k = 0; k < N; k++)
                    {
                        temp += tr[i][k] * Umat[k][j];
                    }

                    UUTmatrix[i][j] = temp;
                  
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("U^T * U\n");

            for (int i = 0; i < N; i++)
            {


                for (int j = 0; j < N; j++)
                {

                    Console.Write($"{UUTmatrix[i][j] } ");

                }
                Console.Write("\n");
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if(Math.Abs(UUTmatrix[i][j] - Amatrix[i][j])>Math.Pow(10,-10))
                  
                    {

                        b = false;
                        break;


                    }

                }
            }
                    if (b) {

                Console.WriteLine("\n --- Check U^T * U = A ---   Correct √ ");
            }
            else {

                Console.WriteLine("\n --- Check U^T * U = A ---   Incorrect X ");
            }

        }
        public static void Check_MultiplicationAX_B(double[] Xmat, double[][] Amatrix,double[] Bmatrix, int N)
        {
            double[] AXmatrix = new double[N];

            double temp;
            bool b = true;
            for (int i = 0; i < N; i++)
            {
                temp = 0;
                for (int j = 0; j < N; j++)
                {
                    
                   
                        temp += Amatrix[i][j] * Xmat[j];
                    

                   

                }
                AXmatrix[i] = temp;
            }
            for (int i = 0; i < N; i++)
            {
                
                    if (Math.Abs(AXmatrix[i] - Bmatrix[i]) > Math.Pow(10, -10))
                    {

                        b = false;
                        break;


                    }

                
            }
            if (b)
            {

                Console.WriteLine("\n --- Check A*X=B ---  Correct √ ");
            }
            else
            {

                Console.WriteLine("\n --- Check A*X=B ---  Incorrect X ");
            }

        }
        public static bool Determinant(double[][] matrix, int n) {
            double det = 1;
            int ind = 0;
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

                            ind++;


                        }
                    }

                    double r = 1;
                   


                    if (matrix[k][k] == 0 || double.IsInfinity(1.0 / matrix[k][k]))
                    {

                        throw new Exception("Nondegenerate matrix => Can not find the inverted matrix ");

                    }
                    else
                    { det *= matrix[k][k];
                        r = 1 / matrix[k][k];

                    }



                    for (int j = 0; j < n; j++)
                    {

                        matrix[k][j] = matrix[k][j] * r; //multiply each elem of k row

                    }

                    for (int i = k + 1; i < n; i++)
                    {

                        double res = matrix[i][k];

                        for (int z = 0; z < n; z++)
                        {
                            matrix[i][z] -= matrix[k][z] * res;


                        }
                    }



                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

            if (det*(Math.Pow(-1,ind)) <= 0) {

                return false;
            }
            return true;
        }
        public static void transpose(double[][] mat, double[][] tr, int N)
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    tr[i][j] = mat[j][i];
        }

      
        public static bool isSymmetric(double[][] mat, int N)
        {
            double[][] tr = MatrixCreate(N);
            transpose(mat, tr, N);
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (mat[i][j] != tr[i][j])
                        return false;
            return true;
        }

        public static void Main()
            {

            Console.Write("Enter dimension of matrix A:");
         
            int N = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n");
            double[][] Amatrix = MatrixCreate(N);
            double[][] AtmpMatrix = MatrixCreate(N);
            double[][] Umatrix = MatrixCreate(N);
            double[] BMatrix = new double[N];
            double[] YMatrix = new double[N];
            double[] XMatrix = new double[N];
            //double[][] UTmatrix = new double[N][];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {


                    Console.Write($"Enter A[{i},{j}] value:");
                    double tmp = Convert.ToDouble(Console.ReadLine());
                    Console.Write("\n");
                    Amatrix[i][j] =tmp;
                    AtmpMatrix[i][j]=tmp;
                }
            }
            for (int i = 0; i < N; i++)
            {
               


                    Console.Write($"Enter B[{i}] value:");
                    double tmp = Convert.ToDouble(Console.ReadLine());
                    Console.Write("\n");
                    BMatrix[i] = tmp;
                   
                
            }
            try {
                if (isSymmetric(AtmpMatrix, N))
                {
                    Console.WriteLine("\n--- MatriX A is symetric ---");
                    if (AtmpMatrix[0][0] <= 0)
                    {

                        throw new Exception("\n--- Main minors must be >0 !!! ---");

                    }
                    else
                    {
                        for (int i = 1; i < N; i++)
                        {

                            if (Determinant(AtmpMatrix, i + 1))
                            {
                                continue;

                            }
                            else
                            {

                                throw new Exception("\n--- Main minors must be >0 !!! ---");

                            }
                        }
                        //заповнюємо нулями під діагогналлю
                        Console.WriteLine("\n--- Main minors are >0 √ ---");
                        for (int i = 0; i < N; i++)
                        {
                            double sum = 0;
                            for (int k = 0; k <= i - 1; k++)
                            {

                                sum += Math.Pow(Umatrix[k][i], 2);
                            }
                            Umatrix[i][i] = Math.Sqrt(Amatrix[i][i] - sum);

                            for (int p = 0; p < N; p++)
                            {

                                if (i > p)
                                {

                                    Umatrix[i][p] = 0;

                                }
                            }
                            for (int j = i + 1; j < N; j++)
                            {
                                double Sum2 = 0;
                                for (int k = 0; k <= i - 1; k++)
                                {

                                    Sum2 += (Umatrix[k][i] * Umatrix[k][j]);
                                }

                                Umatrix[i][j] = ((Amatrix[i][j] - Sum2) / Umatrix[i][i]);
                            }

                        }


                    }
                    Console.WriteLine("UMatrix:\n");
                    for (int i = 0; i < N; i++) {


                        for (int j = 0; j < N; j++) {

                            Console.Write($"{Umatrix[i][j] } ");
                        
                        }
                        Console.Write("\n");
                    }

                    Check_MultiplicationU_UT(Umatrix, Amatrix, N);


                    for (int i = 0; i < N; i++)
                    {
                        double sum3 = 0;
                        for (int k = 0; k <= i - 1; k++)
                        {

                            sum3 += (Umatrix[k][i] * YMatrix[k]);
                        }
                        YMatrix[i] = (1.0 / Umatrix[i][i]) * (BMatrix[i] - sum3);
                    }
                    for (int i = (N - 1); i >= 0; i--)
                    {
                        double sum3 = 0;
                        for (int k = (i + 1); k <= (N - 1); k++)
                        {

                            sum3 += (Umatrix[i][k] * XMatrix[k]);
                        }
                        XMatrix[i] = (1.0 / Umatrix[i][i]) * (YMatrix[i] - sum3);
                    }
                    for (int i = 0; i < N; i++)
                    {
                        Console.Write($"\nX[{i}]: {XMatrix[i]} ");

                    }

                    Check_MultiplicationAX_B(XMatrix, Amatrix, BMatrix, N);
                    double det = 1;
                    for (int i = 0; i < N; i++)
                    {
                        det *= Math.Pow(Umatrix[i][i], 2);

                    }
                    Console.WriteLine($"Det of matrix A:{det}");
                }

                else
                {
                    throw new Exception("\n--- MatriX A is not symetric ---");

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
