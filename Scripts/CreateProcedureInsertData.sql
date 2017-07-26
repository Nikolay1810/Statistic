create procedure insertDataTables
as
Declare @num int;
Declare @num_client int;
Declare @rund_numb int;
Declare @clientId int;
Declare @ordersId int;
Declare @randomProduct int;
Declare @randomQuantity int;
Declare @randomPrice float;
Declare @numForOrderString int;
Declare @cycle int;


delete from OrderString;
delete from Product;
delete from Orders
delete from Client;
delete from Category;

DBCC CHECKIDENT (Category, RESEED, 0);
DBCC CHECKIDENT (Client, RESEED, 0);
DBCC CHECKIDENT (Orders, RESEED, 0);
DBCC CHECKIDENT (OrderString, RESEED, 0);
DBCC CHECKIDENT (Product, RESEED, 0);

insert into Category(CategoryName) values ('Обычный');
insert into Category(CategoryName) values ('Средний');
insert into Category(CategoryName) values ('Топ');
insert into Category(CategoryName) values ('ВИП');

set @num = 1;
while @num <= 5000
begin
	insert into Product (ProductName) values ('Товар '+ Cast(@num as varchar(5)));
	set @num = @num+1;
end

set @num = 1;

while @num <= 100
begin

	insert into Client (Name, Adress, CategoryId) values ('Клиент ' + Cast(@num as varchar(5)), 'Адрес '+ Cast(@num as varchar(5)), 1);
	set @clientId = (SELECT IDENT_CURRENT('Client'));
	set @num_client = 1;
	set @rund_numb = (Rand()*100)/2;
	if(@rund_numb < 5)
	begin
		set @rund_numb = @rund_numb + 5;
	end
	while @num_client <= @rund_numb 
	begin
		insert into Orders (ClientCode, OrederDate) values (@clientId, '07/04/2017');
		set @ordersId = (SELECT IDENT_CURRENT('Orders'));
		set @cycle = Rand()*100;
		if(@cycle < 1)
		begin
			set @cycle = 1;
		end

		set @numForOrderString = 1;

		while @numForOrderString <= @cycle
		begin
			set @randomQuantity = Rand()*100;
			if(@randomQuantity < 1)
			begin
				set @randomQuantity = 1;
			end

			set @randomProduct = Rand()*5000;
			set @randomPrice = Rand() + @randomQuantity;
			insert into OrderString(OrderCode, ProductCode, Price, Quantity, TotalAmount) values (@ordersId, @randomProduct, Round(@randomPrice, 2), @randomQuantity, Round(@randomPrice*@randomQuantity, 2));
			set @numForOrderString = @numForOrderString + 1;
		end
		set @num_client = @num_client + 1;
	end
	
	set @num = @num+1;
end