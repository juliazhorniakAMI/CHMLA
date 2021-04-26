using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeydel_Iter
{
    class Program
    {
        static double[][] Input(int size) {

           
            double[][] matrix = new double[size][];
           
            for (int i = 0; i < size; i++)
            {
                matrix[i] = new double[size + 1];

                for (int j = 0; j < size + 1; j++)
                {
                    if (j != size)
                    {
                        Console.Write($"Enter A[{i}][{j}]: ");
                        double x = Convert.ToInt32(Console.ReadLine());
                        matrix[i][j] = x;

                    }
                    else {
                        Console.Write($"Enter b[{i}]: ");
                        double x = Convert.ToDouble(Console.ReadLine());
                        matrix[i][j] = x;

                    }
                   

                }
            }
            return matrix;

        }

        static bool Check(ref double[][]matrix,int size)
        {
            bool b = true;
           

            for (int i = 0; i < size; i++)
            {
                double sum = 0;

                for (int j = 0; j < size; j++)
                {
                    if (i != j) {

                        sum +=  Math.Abs(matrix[i][j]);
                    }

                }
                if (Math.Abs(matrix[i][i]) > sum)
                {

                    continue;
                }
                else {
                    b = false;
                    int tmpind = i;
                    int n;

                    for (int j = 0; j < size; j++)
                    {
                      
                        double sum2 = 0;
                        double[] tmp = new double[size];
                        tmp = matrix[i];
                        matrix[i] = matrix[j];
                        matrix[j] = tmp;
                        n = j;

                        for (int k = 0; k < size; k++)
                        {
                           
                            if (k != j)
                            {

                                sum2 += Math.Abs(matrix[i][k]);
                            }
                          
                        }
                        i = n;
                        if (Math.Abs(matrix[i][i]) > sum2 )
                        {
                            b = true;
                            i = tmpind;
                            break;
                        }
                        else {
                           
                            continue;
                        
                        }
                       
                    }
                    if (b == false)
                    {

                        break;
                    }

                }
            }
            return b;
        }
        static void AlgoZeydel(int size,double[][]matrix) {




            //double eps = Math.Pow(10, -3);
            double eps = 0.0001;


            double[] previousVariableValues = new double[size];
            previousVariableValues[0] = 1.125;
            previousVariableValues[1] = 0.8;
            previousVariableValues[2] = 3.6;
            previousVariableValues[3] = 4.1;

            //for (int i = 0; i < size; i++) {
            //    previousVariableValues[i] = 0;


            //}


            int k = 0;
            double[] currentVariableValues;
         
            while (true)
            {
                k++;
              currentVariableValues = new double[size];
              
                for (int i = 0; i < size; i++)
                {
                    
                    currentVariableValues[i] = matrix[i][size];

                 
                    for (int j = 0; j < size; j++)
                    {
                        
                        if (j < i)
                        {
                            currentVariableValues[i] -= matrix[i][j] * currentVariableValues[j];
                        }

                       
                        if (j > i)
                        {
                            currentVariableValues[i] -= matrix[i][j] * previousVariableValues[j];
                        }
                    }

                   
                    currentVariableValues[i] /= matrix[i][i];
                }

                
                double error = 0.0;

                for (int i = 0; i < size; i++)
                {
                    error +=Math.Abs(currentVariableValues[i] - previousVariableValues[i]);
                }
                

               
                if (error < eps ||k==3)
                {
                    break;
                }

            
                previousVariableValues = currentVariableValues;
                for (int i = 0; i < size; i++)
                {
                 Console.Write($"{previousVariableValues[i]} ");


                }
            }


            Console.Write($"\n\nx^({k}):");
            for (int i = 0; i < size; i++)
            {
                Console.Write($" {currentVariableValues[i]}");
              
            }

            double temp = 0;
            double[] Axmatrix = new double[size];
            double[] newmatrix = new double[size];
            Console.Write($"\n||A*x^{k}-b|| = ");

            for (int i = 0; i < size; i++)
            {
                temp = 0;
                for (int j = 0; j < size; j++)
                {


                    temp += matrix[i][j] * currentVariableValues[j];




                }
                Axmatrix[i] = temp;
                newmatrix[i] = Math.Abs(Axmatrix[i] - matrix[i][size]);
                Console.Write($" {newmatrix[i]}");
            }
        }
    
            static void Main(string[] args)
        {


            Console.WriteLine("Enter size of A matrix: ");
            int size = Convert.ToInt32(Console.ReadLine());
            double[][] matrix = Input(size);
            if (Check(ref matrix, size))
            {

                Console.WriteLine("Matrix A is Diagonally Dominant");
                AlgoZeydel(size, matrix);

            }
            else
            {

                Console.WriteLine("Matrix A is not Diagonally Dominant :(");


            }
            Console.ReadLine();
        }
    }
}
