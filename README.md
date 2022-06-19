# My.Maqta.Project

This Project is part of Maqta Test Bacnkend.
I have Implemented it in .NET 6.

I have Used 2 Microservices and API Gateway.
Services are Employee API and Product API.

For Implementing Microservice Architecture ,I have Used OCELOT API Gateway to Manage Ingoing and Outgoing request and responses.

For Employee API , I have used Simple CRUD using EntityFramework Code First Approach.
Although We have other options like Dapper etc as well.
But EF gives us oppurunity to work big in less time.

For Product API,I have use hard code data just to Add microservice APIs layers and for Lazy loading in Angular app(link below).

Front end Angular APP : https://github.com/mohsinafridi/My-Maqta-Test-FrontEnd

## Clone
Please Clone the application.
Sln file is in My.Maqta.Project Folder.

API Gateway is running on 5003 port.
Employee API is running on 5001.
Product API is running on 5002.


I have also added Unit tests Project separatly.


## Postman APIs:

Product API : https://localhost:5003/Product
Product API : https://localhost:5003/employee
