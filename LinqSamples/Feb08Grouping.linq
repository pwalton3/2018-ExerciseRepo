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

//Grouping

//A) by a column				Key
//B) by multiple columns		Key.attribute
//C) by an entity				Key.attribute

//groups have 2 components
//	A) key component (group by); to reference this componet use Key[.attribute]
//	B) data (instances in the group)

//Process
//Start with a "pile" of data
//Specify the grouping
//Result is smaller "piles" of data determined by the group

//Grouping can be saved temporarying into datasets and the individual group dataset
//and can be reported on 


//report albums by release year
var resultsorderby = from x in Albums
					orderby x.ReleaseYear
					select x;

resultsorderby.Dump();


//group by
var resultsgroupby = from x in Albums
					group x by  x.ReleaseYear;
resultsgroupby.Dump();

//Group by artist name and album release year
var resultsgroupbycolumns = from x in Albums
							group x by new{x.Artist.Name, x.ReleaseYear};
resultsgroupbycolumns.Dump();


//group traacks by their album
var resultsgroupbyentity = from x in Tracks
							group x by x.Album;
resultsgroupbyentity.Dump();

//IMPORTANT
//if you wish to report on groups (after the group by) 
//	you MUST save the grouping into a temororary dataset
//	then you MUST use the temporary dataset to report from 


var resultsgroupbyReport = from x in Albums
							group x by x.ReleaseYear into gAlbumYear
							select new
							{
								KeyValue = gAlbumYear.Key,
								numberOfAlbums = gAlbumYear.Count(),
								albumAndArtist = from y in gAlbumYear
												select new 
												{
													Title = y.Title,
													Artist = y.Artist.Name
												}
							};
resultsgroupbyReport.Dump();



//group by an entity
var groupAlbumsbyArtist = from x in Albums
							group x by x.Artist into gArtistAlbums
							//select gArtistAlbums; 
							select new
							{
								Artist = gArtistAlbums.Key.Name,
								numberOfAlbums = gArtistAlbums.Count(),
								AlbumList = gArtistAlbums
											.Select(y => new
														{
															Title = y.Title,
															Year = y.ReleaseYear
														})
							};
groupAlbumsbyArtist.Dump();

//Create a query which will report the employee and their customer base.
//List the employee full name and phone, number of customers in their base.
//List the employee full name, city and state for the customer base.








