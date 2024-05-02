using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RP1.Tests
{
	public class AddBookingRecordTests
	{
		private Booking Booking_One;
		private Booking Booking_Two;

		public AddBookingRecordTests()
		{
			Booking_One = new Booking()
			{
				Id = 100,
				SeatAmount = 15,
				Cost = 100.00,
				Email = "isa.c@gmail.com",
				Tickets = new List<Ticket>()
			};

			Booking_Two = new Booking()
			{
				Id = 100,
				SeatAmount = 15,
				Cost = 100.00,
				Email = "isa.c@gmail.com",
				Tickets = new List<Ticket>()
			};
		}

		[Test]
		public void SaveBooking_Booking_One_CheckValuesFromDb()
		{
			var options = new DbContextOptionsBuilder<AppDBContext>()
				.UseInMemoryDatabase(databaseName: "temp_Razor").Options;

			using (var context = new AppDBContext(options))
			{
				context.Booking.Add(Booking_One);
				context.SaveChanges();
			}

			using(var context = new AppDBContext(options)) 
			{ 
				var bookingFromDb = context.Booking.FirstOrDefault(u => u.Id == 100);
				ClassicAssert.AreEqual(Booking_One.Id, bookingFromDb.Id);
				Assert.That(bookingFromDb.SeatAmount, Is.EqualTo(Booking_One.SeatAmount));
			}
		}
	}
}
