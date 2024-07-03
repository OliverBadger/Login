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
string username = Console.ReadLine();
Console.Write("Enter password: ");
string password = Console.ReadLine();

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
    // Gets every line in the text file and stores each line as a string array called Lines
    string[] lines = File.ReadAllLines(textFile);
    bool validated = false;
    
    // Loops through each array and is manipulated as a string called line
    foreach (string line in lines)
    {
        // Splits the username and password by a ':' and stores them as string arrays
        string[] parts = line.Split(':');
        // Validates the Username and Password with the .txt file
        validated = (parts[0] == username && parts[1] == password) ? true : false;
    }
    // Simple display string for output
    string displayString = (validated) ? "Your Details Were Authenticated!" : "Sorry, The Details You Entered Were Incorrect. Please Try Again!";
    Console.WriteLine(displayString);
}