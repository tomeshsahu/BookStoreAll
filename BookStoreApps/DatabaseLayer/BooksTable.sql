use BookStoreApp

drop table Books

alter table Books(
BookId int identity(1,1)Primary key,
BookName varchar(100),
Description varchar(max),
AuthorName varchar(50),
ActualPrice float,
DiscountedPrice float,
Quantity int,
BookImage varchar(max),
TotalRating float,
CountRating float
);


select * from Books
drop table Books

DROP PROCEDURE spAddBook;  
GO
--------------AddBook StoreProcedure-----------

alter procedure spAddBook(  
@BookName varchar(100),
@Description varchar(max),   
@AuthorName varchar(50),  
@ActualPrice float,  
@DiscountedPrice float,
@Quantity int,  
@BookImage varchar(max),
@TotalRating float,
@CountRating float
)  
As  
Begin try  
insert into Books(BookName,Description,AuthorName,ActualPrice,DiscountedPrice,Quantity,BookImage,TotalRating,CountRating) values(@BookName,@Description,@AuthorName,@ActualPrice,@DiscountedPrice,@Quantity,@BookImage,@TotalRating,@CountRating)  
end try  
Begin catch  
SELECT   
 ERROR_NUMBER() AS ErrorNumber,  
 ERROR_STATE() AS ErrorState,  
 ERROR_PROCEDURE() AS ErrorProcedure,  
 ERROR_LINE() AS ErrorLine,  
 ERROR_MESSAGE() AS ErrorMessage;  
END CATCH


-----------GetAll StoreProcedure-----------


create procedure spGetAllBooks
As
Begin try
select * from Books
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

exec spGetAllBooks


---------------DeleteBook-----------

create procedure spDeleteBooks(@BookId int)
As
Begin try
delete from Books where BookId=@BookId;
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH


--------------GetBookById-----------

create procedure spGetBookById(@BookId int)
As
Begin try
select * from Books where BookId=@BookId;
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH



----------UpdateBook----------

alter procedure spUpdateBook(
@BookId int,
@BookName varchar(100),
@Description varchar(max),   
@AuthorName varchar(50),  
@ActualPrice float,  
@DiscountedPrice float,
@Quantity int,  
@BookImage varchar(max),
@TotalRating float,
@CountRating float
)
As
Begin try
update Books set BookName=@BookName,Description=@Description,AuthorName=@AuthorName,ActualPrice=@ActualPrice,DiscountedPrice=@DiscountedPrice,Quantity=@Quantity,BookImage=@BookImage,@TotalRating=@TotalRating,CountRating=@CountRating where BookId=@BookId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH