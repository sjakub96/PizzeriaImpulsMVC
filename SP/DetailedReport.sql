--select * from Orders
--select * from OrderDetails

declare @starDate datetime
declare @endDate datetime
declare @productTypeId int
declare @tmpTable table (Name varchar(max), UnitPrice decimal, ProductCount int, Price decimal, OrderDate datetime)

set @productTypeId = 1
set @starDate = '2023-08-21 21:33:35.203'
set @endDate = '2023-09-10 21:33:35.202'

begin
	if @productTypeId = 1
		begin
			insert into @tmpTable
			select p.Name, od.UnitPrice, od.ProductCount, od.Price, o.OrderDate from OrderDetails od
			join Orders o
			on od.OrderId = o.Id
			join Pizzas p
			on od.ProductId = p.Id
			where (o.OrderDate between @starDate and @endDate)
			order by o.OrderDate desc
		end

	else if @productTypeId = 2
		begin
			insert into @tmpTable
			select d.Name, od.UnitPrice, od.ProductCount, od.Price, o.OrderDate from OrderDetails od
			join Orders o
			on od.OrderId = o.Id
			join Drinks d
			on od.ProductId = d.Id
			where (o.OrderDate between @starDate and @endDate)
			order by o.OrderDate desc
		end

	else
		begin
			insert into @tmpTable
			select a.Name, od.UnitPrice, od.ProductCount, od.Price, o.OrderDate from OrderDetails od
			join Orders o
			on od.OrderId = o.Id
			join Additions a
			on od.ProductId = a.Id
			where (o.OrderDate between @starDate and @endDate)
			order by o.OrderDate desc
		end
end

select * from @tmpTable

--splited by days

;with cte as(
select 
Name,
UnitPrice,
OrderDate,
ProductCount = sum(ProductCount) over (partition by Name),
Price = sum(Price) over(partition by Name),
RowNumber = row_number() over(partition by Name order by Name)
from @tmpTable)
select Name, UnitPrice, ProductCount, Price, OrderDate
from cte Where RowNumber = 1