using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        [SetUp]
        public void Setup()
        {
        }

        //Test case 1: Calculate Fare for given distance and time. The invoice generator should return the total fare for the journey.
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }

        //Test case 2: The invoice generator should take multiple rides and should return the aggregate total fare for all rides.

        [Test]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 35.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }

        //Test case 3: The invoice generator should return the enhanced invoice summary as total number rides, total fare and average fare per ride.

        [Test]
        public void GivenMultipleRideShouldReturnEnhancedInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, 3);
            Assert.AreEqual(expectedSummary, summary);
        }

        //Test case 4: For a given user id and list of rides the invoice generator should return the total fare for the journey.

        [Test]
        public void GivenUserIdShouldReturnInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            invoiceGenerator.AddRides("1", rides);
            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary("1");
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, "1");
            Assert.AreEqual(expectedSummary, summary);
        }

        //Test case 5: Calculate Fare for given distance and time depending on ride type (Normal/Premium). The invoice generator should return the total fare for the journey.

        [Test]
        public void GivenRidesWhenPremiumOrNormalShouldReturnTotalFare() 
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 3.0;
            int time = 20;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 85;
            Assert.AreEqual(expected, fare);
        }

    }
}