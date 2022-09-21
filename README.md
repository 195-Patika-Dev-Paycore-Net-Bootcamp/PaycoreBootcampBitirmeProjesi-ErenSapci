# PaycoreBootcampBitirmeProjesi-ErenSapci
## Details In The Final Project
* In this project, a design was created in which users can register and users who are registered can log in.
* Passwords from the user are kept in the database in an encrypted state.
* The logged in user can add products within the system and can bid on the products sold by other users.
* Instead of making an offer, the user can buy the products directly by paying the value of the products.
* There are also 2 APIs where users can check the offers they receive. If the user does not want to sell the product, he can refuse with the reject offer or accept the offer with the accept offer.
* When users log in, e-mail is sent to the user via the e-mail service. This mail service is implemented in many APIs.

## Execution Of The Project

* First We Clone The Project

```
git clone 195-Patika-Dev-Paycore-Net-Bootcamp/PaycoreBootcampBitirmeProjesi-ErenSapci
```

* Run the project using Visual Studio or similar IDEs

* For database connection from appsetttings file, adapt the connectionstring according to your own database.

```
"AllowedHosts": "*",
  "ConnectionStrings": {
    "PostgreSqlConnection": "User ID=postgres;Password=123;Server=localhost;Port=5432;Database=bootcampfinalprojectdb;Integrated Security=true;Pooling=true;"
```

* To access the database tables of the project, 
you can implement the data in Init.sql that we have 
implemented in the project in PostgreSql. In addition, our project is designed to create tables by itself without implementing this data.

* Db data is not intentionally added to the project file. Because the password information given by the user is in an encrypted state, you cannot access users who have not registered before. 
### Some screenshots of the project are as follows:

* Product and User block hierarchy:

<img width="549" alt="Product-User" src="https://user-images.githubusercontent.com/43892645/191609850-4c915082-4939-4195-9da5-4aca8e48d7c7.PNG">

* Category and Offer block  hierarchy:

<img width="549" alt="Category-Offer" src="https://user-images.githubusercontent.com/43892645/191609963-8e318666-74e6-4fb0-9285-5cfc98aa7614.PNG">

* User Registeration:

<img width="546" alt="User-Register" src="https://user-images.githubusercontent.com/43892645/191610059-b9f2b0d2-3992-4de2-9961-12b9be1e219b.PNG">

* User Login

<img width="539" alt="Login" src="https://user-images.githubusercontent.com/43892645/191610121-51d05213-d92b-4036-97bd-77e311e06a92.PNG">

* Password Encryption:

<img width="568" alt="HashPassword" src="https://user-images.githubusercontent.com/43892645/191610238-feec03f6-ce36-4aea-8ca2-0f590d4a92f0.PNG">

* Mail Service:
* As you can see in this section, we keep the status of the mails. A random method was followed in the determination of these conditions.

<img width="734" alt="MailService" src="https://user-images.githubusercontent.com/43892645/191610489-ef7cb07f-a696-49df-98e5-d81a7fdf2f81.PNG">
