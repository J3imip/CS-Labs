namespace Task1;

internal static class Task1
{
	private enum SearchCriteria
	{
		SearchByCity = 1,
		SearchByCountry = 2,
		SearchByPartialName = 3,
	}

	private static readonly Exception InputTypesMismatch = new("input type mismatch (input number must be in range 1-3).");

	private static void OutputPeople(List<Person<string, string, DateTime, Address>> people)
	{
		if (people.Count == 0) Console.WriteLine("\n-=Nothing was found by this prompt=-");

		people.ForEach(Console.WriteLine);
	}

	private static void Main(string[] args) {
		var group = new Group();
		var group1 = new Group();

		group.AddPerson( new Person<string, string, DateTime, Address>
			(
				"Bohdan",
				"Kuchma",
				new DateTime(2005, 1, 3),
				new Address{Country = "Ukraine", City = "Kyiv", Street = "Nauky avenue", HouseNumber = "120E"}
			)
		);
		group.AddPerson(new Person<string, string, DateTime, Address>
			(
				"Davyd",
				"Konstantinov",
				new DateTime(2005, 9, 11),
				new Address{Country = "Ukraine", City = "Kryvyj Rih", Street = "Bandera's avenue", HouseNumber = "23"}
			)
		);
		group.AddPerson(new Person<string, string, DateTime, Address>
			(
				"Kate",
				"Hryhorieva",
				new DateTime(2003, 6, 4),
				new Address{Country = "Ukraine", City = "Odessa", Street = "Sichovyh Stril'tsiv", HouseNumber = "10"}
			)
		);
		group.AddPerson(new Person<string, string, DateTime, Address>
			(
				"Dmytro",
				"Ivaniv",
				new DateTime(2005, 5, 29),
				new Address{Country = "Ukraine", City = "Kyiv", Street = "Yaroslaviv val", HouseNumber = "21"}
			)
		);

		group1.AddPerson( new Person<string, string, DateTime, Address>
			(
				"Bohdan",
				"Kuchma",
				new DateTime(2005, 1, 3),
				new Address{Country = "Ukraine", City = "Kyiv", Street = "Nauky avenue", HouseNumber = "120E"}
			)
		);
		group1.AddPerson(new Person<string, string, DateTime, Address>
			(
				"Davyd",
				"Konstantinov",
				new DateTime(2005, 9, 11),
				new Address{Country = "Ukraine", City = "Kryvyj Rih", Street = "Bandera's avenue", HouseNumber = "23"}
			)
		);
		group1.AddPerson(new Person<string, string, DateTime, Address>
			(
				"Kate",
				"Hryhorieva",
				new DateTime(2003, 6, 4),
				new Address{Country = "Ukraine", City = "Odessa", Street = "Sichovyh Stril'tsiv", HouseNumber = "10"}
			)
		);
		group1.AddPerson(new Person<string, string, DateTime, Address>
			(
				"Dmytro",
				"Ivaniv",
				new DateTime(2005, 5, 29),
				new Address{Country = "Ukraine", City = "Kyiv", Street = "Yaroslaviv val", HouseNumber = "21"}
			)
		);


		// It will be deleted so we won't see test person in output
		var testPerson = new Person<string, string, DateTime, Address>("test", "test", new DateTime(), null);

		group.AddPerson(testPerson);
		group.RemovePerson(testPerson);

		Console.WriteLine(group);
		Console.WriteLine(group.Equals(group1) ? "Two groups are identical." : "Groups are different.");

		do {
			try {
				Console.Write(
					"\nEnter your choice:\n" +
					"{0} - Search people by city\n" +
					"{1} - Search people by country\n" +
					"{2} - Search people by partial name: ",
					SearchCriteria.SearchByCity.GetHashCode(),
					SearchCriteria.SearchByCountry.GetHashCode(),
					SearchCriteria.SearchByPartialName.GetHashCode()
				);

				var userInput = Console.ReadLine();
				Console.WriteLine();
				if (int.TryParse(userInput, out int userChoice)) {
					switch (userChoice) {
						case (int)SearchCriteria.SearchByCity:
							Console.Write("Enter city: ");
							var city = Console.ReadLine();

							OutputPeople(group.GetPeopleByCity(city));
							break;
						case (int)SearchCriteria.SearchByCountry:
							Console.Write("Enter country: ");

							var country = Console.ReadLine();

							OutputPeople(group.GetPeopleByCountry(country));
							break;
						case (int)SearchCriteria.SearchByPartialName:
							Console.Write("Enter partial name: ");

							var partialName = Console.ReadLine();

							OutputPeople(group.GetPeopleByPartialName(partialName));
							break;
						default:
							throw InputTypesMismatch;
					}
				}
				else throw InputTypesMismatch;
			}
			catch (Exception ex) {
				Console.Error.WriteLine(ex.ToString());
			}
		} while (true);
	}
}