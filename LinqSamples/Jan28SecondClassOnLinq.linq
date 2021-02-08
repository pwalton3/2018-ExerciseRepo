<Query Kind="Program">
  <Connection>
    <ID>9f31dddb-f621-4015-a5b7-152395709601</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
//	//List all customers in alphabetical order by last name, first name who live in the USA?
//	//query syntax
//	var results = from x in Customers
//	orderby x.LastName ascending
//	where x.Country == "USA"
//	select new
//	{
//		LastName = x.LastName,
//		FirstName = x.FirstName
//		
//	};
//	results.Dump();
//	//.Contain will find if the value contains part of the string
//	var country = "US";
//	var results2 = from x in Customers
//	orderby x.FirstName, x.LastName 
//	where x.Country.Contains(country)
//	select new
//	{
//		LastName = x.LastName,
//		FirstName = x.FirstName,
//		FullName = x.LastName + ", " + x.FirstName
//		
//	};
//	results2.Dump();
//	//method syntax
//	var countrys = "USA";
//	var results3 = Customers
//	   .OrderBy (x => x.LastName)
//	   .Where (x => (x.Country == countrys))
//	   .Select (
//	      x => 
//	         new  
//	         {
//	            LastName = x.LastName, 
//	            FirstName = x.FirstName
//	         }
//	   );
//	results3.Dump();
//	
//	// if using statements we need to display the contents of results
//	//in LinqPad use the application method .Dump()
//	
//	
//	
//	//create an alphabetic list of albums by ReleaseLabel
//	//Albums missing Labels will be listed as "Unknown"
//	
//	var label = "unkown";
//	results = from x in Albums
//	orderby x.ReleaseLabel ascending
//	if (ReleaseLabel == Label)
//	
//	{
//	
//	}
//	
//	var Label ="Unknown";
//	var results4 = Albums
//		.OrderBy(x => x.ReleaseLabel)
//		.Select(x => new
//		{
//			Title = x.Title,
//			Label = x.ReleaseLabel == null ? "Unknown" : x.ReleaseLabel
//		});
//		
//		results4.Dump();
//	
//	
//	//create an alphabetic list of albums by decades of 70's, 80's, and 90's
//	//list the title and year
//	var results5 = from x in Albums
//					select new
//					{
//						Title = x.Title,
//						Decade = x.ReleaseYear >= 1970 && x.ReleaseYear < 1980 ? "70's" :
//						(x.ReleaseYear >= 1980 && x.ReleaseYear < 1990 ? "80's" :
//						x.ReleaseYear >= 1990 && x.ReleaseYear < 2000 ? "90's" : "others")
//					};
//					results5.Dump();
//}

// You can define other methods, fields, classes and namespaces here
//remember a class is a developer firendly 















public class AlbumDecades
{
	public string Title {get; set;}
	public int Year {get; set; }
	public string Decade { get; set; }
}
