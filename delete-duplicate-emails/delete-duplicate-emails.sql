# Please write a DELETE statement and DO NOT write a SELECT statement.
# Write your MySQL query statement below

delete p1.*
from Person p1
inner join  Person p2
using (email)
where p1.id>p2.id;



