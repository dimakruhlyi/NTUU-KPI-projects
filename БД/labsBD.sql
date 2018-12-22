use mydb;
drop database mydb;

SET SQL_SAFE_UPDATES = 0;

insert into Topic(name_topic) values ("Topic name");
insert into Topic(name_topic) values ("Topic name1");
insert into Topic(name_topic) values ("Topic name2");
insert into Topic(name_topic) values ("Topic name3");
insert into Topic(name_topic) values ("Topic name4");
insert into Topic(name_topic) values ("Topic name5");

insert into employees(emp_no,full_name, group_student) values ("s01","Nazar", "TR-61");
insert into employees(emp_no,full_name, group_student) values ("s02","Gosha", "TR-62");
insert into employees(emp_no,full_name, group_student) values ("s03","Sorax", "TR-63");
insert into employees(emp_no,full_name, group_student) values ("s04","Topic name3", "TR-64");
insert into employees(emp_no,full_name, group_student) values ("s05","Topic name4", "TR-65");

#Транзакция

SET session TRANSACTION ISOLATION LEVEL read committed;
SET session TRANSACTION ISOLATION LEVEL repeatable read;
#SET SESSION TRANSACTION ISOLATION LEVEL serializable;
#SELECT @@GLOBAL.tx_isolation;
SHOW VARIABLES LIKE '%tx_isolation%';

START transaction;
	insert into employees(emp_no,full_name, group_student) values ("s15","Leonid", "TR-81");
	select * from employees where emp_no = "s15";
rollback;
	select * from employees where emp_no = "s15";
    insert into employees(emp_no,full_name, group_student) values ("s15","Leonid", "TR-82");
commit;
	select * from employees where emp_no = "s15";


delete from employees  where emp_no = "s15";

select *from topic;

select *from employees;

select full_name from employees where emp_no = "S02";

select employees.Full_Name, topic.name_topic from employees, topic where  employees.Full_Name = topic.name_topic;
select employees.Full_Name, topic.name_topic from employees, topic where Emp_No = "s02";

select *from topic where name_topic not in (select full_name from employees);

delete from topic  where name_topic = "Topic name";


#Представлення
create view v1 as select topic.Name_Topic, employees.Full_Name  from topic, employees;
select *from v1;

drop view v1;
#Курсори    
select *from table1;

call cursors();

delimiter //
create procedure cursors()
begin
  declare done INT DEFAULT 0;
  declare a CHAR(20);
  declare b CHAR(20);
  declare cur1 cursor for select name_topic from topic;
  declare cur2 cursor for select full_name from employees;
  declare continue handler for sqlstate '02000' set done = 1;

  open cur1;
  open cur2;

repeat
    fetch cur1 into a;
    fetch cur2 into b;
    if not done then
       if a = b then
         insert into table1(table1col) values (a);
       end if;
    end if;
until done end repeat;

  close cur1;
  close cur2;
end//

drop procedure cursors;

#Процедури
call proc1(10);

delimiter //
create procedure proc1(IN num INT)
	begin
		declare x INT;
        SET x = 6;
        loop_label: loop
        insert into topic(name_topic) values ("Topic name");
        SET x = x + 1;
        if x >= num 
        then leave loop_label;
        end if;
        end loop;
	end //
    
drop procedure proc1;

call proc2("Topic name6");

delimiter //
create procedure proc2(val char(20))
	begin
		if (select Count(*) from topic where topic.name_topic = val) then
			select name_topic from topic where name_topic = val;
		else
		   insert into topic(name_topic) values(val);
		end if;
	end; //
    
drop procedure proc2;
