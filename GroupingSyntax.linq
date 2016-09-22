<Query Kind="Expression">
  <Connection>
    <ID>2953e2d4-0e54-498d-94a4-f0462aad3481</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//MultiColumn group. Grouping data placed in a local data set for further processing
//.Key allows you to access the value(s) in your group key(s)
//If you have multiple group columns the MUST be an annonymous datatype
//to create a DTO type collection you can use .ToList() on the temp data set
//You can have a custom annonymous data collection by using a nested query

//step 1
from food in Items
    group food by new {food.MenuCategoryID, food.CurrentPrice} ;

//step 2 DTO set
from food in Items
    group food by new {food.MenuCategoryID, food.CurrentPrice} into tempdataset
	select new { MenuCategoryID = tempdataset.Key.MenuCategoryID, CurrentPrice = tempdataset.Key.CurrentPrice, FoodItems = tempdataset.ToList()}
					
//step 3 DTO custom
from food in Items
    group food by new {food.MenuCategoryID, food.CurrentPrice} into tempdataset
	//select new { MenuCategoryID = tempdataset.Key.MenuCategoryID, CurrentPrice = tempdataset.Key.CurrentPrice, FoodItems = tempdataset.ToList()}
	select new { MenuCategoryID = tempdataset.Key.MenuCategoryID, CurrentPrice = tempdataset.Key.CurrentPrice, 
					FoodItems = from x in tempdataset select new {ItemID = x.ItemID, FoodDescription = x.Description, TimeServed = x.BillItems.Count()}}
