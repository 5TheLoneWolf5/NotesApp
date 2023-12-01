using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("--- Notes App ---");
            Console.WriteLine("\nType the file name to open or create one: ");

            File file = new File(Console.ReadLine());
            file.CreateOrOpenFile();
            file.CloseFile(); // Starting at 0. If user wants to only read file, for example.

            int userInput = 0;

            while(userInput != 3)
            {
                Console.WriteLine("\n1 - Type a note (type EXIT to leave)\n2 - Read notes\n3 - Leave\n");
                userInput = int.Parse(Console.ReadLine());
                Console.WriteLine();
                
                switch (userInput)
                {
                    case 1:

                        if(!file.Open)
                        {
                            file.CreateOrOpenFile();
                        }

                        string userInput2 = "";
                        int currentLine = 0;

                        do
                        {
                            currentLine++;
                            Console.WriteLine($"Note {currentLine}: ");
                            userInput2 = Console.ReadLine();
                            if (!userInput2.Trim().ToUpper().Equals("EXIT"))
                                file.RecordMessage(userInput2);
                        } while(!userInput2.Trim().ToUpper().Equals("EXIT"));

                        file.CloseFile();
                        break;
                    case 2:
                        file.ReadFile();
                        break;
                    case 3:
                        Console.WriteLine("Exiting program.");
                        break;
                    default:
                        Console.WriteLine("Command not identified.");
                        break;
                }
            }

        }
    }
}
