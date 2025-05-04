using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


public class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
    
    public class DiaryManager
    {
        private readonly string usersFilePath;
        private readonly Dictionary<string, User> users;
        private User currentUser;
        
        public DiaryManager()
        {
            usersFilePath = "users.txt";
            users = new Dictionary<string, User>();
            LoadUsers();
        }
        
        private void LoadUsers()
        {
            if (!File.Exists(usersFilePath))
            {
                File.Create(usersFilePath).Close();
                return;
            }
            
            using (StreamReader reader = new StreamReader(usersFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        User user = new User
                        {
                            Username = parts[0],
                            PasswordHash = parts[1]
                        };
                        users[user.Username] = user;
                    }
                }
            }
        }
        
        private void SaveUsers()
        {
            using (StreamWriter writer = new StreamWriter(usersFilePath, false))
            {
                foreach (var user in users.Values)
                {
                    writer.WriteLine($"{user.Username}|{user.PasswordHash}");
                }
            }
        }
        
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        
        public bool Register(string username, string password)
        {
            if (users.ContainsKey(username))
            {
                Console.WriteLine("\t\t   Username already exists.");
                return false;
            }
            
            User newUser = new User
            {
                Username = username,
                PasswordHash = HashPassword(password)
            };
            
            users[username] = newUser;
            SaveUsers();
            
            string userDir = Path.Combine("Diaries", username);
            if (!Directory.Exists(userDir))
            {
                Directory.CreateDirectory(userDir);
            }
            
            return true;
        }
        
        public bool Login(string username, string password)
        {
            if (!users.ContainsKey(username))
            {
                Console.WriteLine("\t\t   Username not found.");
                return false;
            }
            
            User user = users[username];
            if (user.PasswordHash != HashPassword(password))
            {
                Console.WriteLine("\t\t   Incorrect password.");
                return false;
            }
            
            currentUser = user;
            return true;
        }
        
        public bool IsLoggedIn()
        {
            return currentUser != null;
        }
        
        public string GetCurrentUsername()
        {
            return currentUser?.Username;
        }
        
        public void Logout()
        {
            currentUser = null;
        }
    }