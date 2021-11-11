using System;

namespace CabInvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Generator");

            InvoiceGenerator normal = new InvoiceGenerator(RideType.NORMAL);
            InvoiceGenerator premium = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };

            Console.WriteLine("\n\n1. Single ride invoice summary");
            double fare = normal.CalculateFare(2.0, 5);
            Console.WriteLine($"Fare : {fare}");


            Console.WriteLine("\n\n2. Multiple ride invoice summary");
            InvoiceSummary summary = normal.CalculateFare(rides);
            Console.WriteLine("Total Rides: " + summary.numberOfRides + "\nTotal Fare: " + summary.totalFare);

            Console.WriteLine("\n\n3. Multiple ride enhanced invoice summary");
            InvoiceSummary enhancedSummary = normal.CalculateFare(rides);
            Console.WriteLine("Total Rides: " + enhancedSummary.numberOfRides + "\nTotal Fare: " + enhancedSummary.totalFare + "\nAverage Fare Per Ride: " + enhancedSummary.averageFare);

            Console.WriteLine("\n\n4. Multiple premium ride enhanced invoice summary");
            InvoiceSummary premiumSummary = premium.CalculateFare(rides);
            Console.WriteLine("Total Rides: " + premiumSummary.numberOfRides + "\nTotal Fare: " + premiumSummary.totalFare + "\nAverage Fare Per Ride: " + premiumSummary.averageFare);

            Console.ReadKey();
        }
    }
}
