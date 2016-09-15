<Query Kind="Expression">
  <Connection>
    <ID>82d988ef-afb4-4378-bd49-e67673efe183</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

from x in Customers
where x.SupportRepIdEmployee.LastName.Equals("Peacock") && x.SupportRepIdEmployee.FirstName.Equals("Jane")
orderby x.LastName
select new{Name = x.LastName +", "+ x.FirstName, City = x.City, State = x.State, Phone = x.Phone, Email = x.Email}

//Use OF agragites in queries
//sum totals a specific field thus you will likely need to use a delagte to indicate the collection instant attribute to be used
from x in Albums
orderby x.Title
where x.Tracks.Count() > 0
select new { Title = x.Title, NumberOfAlbumTracks = x.Tracks.Count(), CostForAllTracks = x.Tracks.Sum(y => y.UnitPrice), AverageTrackLengthInSeconds = x.Tracks.Average(y => y.Milliseconds)/ 1000}


from x in MediaTypes
select new{Name = x.Name.Max(y => y.Tracks.Sum())}