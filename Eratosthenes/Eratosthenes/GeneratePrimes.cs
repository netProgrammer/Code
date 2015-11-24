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
            for (var j = 0; j < CalcMaxPrimeFactor(); j++)
            {
                if (_workArray[j]){
                    CrossOutputMultiplesOf(j);
                }
            }
        }

        private static void CrossOutputMultiplesOf(int j)
        {
            for (var i = 2 * j; i < _workArray.Length; i += j)
            {
                _workArray[i] = false;
            }
        }

        private static int CalcMaxPrimeFactor()
        {
            return (int) (Math.Sqrt(_workArray.Length) + 1);
        }

        private static void InitArray(int maxValue)
        {
            _workArray = new bool[maxValue + 1];
            for (var i = 2; i < _workArray.Length; i++)
            {
                _workArray[i] = true;
            }
        }
    }
}