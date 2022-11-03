using Domain.Entities;
using Domain.Enums;
using NUnit.Framework;

namespace DomainTests.BookingTest
{
    public class StateMachineTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldAlwaysStartWithCreatedStatus()
        {
            var booking = new Booking();

            Assert.That(booking.CurrentStatus, Is.EqualTo(EnStatus.Created));
        }

        [Test]
        public void ShouldSetStatusToPaidWhenPayingForABookingWithCreatedStatus()
        {
            var booking = new Booking();

            booking.ChangeState(EnAction.Pay);

            Assert.That(booking.CurrentStatus, Is.EqualTo(EnStatus.Paid));
        }

        [Test]
        public void ShouldSetStatusToCanceledWhenCancelingABookingWithCreatedStatus()
        {
            var booking = new Booking();

            booking.ChangeState(EnAction.Cancel);

            Assert.That(booking.CurrentStatus, Is.EqualTo(EnStatus.Canceled));
        }

        [Test]
        public void ShouldSetStatusToFinishedWhenFinishingAPaidBooking()
        {
            var booking = new Booking();

            booking.ChangeState(EnAction.Pay);
            booking.ChangeState(EnAction.Finish);

            Assert.That(booking.CurrentStatus, Is.EqualTo(EnStatus.Finished));
        }

        [Test]
        public void ShouldSetStatusToRefoundWhenRefoundingAPaidBooking()
        {
            var booking = new Booking();

            booking.ChangeState(EnAction.Pay);
            booking.ChangeState(EnAction.Refound);

            Assert.That(booking.CurrentStatus, Is.EqualTo(EnStatus.Refounded));
        }

        [Test]
        public void ShouldSetStatusToCreatedWhenReopeningACanceledBooking()
        {
            var booking = new Booking();

            booking.ChangeState(EnAction.Cancel);
            booking.ChangeState(EnAction.Reopen);

            Assert.That(booking.CurrentStatus, Is.EqualTo(EnStatus.Created));
        }

        [Test]
        public void ShouldNotChangeStatusWhenRefoundingABookingWithCreatedStatus()
        {
            var booking = new Booking();

            booking.ChangeState(EnAction.Refound);

            Assert.That(booking.CurrentStatus, Is.EqualTo(EnStatus.Created));
        }

        [Test]
        public void ShouldNotChangeStatusWhenRefoundingAFinishedBooking()
        {
            var booking = new Booking();

            booking.ChangeState(EnAction.Pay);
            booking.ChangeState(EnAction.Finish);
            booking.ChangeState(EnAction.Refound);

            Assert.That(booking.CurrentStatus, Is.EqualTo(EnStatus.Finished));
        }
    }
}
