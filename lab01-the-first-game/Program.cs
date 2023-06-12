using System.Diagnostics.CodeAnalysis;

namespace lab01_the_first_game
{
    internal class Program
    {
        static void Main(string[] args)
        {  //Calls StartSequence Method 
            try
            { StartSequence(); }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("The progarm completed!");
            }

        }
        static void StartSequence()
        { // Calls the other Methods, Contains information to be displayed to the user and contain the Exceptions 
            try { 
            Console.WriteLine("Wellcome To The Numbers Game");
            Console.WriteLine("Enter a number greater than zero");
            int arraySize = Convert.ToInt32(Console.ReadLine());
            if (arraySize < 1) {
                throw new Exception("arraySize less than one");
            }
            int[] array = new int[arraySize];
            Populate(array);
            int sum = GetSum(array);
            int product = GetProduct(array, sum);
            decimal quotient = GetQuotient(product);

                Console.WriteLine($"Your Array size is : {arraySize}");
                Console.Write("The numbers in the array are ");
                for (int i = 0; i < arraySize; i++)
                {
                    if (i == arraySize - 1)
                    {
                        Console.WriteLine($"{array[i]}");
                        continue;
                    }
                    Console.Write($"{array[i]},");
                }
                Console.WriteLine($"The sum of the array is {sum}");
                Console.WriteLine($"{sum} * {product / sum} = {product}");
                Console.WriteLine($"{product} / {quotient} = {product / quotient}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        static int[] Populate(int[] array)
        {//Make the user choose the numbers to start
            for ( int i = 0; i < array.Length; i++ )
            {
                Console.WriteLine($"Please enter number {i+1} : {array.Length}");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            return array;
        }
        static int GetSum(int[] array)
        {// sum of all elements in array
            int sum = 0;
            for(int i=0 ; i < array.Length;i++ )
            {
                sum += array[i];
            }
            if ( sum < 20)
            {
                throw new Exception($"The vlaue of {sum} is too low");
            }
            return sum;
        }
        static int GetProduct(int[] array ,int sum)
        {// Take user input and find the matching index in array
            Console.WriteLine($"Select a random number from 1 - {array.Length}");
            int product = Convert.ToInt32(Console.ReadLine());
            if ( product < 1 || product > array.Length) {
                throw new Exception("Out of range");
            }
            product = array[product -1];
            product *= sum;
            return product;
        }
        static decimal GetQuotient(int product )
        { // Divides product by user input
            Console.WriteLine($"Please enter a number to divide your  product {product} by ");
            decimal quotient = Convert.ToInt32(Console.ReadLine());
            if(quotient == 0 )
            {
                throw new Exception("Can't divide by zero");
            }
            return quotient;
        
        }
    }
}