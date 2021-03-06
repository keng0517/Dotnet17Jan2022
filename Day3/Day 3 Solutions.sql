------------------------------------------------------------------------------------------------------------

--1) Select the author firtname and last name
select concat(au_fname, ' ', au_lname) 'Author Name' from authors

--2) Sort the titles by the title name in descending order and print all the details
select * from titles
order by title desc

--3) Print the number of titles published by every author
select au_id, count(title_id)'Number of titles'
from titleauthor
group by au_id

--4) print the author name and title name
select concat(au.au_fname, ' ', au.au_lname) 'Author Name', t.title
from titles t join titleauthor ta
on t.title_id = ta.title_id join authors au
on ta.au_id = au.au_id


--5) print the publisher name and the average advance for every publisher
select * from titles

select p.pub_name, avg(t.advance) 'Average advance'
from titles t join publishers p
on t.pub_id = p.pub_id
group by p.pub_name

--6) print the publishername, author name, title name and the sale amount(qty*price)
select p.pub_name, concat(au.au_fname, ' ', au.au_lname) 'Author Name', t.title, s.qty*t.price 'Sale Amount'
from publishers p join titles t
on p.pub_id = t.pub_id join sales s
on s.title_id = t.title_id join titleauthor ta
on ta.title_id = t.title_id join authors au
on au.au_id = ta.au_id



--7) print the price of all that titles that have name that ends with s
select title, price
from titles
where title like '%s'


--8) print the title names that contain 'and' in it 
select title 
from titles
where title like '%and%'

--9) print the employee name and the publisher name
select concat(e.fname, ' ',e.lname) 'Employee Name', p.pub_name
from publishers p join employee e
on p.pub_id = e.pub_id

--10) print the publisher name and number of employees woking in it if the publisher has more than 2 employees
select p.pub_name, count(e.emp_id) 'Number of employee'
from publishers p join employee e
on p.pub_id = e.pub_id
group by p.pub_name
having count(e.emp_id) > 2

--11) Print the author names who have published using the publisher name 'Algodata Infosystems'
select concat(au.au_fname, ' ', au.au_lname) 'Author Name', p.pub_name
from publishers p join titles t
on p.pub_id = t.pub_id join sales s
on s.title_id = t.title_id join titleauthor ta
on ta.title_id = t.title_id join authors au
on au.au_id = ta.au_id
where p.pub_name = 'Algodata Infosystems'


--12) Print the employees of the publisher 'Algodata Infosystems'
select concat(e.fname, ' ',e.lname) 'Employee Name', p.pub_name
from publishers p join employee e
on p.pub_id = e.pub_id
where p.pub_name = 'Algodata Infosystems'


--14)Create the following tables
--Employee(id-identity starts in 100 inc by 1,
--Name,age, phone cannot be null, gender)
create table Employee(
	emp_id		int			not null	identity(100, 1) primary key,
	emp_name	varchar(50),
	emp_age		int,
	phone		char(11)	not null,
	gender		char(1)
)
	
--Salary(id-identity starts at 1 increments by 100,
--Basic,Dearness allowance(da), House Rent Allowance(hra),deductions)
create  table Salary(
	sal_id		int			not null	identity(1, 100) primary key,
	sal_basic	float,
	hra			float,
	da			float,
	deductions	float
)


--EmployeeSalary(transaction_number int,
--employee_id-reference Employee's Id 
--Salary_id reference Salary Id,
--Date)

--PS - In the emeployee salary table transaction number is the primary key
--the combination of employee_id, salary_id and date should always be unique
create table EmployeeSalary(
	trans_no	int		not null	primary key,
	emp_id		int		references Employee(emp_id),
	sal_id		int		references Salary(sal_id),
	date		datetime	unique
)


--Add a column email-varchar(100) to the employee table
alter table employee
add email varchar(100) 

--Insert few records in all the tables
insert into employee (emp_name, emp_age, phone, gender, email) values ('Johnson', 18, '1231231123', 'M', 'johnson@email.com')
insert into employee (emp_name, emp_age, phone, gender, email) values ('Albert Liew', 22, '54564567', 'F', 'liew@email.com')
insert into employee (emp_name, emp_age, phone, gender, email) values ('Michael Lim', 65, '678687897', 'M', 'lim@email.com')

insert into salary (sal_basic, hra, da, deductions) values (2000, 200, 200, 100)
insert into salary (sal_basic, hra, da, deductions) values (3500, 300, 200, 250)
insert into salary (sal_basic, hra, da, deductions) values (4500, 300, 200, 300)
insert into salary (sal_basic, hra, da, deductions) values (224500, 300, 200, 300)

insert into EmployeeSalary (trans_no, emp_id, sal_id, date) values (1, 100, 1, '2021-09-14 00:00:00.000')
insert into EmployeeSalary (trans_no, emp_id, sal_id, date) values (2, 101, 101, '2021-03-12 00:00:00.000')
insert into EmployeeSalary (trans_no, emp_id, sal_id, date) values (3, 102, 201, '2021-11-29 00:00:00.000')
insert into EmployeeSalary (trans_no, emp_id, sal_id, date) values (4, 101, 201, '2021-04-29 00:00:00.000')
insert into EmployeeSalary (trans_no, emp_id, sal_id, date) values (5, 101, 301, '2021-04-27 00:00:00.000')


--Create a procedure which will print the total salary of employee by taking the employee id and the date
--total = Basic+HRA+DA-deductions
create proc proc_totalSalaryCalculator(@emp_id int, @date datetime)
as
begin
	declare
	@total float

	set @total = (select sum(s.sal_basic + s.hra + s.da - s.deductions) total_salary from employee e join employeesalary es
						on e.emp_id = es.emp_id join salary s
						on s.sal_id = es.sal_id
						where e.emp_id = @emp_id and es.date = @date)

	print 'Total Salary: ' + cast(@total as varchar(20))
	
end

exec proc_totalSalaryCalculator 101, '2021-03-12 00:00:00.000'



--Create a procudure which will calculate the average salary of an employee taking his ID
create proc procAverageSalaryCalculator(@emp_id int)
as
begin
	declare
	@averageSalary float,
	@totalSalary float,
	@timesOfSalary int

	set @totalSalary = (select sum(s.sal_basic + s.hra + s.da - s.deductions) total_salary from employee e join employeesalary es
						on e.emp_id = es.emp_id join salary s
						on s.sal_id = es.sal_id
						where e.emp_id = @emp_id)

	set @timesOfSalary = (select count(es.emp_id) from employee e join employeesalary es
						on e.emp_id = es.emp_id join salary s
						on s.sal_id = es.sal_id
						where e.emp_id = @emp_id
						group by es.emp_id)

	set @averageSalary = @totalSalary / @timesOfSalary


	print 'Total Salary: ' + cast(@totalSalary as varchar(20))
	print 'Total times of salary released: ' + cast(@timesOfSalary as varchar(20)) + ' times'
	print 'Average Salary: ' + cast(@averageSalary as varchar(20))

end


exec procAverageSalaryCalculator 101



--Create a procedure which will catculate tax payable by employee
--Slabs as follows
--total - 100000 - 0%
--100000 > total < 200000 - 5%
--200000 > total < 350000 - 6%
--total > 350000 - 7.5%


create proc taxCalculator(@emp_id int, @date datetime)
as
begin
	declare
	@total float,
	@taxRate float,
	@tax float


	set @total = (select s.sal_basic + s.hra + s.da - s.deductions from employee e join employeesalary es
						on e.emp_id = es.emp_id join salary s
						on s.sal_id = es.sal_id
						where e.emp_id = @emp_id and es.date = @date)

	print 'Total Salary: ' + cast(@total as varchar(20))

	if (@total < 100000)
		set @taxRate = 0
	else if (@total >= 100000 and @total < 200000)
		set @taxRate = 0.05
	else if (@total >= 200000 and @total < 350000)
		set @taxRate = 0.06
	else
		set @taxRate = 0.075

	set @tax = @total * @taxRate

	print 'Tax Percentage: '+ cast(@taxRate as varchar(20)) +'%'
	print 'Total tax payable: '+ cast(@tax as varchar(20))

end

exec taxCalculator 101, '2021-04-27 00:00:00.000'




--15) Create a function that will take the basic,HRA and da returns the sum of the three
create function fnSumofSalary (@basic float, @hra float, @da float)
returns float
as
begin
	declare
	@total float

	set @total = @basic + @hra + @da

	return @total
end

select dbo.fnSumofSalary(200000, 2000, 200) 'Sum of Salary'


--16) Create a cursor that will pick up every employee and print his details 
--then print all the entries for his salary in the employeesalary table. 
--Also show the salary splitt up(Hint-> use the salary table)
declare
@e_emp_id		int,
@e_emp_name	varchar(50),
@e_emp_age	int,
@e_phone		char(11),
@e_gender		char(1),
@e_email		varchar(100)

declare cur_employee cursor for select * from employee
open cur_employee
fetch next from cur_employee into @e_emp_id, @e_emp_name, @e_emp_age, @e_phone, @e_gender, @e_email

	while(@@FETCH_STATUS = 0)
	begin
		print '====================================================='
		print 'Employee ID			: '+ cast(@e_emp_id as varchar(20))
		print 'Employee Name		: '+ cast(@e_emp_name as varchar(20))
		print 'Employee Age			: '+ cast(@e_emp_age as varchar(20))
		print 'Phone				: '+ cast(@e_phone as varchar(20))
		print 'Gender				: '+ cast(@e_gender as varchar(20))
		print 'Email				: '+ cast(@e_email as varchar(20))
		print '-----------------------------------------------------'

		declare 
		@es_trans_no int,
		@es_emp_id int,
		@es_sal_id int,
		@es_date datetime,
		@s_sal_basic float,
		@s_hra float,
		@s_da float,
		@s_deduction float,
		@sum_salary float


		declare cur_transDetails cursor for select es.trans_no, es.emp_id, es.sal_id, es.date, s.sal_basic, s.hra, s.da, s.deductions
		from employeesalary es join salary s
		on es.sal_id = s.sal_id
		where emp_id = @e_emp_id

		open cur_transDetails
		fetch next from cur_transDetails into @es_trans_no, @es_emp_id, @es_sal_id, @es_date, @s_sal_basic, @s_hra, @s_da, @s_deduction

		while(@@FETCH_STATUS = 0)
		begin
			print 'Transaction Number			: ' +cast(@es_trans_no as varchar(20))
			print 'Transaction Date				: ' +cast(@es_date as varchar(20))
			print 'Employee ID					: ' +cast(@es_emp_id as varchar(20))
			print 'Salary ID					: ' +cast(@es_sal_id as varchar(20))
			print 'Basic Salary					: ' +cast(@s_sal_basic as varchar(20))
			print 'Hourse Rent Allowance(HRA)	: ' +cast(@s_hra as varchar(20))
			print 'Dearness Allowance(DA)		: ' +cast(@s_da as varchar(20))
			print 'Deductions					: ' +cast(@s_deduction as varchar(20))
			print '====================================================='

			fetch next from cur_transDetails into @es_trans_no, @es_emp_id, @es_sal_id, @es_date, @s_sal_basic, @s_hra, @s_da, @s_deduction
		end

		close cur_transDetails
		deallocate cur_transDetails


		fetch next from cur_employee into @e_emp_id, @e_emp_name, @e_emp_age, @e_phone, @e_gender, @e_email
	end

close cur_employee
deallocate cur_employee



--17) https://www.hackerrank.com/challenges/maximum-element/problem



--18) https://www.geeksforgeeks.org/find-if-there-is-a-subarray-with-0-sum/

