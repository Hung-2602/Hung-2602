using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chỉnh_programing_lần_cuối
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Water Bill Calculator");

            // Input gathering
            string customerName = GetCustomerName();
            int lastMonthReadings = GetIntegerInput("Enter last month's water meter readings: ");
            int thisMonthReadings = GetIntegerInput("Enter this month's water meter readings: ");
            int customerType = GetCustomerType();
            int numberOfPeople = 0;

            if (customerType == 1) // Household
            {
                numberOfPeople = GetIntegerInput("Enter the number of people in the household: ");
            }

            // Consumption calculation
            int consumption = CalculateConsumption(thisMonthReadings, lastMonthReadings);

            // Bill calculation
            double price = 0;
            double environmentFees = 0;

            CalculateBill(customerType, consumption, numberOfPeople, out price, out environmentFees);

            // Total water bill calculation
            double totalBill = CalculateTotalBill(price, consumption, environmentFees);

            // Output generation
            DisplayBill(customerName, lastMonthReadings, thisMonthReadings, consumption, totalBill);

            // Additional features (not implemented)
            // Sorting, searching, invoice generation, payment dues

            Console.ReadLine();
        }

        // Function to get customer name from user input
        static string GetCustomerName()
        {
            Console.Write("Enter customer name: ");
            return Console.ReadLine();
        }

        // Function to get integer input from user
        static int GetIntegerInput(string message)
        {
            Console.Write(message);
            return Convert.ToInt32(Console.ReadLine());
        }

        // Function to get customer type from user input
        static int GetCustomerType()
        {
            Console.Write("Enter the customer type (1 - Household, 2 - Administrative agency, 3 - Production units, 4 - Business services): ");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Function to calculate water consumption
        static int CalculateConsumption(int thisMonthReadings, int lastMonthReadings)
        {
            return thisMonthReadings - lastMonthReadings;
        }

        // Function to calculate bill based on customer type and consumption
        static void CalculateBill(int customerType, int consumption, int numberOfPeople, out double price, out double environmentFees)
        {
            price = 0;
            environmentFees = 0; 

            switch (customerType)
            {
                case 1: // Household
                    if (consumption <= 10 * numberOfPeople)
                    {
                        price = 5.973;
                        environmentFees = 597.30;
                    }
                    else if (consumption <= 20 * numberOfPeople)
                    {
                        price = 7.052;
                        environmentFees = 705.20;
                    }
                    else if (consumption <= 30 * numberOfPeople)
                    {
                        price = 8.699;
                        environmentFees = 866.90;
                    }
                    else
                    {
                        price = 15.929;
                        environmentFees = 1592.90;
                    }
                    break;

                case 2: // Administrative agency, public services
                    price = 9.955;
                    environmentFees = 995.50;
                    break;

                case 3: // Production units
                    price = 11.615;
                    environmentFees = 1161.50;
                    break;

                case 4: // Business services
                    price = 22.068;
                    environmentFees = 2206.80;
                    break;

                default:
                    Console.WriteLine("Invalid customer type.");
                    break;
            }
        }

        // Function to calculate total bill
        static double CalculateTotalBill(double price, int consumption, double environmentFees)
        {
            return (price * consumption) + environmentFees;
        }

        // Function to display bill details
        static void DisplayBill(string customerName, int lastMonthReadings, int thisMonthReadings, int consumption, double totalBill)
        {
            Console.WriteLine();
            Console.WriteLine("Customer Name: " + customerName);
            Console.WriteLine("Last Month's Water Meter Readings: " + lastMonthReadings);
            Console.WriteLine("This Month's Water Meter Readings: " + thisMonthReadings);
            Console.WriteLine("Amount of Consumption: " + consumption);
            Console.WriteLine("Total Water Bill: " + totalBill.ToString("0.00 VND"));

            Console.WriteLine();
        }
    }
}
