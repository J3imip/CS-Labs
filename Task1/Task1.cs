namespace Task1
{
    class Address
    {
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string HouseNumber { get; set; }
    }

    class Student
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required int CardID { get; set; }
        public required Address Address { get; set; }
    }

    class Group
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public List<Student> GetStudentByCardID(int CardID)
        {
            return students.Where(student => student.CardID == CardID).ToList();
        }
		public List<Student> GetStudentsByPartialName(string? PartialName)
		{
			return students.Where(student => (student.FirstName.ToLower() + " " + student.LastName.ToLower()).Contains(PartialName)).ToList();
		}
		public List<Student> GetStudentsByCity(string? City)
        {
            return students.Where(student => student.Address.City.ToLower() == City?.ToLower()).ToList();
        }
        public List<Student> GetStudentsByCountry(string? Country)
        {
            return students.Where(student => student.Address.Country.ToLower() == Country?.ToLower()).ToList();
        }
    }

    class Program
    {
        public enum SearchCriteria
        {
            SearchByCity = 1,
            SearchByCardID = 2,
            SearchByCountry = 3,
            SearchByPartialName = 4,
        }

        static public Exception InputTypesMismatch = new Exception("input type mismatch (input number must be in range 1-3).");

        static void OutputStudents(List<Student> students)
        {
            if (students.Count == 0) Console.WriteLine("\n-=Nothing was found by this prompt=-");

            students.ForEach(student =>
            {
                Console.WriteLine(
                    "\t-=Student=-\n" +
                    $"Full Name:\t{student.FirstName} {student.LastName}\n" +
                    $"CardID:\t\t{student.CardID}\n" +
                    $"Country:\t{student.Address.Country}\n" +
                    $"City:\t\t{student.Address.City}\n" +
                    $"Street:\t\t{student.Address.Street} {student.Address.HouseNumber}\n"
                );
            });
        }
        static void Main(string[] args) {
            do { 
				try {
					Group group = new Group();

					group.AddStudent(new Student { FirstName = "Bohdan", LastName = "Kuchma", CardID = 1, Address = new Address { Country = "Ukraine", City = "Kyiv", Street = "Nauky avenue", HouseNumber = "120E", } });
					group.AddStudent(new Student { FirstName = "Davyd", LastName = "Konstantinov", CardID = 2, Address = new Address { Country = "Ukraine", City = "Kryvyj Rih", Street = "Bandera's avenue", HouseNumber = "23", } });
					group.AddStudent(new Student { FirstName = "Kate", LastName = "Hryhorieva", CardID = 3, Address = new Address { Country = "Ukraine", City = "Odessa", Street = "Sichovyh Stril'tsiv", HouseNumber = "10", } });
					group.AddStudent(new Student { FirstName = "Dmytro", LastName = "Ivaniv", CardID = 4, Address = new Address { Country = "Ukraine", City = "Kyiv", Street = "Yaroslaviv val", HouseNumber = "21", } });

					Console.Write(
						"\nEnter your choice:\n" +
						"1 - Search students by city\n" +
						"2 - Search student by card id\n" +
						"3 - Search students by country\n" +
						"4 - Search students by partial name: "
					);

					string? userInput = Console.ReadLine();
					Console.WriteLine();
					if (int.TryParse(userInput, out int userChoice)) {
						switch (userChoice) {
							case (int)SearchCriteria.SearchByCity:
								Console.Write("Enter city: ");
								string? city = Console.ReadLine();

								OutputStudents(group.GetStudentsByCity(city));
								break;
							case (int)SearchCriteria.SearchByCardID:
								Console.Write("Enter student's card ID: ");

								string? cardID = Console.ReadLine();
								if (!int.TryParse(cardID, out int userCardID))
									throw new Exception("incorrect card id (input must be an integer)");

								OutputStudents(group.GetStudentByCardID(userCardID));
								break;
							case (int)SearchCriteria.SearchByCountry:
								Console.Write("Enter country: ");

								string? country = Console.ReadLine();

								OutputStudents(group.GetStudentsByCountry(country));
								break;
							case (int)SearchCriteria.SearchByPartialName:
								Console.Write("Enter partial name: ");

								string? partialName = Console.ReadLine();

								OutputStudents(group.GetStudentsByPartialName(partialName));
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
}
