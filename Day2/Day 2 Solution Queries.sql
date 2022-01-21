--1) Select all the author's details
select * from authors

--2) print all the author's full name
select concat(au_lname,' ',au_fname) 'Full Name' from authors

--3) Print the average price , total price of all the titles
select avg(price) 'Average Price', sum(price) 'Total Price' from titles

--4) Print the average price of a titles published by '0736'
select avg(price) 'Average Price' from titles
where pub_id = 0736

--5) print the titles whicha have advance min of 3200 and maximum of 5000
select * from titles
where advance between 3200 and 5000

--6) Print the titles which are of type 'psychology' or 'mod_cook'
select * from titles
where type = 'psychology' or type = 'mod_cook'

--7) print all titles published before '1991-06-09 00:00:00.000'
select * from titles
where pubdate < '1991-06-09 00:00:00.000'

--8) Select all the authors from 'CA'
select * from authors 
where state = 'CA'

--9) Print the average price of titles in every type
select type, avg(price) 'Average price' from titles
group by type

--10) print the sum of price of all the books pulished by every publisher
select pub_id, sum(price) 'Sum of price' from titles
group by pub_id

--11) Print the first published title in every type
select type, min(pubdate) 'Published Date' from titles
group by type



--12) calculate the total royalty for every publisher
select pub_id, sum(royalty) 'Total Royalty' from titles
group by pub_id

--13) print the titles sorted by published date
select * from titles
order by pubdate

--14) print the titles sorted by publisher then by price
select * from titles
order by pub_id, price

--15) Print the books published by authors from 'CA'
select * from titles
where title_id in (
	select title_id from titleauthor where au_id in (
		select au_id from authors where state = 'CA'
		)
	)

--16) Print the author name of books whcih have royalty more than the average royalty of all the titletes
select concat(au.au_lname,' ',au.au_fname) 'Author name', sum(t.royalty) 'Total Royalty'
from titles t join titleauthor ta
on t.title_id = ta.title_id join authors au
on ta.au_id = au.au_id
where t.royalty is not null
group by concat(au.au_lname,' ',au.au_fname)
having sum(t.royalty) > avg(t.royalty)
order by concat(au.au_lname,' ',au.au_fname)

--correct answer
select concat(au_fname,' ',au_lname) from authors where au_id in
(select au_id from titleauthor where title_id in
(select title_id from titles where royalty >
(select avg(royalty) from titles)))


--17) Print all the city and the number of pulishers in it, only if the city has more than one publisher
select city, count(pub_id) 'Number of Publishers' from publishers
group by city
having count(pub_id) > 1



--18) Print the total number of orders for every title
select t.title, sum(s.qty) 'Total orders'
from titles t inner join sales s
on t.title_id = s.title_id
group by t.title

--19) Print the total number of titles in evry order
select s.ord_num, count(t.title) 'Total Number of Titles'
from titles t join sales s
on t.title_id = s.title_id
group by s.ord_num


--20) Print the order date and the title name
select t.title, s.ord_date
from titles t join sales s
on t.title_id = s.title_id 
order by t.title

--21) Print all the title names and publisher names
select t.title, p.pub_name 'Publisher Name'
from titles t join publishers p
on t.pub_id = p.pub_id

--22) print all the publisher names(even if they have not published) and the title names that they have published
select t.title, p.pub_name 'Publisher Name'
from titles t join publishers p
on t.pub_id = p.pub_id
where t.price is null

--23) print the title id and the number of authors contributing to it
select title_id, count(au_id) 'Number of authors'
from titleauthor
group by title_id

--24) Print the title name and the author name
select t.title, concat(au.au_lname,' ',au.au_fname) 'Author Name'
from titles t join titleauthor ta
on t.title_id = ta.title_id join authors au
on ta.au_id = au.au_id


--25) print the title name, author name and the publisher name
select t.title, concat(au.au_lname,' ',au.au_fname) 'Author Name', p.pub_name 'Publisher Name'
from publishers p join titles t
on p.pub_id = t.pub_id  join titleauthor ta
on t.title_id = ta.title_id join authors au
on ta.au_id = au.au_id

--26) print the title name author name, publisher name, orderid, order date, quantity ordered and the total price
select t.title, concat(au.au_lname,' ',au.au_fname) 'Author Name', p.pub_name 'Publisher Name', 
s.ord_num 'Order Id', s.ord_date 'Order Date', s.qty, t.price
from publishers p join titles t
on p.pub_id = t.pub_id join sales s
on t.title_id = s.title_id join titleauthor ta
on t.title_id = ta.title_id join authors au
on ta.au_id = au.au_id 


--27) given a title name print the stores in which it was sold
select t.title, s.stor_id, st.stor_name, s.payterms
from titles t join sales s
on t.title_id = s.title_id join stores st
on s.stor_id = st.stor_id
where t.title like '%B%' and s.payterms like '%NET%'


--28) Select the stores who have taken morethan 2 orders
select st.stor_id, st.stor_name, count(s.ord_num) 'Number of orders'
from sales s join stores st
on s.stor_id = st.stor_id 
group by st.stor_id, st.stor_name
having count(ord_num) > 2
order by st.stor_id

--answer from miss
select stor_id, count(ord_num) 'Number of orders' 
from sales
group by stor_id
having count(ord_num) > 2



--29) Select all the titles and print the first order date (titles that have not be ordered should also be present)
select t.title, min(s.ord_date) 'First Order Date'
from titles t left outer join sales s
on t.title_id = s.title_id
group by t.title



--30) select all the data from the orderes and the authors table (cross join)
select * 
from sales cross join authors







