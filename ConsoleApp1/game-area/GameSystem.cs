using StudyingTesting.user;
using StudyingTesting.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingTesting.game_area
{
    public class GameSystem
    {
        // List to hold active tables in the game
        private static List<string> tables = new List<string>();

        // Method to check if the user has permission to add a table
        public static bool CanAddTable(User user)
        {
            // Check if the user has either Admin or Manager role
            return user.Roles.Contains(User_Role.ADMIN) || user.Roles.Contains(User_Role.MANAGER);
        }

        // Method to add a table, if the user is authorized
        public static void AddTable(User user, string tableName)
        {
            if (CanAddTable(user))
            {
                // Check if the table name already exists
                if (!tables.Contains(tableName))
                {
                    tables.Add(tableName);
                    Console.WriteLine($"Table '{tableName}' added successfully by {user.Username}. Welcome to the game!");
                }
                else
                {
                    Console.WriteLine($"Table '{tableName}' already exists. Please choose a different name.");
                }
            }
            else
            {
                Console.WriteLine($"Sorry {user.Username}, you don't have permission to add a table.");
            }
        }

        // Method to remove a table, if the user is authorized
        public static void RemoveTable(User user, string tableName)
        {
            if (CanAddTable(user)) // Only Admin or Manager can remove a table
            {
                if (tables.Contains(tableName))
                {
                    tables.Remove(tableName);
                    Console.WriteLine($"Table '{tableName}' removed successfully by {user.Username}.");
                }
                else
                {
                    Console.WriteLine($"Table '{tableName}' does not exist.");
                }
            }
            else
            {
                Console.WriteLine($"Sorry {user.Username}, you don't have permission to remove a table.");
            }
        }

        // Method to list all available tables
        public static void ListTables()
        {
            if (tables.Count > 0)
            {
                Console.WriteLine("Current tables in the game:");
                foreach (var table in tables)
                {
                    Console.WriteLine($"- {table}");
                }
            }
            else
            {
                Console.WriteLine("No tables have been created yet.");
            }
        }
        
        public static void DemoMain()
        {
            // Creating test users
            User adminUser = new User("AdminUser", new List<User_Role> { User_Role.ADMIN });
            User managerUser = new User("ManagerUser", new List<User_Role> { User_Role.MANAGER });
            User playerUser = new User("PlayerUser", new List<User_Role> { User_Role.PLAYER });

            // Test cases for adding tables
            GameSystem.AddTable(adminUser, "Table1");  // Should allow
            GameSystem.AddTable(managerUser, "Table2"); // Should allow
            GameSystem.AddTable(playerUser, "Table3");  // Should deny

            // List all tables after adding
            GameSystem.ListTables();

            // Test cases for removing tables
            GameSystem.RemoveTable(adminUser, "Table1");    // Should allow
            GameSystem.RemoveTable(managerUser, "Table2");  // Should allow
            GameSystem.RemoveTable(playerUser, "Table3");   // Should deny

            // List all tables after removing
            GameSystem.ListTables();
        }
    }

}
