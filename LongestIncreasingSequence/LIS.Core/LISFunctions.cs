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
                throw new ArgumentException($"Failed to process the provided input : {inputString}, please check your input and try again");
            }
        }
    }
}
