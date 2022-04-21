using System;

namespace CIT365_Week_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables
            string name;
            string location;
            DateTime today;
            DateTime xmas = new System.DateTime(2022, 12, 25);
            int daysTilXmas;

            // Standard greeting for the program
            Console.WriteLine("Welcome to the CIT365 Week 1 program.");

            // Call our functions and assign the results to our variables
            name = PromptName();
            location = PromptLocation();
            today = DateTime.Today;
            daysTilXmas = DaysTilXmas(today, xmas);

            // Display the final output
            DisplayValues(name, location, today, daysTilXmas);

            // Call the function from the book
            BookFunction();

            // Ending the program by requiring the user to press any key.
            Console.WriteLine("Press Any Key to End Program...");
            Console.ReadKey();
        }

        // Prompt the User for their name. (No Validation)
        static String PromptName() 
        {
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            return name;
        }
        // Prompt the User for their location. (No Validation)
        static String PromptLocation()
        {
            Console.Write("Enter your Location: ");
            string location = Console.ReadLine();
            return location;
        }
        // Calculate how many days there are until Christmas.
        static int DaysTilXmas(DateTime today, DateTime xmas) {
            System.TimeSpan diff = xmas.Subtract(today);
            return (int) diff.Days;
        }
        // Display all the values once they have been assigned.
        static void DisplayValues(string name, string location, DateTime date, int daysTilXmas) {
            Console.WriteLine($"\nYour name is {name}, And you are from {location}.");
            Console.WriteLine($"Today's date is { date.ToString("d")}.");
            Console.WriteLine($"And there are {daysTilXmas} days until Christmas.\n");
        }

        // This is the function from the book that I have altered slightly to be User friendly and use string interpolation.
        static void BookFunction() {
            double width, height, woodLength, glassArea;
            string widthString, heightString;
            Console.Write("Enter Width: ");
            widthString = Console.ReadLine();
            width = double.Parse(widthString);
            Console.Write("Enter Height: ");
            heightString = Console.ReadLine();
            height = double.Parse(heightString);
            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);
            Console.WriteLine($"The length of the wood is {woodLength} feet");
            Console.WriteLine($"The area of the glass is {glassArea} square metres\n");
        }
    }
}
