<Query Kind="Expression">
  <Connection>
    <ID>3faee7fc-03e7-4689-a676-83fa50752e0a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from x in Items
where x.CurrentPrice > 5.00m
select new{x.Description, x.Calories}
