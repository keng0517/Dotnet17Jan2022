use Northwind

select * from Products

select ProductName from Products
select ProductName, QuantityPerUnit from Products
select ProductName Product_Name, QuantityPerUnit Quantity_In_Every_Unit from Products

select * from Products where UnitPrice >= 15

select * from Products where UnitPrice >= 15 and UnitPrice <= 25
select * from Products where UnitPrice between 15 and 25
select * from Products where UnitPrice >= 15 and SupplierID = 17

--Select the products that are supplied by 15
--or the unitsonstock is less than 5

select * from Products where SupplierID = 15 OR UnitsInStock <= 5

select * from Products where SupplierID > 5 and SupplierID < 10
select * from Products where SupplierID not in (8, 12, 13, 18)

select * from Products where ProductName = 'Ikura'
select * from Products where ProductName like '%on%'

select avg(unitsinstock) Average_Stock from Products
select avg(unitsinstock) Average_Stock, sum(unitsinstock) 'Total number of units' from Products

--Print the average price of products that are supplied by
--supplier with id 2, 6, 9
select avg(UnitPrice) 'Average Unit Price' from Products where SupplierID = 2 or SupplierID = 6 or SupplierID = 9
select avg(UnitPrice) 'Average Unit Price' from Products where SupplierID in (2, 6, 9)

select count(SupplierId) from Products
select count(distinct SupplierId) from Products

select * from products order by supplierId
select * from products order by supplierId desc
select * from products order by supplierId, UnitsInStock
select * from products order by supplierId, UnitsInStock desc

--Print all the products sorted by supplierid
--where the product name should contain 'e'

select * from products where productName like '%e%' order by SupplierID


select supplierid, count(productid) 'Number of products'
from products
where UnitsInStock > 0
group by SupplierID
order by 'Number of products'

select supplierid, count(productid) 'Number of products'
from products 
where UnitsInStock > 0
group by SupplierID
order by 2

select supplierid, count(productid) 'Number of products'
from products 
where UnitsInStock > 0
group by SupplierID
having count(productid) > 2
order by 2


select * from invoices

--Print the average price of products sold by every salesperson
--if the average is greater than 3
--where thr shipCountry is france and the customer name contains 'e'
--sort the resuly by the salesperson


select Salesperson, round(avg(unitprice),2) Average_Price
from invoices
where ShipCountry = 'France' and CustomerName like '%e%'
group by Salesperson
having avg(unitprice) > 3
order by Salesperson



select * from suppliers

select * from products where supplierid in (4,6)

select * from Products where SupplierID in (
select SupplierId from Suppliers
where Country = 'Germany')

select * from Products where SupplierID = 
(select SupplierId from Suppliers
where CompanyName = 'Tokyo Traders')


--select the average units in stock of products that are supplied by supplier
--whose region name is not null and the average is greater than 3
--sort the result by the average units
select * from Suppliers
select * from Products

select SupplierID, avg(UnitsInStock) Averagefrom Productswhere SupplierID in ( select SupplierID					  from Suppliers					  where Region is not null )group by SupplierIDhaving avg(UnitsInStock) > 3order by Average


--select the products details which are from categroy with name that has 'pro' in it
--and the quantity in stock is greater than 0
--sort the result by the unit price

select *from Productswhere CategoryID in ( select CategoryID					  from Categories					  where CategoryName like '%pro%' )and UnitsInStock > 0order by UnitPrice



select ProductName, [Order Details].UnitPrice, Quantity, [Order Details].UnitPrice*Quantity 'Product Price'
from Products join [Order Details]
on Products.ProductID = [Order Details].ProductID

select ProductName, od.UnitPrice,
Quantity, od.UnitPrice*Quantity 'Product Price'
from Products p inner join [Order Details] od
on p.ProductID = od.ProductID
order by ProductName, Quantity


select c.ContactName 'Customer Name', od.OrderDate 'Order Date'
from Customers c left outer join Orders od
on c.CustomerID = od.CustomerID
order by c.ContactName


select c.ContactName 'Customer Name', od.OrderDate 'Order Date'
from Orders od right outer join Customers c
on c.CustomerID = od.CustomerID
order by c.ContactName


select concat(firstname,' ', lastname) employee_name,
count(orderid) 'Number orders'
from Employees e join orders o
on e.employeeid = o.EmployeeID
group by concat(firstname,' ', lastname)
having count(orderid) > 50
order by 2

--print the orderid and the productName, customerName
--order, orderdetails, product, customer
select c.ContactName 'Customer Name',o.OrderId,p.ProductName , od.UnitPrice*od.Quantity 'Price'
from Customers c left outer join Orders o 
on c.CustomerID = o.CustomerID
left outer join [Order Details] od on od.OrderID = o.OrderID
left outer join Products p on p.ProductID = od.ProductID
order by price

select c.ContactName 'Customer Name',o.OrderId,p.ProductName , od.UnitPrice*od.Quantity 'Price'
from Products p join [Order Details] od
on p.ProductID = od.ProductID
join Orders o  on od.OrderID = o.OrderID
right outer join Customers c on c.CustomerID = o.CustomerID
order by price

select * from Region cross join Shippers

select * from Employees
select EmployeeId, ReportsTo
from Employees

select emp.EmployeeId 'Employee ID' , emp.FirstName 'Employee Name' , 
emp.ReportsTo 'Manager Id', mgr.FirstName 'Manager Name'
from Employees emp join Employees mgr
on emp.ReportsTo = mgr.EmployeeID





