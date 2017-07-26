create trigger setStatus on Orders for insert
as

Declare @clientId int;
Declare @quantity int;

select @clientId = ClientCode from inserted;
select @quantity = Count(*) from Orders where ClientCode = @clientId;

if(@quantity <= 5)
begin
	update Client set CategoryId = 1 where ClientCode = @clientId;
end

if(@quantity > 5 AND @quantity <= 30)
begin
	update Client set CategoryId = 2 where ClientCode = @clientId;
end

if(@quantity > 30 AND @quantity <= 40)
begin
	update Client set CategoryId = 3 where ClientCode = @clientId;
end

if(@quantity > 40)
begin
	update Client set CategoryId = 4 where ClientCode = @clientId;
end