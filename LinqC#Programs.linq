<Query Kind="Program">
  <Connection>
    <ID>3faee7fc-03e7-4689-a676-83fa50752e0a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

void Main()
{
	//List of bill counts for all waiters
	//this query will create a flat data set. The columns are native data types (int, string, ... )
	//One is not concerned wioth repeted data in a column.
	//instead of using an anonymous data type (new{ ... }) we wish to use a defined class definition.
	var bestWaiter = from x in Waiters
						//where x.Bills.Count == Waiters.Select(bc => bc.Bills.Count()).Max()
						select new WaiterBillCounts{Name = x.FirstName + " " + x.LastName, TCount = x.Bills.Count()};
	bestWaiter.Dump();
	
	
	var waiterBills = from x in Waiters
						where x.LastName.Contains("k")
						orderby x.LastName, x.FirstName
						select new WaiterBills{Name = x.LastName + ", " + x.FirstName, TotalBillCount = x.Bills.Count(),
							BillInfo = (from y in x.Bills where y.BillItems.Count() > 0 select new BillItemSummary{BillId = y.BillID, BillDate = y.BillDate, TableId = y.TableID, 
							Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)}).ToList()};
waiterBills.Dump();
}


//an example of a POCO class
public class WaiterBillCounts
{
	//Whatever reciveing field on your query in your select appears as a property in this class
	public string Name{get; set;}
	public int TCount{get; set;}
}

public class BillItemSummary
{
	public int BillId{get; set;}
	public DateTime BillDate{get; set;}
	public int? TableId{get; set;}
	public decimal Total{get; set;}
}

//An example of a DTO class (structured)
public class WaiterBills
{
	public string Name {get; set;}
	public int TotalBillCount{get; set;}
	public List<BillItemSummary> BillInfo{get; set;}
}
