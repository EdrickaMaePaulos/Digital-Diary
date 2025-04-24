using System;
using System.IO;

namespace Digital_Diary
{
    public class Diary
    {
        private readonly string filePath;

        public Diary()
        {
            filePath = "diary.txt";

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        public void WriteEntry(string text)
        {
            string entry = $"[{DateTime.Now.ToString("yyyy-MM-dd")}] [{DateTime.Now.ToString("HH:mm:ss")}]: {text}";            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(entry);
            }

            Console.WriteLine("Entry saved successfully!");
            Pause();
        }

        public void ViewAllEntries()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No entries found.");
                return;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                if (string.IsNullOrWhiteSpace(content))
                {
                    Console.WriteLine("No entries found.");
                }
                else
                {
                    Console.WriteLine("Diary Entries:\n");
                    Console.WriteLine(content);
                }
            }
            Pause();
        }

        public void SearchByDate(string date)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No entries found.");
                return;
            }

            bool entryFound = false;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                Console.WriteLine($"Entries for {date}:\n");
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith(date))
                    {
                        Console.WriteLine(line);
                        entryFound = true;
                    }
                }
            }

            if (!entryFound)
            {
                Console.WriteLine("No entries found for this date.");
            }
            Pause();
        }
        
        public  void Pause()
        {
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }

    }
}