
backup database DB_PLANO_DEV to disk= N'C:\TFS\Plan360\BD\BKP.BAK'

select * from [plan]
select * from PlanProduct
where idplan=26

select * from PlanAgent
select * from PlanEntity
select * from PlanEntityCount
select * from PlanParameter


delete [plan]
delete PlanProduct
delete PlanAgent
delete PlanEntity
delete PlanEntityCount
delete PlanParameter
