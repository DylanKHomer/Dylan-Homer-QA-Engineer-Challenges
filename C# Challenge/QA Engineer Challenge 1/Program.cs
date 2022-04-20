using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QA_Engineer_Challenge_1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string[] text;
            text = System.IO.File.ReadAllLines(@"..\..\..\src\1.txt");
            Console.Write("1: File: 1.txt, ");
            RepititionCounter(text);

            text = System.IO.File.ReadAllLines(@"..\..\..\src\2.txt");
            Console.Write("2: File: 2.txt, ");
            RepititionCounter(text);

            text = System.IO.File.ReadAllLines(@"..\..\..\src\3.txt");
            Console.Write("3: File: 3.txt, ");
            RepititionCounter(text);

            text = System.IO.File.ReadAllLines(@"..\..\..\src\4.txt");
            Console.Write("4: File: 4.txt, ");
            RepititionCounter(text);

            text = System.IO.File.ReadAllLines(@"..\..\..\src\5.txt");
            Console.Write("5: File: 5.txt, ");
            RepititionCounter(text);
            Console.ReadLine();
        }

        static void RepititionCounter(string[] text)
        {
            // Get number of elements in array, as array.count is part of linq
            int count = 0;
            foreach (string number in text)
            {
                count++;
            }
            // Store the value in text
            int?[] trackerInt = new int?[count];
            // Store the number of times a value is repeated
            int?[] trackerCount = new int?[count];
            // Store the most repeated number and the number of times it is repeated
            int mostRepeatedValue, timesRepeated;
            // For every integer in text...
                // Check if current integer exists in trackerInt
                    // If it does, add increment value of the same index in trackerCount
                    // Else add current integer to end of  trackerInt; set same index in trackerCount to 1
            foreach(string number in text)
            {
                // Convert number to int
                int.TryParse(number, out int currentNumber);
                // Check if current integer exists in trackerInt
                for(int i = 0; i < count; i++)
                {
                    // Check if current index is same number
                    if (trackerInt[i] == currentNumber)
                    {
                        // If it is, increment trackerCount
                        trackerCount[i]++;
                        break;
                    }
                    // Check if current index has a number - if not, add current number to this index
                    else if (trackerInt[i] == null)
                    {
                        trackerInt[i] = currentNumber;
                        trackerCount[i] = 1;
                        break;
                    }
                }
            }
            Array.Sort(trackerCount, trackerInt);

            // Updated most repeated value and the number of times it is repeated
            mostRepeatedValue = trackerInt[trackerInt.Length - 1].Value;
            timesRepeated = trackerCount[trackerCount.Length - 1].Value;

            // Check if another value was repeated the same number of times
            for(int i = 0; i < trackerCount.Length; i++)
            {
                // Only evaluate indexes that aren't null
                if(trackerCount[i] != null)
                {
                    if(trackerCount[i] == timesRepeated && trackerInt[i] != mostRepeatedValue)
                    {
                        if(trackerInt[i] < mostRepeatedValue)
                        {
                            mostRepeatedValue = trackerInt[i].Value;
                        }
                    }
                }
            }

            Console.WriteLine("Number: " + mostRepeatedValue + ", Repeated: " + timesRepeated + " times.");

            return;
        }

    }
}
