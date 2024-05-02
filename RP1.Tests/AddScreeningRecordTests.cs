using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RP1.Tests
{
	public class AddScreeningRecordTests
	{
		private Screening Screening_One;
		private Screening Screening_Two;

		public AddScreeningRecordTests()
		{
			Screening_One = new Screening()
			{
				Id = 1,
				Date = DateTime.Now,
				seatsRemaining = 100,
				filmId = 1,
				Film = new Film(),
				theatreId = 1,
				Theatre = new Theatre()
			};

			Screening_Two = new Screening()
			{
				Id = 8,
				Date = DateTime.Now,
				seatsRemaining = 12,
				filmId = 5,
				Film = new Film(),
				theatreId = 3,
				Theatre = new Theatre()
			};
		}

		[Test]
		public void SaveScreening_Screening_One_CheckValuesFromDb()
		{
			var options = new DbContextOptionsBuilder<AppDBContext>()
				.UseInMemoryDatabase(databaseName: "temp_Razor").Options;

			using (var context = new AppDBContext(options))
			{
				context.Screenings.Add(Screening_One);
				context.SaveChanges();
			}

			using(var context = new AppDBContext(options)) 
			{ 
				var screeningFromDb = context.Screenings.FirstOrDefault(u => u.Id == 100);
				ClassicAssert.AreEqual(Screening_One.Id, screeningFromDb.Id);
				Assert.That(screeningFromDb.Id, Is.EqualTo(Screening_One.Id));
			}
		}
	}
}
