using System;
using System.Linq;

namespace Eratosthenes
{
    public class GeneratePrimes
    {
        private static bool[] _workArray;
        private static int[] _result;

        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
            {
                return new int[0];
            }

            InitArray(maxValue);
            Sieve();
            LoadPrimes();
            return _result;
        }

        private static void LoadPrimes()
        {
            _result = new int[_workArray.Count(t => t)];

            for (int j = 0, i = 0; j < _workArray.Length; j++)
            {
                if (_workArray[j])
                {
                    _result[i++] = j;
                }
            }
        }

        private static void Sieve()
        {
            for (var j = 0; j < Math.Sqrt(_workArray.Length) + 1; j++)
            {
                if (_workArray[j])
                {
                    for (var i = 2*j; i < _workArray.Length; i += j)
                    {
                        _workArray[i] = false;
                    }
                }
            }
        }

        private static void InitArray(int maxValue)
        {
            _workArray = new bool[maxValue + 1];
            _workArray[0] = _workArray[1] = false; //exclude not prime numbers
            for (var i = 2; i < _workArray.Length; i++)
            {
                _workArray[i] = true;
            }
        }
    }
}