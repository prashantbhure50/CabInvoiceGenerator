using CabInvoiceGenerator;
using NUnit.Framework;
using System;

namespace UnitProject1
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
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
        [Test]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 31.0);
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenMultipleRideShouldReturnAverageRide()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 31.0);
            bool result = summary.Equals(expectedSummary);
            Assert.IsTrue(result);
        }
        
          //  [Test]

          //public void test()
          //{
          //  Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
          //  Ride[] rides1 = { new Ride(2.0, 5), new Ride(0.1, 5) };
          //  string user1 = "user1";
          //  string user2 = "user2";
          //  RideRepository riderepo = invoiceGenerator.ReturnRideRideRepository();
          //  RideRepository r = new RideRepository();
           

           
          //  //riderepo.AddRide(user1,rides);
          //  //riderepo.AddRide(user2,rides1);
          //  InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary(user1);
          //  InvoiceSummary expectedSummary = new InvoiceSummary(2,31.0);
          //  Console.WriteLine(expectedSummary);
          //  Console.WriteLine(summary);
          //  Assert.AreEqual(expectedSummary, summary);

          //}
        [Test]
        public void GivenDistanceAndTimeForPremiumRideShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 40;
            Assert.AreEqual(expected, fare);
        }
        [Test]
        public void GivenMultiplePremiumRideShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 60.0);
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenWrongRideType_ShouldReturn_Invalid_Ride_Type_Exception()
        {
            var exception = Assert.Throws<CabInvoiceException>(() => invoiceGenerator = new InvoiceGenerator(RideType.Utltrapremium));
            Assert.AreEqual(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, exception.type);
        }
        [Test]
        public void GivenWrongRideType_ShouldReturn_INVALID_DISTANCE()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 0;
            int time = 3;
            double fare;
            var exception = Assert.Throws<CabInvoiceException>(() => fare = invoiceGenerator.CalculateFare(distance, time));
            Assert.AreEqual(CabInvoiceException.ExceptionType.INVALID_DISTANCE, exception.type);

        }
        [Test]
        public void GivenWrongRideType_ShouldReturn_INVALID_Time()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 0;
            double fare;
            var exception = Assert.Throws<CabInvoiceException>(() => fare = invoiceGenerator.CalculateFare(distance, time));
            Assert.AreEqual(CabInvoiceException.ExceptionType.INVALID_TIME, exception.type);
        }
    }
}