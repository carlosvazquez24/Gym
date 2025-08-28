# 🏋️‍♂️ Gym Manager

This project is a **management system for public gyms**, developed in **MVC .NET Core** with **Entity Framework Core** and **MySQL**.  
Allow to manager members, memberships, access and more

---

## 📌 Features

### Login
![imagen](images/Screenshot_179.png) 

### Member register and managment

- Create Member
![imagen](images/Screenshot_186.png) 

- Member List
![imagen](images/Screenshot_187.png) 


### Memberships control (Active/Expired)

- Membership control list
![imagen](images/Screenshot_189.png) 

- Renew membership (You can select the new membership and you will se the new expiration date)
![imagen](images/Screenshot_190.png) 

### Attendance management (Check in/Check Out)

- Attendance panel
![imagen](images/Screenshot_191.png) 

- When a User with a EXPIRED membership try to check in... the system will not register and suggest renew the membership
![imagen](images/Screenshot_199.png) 

- But when a user with an ACTIVE membership try to check in... the systems will register the attendance 
![imagen](images/Screenshot_199.png) 


### Reports (Prototype)

-HTML Reports
![imagen](images/Screenshot_192.png) 

![imagen](images/Screenshot_193.png) 

- PDF Reports
![imagen](images/Screenshot_194.png) 

![imagen](images/Screenshot_195.png) 


### Dark/Light mode switch
- Dark mode
![imagen](images/Screenshot_196.png) 

- Light mode
![imagen](images/Screenshot_197.png) 


### Other CRUDS

- Membership Types List
![imagen](images/Screenshot_188.png)

- Equipment Types List
![imagen](images/Screenshot_198.png) 

---

## ⚙️ Tecnologhies used

- [.NET 6/7](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [MySQL](https://www.mysql.com/)


---

## 🚀 Instalation and execution

### Create a database in your MYSQL local enviroment

![imagen](images/Screenshot_174.png)


### Clone the repsoitory, then, enter to GymManager.Web.sln file

![imagen](images/Screenshot_173.png)


### In Visual Studio, go to GymManager.Web project and modifiy the string connection in the appsettings.json file, replacing your database name and MYSQL credentials

![imagen](images/Screenshot_172.png)


### Be sure you had the GymManager.Web like the default project. 
![imagen](images/Screenshot_175.png)

### Open the Package Manager Console and select GymManager.DataAccess like default project
![imagen](images/Screenshot_176.png) 

### Run the next Command:
![imagen](images/Screenshot_177.png) 

### The database migration has been applied successfully !
![imagen](images/Screenshot_178.png) 

### Now you cant test the App. Click on the Play green button
![imagen](images/Screenshot_181.png)

### You will see the login page. 
You can use the next credentials:
username: carlosEliam@gmail.com (This is not my email, it's just a random email, it's not verified)
<br>
<br>
password: Tacos123*

![imagen](images/Screenshot_179.png) 

### The default account is in the Account Controller. You can change the default account
![imagen](images/Screenshot_180.png) 

### Inside of the App, you can create new users
![imagen](images/Screenshot_182.png) 

![imagen](images/Screenshot_183.png) 


## 📜 License
## 📜 License
This project is under MIT License
Free to use, modify and distribute

## 👨‍💻 Autor
## 👨‍💻 Autor
Carlos Vázquez
Email: carloseliamvazquez@gmail.com
