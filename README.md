#  Digital Diary – C# Console Application

## 💻 Project Description and Features

**Digital Diary** is a C# console-based application that allows users to create, manage, and secure personal diary entries. It implements a simple interface where users must register and log in before accessing the diary features. This program offers basic yet essential functions for diary management and demonstrates file-based data storage.

### 🖇 Key Features

- **User Registration and Login**
  - Users can create accounts and log in with secure credentials.
  - Each account is protected with hashed passwords.

- **Write Diary Entries**
  - Allows users to create diary entries with automatic timestamps.

- **View All Entries**
  - Displays all saved entries for the logged-in user in chronological order.

- **Search Entries by Date**
  - Users can search for specific diary entries using a date filter.

- **Delete Entries**
  - Provides an option to delete selected diary entries.

- **Logout**
  - Ends the current session securely.

- **File-Based Persistence**
  - All user data and diary entries are stored and managed using the file system.
  - Each user has a separate folder with entries stored by date.

## How OOP Principles are used

### Encapsulation

Encapsulation in the code is achieved by hiding the internal details of the User, DiaryManager, and DiaryBase classes and exposing controlled access through public methods and properties. 

The get and set methods in the User class allow controlled access to private fields like Username and PasswordHash, ensuring that sensitive data is not directly modified.
```
public class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
```

The DiaryManager class encapsulates user-related operations like login and registration.
```
public class DiaryManager
    {
        private readonly string usersFilePath;
        private readonly Dictionary<string, User> users;
        private User currentUser;
```
The DiaryBase and Diary classes handle diary entry management through methods like WriteEntry, ViewAllEntries, SearchByDate, and DeleteEntry. 
```
public abstract class DiaryBase
{
    protected string filePath;
    protected readonly DiaryManager diaryManager;
```
```
public class Diary : DiaryBase
```

This approach ensures that data is accessed and modified in a controlled manner, promoting data protection and a clear separation between the internal state of objects and external interaction.

### Abstraction

Abstraction is used in this program through the abstract class DiaryBase, which provides a general template for diary-related actions such as WriteEntry, ViewAllEntries, SearchByDate, and DeleteEntry. These methods are declared in the base class but have no actual code, leaving the details to be defined by any class that inherits from it. The Diary class inherits from DiaryBase and gives its own specific implementation of these methods. 
```
public abstract class DiaryBase
{
    protected string filePath;
    protected readonly DiaryManager diaryManager;

    public abstract void WriteEntry(string text);
    public abstract void ViewAllEntries();
    public abstract void SearchByDate(string date);
    public abstract void DeleteEntry();

}
```
```
public class Diary : DiaryBase
```
This approach hides complex code details and focuses on what actions the diary should perform, not how they are done. Abstraction makes the program easier to manage, reuse, and extend in the future.

### Inheritance

Inheritance is demonstrated through the relationship between the abstract class DiaryBase and the derived class Diary. 
The DiaryBase class serves as a blueprint that outlines the core structure and required functionalities for any diary-related class. It defines common fields like filePath and diaryManager, and provides shared methods such as UpdateFilePath() for setting up the diary file and Pause() for user interaction. It also declares four abstract methods—WriteEntry, ViewAllEntries, SearchByDate, and DeleteEntry—which must be implemented by any subclass. 
```
public abstract class DiaryBase
{
    protected string filePath;
    protected readonly DiaryManager diaryManager;

    public DiaryBase(DiaryManager manager)
    {
        diaryManager = manager;

        if (!Directory.Exists("Diaries"))
        {
            Directory.CreateDirectory("Diaries");
        }
    }

    protected void UpdateFilePath()
    {
        // logic of UpdateFilePath
    }

    public abstract void WriteEntry(string text);
    public abstract void ViewAllEntries();
    public abstract void SearchByDate(string date);
    public abstract void DeleteEntry();

    public virtual void Pause()
    {
        // logic of Pause
    }
```
The Diary class inherits from DiaryBase and provides its own concrete implementations of these abstract methods
```
public class Diary : DiaryBase
```
This use of inheritance allows the Diary class to reuse the common functionality from the base class while also defining specific behaviors for each operation. It promotes cleaner, more organized code by separating shared logic from the individual implementation details, and supports maintainability and scalability in the application's design.

### Polymorphism

Polymorphism is applied through the use of the abstract class DiaryBase and its derived class Diary. DiaryBase defines abstract methods like WriteEntry, ViewAllEntries, SearchByDate, and DeleteEntry, which must be implemented by any class that inherits from it.
```
public abstract class DiaryBase
{
    public abstract void WriteEntry(string text);
    public abstract void ViewAllEntries();
    public abstract void SearchByDate(string date);
    public abstract void DeleteEntry();
}
```
The Diary class provides its own specific implementation for each of these methods.
```
public class Diary : DiaryBase
{
    public override void WriteEntry(string text)
    {
        // Implementation of WriteEntry
    }

    public override void ViewAllEntries()
    {
        // Implementation of ViewAllEntries
    }

    public override void SearchByDate(string date)
    {
        // Implementation of SearchByDate
    }

    public override void DeleteEntry()
    {
        // Implementation of DeleteEntry
    }
}
```
Because of polymorphism, code that works with DiaryBase—such as a controller class or a menu system—can interact with any subclass, like Diary, without needing to know its exact implementation. This enables flexibility and scalability, allowing developers to introduce new diary behaviors or formats in other derived classes without modifying the core logic that uses the base class. The ability to call overridden methods in Diary through a DiaryBase reference is a key example of runtime polymorphism.

## 🛠️ Instructions on Running the App
### Requirements:
  - .NET SDK installed (e.g., .NET 6 or later)
  - A C# IDE (e.g., Visual Studio, Visual Studio Code, or JetBrains Rider)
### Steps to Run:
  1. Download or clone the project folder.
  2. Open a terminal/command prompt.
  3. Navigate to the project directory using cd.
  4. Compile and run the program:
  ```
  dotnet run
  ```
### Usage:
When the app runs, you'll see a menu to:
  - Register a new account
  - Log in
  - Write, view, search, or delete diary entries
Follow on-screen prompts to use the features.



## 📁 File Structure
```
Digital Diary/
├── 📂 bin/Debug/net9.0/
│ ├── Digital Diary.deps.json
│ ├── Digital Diary.dll
│ ├── Digital Diary.exe
│ ├── Digital Diary.pdb
│ ├── Digital Diary.runtimeconfig.json
│ └── diary.txt
│
├── 📂 obj/Debug/net9.0/
│ ├── Digital Diary.csproj.nuget.dgspec.json
│ ├── Digital Diary.csproj.nuget.g.props
│ ├── Digital Diary.csproj.nuget.g.targets
│ ├── project.assets.json
│ ├── project.nuget.cache
│ ├── project.packagespec.json
│ ├── rider.project.model.nuget.info
│ └── rider.project.restore.info
│
├── Diary.cs # Contains the Diary class and related functionality
├── Digital Diary.csproj # Project file for the C# application
├── Program.cs # Entry point of the application
├── User.cs # Contains the User class for authentication
└── README.md # Project documentation
```

## Sample Output

### Start
![start](https://github.com/user-attachments/assets/835fd5fe-17ea-4d8b-ae0d-459bb7301193)

### Register
![Register](https://github.com/user-attachments/assets/be9bd0de-dbdb-42fe-81ab-63d7e535e291)

### Login
![login](https://github.com/user-attachments/assets/88e13dcd-849e-4403-8a87-2c2df12860ae)   ![loggein](https://github.com/user-attachments/assets/670880a5-6c5f-4f74-8b64-126672062c51)

### First Entry 
![firstentry](https://github.com/user-attachments/assets/fea2f34e-ed6b-4d5e-acb2-b8f5623892db)

### Second Entry
![secondentry](https://github.com/user-attachments/assets/a0b69875-85fb-4998-96b7-47d70149b00d)

### View Entries in Console
![entriesConsole](https://github.com/user-attachments/assets/c05cafde-0a04-486b-a2e9-a1b95939e708)

### View Entries in TXT File
![entriesTXT](https://github.com/user-attachments/assets/a403ba46-88c3-479d-aac3-f66add5436e6)

### Search Entry
![searchEntry](https://github.com/user-attachments/assets/2103ef63-c570-45c8-83a8-6c76b2d6e55f)

### Delete Entry
![deleteEntry](https://github.com/user-attachments/assets/5dde80b9-3339-4480-a14b-e830a16f46b9)

### View Entry after Delete
![viewafterdelete](https://github.com/user-attachments/assets/a99bd545-c4f1-45fd-af12-c4d6f2e82a51)

### Logout
![logout](https://github.com/user-attachments/assets/15b92a61-d5dd-4ff9-84a9-23191137a8ed)

### Exit the Program
![exit](https://github.com/user-attachments/assets/0b5831c8-bf1e-41c0-8823-12972a098906)
---

##  <a id = "contrib"> 👨‍💻 Contributors </a> <br>
| Name | Role | E-mail | Other Contacts |
| --- | --- | --- | --- |
| <a href = "https://github.com/CambaRalphVincent">Camba, Ralph Vincent</a> | Developer | 23-02389@g.batstate-u.edu.ph|   |
| <a href = "https://github.com/LenardAndrei">Panganiban, Lenard Andrei</a>|  Developer  | 23-02989@g.batstate-u.edu.ph |  |
| <a href = "https://github.com/EdrickaMaePaulos">Paulos, Edricka Mae</a>| Developer | 23-07123@g.batstate-u.edu.ph | |
| <a href = "https://github.com/RC-Torres>">Torres, Richard Crue</a>| Developer | 23-02148@g.batstate-u.edu.ph | |

<h3> COURSE </h3>
<p> CS 222 - Advance Object-Oriented Programming</p>
<h3> FACILITATOR </h3>
<p> Ms. Fatima Marie Agdon</p> <br>

## 🙏 Acknowledgement

We would like to express our heartfelt gratitude to **Ms. Fatima Marie Agdon**, our professor, for her valuable guidance, support, and encouragement throughout the development of this project. 

This project is a collaborative effort of four dedicated members, who worked together in designing, developing, and testing the features of this application. Our teamwork and shared learning have played a vital role in bringing this project to life.

Thank you for being a part of our learning journey!

