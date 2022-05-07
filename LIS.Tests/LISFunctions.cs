using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIS.Tests
{
    public class LISFunctions
    {
        /// <summary>
        /// Returns a list of numbers from a given string
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static IList<int> CovertStringToListOfNumbers(string inputString)
        {
            try
            {
                var resultList = new List<int>();
                var stringList = inputString.Split(' ').ToList();
                stringList.ForEach(element => resultList.Add(int.Parse(element)));

                return resultList;
            }
            catch (Exception)
            {
                throw new Exception($"Method : CovertStringToListOfNumbers; Failed to process the provided input : {inputString}, please check your input and try again.");
            }
        }

        /// <summary>
        /// Returns the first of many calculated longest sequences from a list of numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static string GetFirstLongestIncreasingSubsequence(string inputString)
        {
            if (string.IsNullOrEmpty(inputString)) throw new ArgumentException("Parameter not supplied");

            var numbers = CovertStringToListOfNumbers(inputString);
            var tempSequence = new List<int>();
            var resultSequence = new List<int>();

            try
            {
                for (var index = 0; index < numbers.Count; index++)
                {
                    if (index != numbers.Count - 1 && numbers[index + 1] > numbers[index])
                    {
                        TraverseSequence(numbers, tempSequence, index);
                    }
                    else
                    {
                        ProcessResultSequence(tempSequence, resultSequence);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception($"Method : GetFirstLongestIncreasingSubsequence; Failed to Get First Longest Increasing Subsequence");
            }

            var resultString = BuildResultString(resultSequence);

            return resultString;
        }

        private static string BuildResultString(List<int> resultSequence)
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in resultSequence)
            {
                stringBuilder.Append(item);
                stringBuilder.Append(' ');
            }

            return stringBuilder.ToString().TrimStart().TrimEnd();
        }

        private static void ProcessResultSequence(List<int> tempSequence, List<int> resultSequence)
        {
            if (resultSequence.Count() < tempSequence.Count())
            {
                resultSequence.Clear();
                resultSequence.AddRange(tempSequence);
            }
            tempSequence.Clear();
        }

        private static void TraverseSequence(IList<int> numbers, List<int> tempSequence, int index)
        {
            //Prepare sub sequence list
            if (tempSequence.Count == 0)
            {
                tempSequence.Add(numbers[index]);
            }
            tempSequence.Add(numbers[index + 1]);
        }
    }
}
