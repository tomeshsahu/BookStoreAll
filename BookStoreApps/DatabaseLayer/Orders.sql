create table Orders(
OrderId int identity(1,1)Primary key,
BookId int Foreign Key references Books(BookId),
UserId int Foreign Key references Users(UserId),
AddressId int Foreign key references AddressTable(AddressId),
OrderBookQuantity int,
OrderDate Date not null,
Totalprice float
)

select * from Orders


-----create StoreProcedure---------

create procedure spAddOrder(
	@OrderBookQuantity int,
	@UserId int,
	@BookId int,
	@AddressId int
)
as
Declare @TotalPrice int
begin
		set @TotalPrice = (select DiscountedPrice from Books where BookId = @BookId);
		If(Exists(Select * from Books where BookId = @BookId))
			begin
			If(Exists (Select * from Users where UserId = @UserId))
				BEGIN
					Begin try
						Begin Transaction
						Insert Into Orders(Totalprice, OrderBookQuantity, OrderDate, UserId, BookId, AddressId)
						Values(@TotalPrice*@OrderBookQuantity, @OrderBookQuantity, GETDATE(), @UserId, @BookId, @AddressId);
						Update Books set Quantity=Quantity-@OrderBookQuantity where BookId = @BookId;
						Delete from Cart where BookId = @BookId and UserId = @UserId;
						select * from Orders;
commit Transaction
					End try
					Begin Catch
							rollback; 
					End Catch
				end
			Else
				Begin
					Select 3;
				End
		End
	Else
		Begin
			Select 2;
		End
end;

select * from Orders


---------------------GetAllOrder---------

drop proc SPGetOrders

alter procedure spGetOrders
(
	@UserId int
)
as
begin
		Select 
		O.OrderId,O.UserId, O.AddressId, b.bookId,
		O.TotalPrice, O.OrderBookQuantity, O.OrderDate,
		b.BookName, b.AuthorName, b.BookImage
		FROM Books b
		inner join Orders O on O.BookId = b.BookId 
		where 
			O.UserId = @UserId;
end;