public class Program
    {
        static void Main()
        {
            DiaryManager diaryManager = new DiaryManager();
            Diary diary = new Diary(diaryManager);
            
            bool exit = false;
            
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(new string('=', 60));
                Console.WriteLine("\t\t    D I G I T A L   D I A R Y");
                Console.WriteLine(new string('=', 60));
                
                if (diaryManager.IsLoggedIn())
                {
                    Console.WriteLine($"\t\t===== Logged in as: {diaryManager.GetCurrentUsername()} =====");
                    Console.WriteLine(new string('-', 60));

                    Console.WriteLine("\n\t\t[1] Write a new entry");
                    Console.WriteLine("\t\t[2] View all entries");
                    Console.WriteLine("\t\t[3] Search entries by date");
                    Console.WriteLine("\t\t[4] Delete an entry");
                    Console.WriteLine("\t\t[5] Logout");
                    Console.WriteLine("\t\t[6] Exit");
                    Console.WriteLine("\n" + new string('-', 60));
                    Console.Write("\t\tEnter your choice: ");
                    string choice = Console.ReadLine();
                    
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine(new string('=', 60));
                            Console.WriteLine("\t\t\tNEW ENTRY");
                            Console.WriteLine(new string('=', 60));
                            Console.WriteLine("\t\tWrite your diary entry:");
                            string entryText = Console.ReadLine();
                            diary.WriteEntry(entryText);
                            break;
                            
                        case "2":
                            Console.Clear();
                            Console.WriteLine(new string('=', 60));
                            Console.WriteLine("\t\t\tYOUR DIARY ENTRY");
                            Console.WriteLine(new string('=', 60));
                            diary.ViewAllEntries();
                            break;
                            
                        case "3":
                            Console.Clear();
                            Console.WriteLine(new string('=', 60));
                            Console.WriteLine("\t\t\tSEARCH ENTRY");
                            Console.WriteLine(new string('=', 60)); 
                            Console.Write("\n\t\tEnter date (YYYY-MM-DD): ");
                            string date = Console.ReadLine();
                            diary.SearchByDate(date);
                            break;
                        
                        case "4":
                            Console.Clear();
                            Console.WriteLine(new string('=', 60));
                            Console.WriteLine("\t\t\tDELETE ENTRY");
                            Console.WriteLine(new string('=', 60));
                            diary.DeleteEntry();
                            break;
                            
                        case "5":
                            diaryManager.Logout();
                            Console.WriteLine("\t\tLogged out successfully.");
                            Console.ReadKey();
                            diary.Pause();
                            break;
                            
                        case "6":
                            Console.WriteLine("\t\t\t\tYou're exiting...");
                            exit = true;
                            break;
                            
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n\t\t\t[1]\tLogin");
                    Console.WriteLine("\t\t\t[2]\tRegister");
                    Console.WriteLine("\t\t\t[3]\tExit");
                    Console.WriteLine("\n" + new string('-', 60));
                    Console.Write("\t\tEnter your choice: ");
                    string choice = Console.ReadLine();
                    
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine(new string('=', 60));
                            Console.WriteLine("\t\t\tLOG-IN");
                            Console.WriteLine(new string('=', 60));                            
                            Console.Write("\n\t\tUsername: ");
                            string loginUsername = Console.ReadLine();
                            Console.Write("\t\tPassword: ");
                            string loginPassword = Console.ReadLine();
                            Console.WriteLine(new string('-', 60));

                            
                            if (diaryManager.Login(loginUsername, loginPassword))
                            {
                                Console.WriteLine("\n\t\t   Login successful!");
                            }
                            else
                            {
                                Console.WriteLine("\t\tLogin failed. Try again.");
                            }

                            diary.Pause();                            
                            Console.ReadKey();
                            break;
                            
                        case "2":
                            Console.Clear();
                            Console.WriteLine(new string('=', 60));
                            Console.WriteLine("\t\t\tREGISTER");
                            Console.WriteLine(new string('=', 60));
                            Console.Write("\n\t\tNew Username: ");
                            string regUsername = Console.ReadLine();
                            Console.Write("\t\tNew Password: ");
                            string regPassword = Console.ReadLine();
                            Console.WriteLine("\n" + new string('-', 60));

                            
                            if (diaryManager.Register(regUsername, regPassword))
                            {
                                Console.WriteLine("\n\t\tRegistration successful!");
                            }
                            else
                            {
                                Console.WriteLine("\t\tRegistration failed. Try again.");
                            }
                            diary.Pause();                            

                            Console.ReadKey();
                            break;
                            
                        case "3":
                            exit = true;
                            break;
                            
                        default:
                            Console.WriteLine(new string('-', 60));
                            Console.WriteLine("\t\tInvalid choice. Try again.");
                            Console.ReadKey();
                            break;
                    }
                }
            }
        }
    }
