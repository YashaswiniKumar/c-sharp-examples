
using System;

namespace complex-num-example
{

    class ComplexNumber
    {
        //Variable declaration
        double real, imaginary, absoluteValue, phaseValue;

        public double GetAbsoluteValue
        {
            get { return absoluteValue; }
        }
        public double GetPhaseValue
        {
            get { return phaseValue; }
        }
       
        ComplexNumber(double _real, double _imaginary)
        {
            real = _real; imaginary = _imaginary;
        }

        //Polar Coordinates
        public static (double,double) GetPolarCoordinates(ComplexNumber comp1){

            //return the absolute value(r) and theta
            return (System.Math.Sqrt(comp1.real * comp1.real + comp1.imaginary * comp1.imaginary), System.Math.Atan2(comp1.imaginary,comp1.real));
        }

        // Override the ToString method
        public override string ToString()
        {
            return this.real +" + "+this.imaginary+"i";
        }

        //Complex Number Multiplication
        public static ComplexNumber operator*(ComplexNumber comp1, ComplexNumber comp2)
        {
            //result array
            ComplexNumber result = new ComplexNumber(0,0);

            //The formula for complex number multiplication is implemented here
            result.real = (comp1.real * comp2.real) - (comp1.imaginary * comp2.imaginary);
            result.imaginary = (comp1.imaginary * comp2.real) + (comp1.real * comp2.imaginary);
            return result;
        }

        //Complex Number Addition
        public static ComplexNumber operator+(ComplexNumber Comp1, ComplexNumber Comp2)
        {
            //result array
            ComplexNumber result = new ComplexNumber(0, 0);

            //The formula for complex number Addition is implemented here
            result.real = Comp1.real + Comp2.real;
            result.imaginary = Comp1.imaginary + Comp2.imaginary;
            return result;
        }

        //Complex Number subtraction
        public static ComplexNumber operator-(ComplexNumber Comp1, ComplexNumber Comp2)
        {
            //result array
            ComplexNumber result = new ComplexNumber(0, 0);

            //The formula for complex number Subtraction is implemented here
            result.real = Comp1.real - Comp2.real;
            result.imaginary = Comp1.imaginary - Comp2.imaginary;
            return result;
        }

        //Complex Number Matrix Multiplication
        static ComplexNumber[,] MatrixMultiplication(ComplexNumber[,] m1, ComplexNumber[,] m2)
        {

            //result array
            ComplexNumber[,] result = new ComplexNumber[2, 2];

            //To fetch the length of 2d array
            double m = m1.GetLength(0);
            double n = m1.GetLength(1);
            double p = m1.GetLength(1);

            //result array initialization
            for (int i = 0; i < m; i++)
                for (int j = 0; j < p; j++)
                    result[i, j] = new ComplexNumber(0, 0);

            //Multiplication and addition of two-dimension matrices
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    ComplexNumber MultiplicationComplex = new ComplexNumber(0, 0);
                    ComplexNumber AdditionComplex = new ComplexNumber(0, 0);

                    //matrix multiplication
                    for (int k = 0; k < n; k++)
                    {
                        MultiplicationComplex = m1[i, k] * m2[k, j];
                        AdditionComplex = AdditionComplex + MultiplicationComplex;
                        result[i, j] = AdditionComplex;
                    }
                }
            }
            return result;
        }

        
        static void Main(string[] args)
        {
            
            //Return the Polaroid co-ordinates of complex number and print the values on Console
            ComplexNumber c = new ComplexNumber(0,0); 
            double AbsoluteValue = c.GetAbsoluteValue;
            double PhaseValue = c.GetPhaseValue;
            (AbsoluteValue,PhaseValue) = GetPolarCoordinates(new ComplexNumber(5,2));
            Console.WriteLine("The polar co-ordinates are "+AbsoluteValue+", "+PhaseValue+"\n");

            //Overriding the ToString Method
            ComplexNumber ComplexNum = new ComplexNumber(0,-3);
            String ComplexNumIntoString = ComplexNum.ToString();
            Console.WriteLine("Printing the ComplexNumber object using overrided ToString method "+ComplexNumIntoString + "\n");

            //Complex 2D Matrix Number 1 
            ComplexNumber[,] matrix1 = new ComplexNumber[2, 2]{
                { new ComplexNumber(1,1), new ComplexNumber(2,0) },
                { new ComplexNumber(0,0), new ComplexNumber(2,5) }};

            //Complex 2D Matrix Number 2 
            ComplexNumber[,] matrix2 = new ComplexNumber[2, 2]{
                { new ComplexNumber(5,-5), new ComplexNumber(0,-2) },
                { new ComplexNumber(0, 4.2), new ComplexNumber(-11.1,0) } };

            //Complex 2D Matrix Result  
            ComplexNumber[,] result = new ComplexNumber[2, 2]{
                { new ComplexNumber(0,0), new ComplexNumber(0, 0) },
                { new ComplexNumber(0, 0), new ComplexNumber(0,0) } };

            //Checking if matrix can be multiplied or not using if-else
            if (matrix1.Length == matrix2.Length)
            {
                // Calculating the complex number matrix multiplication 
                result = MatrixMultiplication(matrix1, matrix2);

                Console.WriteLine("The Complex Number Matrix Multiplication result is");    
                //printing the final result matrix 
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        Console.Write($"{result[i, j].real} + {result[i, j].imaginary}i\t");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("The matrix multiplication is not possible due to unmatching matrix dimensions" +
                                  " : column of matrix 1 not equal to row of matrix 2");
            };
            
        }
    }
}
