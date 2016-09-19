<Query Kind="Statements">
  <Connection>
    <ID>3faee7fc-03e7-4689-a676-83fa50752e0a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//which waiter has the most bills

var highestBills = from x in Waiters
where x.Bills.Count == Waiters.Select(bc => bc.Bills.Count()).Max()
select new{Name = x.FirstName + " " + x.LastName, BillCount = x.Bills.Count()};

highestBills.Dump();

//To check the answer that I got.
//var highestBills01 = from x in Waiters
//select new{Name = x.FirstName + " " + x.LastName, BillCount = x.Bills.Count()};
//highestBills01.Dump();

//Create a data set that contains the summary bill info by waiter
var waiterBills = from x in Waiters
orderby x.LastName, x.FirstName
select new {Name = x.LastName + ", " + x.FirstName, BillInfo = (from y in x.Bills where y.BillItems.Count() > 0 select new{BillId = y.BillID, BillDate = y.BillDate, TableId = y.TableID, Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)})};
waiterBills.Dump();