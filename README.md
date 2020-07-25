# Website kinh doanh thiết bị công nghệ sử dụng ASP .NET Core MVC

## Công nghệ sử dụng: ASP .NET Core 3.1, SQL Server

## Đường dẫn (có thể không hoạt động): <http://e-mobile-shop.azurewebsites.net/>

## 1. Build trên Windows hoặc Linux: 
### Sử dụng SQL Script trong thư mục Database để restore database, hoặc sử dụng Azure Database Connectionstring dưới đây

"Server=tcp:e-shop.database.windows.net,1433;Initial Catalog=eShopDb;Persist Security Info=False;User ID=admin2;Password=VACha2JKhnsMhDr;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

## 2. Sử dụng Docker:

Image của database: **docker pull lqt1912/emobileshop**

Pull về sau đó mở project từ github lên, chạy lệnh:

**- docker-compose build**

**- docker-compose up**
