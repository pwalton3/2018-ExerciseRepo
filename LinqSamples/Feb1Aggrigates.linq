<Query Kind="Statements">
  <Connection>
    <ID>9f31dddb-f621-4015-a5b7-152395709601</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

// //Aggregates
// //.Count(), .Sum(), .Min(), .Max(), .Average()
// //Aggregates operate on collections
// 
// Albums.Count()
// 
// //For aggregates .Sum(), .Max(), .Min(), .Average()
// //you need to specific field to the aggregate
//  Albums.Sum()
// //how much room does the music collection on the database take
////Tracks table has a field called Bytes this field holds the size of a track
////summing the field of all tracks will get me the total requiured disk space
//
//var ex1 = Tracks.Where(x => x.Album.ReleaseYear == 1990).Sum(x => x.Bytes);
//ex1.Dump();
//var ex2 = Tracks.Where(x => x.Album.ReleaseYear == 1990).Min(x => x.Bytes);
//ex2.Dump();
//var ex3 = Tracks.Where(x => x.Album.ReleaseYear == 1990).Max(x => x.Bytes);
//ex3.Dump();
//var ex4 = Tracks.Where(x => x.Album.ReleaseYear == 1990).Average(x => x.Bytes);
//ex4.Dump();
//
//
//var ex5 = (from x in Tracks
//			where x.Album.ReleaseYear == 1990
//			select x.Bytes).Sum();
//ex5.Dump();
//
//
//
////list of all albums showing their title, artist name, and the number of traacks for that album. Show only albums of the 60's. Order by the
////the number of tracks from smallest to greatest 
//var ex = Tracks.Where(x => x.Album.ReleaseYear == 1960)
//
//var ex6 = (from x in Albums
//			where x.ReleaseYear > 1959 && x.ReleaseYear < 1970
//			orderby x.Tracks.Count() descending
//			select new
//			{
//				Title = x.Title,
//				Artist = x.Artist.Name,
//				Year = x.ReleaseYear,
//				NumberOfTracks = x.Tracks.Count()
//			});
//			
//ex6.Dump();
//
////produce a list of albums which have tracks showing their title,
////artist, number of tracks on album, total price of all tracks on album, the longest album track
////the shortest album track and the average track length

var ex7 = from x in Albums
			where x.ReleaseYear > 1959 && x.ReleaseYear < 1970
			&& x.Tracks.Count() > 0
			select new
			{
				Title = x.Title,
				Artist = x.Artist.Name,
				NumberOfTracks = x.Tracks.Count(),
				CostOfTracks = x.Tracks.Sum(y => y.UnitPrice),
				QueryCostOfTracks = (from y in x.Tracks
										select y.UnitPrice).Sum(),
				Longest = x.Tracks.Max(y => y.Milliseconds),
				Shortest = x.Tracks.Min(y => y.Milliseconds),
				Average = x.Tracks.Average(y => y.Milliseconds)
			};

ex7.Dump();











