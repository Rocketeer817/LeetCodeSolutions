# Write your MySQL query statement below

select employee_id, (employee_id%2)*(name not like "M%")*salary as bonus
from Employees
order by employee_id;



