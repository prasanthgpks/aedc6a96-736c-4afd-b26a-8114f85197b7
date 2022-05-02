using System;
using System.Collections.Generic;
using System.Linq;

namespace LIS.Core
{
    public class LISFunctions
    {
        /// <summary>
        /// Returns a list of numbers from a given string
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static IList<int> CovertStringToListOfNumbers(string inputString)
        {
            try
            {
                if (string.IsNullOrEmpty(inputString)) throw new ArgumentException("Parameter not supplied");

                var resultList = new List<int>();
                var stringList = inputString.Split(' ').ToList();
                stringList.ForEach(element => resultList.Add(int.Parse(element)));

                return resultList;
            }
            catch (Exception)
            {
                throw new Exception($"Failed to process the provided input : {inputString}, please check your input and try again");
            }
        }

        /// <summary>
        /// Returns the first of many calculated longest sequences from a list of numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static IList<int> GetFirstLongestIncreasingSubsequence(IList<int> numbers)
        {
            List<int> tempSequence = new List<int>();
            List<int> resultSequence = new List<int>();

            for (var index = 0; index < numbers.Count; index++)
            {
                //traverse the sequence until last element to find the longest sub-sequence
                if (index != numbers.Count - 1 && numbers[index + 1] > numbers[index])
                {
                    //Prepare sub sequence list
                    if (tempSequence.Count == 0)
                    {
                        tempSequence.Add(numbers[index]);
                    }
                    tempSequence.Add(numbers[index + 1]);
                }
                else
                {
                    //New prepared sequence is having greater count than existing count
                    if (resultSequence.Count() < tempSequence.Count())
                    {
                        resultSequence.Clear();
                        resultSequence.AddRange(tempSequence);
                    }
                    tempSequence.Clear();
                }
            }
            return resultSequence;    //return the highest sub sequence list
        }
    }
}
