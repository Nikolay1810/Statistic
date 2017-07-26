--drop database ShopInvert;
create database ShopInvert;
use ShopInvert;

create table Client(
ClientCode int identity primary key,
Name varchar(60),
Adress varchar(60),
CategoryId int,
foreign key (CategoryId) references Category(Id),
 );

create table Category(
Id int identity primary key,
CategoryName varchar(30)
);

create table Product(
ProductCode int identity primary key,
ProductName varchar(30),
);

create table Orders(
OrderCode int identity primary key,
ClientCode int,
OrederDate date,
foreign key (ClientCode) references Client(ClientCode)
);

create table OrderString(
StringCode int identity primary key,
OrderCode int,
ProductCode int,
Price float,
Quantity int,
TotalAmount float,
foreign key (OrderCode) references Orders(OrderCode),
foreign key (ProductCode) references Product(ProductCode)
);

insert into Category(CategoryName) values ('Обычный');
insert into Category(CategoryName) values ('Средний');
insert into Category(CategoryName) values ('Топ');
insert into Category(CategoryName) values ('ВИП');

--exec insertDataTables;

--insert into Orders(ClientCode) values (1);
--insert into Orders(ClientCode) values (1);
--insert into Orders(ClientCode) values (1);
--insert into Orders(ClientCode) values (1);
--insert into Orders(ClientCode) values (1);

--delete from OrderString;
--delete from Product;
--delete from Orders
--delete from Client;
--delete from Category;


--DBCC CHECKIDENT (Category, RESEED, 0);
--DBCC CHECKIDENT (Client, RESEED, 0);
--DBCC CHECKIDENT (Orders, RESEED, 0);
--DBCC CHECKIDENT (OrderString, RESEED, 0);
--DBCC CHECKIDENT (Product, RESEED, 0);

