using System;

namespace Eratosthenes
{
    public class GeneratePrimes
    {
        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue >= 2)
            {
                int arraySize = maxValue + 1;
                bool[] workArray = new bool[arraySize];

                for (int i = 0; i < arraySize; i++)
                {
                    workArray[i] = true;
                }

                workArray[0] = workArray[1] = false; //exclude not prime numbers

                for (int j = 0; j < Math.Sqrt(arraySize) + 1; j++)
                {
                    if (workArray[j])
                    {
                        for (int i = 2*j; i < arraySize; i+=j)
                        {
                            workArray[i] = false;
                        }
                    }
                }

                int count = 0;
                for (int i = 0; i < arraySize; i++)
                {
                    if (workArray[i])
                    {
                        count++;
                    }
                }

                int[] result = new int[count];
                for (int j = 0, i = 0; j < arraySize; j++)
                {
                    if (workArray[j])
                    {
                        result[i++] = j;
                    }
                }

                return result;
            }

            return new int[0]; //maxValue < 2
        }
    }
}
