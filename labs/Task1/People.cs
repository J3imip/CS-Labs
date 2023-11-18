namespace Task1;

internal abstract class People<TFirstName, TLastName, TCardId, TAddress>
{
	protected readonly List<Person<TFirstName, TLastName, TCardId, TAddress>> PeopleList = new();

	public void AddPerson(Person<TFirstName, TLastName, TCardId, TAddress> person)
	{
		PeopleList.Add(person);
	}

	public void RemovePerson(Person<TFirstName, TLastName, TCardId, TAddress> person)
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
		if (obj is not People<TFirstName, TLastName, TCardId, TAddress> otherGroup) return false;
		return !PeopleList.Where((t, i) => !t.Equals(otherGroup.PeopleList[i])).Any();
	}

	public override int GetHashCode()
	{
		return PeopleList.GetHashCode();
	}
}

internal class Group : People<string, string, DateTime, Address>
{
	public List<Person<string, string, DateTime, Address>> GetPeopleByCity(string city)
	{
		return PeopleList
			.Where(person => person.Address is Address address && address.City.ToLower().Equals(city.ToLower()))
			.ToList();
	}

	public List<Person<string, string, DateTime, Address>> GetPeopleByCountry(string country)
	{
		return PeopleList
			.Where(person => person.Address is Address address && address.Country.ToLower() == country?.ToLower())
			.ToList();
	}

	public List<Person<string, string, DateTime, Address>> GetPeopleByPartialName(string partialName)
	{
		return PeopleList.Where(person =>
			(person.FirstName.ToLower() + " " + person.LastName.ToLower())
			.Contains((partialName?.ToLower() ?? string.Empty))
		).ToList();
	}

	public void SortByLastName()
	{
		PeopleList.Sort(
			(person1, person2) =>
			string.Compare(person1.LastName, person2.LastName, StringComparison.Ordinal)
		);
	}

	//add sorting by birth date
	public void SortByBirthDate()
	{
		PeopleList.Sort(
			(person1, person2) =>
			DateTime.Compare(person1.BirthDate, person2.BirthDate)
		);
	}
}

internal class Address
{
	public required string Country{ get; init; }
	public required string City { get; init; }
	public required string Street { get; init; }
	public required string HouseNumber { get; init; }
}

internal class Person<TFirstName, TLastName, TBirthDate, TAddress>
{
	public TFirstName FirstName { get; }
	public TLastName LastName { get; }
	public TBirthDate BirthDate { get; }
	public TAddress Address { get; }

	public Person(TFirstName firstName, TLastName lastName, TBirthDate birthDate, TAddress address)
	{
		FirstName = firstName;
		LastName = lastName;
		BirthDate = birthDate;
		Address = address;
	}

	public override string ToString()
	{
		if (Address == null || BirthDate == null) throw new Exception("Address or Birth Date is null");

		var address = (Address)(object)Address;
		var date = (DateTime)(object)BirthDate;

		return "\t-=Person=-\n" +
		       $"Full Name:\t{FirstName} {LastName}\n" +
		       $"Birth Date:\t{date.ToShortDateString()}\n" +
		       $"Country:\t{address.Country}\n" +
		       $"City:\t\t{address.City}\n" +
		       $"Street:\t\t{address.Street} {address.HouseNumber}\n";
	}
}
