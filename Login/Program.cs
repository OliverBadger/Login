// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

// Variables
string username = "user";
string localUsername = "user";
string password = "pass";
string localPassword = "pass";

// Ternary operator to authenticate password
string display = (username == localUsername && password == localPassword) ? "Correct!" : "Incorrect Details!";

// Display outcome of authentication
Console.WriteLine(display);