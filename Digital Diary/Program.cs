using System;

namespace Digital_Diary
{
    class Program
    {
        static void Main()
        {
            Diary diary = new Diary();
            int choice;

            do
            {
                Console.WriteLine("\nDigital Diary Menu:");
                Console.WriteLine("1. Write a New Entry");
                Console.WriteLine("2. View All Entries");
                Console.WriteLine("3. Search Entry by Date (YYYY-MM-DD)");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter your diary entry: ");
                        string text = Console.ReadLine();
                        diary.WriteEntry(text);
                        break;

                    case 2:
                        diary.ViewAllEntries();
                        break;

                    case 3:
                        Console.Write("Enter the date to search (YYYY-MM-DD): ");
                        string date = Console.ReadLine();
                        diary.SearchByDate(date);
                        break;

                    case 4:
                        Console.WriteLine("Exiting Digital Diary. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        diary.Pause();
                        break;
                }
            } while (choice != 4);
        }
    }
}