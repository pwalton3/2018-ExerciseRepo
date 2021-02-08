<Query Kind="Expression">
  <Connection>
    <ID>9f31dddb-f621-4015-a5b7-152395709601</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

////TO COMMENT CTRLKC
////TO UNCOMMENT CTRLKU
////method syntax (code as objects)
//Albums
//.Select(x => x)
//
////query syntax
////the placeholder "currentrow" represents an indiividual row
////		on your table at any point in time during processing 
////"currentrow" can be any name you wish
////from currentrow in Albums
////select currentrow
//
////partial table rows
////in this example we will create a new output instance layout
////the default layout is the specified recieving field names and order
////		the data fills the new output instance comes from the current row of the table
////query syntax
//from x in Albums
//select new 
//{
//	Title = x.Title,
//	Year = x.ReleaseYear
//}
//
//
////method syntax
//Albums
//   .Select (x => new  
//         {
//            Title = x.Title, 
//            Year = x.ReleaseYear
//         }
//   		)	
////where clause
////is used for filtering your selection
////QUERY SYNTAX
////Select only albums in the year 1990
//from x in Albums
//where x.ReleaseYear == 1990
//select x
//
//////METHOD SYNTAX
//Albums
//   .Where (x => (x.ReleaseYear == 1990))
//   .Select(x => x)
//   
////order by clause
//ascending and or descending   
//from x in Albums
//where x.ReleaseYear >= 1990 && x.ReleaseYear < 2000
//orderby x.ReleaseYear ascending, x.Title descending
//select x
   
////method syntax
//Albums
//   .Where (x => ((x.ReleaseYear >= 1990) && (x.ReleaseYear < 2000)))
//   .OrderBy (x => x.ReleaseYear)
//   .ThenByDescending (x => x.Title)
////Dons method syntax
//Albums
//	.Where(x => x.ReleaseYear >= 1990 && x.ReleaseYear < 2000)
//	.OrderBy(x => x.ReleaseYear)
//	.ThenByDescending(x => x.Title)
//	.Select(x => x)

//Create a list of albums showing the Album Title, Artist, and ReleaseYear for the good old 70's order by artist then title
//query syntax
//from x in Albums 
//where x.ReleaseYear >= 1970 && x.ReleaseYear <= 1979
//orderby x.Artist.Name, x.Title 
//select new
//{
//	Artist = x.Artist.Name,
//	Title = x.Title,
//	ReleaseYear = x.ReleaseYear
//}

////method syntax
//Albums
//   .Where (x => ((x.ReleaseYear >= 1970) && (x.ReleaseYear <= 1979)))
//   .OrderBy (x => x.Artist.Name)
//   .ThenBy (x => x.Title)
//   .Select (
//      x => 
//         new  
//         {
//            Artist = x.Artist.Name, 
//            Title = x.Title, 
//            ReleaseYear = x.ReleaseYear
//         }
//   )
//   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   