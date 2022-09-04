drop table WishList

create table WishList(
WishListId int Identity (1,1)primary key,
UserId INT FOREIGN KEY REFERENCES Users(UserId),
BookId Int Foreign key references Books(BookId)
)

select * from WishList


------Add WishList procedure------

create procedure spAddWishList
(
@UserId int,
@BookId int
)
As
Begin try
insert into WishList (UserId,BookId) values(@UserId,@BookId);
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH


---------Delete WishList---------


create procedure spDeleteWishList
(
@UserId int,
@WishListId int
)
As
Begin try
delete from WishList where WishListId=@WishListId and UserId=@UserId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH


-----WishList GetAll --------


create procedure spGetAllWishList
(
@UserId int
)
As
Begin try 
select WishList.WishListId,WishList.BookId,WishList.UserId,
Books.BookName, Books.Description, Books.AuthorName, Books.ActualPrice, Books.DiscountedPrice, Books.Quantity, Books.BookImage
from WishList inner join Books on WishList.BookId=Books.BookId
where WishList.UserId=@UserId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH