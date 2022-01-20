--CREATE proc addAdmin
--@Name nvarchar(255), @Username nvarchar(255), @Password nvarchar(255), @Image image, @Rule nvarchar(255) 
--AS
--INSERT INTO Admin values (@Name,@Username,@Password,@Image,@Rule)

--CREATE proc getDetailAdmin
--@Username nvarchar(255)
--AS
--SELECT * FROM Admin Where Username=@Username

--CREATE proc login
--@Username nvarchar(255), @Password nvarchar(255)
--AS
--SELECT * FROM Admin Where Username=@Username AND Password=@Password

--CREATE proc updateAdmin
--@Name nvarchar(255), @Username nvarchar(255), @Password nvarchar(255), @Image image
--AS
--UPDATE Admin Set Name=@Name, Password=@Password, Image=@Image Where Username=@Username
