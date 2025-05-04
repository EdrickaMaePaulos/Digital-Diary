public class Diary
    {
        private string filePath;
        private readonly DiaryManager diaryManager;
        
        public Diary(DiaryManager manager)
        {
            diaryManager = manager;
            
            if (!Directory.Exists("Diaries"))
            {
                Directory.CreateDirectory("Diaries");
            }
        }
        
        private void UpdateFilePath()
        {
            string username = diaryManager.GetCurrentUsername();
            string userDir = Path.Combine("Diaries", username);
            
            if (!Directory.Exists(userDir))
            {
                Directory.CreateDirectory(userDir);
            }
            
            filePath = Path.Combine(userDir, "diary.txt");
            
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        public void WriteEntry(string text)
        {
            if (!diaryManager.IsLoggedIn())
            {
                Console.WriteLine("\tYou must be logged in to write an entry.");
                Pause();
                return;
            }
            
            UpdateFilePath();
            
            string entry = $"[{DateTime.Now.ToString("yyyy-MMMM-dd")}] [{DateTime.Now.ToString("HH:mm:ss")}]: {text}";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(entry);
            }
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("\t\t\tEntry saved successfully!");
            Pause();
            
        }

        public void ViewAllEntries()
        {
            if (!diaryManager.IsLoggedIn())
            {
                Console.WriteLine("\tYou must be logged in to view entries.");
                Pause();
                return;
            }
            
            UpdateFilePath();
            
            if (!File.Exists(filePath))
            {
                Console.WriteLine("\t\t\t  No entries found.");
                Pause();
                return;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                if (string.IsNullOrWhiteSpace(content))
                {
                    Console.WriteLine("\t\t\tNo entries found.");
                }
                else
                {
                    Console.WriteLine($"\t\t===== Logged in as: {diaryManager.GetCurrentUsername()} =====");
                    Console.WriteLine(new string('-', 60));
                    Console.WriteLine(content);
                }
            }
            Pause();
        }

        public void SearchByDate(string date)
        {
            if (!diaryManager.IsLoggedIn())
            {
                Console.WriteLine("\tYou must be logged in to search entries.");
                Pause();
                return;
            }
            
            UpdateFilePath();
            
            if (!File.Exists(filePath))
            {
                Console.WriteLine("\t\t   No entries found.");
                Pause();
                return;
            }

            bool entryFound = false;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                Console.WriteLine($"\t\t\tEntries for {date}:\n");
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains($"[{date}]"))
                    {
                        Console.WriteLine(line);
                        entryFound = true;
                    }
                }
            }

            if (!entryFound)
            {
                Console.WriteLine("\t\tNo entries found for this date.");
            }
            Pause();
        }
        
        public void DeleteEntry()
        {
            if (!diaryManager.IsLoggedIn())
            {
                Console.WriteLine("\tYou must be logged in to delete entries.");
                Pause();
                return;
            }
            
            UpdateFilePath();
            
            if (!File.Exists(filePath))
            {
                Console.WriteLine("\t\tNo entries found to delete.");
                Pause();
                return;
            }
            
            List<string> entries = new List<string>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    entries.Add(line);
                }
            }
            
            if (entries.Count == 0)
            {
                Console.WriteLine("\t\tNo entries found to delete.");
                Pause();
                return;
            }
            
            Console.WriteLine("\t\tSelect an entry to delete:\n");
            for (int i = 0; i < entries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {entries[i]}");
            }
            
            Console.WriteLine("\n" + new string('-', 60));
            Console.Write("Enter the number of the entry to delete (0 to cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int selection) || selection < 0 || selection > entries.Count)
            {
                Console.WriteLine("\t\t\t   Invalid selection.");
                Pause();
                return;
            }
            
            if (selection == 0)
            {
                Console.WriteLine("\n\t\tDelete operation cancelled.");
                Pause();
                return;
            }
            
            entries.RemoveAt(selection - 1);
            
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (string entry in entries)
                {
                    writer.WriteLine(entry);
                }
            }
            
            Console.WriteLine("\t\t\t  Entry deleted successfully!");
            Pause();
        }
        
        public void Pause()
        {
            Console.WriteLine("\n\t\tPress any key to continue...");
            Console.ReadKey();
        }
    }
