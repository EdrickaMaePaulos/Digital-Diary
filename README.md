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

Encapsulation in the code is achieved by hiding the internal details of the User, DiaryManager, and DiaryBase classes and exposing controlled access through public methods and properties. The get and set methods in the User class allow controlled access to private fields like Username and PasswordHash, ensuring that sensitive data is not directly modified. The DiaryManager class encapsulates user-related operations like login and registration, while the DiaryBase and Diary classes handle diary entry management through methods like WriteEntry, ViewAllEntries, SearchByDate, and DeleteEntry. This approach ensures that data is accessed and modified in a controlled manner, promoting data protection and a clear separation between the internal state of objects and external interaction.

### Abstraction

Abstraction is used in this program through the abstract class DiaryBase, which provides a general template for diary-related actions such as WriteEntry, ViewAllEntries, SearchByDate, and DeleteEntry. These methods are declared in the base class but have no actual code, leaving the details to be defined by any class that inherits from it. The Diary class inherits from DiaryBase and gives its own specific implementation of these methods. This approach hides complex code details and focuses on what actions the diary should perform, not how they are done. Abstraction makes the program easier to manage, reuse, and extend in the future.

### Inheritance

Inheritance is demonstrated through the relationship between the abstract class DiaryBase and the derived class Diary. The DiaryBase class serves as a blueprint that outlines the core structure and required functionalities for any diary-related class. It defines common fields like filePath and diaryManager, and provides shared methods such as UpdateFilePath() for setting up the diary file and Pause() for user interaction. It also declares four abstract methods—WriteEntry, ViewAllEntries, SearchByDate, and DeleteEntry—which must be implemented by any subclass. The Diary class inherits from DiaryBase and provides its own concrete implementations of these abstract methods. This use of inheritance allows the Diary class to reuse the common functionality from the base class while also defining specific behaviors for each operation. It promotes cleaner, more organized code by separating shared logic from the individual implementation details, and supports maintainability and scalability in the application's design.

### Polymorphism

Polymorphism is applied through the use of the abstract class DiaryBase and its derived class Diary. DiaryBase defines abstract methods like WriteEntry, ViewAllEntries, SearchByDate, and DeleteEntry, which must be implemented by any class that inherits from it. The Diary class provides its own specific implementation for each of these methods. Because of polymorphism, code that works with DiaryBase—such as a controller class or a menu system—can interact with any subclass, like Diary, without needing to know its exact implementation. This enables flexibility and scalability, allowing developers to introduce new diary behaviors or formats in other derived classes without modifying the core logic that uses the base class. The ability to call overridden methods in Diary through a DiaryBase reference is a key example of runtime polymorphism.

# Instructions on running the app
## 🔐 Getting Started

### Register (New Users)
- Select the `Register` option from the menu.
- Provide your personal details to create a new account.

### Log In (Existing Users)
- Select the `Log In` option.
- Enter your registered username and password to access your diary.

---

### [1] Write a New Entry
- After logging in, choose **Write a New Entry** from the menu.
- Type your diary content when prompted.
- The entry will be saved automatically with the **current date and time**.

### [2] View All Entries
- Select **View All Entries** from the main menu.
- All diary entries will be shown in **chronological order**.
- Each entry includes the **date** and **text content**.

### [3] Search Entries by Date
- Choose **Search by Date** from the menu.
- Enter a date in the format: `yyyy-MMMM-dd` (e.g., `2025-May-05`).
- All matching entries for that date will be displayed.

### [4] Delete an Entry
- Select **Delete Entry** from the menu.
- Enter the **date** of the entry you want to delete.
- If found, the entry will be **permanently deleted**.

### [5] Log Out
- Select **Log Out** to safely end your session.

### [6] Exit
- Choose **Exit** to close the application completely.


![loggein](https://github.com/user-attachments/assets/8ed66dba-1585-4a4d-916a-db9ee7903d60)



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
