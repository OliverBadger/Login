// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System;
using System.Transactions;

namespace UserManagement
{
    class Program
    {
        // There should be a standard way of creating a file path for every computer
        static private string textFile = @"C:\Users\Oliver\source\repos\Login\Login\users.txt";
        
        static void Main(string[] args)
        {

            bool validAnswer = false;

            string? answer;

            // Do while to validate the answers given
            do
            {
                // Gets user details
                Console.WriteLine("Please Enter Username: ");
                string? username = Console.ReadLine();
                Console.WriteLine("Please Enter Password: ");
                string? password = Console.ReadLine();

                // Reads all lines from the text file and stores each line in a string array called lines
                string[] lines = File.ReadAllLines(textFile);
                bool validated = false;

                // Loops through each line in the lines array
                foreach (string line in lines)
                {
                    // Splits each line by ':' and stores the parts in a string array
                    string[] parts = line.Split(':');
                    // Validates the username and password with the entries in the text file & breaks if true
                    if (parts[0] == username && parts[1] == password) { validated = true; break; }
                }

                // If the username and password is not valid then we have an option to register 
                validAnswer = validated ? true : false;
                if (!validAnswer)
                {
                    Console.WriteLine("User not found. Would you like to Register? [y/n]");
                    answer = Console.ReadLine();
                    validAnswer = (answer == "y") ? false : true;
                    registerUser(username, password);
                }
                else Console.WriteLine("User found!");

                // Option to re-run the system
                Console.WriteLine("Would you like to use the system again? [y/n]");
                answer = Console.ReadLine();
                validAnswer = (answer == "y") ? false : true;
            }
            while (!validAnswer);
        }

        private static void registerUser(string username, string password)
        {
            // Reads all lines from the text file and stores each line in a string array called lines
            string[] lines = File.ReadAllLines(textFile);
            bool validated = false;

            // Loops through each line in the lines array
            foreach (string line in lines)
            {
                // Splits each line by ':' and stores the parts in a string array
                string[] parts = line.Split(':');
                // Validates the username and password with the entries in the text file & breaks if true
                if (parts[0] == username && parts[1] == password) { validated = true; break; }
            }
            // Displays an appropriate message based on the validation result
            string displayString = validated ? "Your Details Were Authenticated!" : "Sorry, The Details You Entered Were Incorrect. Please Try Again!";
            Console.WriteLine(displayString);
        }
    }
}