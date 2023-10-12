namespace Task1;

internal abstract class People
{
	protected readonly List<Person> PeopleList = new List<Person>();

	public void AddPerson(Person person)
	{
		PeopleList.Add(person);
	}

	public void RemovePerson(Person person)
	{
		PeopleList.Remove(person);
	}

	public override string ToString()
	{
		var people = $"Group {GetHashCode()}:\n\n";
		PeopleList.ForEach(person =>
		{
			people += person;
		});

		return people;
	}

	public override bool Equals(object? obj)
	{
		if (obj is not Group otherGroup) return true;
		return !PeopleList.Where((t, i) => t.Equals(otherGroup.PeopleList[i])).Any();
	}

	public override int GetHashCode()
	{
		return PeopleList.GetHashCode();
	}
}

internal class Group : People
{
	public List<Person> GetPeopleByCity(string city)
	{
		return PeopleList.Where(person => person.Address.City.ToLower().Equals(city.ToLower())).ToList();
	}

	public List<Person> GetPeopleByCountry(string country)
	{
		return PeopleList.Where(person => person.Address.Country.ToLower() == country?.ToLower()).ToList();
	}

	public List<Person> GetPeopleByPartialName(string partialName)
	{
		return PeopleList.Where(person =>
			(person.FirstName.ToLower() + " " + person.LastName.ToLower())
			.Contains(partialName?.ToLower() ?? string.Empty)
		).ToList();
	}
}

internal class Address
{
	public required string Country { get; init; }
	public required string City { get; init; }
	public required string Street { get; init; }
	public required string HouseNumber { get; init; }
}

internal class Person
{
	public required string FirstName { get; init; }
	public required string LastName { get; init; }
	public required int CardId { get; init; }
	public required Address Address { get; init; }

	public override string ToString()
	{
		return "\t-=Person=-\n" +
		       $"Full Name:\t{FirstName} {LastName}\n" +
		       $"CardID:\t\t{CardId}\n" +
		       $"Country:\t{Address.Country}\n" +
		       $"City:\t\t{Address.City}\n" +
		       $"Street:\t\t{Address.Street} {Address.HouseNumber}\n";
	}
}

internal static class Task1
{
	private enum SearchCriteria
	{
		SearchByCity = 1,
		SearchByCountry = 2,
		SearchByPartialName = 3,
	}

	private static readonly Exception InputTypesMismatch = new("input type mismatch (input number must be in range 1-3).");

	private static void OutputPeople(List<Person> people)
	{
		if (people.Count == 0) Console.WriteLine("\n-=Nothing was found by this prompt=-");

		people.ForEach(person =>
		{
			Console.WriteLine(
				"\t-=Person=-\n" +
				$"Full Name:\t{person.FirstName} {person.LastName}\n" +
				$"CardID:\t\t{person.CardId}\n" +
				$"Country:\t{person.Address.Country}\n" +
				$"City:\t\t{person.Address.City}\n" +
				$"Street:\t\t{person.Address.Street} {person.Address.HouseNumber}\n"
			);
		});
	}

	private static void Main(string[] args) {
		var group = new Group();
		var group1 = new Group();

		group.AddPerson(new Person { FirstName = "Bohdan", LastName = "Kuchma", CardId = 1, Address = new Address { Country = "Ukraine", City = "Kyiv", Street = "Nauky avenue", HouseNumber = "120E" } });
		group.AddPerson(new Person { FirstName = "Davyd", LastName = "Konstantinov", CardId = 2, Address = new Address { Country = "Ukraine", City = "Kryvyj Rih", Street = "Bandera's avenue", HouseNumber = "23" } });
		group.AddPerson(new Person { FirstName = "Kate", LastName = "Hryhorieva", CardId = 3, Address = new Address { Country = "Ukraine", City = "Odessa", Street = "Sichovyh Stril'tsiv", HouseNumber = "10" } });
		group.AddPerson(new Person { FirstName = "Dmytro", LastName = "Ivaniv", CardId = 4, Address = new Address { Country = "Ukraine", City = "Kyiv", Street = "Yaroslaviv val", HouseNumber = "21" } });

		group1.AddPerson(new Person { FirstName = "Bohdan", LastName = "Kuchma", CardId = 1, Address = new Address { Country = "Ukraine", City = "Kyiv", Street = "Nauky avenue", HouseNumber = "120E" } });
		group1.AddPerson(new Person { FirstName = "Davyd", LastName = "Konstantinov", CardId = 2, Address = new Address { Country = "Ukraine", City = "Kryvyj Rih", Street = "Bandera's avenue", HouseNumber = "23" } });
		group1.AddPerson(new Person { FirstName = "Kate", LastName = "Hryhorieva", CardId = 3, Address = new Address { Country = "Ukraine", City = "Odessa", Street = "Sichovyh Stril'tsiv", HouseNumber = "10" } });
		group1.AddPerson(new Person { FirstName = "Dmytro", LastName = "Ivaniv", CardId = 4, Address = new Address { Country = "Ukraine", City = "Kyiv", Street = "Yaroslaviv val", HouseNumber = "21" } });

		// It will be deleted so we won't see test person in output
		var testPerson = new Person { FirstName = "test", LastName = "test", CardId = 0, Address = null };

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