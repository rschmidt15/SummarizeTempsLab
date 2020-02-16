using System;
using System.IO;

namespace SummarizeTempsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //define wat is needed
            string filepath = "temps.txt";
            //first request: wright out file prompt
            Console.WriteLine("enter file name");
            //informe thime of there options
            Console.WriteLine("the only file on this document is     temps.txt     ");
            //Read file name
            filepath = Console.ReadLine();
                if (File.Exists(filepath))
            {
                Console.WriteLine("yes---file exists");
                //ask for the temperature threshold
                Console.WriteLine("enter temperature threshold");
                //define variables
                string input;
                int threshold;
                    input = Console.ReadLine();
                threshold = int.Parse(input);
                int test;
                //consloe wright line(test)
                //full descloser: i dont know what im doing here
                int sumTemps = 0;
                int numAbove = 0;
                int numBelow = 0;
                int tempCount = 0;
                //open the file and create stream reader
                //read a line int a string variable
                using (StreamReader sr=File.OpenText(filepath))
                     {
                    string line = sr.ReadLine();
                        int temp;
                    //while line is not null
                    while(line !=null)
                    {
                        //convert(parse)into an interger variable
                        temp = int.Parse(line);
                        //add temp to my summing variable
                        sumTemps += temp;
                        //increment temp count
                        tempCount += 1;
                        //if the current temperature is greater or equal to threshold
                        if(temp >= threshold)
                        {
                            //increment above counter by 1
                            numAbove += 1;

                        }
                        else
                        {
                            //increment below counter by 1
                            numBelow += 1;
                        }
                        line = sr.ReadLine();
                    }
                     }
                Console.WriteLine("temps below=" + numAbove);
                Console.WriteLine("temps below=" + numBelow);
                //calculate the average
                int average = sumTemps / tempCount;
                    //Print out the average
                    Console .WriteLine("average temperature=" + average);
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    //what do we want on the output document?
                    sw.WriteLine(System.DateTime.Now.ToString());
                    //dear roman, the sw is telling the system to put the data from the write line into the document output
                    sw.WriteLine("temperatures above=" + numAbove);
                    sw.WriteLine("temperatures below=" + numBelow);
                    sw.WriteLine("temperatures average=" + average);
                }

            }
            else
            {
                //else(file does dot exist)
                //inform user it does not exist
                Console.WriteLine("NO---File does not exist");
            }
        }
    }
}