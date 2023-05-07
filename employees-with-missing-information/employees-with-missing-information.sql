# Write your MySQL query statement below
select employee_id
from Employees
left join Salaries
using (employee_id)
where  salary is null

union

select employee_id
from Salaries
left join Employees
using (employee_id)
where name is null

order by employee_id;