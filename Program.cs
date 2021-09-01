using System;
using System.IO;
using System.Linq;

namespace Mod1
{
    class Program
    {
        static void Main(string[] args)
        {
        
        string choice;
        string repeat;
        string file = "tickets.csv";

            do
            {
                    // ask user a question
                    Console.WriteLine("1) Read data from file.");
                    Console.WriteLine("2) Create file from data.");
                    Console.WriteLine("Enter any other key to exit.");
                    // input response
                    choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        if (File.Exists(file))
                        {
                   
                            // read data from file                       
                            string[] lines = System.IO.File.ReadAllLines(file);
                            lines = lines.Skip(1).ToArray();

                            foreach (string line in lines)
                            {
                                var cols = line.Split(';');
                                System.Console.WriteLine(line);
                            }
                        }
                        else
                        {
                            Console.WriteLine("File does not exist");
                        }
                    }
                    else if (choice == "2")
                    {
                        // create file from data
                        StreamWriter sw = new StreamWriter(file);
                        sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");

                        do{

                            // prompt for questions
                            Console.WriteLine("TicketID");
                            string ticketID = Console.ReadLine();

                            Console.WriteLine("Summary");
                            string summary = Console.ReadLine();

                            Console.WriteLine("Status");
                            string status = Console.ReadLine();

                            Console.WriteLine("Priority");
                            string priority = Console.ReadLine().ToUpper();

                            Console.WriteLine("Submitter");
                            string submitter = Console.ReadLine();

                            Console.WriteLine("Assigned");
                            string assigned = Console.ReadLine();

                            sw.Write("{0},{1},{2},{3},{4},{5},", ticketID, summary, status, priority, submitter, assigned);

                        sw.Close();
                                for (int i = 0; i < 5; i++)
                        {
                            sw = File.AppendText(file);
                            Console.WriteLine("Would you like to add someone to the watching list? (Y/N)?");
                            string watchingLoop = Console.ReadLine().ToUpper();
                            if (watchingLoop != "Y") 
                            { 
                                sw.WriteLine("");
                                break; }

                            Console.WriteLine("Enter the name.");
                            string name = Console.ReadLine();
                            sw.Write("{0}|", name);
                            sw.Close();
                        }
                            sw.Close();

                            System.Console.WriteLine("Would you like to enter another ticket? (Y/N)");
                            repeat = Console.ReadLine().ToUpper();
                            if (repeat == "Y") 
                            { 
                                sw = File.AppendText(file);
                             }
                            
                    } while (repeat == "Y");
                } 
            } while (choice == "1" || choice == "2");
        }
    }
}
