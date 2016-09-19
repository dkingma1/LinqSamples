<Query Kind="Statements">
  <Connection>
    <ID>162d9807-b50d-439d-af3b-c056d676df44</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//when you need to use multple steps to solve a problem, switch your language choice to eiths statment(s) or program.
//The results of each query will now be saved ina variable, which can can be used in future queries
var maxcount = (from x in MediaTypes 
select x.Tracks.Count()).Max();

//to display the contents of a variable in linq pad you use the method .Dump()
maxcount.Dump();

//USe a value in a perceeding created variable
var popularMediaType = from x in MediaTypes where x.Tracks.Count() == maxcount select new{Type = x.Name, TypeCount = x.Tracks.Count()};
popularMediaType.Dump();

//can this set of statments be done as one complete query. The answer is possibly, and in this case yes.
//In this example maxcount could be exchanged for the query that actually created the value in the first place.
//This substatuted query is a subquery
var popularMediaType02 = from x in MediaTypes where x.Tracks.Count() == (from y in MediaTypes 
select y.Tracks.Count()).Max() select new{Type = x.Name, TypeCount = x.Tracks.Count()};
popularMediaType02.Dump();

//using the method syntax to find the count value for the where expression
//This proves that queries can be construced using query syntax and method syntax
var populaSubMethod = from x in MediaTypes where x.Tracks.Count() == MediaTypes.Select(mt => mt.Tracks.Count()).Max()
select new{Type = x.Name, TypeCount = x.Tracks.Count()};
populaSubMethod.Dump();