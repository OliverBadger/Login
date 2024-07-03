// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

string textFile = @"C:\Users\Oliver\source\repos\Login\Login\users.txt";

// Display Menu
Console.WriteLine("""
    1. Register
    2. Login
    Select an option: 
    """);
byte option = byte.Parse(Console.ReadLine());

// Get Credentials
Console.Write("Enter username: ");
string? username = Console.ReadLine();
Console.Write("Enter password: ");
string? password = Console.ReadLine();

// Option for registering user
if (option == 1)
{
    // This is the template for data entry
    string userData = $"{username}:{password}";
    // Append to ensure no data loss
    File.AppendAllText(textFile, userData + Environment.NewLine);
    Console.WriteLine("User registered successfully.");
}
// Option for logging in
else if (option == 2)
{
    // Reads all lines from the text file and stores each line in a string array called lines
    string[] lines = File.ReadAllLines(textFile);
    bool validated = false;

    // Loops through each line in the lines array
    foreach (string line in lines)
    {
        // Splits each line by ':' and stores the parts in a string array
        string[] parts = line.Split(':');
        // Validates the username and password with the entries in the text file
        validated = (parts[0] == username && parts[1] == password) ? true : false;
    }
    // Displays an appropriate message based on the validation result
    string displayString = validated ? "Your Details Were Authenticated!" : "Sorry, The Details You Entered Were Incorrect. Please Try Again!";
    Console.WriteLine(displayString);
}