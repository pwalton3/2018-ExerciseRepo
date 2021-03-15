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

//Comparing the playlists of Roberto Almeida (AlmeidaR) and Michelle Brooks (BrooksM)
//Comparing two lists to each other

//obtain a distinct list of all playlist tracks for Roberto Almeida
//.Distinct() can destroy the sort of a query syntax, thus add 
//		the sory after the .Distinct()

var almeida = (from x in PlaylistTracks 
				where x.Playlist.UserName.Contains("AlmeidaR")
				//orderby x.Track.Name
				select new
				{
					Genre = x.Track.Genre.Name,
					ID = x.TrackId,
					song = x.Track.Name,
					artist = x.Track.Album.Artist.Name
				}).Distinct().OrderBy(y => y.song);
//almeida.Dump();	110

var brooks = (from x in PlaylistTracks 
				where x.Playlist.UserName.Contains("BrooksM")
				select new
				{
					Genre = x.Track.Genre.Name,
					ID = x.TrackId,
					song = x.Track.Name,
					artist = x.Track.Album.Artist.Name
				}).Distinct().OrderBy(y => y.song);
//brooks.Dump();	88

//list the tracks that both Roberto and Michelle like
//comparing two datasets together 
//list A (Roberto) compared to list B (Michelle)

var likes = almeida.Where(a => brooks.Any(b => b.ID == a.ID))
			.OrderBy(a => a.Genre)
			.ThenBy(a => a.song)
			.Select(a => a);
//likes.Dump();

//list the tracks that Roberto likes but Michelle does not listen to

var almeidaDiff = almeida
					.Where(a => !brooks.Any(b => b.ID == a.ID))
					.OrderBy(a => a.Genre)
					.ThenBy(a => a.song)
					.Select(a => a);
//almeidaDiff.Dump();

//list the tracks that Michelle likes but Roberto does not listen to

var brooksDiff = brooks
					.Where(a => !almeida.Any(b => b.ID == a.ID))
					.OrderBy(a => a.song)
					.Select(a => a);
//brooksDiff.Dump();

var resultsAvg = Tracks.Average(tr => tr.Milliseconds);
//resultsAvg.Dump();


var resultsTrackAvgLength = (from x in Tracks
							select new
							{
								song = x.Name,
								milliseconds = x.Milliseconds,
								length = x.Milliseconds < resultsAvg ? "Shorter" : 
										x.Milliseconds > resultsAvg ? "Longer" : 
										"Average"
							}).OrderBy(x => x.length);
//resultsTrackAvgLength.Dump();



//Union is the joining of multiple results intno a single query dataset
//syntax	(query).union(query).union(query)....
//rules		same as SQL 
//number of columns must be the same 
//Data type of column must be the same 
//ordering should be done as a method on the unioned dataset

//list the stats of Albums on Tracks(Count, Cost($), average track length)
//NOTE: For cost and average, one will need an instance to actually process
//		if an album contains no tracks then no sum or average will be allowed


var unionResults = (from x in Albums 
					where x.Tracks.Count() > 0
					select new 
					{
						title = x.Title,
						TotalTracks = x.Tracks.Count(),
						TotalPrice = x.Tracks.Sum(tr => tr.UnitPrice),
						AverageLength = x.Tracks.Average(tr => tr.Milliseconds)/1000.0
					}).Union(from x in Albums 
							where x.Tracks.Count() > 0
							select new 
							{
								title = x.Title,
								TotalTracks = x.Tracks.Count(),
								TotalPrice = 0.00m,
								AverageLength = 0.0
							}).OrderBy(u => u.TotalTracks);	
unionResults.Dump();








