# Write your MySQL query statement below
select p.product_id
from Products p
where p.low_fats='Y' AND p.recyclable='Y'