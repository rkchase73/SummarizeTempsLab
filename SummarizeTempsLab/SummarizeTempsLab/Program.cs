using System;
using System.IO;

namespace SummarizeTempsLab
{
    class Program
    {
        static void Main(string[] args)
        {
                string fileName;
                Console.WriteLine("***File Data Summary***");
                Console.WriteLine("Enter File Name");
                fileName = Console.ReadLine();
        
                if (File.Exists(fileName))
                {
                    
                        
                        Console.WriteLine("File Exists!");
                bool choice = true;
                while (choice)
                {
                    Console.WriteLine("Enter Threshold");

                    string input;
                    int threshold;
                    input = Console.ReadLine();
                    threshold = int.Parse(input);

                    int sumTemps = 0;
                    int numAbove = 0;
                    int numBelow = 0;
                    int tempCount = 0;

                    using (StreamReader sr = File.OpenText(fileName))
                    {
                        string line = sr.ReadLine();
                        int temp;
                        while (line != null)
                        {
                            temp = int.Parse(line);
                            sumTemps += temp;
                            if (temp >= threshold)
                            {
                                numAbove += 1;
                            }
                            else
                            {
                                numBelow += 1;
                            }
                            line = sr.ReadLine();
                        }
                    }
                    Console.WriteLine("Temperatures above =" + numAbove);
                    Console.WriteLine("Temperatures below =" + numBelow);
                    tempCount = numAbove + numBelow;
                    int average = sumTemps / tempCount;
                    Console.WriteLine("Average temp =" + average);
                    Console.WriteLine("Do you want to continue and pick another threshold? Type yes or no.");
                    string repeat = Console.ReadLine();
                    if (repeat == "yes")
                    {
                        choice = true;
                    }
                    else
                    {
                        choice = false;
                    }
                }
            }
                        
                else
                {
                    Console.WriteLine("File does not exist");
                }
            Console.WriteLine("Summarizing of Temps has ended");
        }
    }
}
