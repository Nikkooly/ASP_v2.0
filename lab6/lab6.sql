create database WSYNS
use WSYNS
create table Student
(
	Id int identity(1,1) primary key,
	Name nvarchar(max)
)

create table Note
(
	Id int identity(1,1) primary key,
	Subj nvarchar(max),
	Note int null,
	StudentId int not null foreign key 
	references Student(Id)
)
insert into Student values 
('Nickolay'), 
('Vitaliy'), 
('Alex'),
('Maksim'),
('Andrey'),
('Yan')

insert into Note(Subj,Note,StudentId) values
('PMMP', 10, 1),
('PIA', 4, 1),
('Bisness', 7, 1),
('PMMP', 8, 2),
('PIA', 8, 2),
('Bisness', 8, 2),
('PMMP', 5, 3),
('PIA', 5, 3),
('Bisness', 6, 3)

alter table Note
add constraint Fk_Note_Student_id___Cascade
foreign key (StudentId) references Student(id) on delete cascade

