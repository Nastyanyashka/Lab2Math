using System;

namespace MathLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            float[,] matrixA ={
                { 3f, 5f, 1f,12f},
                { 1.799999f, 3f, 7f,13.599998f},
                { 8f,1f,1f,18f}};
            
            
            SolutionWithChooseOfMainElement(matrixA);
           
        }
        public static float[,] TriangleView( float[,] matrix)
        {
            float koef = 0;
            for (int g = 0; g < matrix.GetLength(0) - 1; g++)
            {
                for (int i = 1 + g; i < matrix.GetLength(0); i++)
                {
                    koef = matrix[i, g] / -matrix[g, g];
                    for (int j = g; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = matrix[i, j] + matrix[g, j] * koef;
                    }
                }
            }
            return matrix;
        }
        public static void PrintMatrix(float[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void SolutionWithoutChooseOfMainElement(float[,] matrix)
        {
            matrix = TriangleView(matrix);
            PrintMatrix(matrix);
            float[] allX = new float[matrix.GetLength(1)];
            float B = 0f;
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                B = matrix[i, matrix.GetLength(1) - 1];
                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    B -= matrix[i, j] * allX[j];
                }
                allX[i] = B / matrix[i, i];
            }
            Console.WriteLine();
            foreach (float i in allX)
            {
                Console.Write($" {i}");
            }
        }
        public static void SolutionWithChooseOfMainElement(float[,] matrix)
        {
            float maxNum =0f;
            int indexi = 0;
           for(int i = 0;i<matrix.GetLength(0);i++)
            {
                if (matrix[i, 0] > maxNum)
                {
                    maxNum = matrix[i, 0];
                    indexi= i;
                }
            }

           float[] temp = new float[matrix.GetLength(1)];
           for(int i = 0;i<matrix.GetLength(1);i++)
            {
                temp[i] = matrix[0, i];
                matrix[0, i] = matrix[indexi, i];
                matrix[indexi,i] = temp[i];
            }
            PrintMatrix(matrix);
            Console.WriteLine();
            SolutionWithoutChooseOfMainElement(matrix);
        }
    }
}


