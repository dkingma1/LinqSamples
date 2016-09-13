<Query Kind="Statements">
  <Connection>
    <ID>3faee7fc-03e7-4689-a676-83fa50752e0a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Waiters
var results = from x in Waiters
where x.FirstName.Contains("a")
orderby x.LastName
select x.LastName + ", " + x.FirstName;
results.Dump();