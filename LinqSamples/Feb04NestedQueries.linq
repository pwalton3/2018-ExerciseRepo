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

////Nested Queries aka sub queries
////simply put: it is a query inside a query
//
////list all sales support employees showing their full name(LastName, FirstName) 
////there title and the number of customers each supports. Order by full name.
////In addition show a list of the customers for each employee.
//
////There will be two seperate list within the same dataset collection
////one for employees and one for customers of an employee
//
////C# point of view in a class definition 
////class name 
////	property1 (field)
////		property2 (field)
////			...
////	collection<T> set of records 
//
////to acomplish the list of customers we will use a nested query
////the data source for the list of customers will be the x.collection<Customers>
////x.NavCollectionName
////x represents the current record on the outer query
////.NavCollectionName represents all the "children" of x
//
//
var results = from x in Employees
				where x.Title.Contains("Sales Support")
				orderby x.LastName, x.FirstName
				select new EmployeeCustomerList
				{
					EmployeeName = x.LastName + " , " + x.FirstName,
					Title = x.Title,
					CustomersSupportCount = x.SupportRepCustomers.Count(),
					CustomerList = (from y in x.SupportRepCustomers
									select new CustomerSupportItem
									{
										CustomerName = y.LastName + " , " + y.FirstName,
										Phone = y.Phone,
										City = y.City,
										State = y.State,
									}).ToList()
				};
	results.Dump();			
	
//
//var results2 = Employees
//   .Where (x => x.Title.Contains ("Sales Support"))
//   .OrderBy (x => x.LastName)
//   .ThenBy (x => x.FirstName)
//   .Select (
//      x => 
//         new  
//         {
//            EmployeeName = ((x.LastName + " , ") + x.FirstName), 
//            Title = x.Title, 
//            CustomersSupportCount = x.SupportRepCustomers.Count (), 
//            CustomerList = x.SupportRepCustomers
//               .Select (
//                  y => 
//                     new  
//                     {
//                        CustomerName = ((y.LastName + " , ") + y.FirstName), 
//                        Phone = y.Phone, 
//                        City = y.City, 
//                        State = y.State
//                     }
//               )
//         }
//   );
//results2.Dump();




//var results1 = from x in Albums
//				where x.Tracks.Count() >= 25
//				select new
//				{​​
//					Title = x.Title,
//					ArtistName = x.Artist.Name,
//					TrackCount = x.Tracks.Count(),
//					TrackList = (from y in x.Tracks
//								where y.AlbumId == x.AlbumId
//								select new
//								{​​
//									Name = y.Name,
//									SongLength = y.Milliseconds/1000.0
//								}​​
//				
//				}​​;
//results1.Dump();

//Define other methods and classes here
public class EmployeeCustomerList
{
	public string EmployeeName {get; set; }
	public string Title {get; set; }
	public int CustomerSupportCount {get; set; }
	public IEnumerable<CustomerSupportItem> CustomerList {get; set; }
	
}

public class CustomerSupportItem
{
	public string CustomerName {get; set; } 
	public string Phone { get; set; }
	public string City { get; set; }
	public string State { get; set; }
}

}












