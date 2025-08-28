# 🏋️‍♂️ Gym Manager

This project is a **management system for public gyms**, developed in **MVC .NET Core** with **Entity Framework Core** and **MySQL**.  
Allow to manager members, memberships, access and more

---

## 📌 Features

### Login
![Texto alternativo](images/Screenshot_179.png) 

### Member register and managment

- Create Member
![Texto alternativo](images/Screenshot_186.png) 

- Member List
![Texto alternativo](images/Screenshot_187.png) 


### Memberships control (Active/Expired)

- Renew Membership
![Texto alternativo](images/Screenshot_189.png) 


![Texto alternativo](images/Screenshot_190.png) 

### Attendance management (Check in/Check Out)

- When a User with a expired membership tried to check in...
![Texto alternativo](images/Screenshot_191.png) 


### Reports (Prototype)

![Texto alternativo](images/Screenshot_192.png) 

![Texto alternativo](images/Screenshot_193.png) 

![Texto alternativo](images/Screenshot_194.png) 

![Texto alternativo](images/Screenshot_195.png) 


### Dark/Light mode switch
- Dark mode
![Texto alternativo](images/Screenshot_196.png) 

- Light mode
![Texto alternativo](images/Screenshot_197.png) 


### Other CRUDS

- Membership Types List
![Texto alternativo](images/Screenshot_188.png)

-Equipment Types
![Texto alternativo](images/Screenshot_198.png) 

---

## ⚙️ Tecnologhies used

- [.NET 6/7](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [MySQL](https://www.mysql.com/)


---

## 🚀 Instalation and execution

### Create a database in your MYSQL local enviroment

![Texto alternativo](images/Screenshot_174.png)


### Clone the repsoitory, then, enter to GymManager.Web.sln file

![Texto alternativo](images/Screenshot_173.png)


### In Visual Studio, go to GymManager.Web project and modifiy the string connection in the appsettings.json file, replacing your database name and MYSQL credentials

![Texto alternativo](images/Screenshot_172.png)


### Be sure you had the GymManager.Web like the default project. 
![Texto alternativo](images/Screenshot_175.png)

### Open the Package Manager Console and select GymManager.DataAccess like default project
![Texto alternativo](images/Screenshot_176.png) 

### Run the next Command:
![Texto alternativo](images/Screenshot_177.png) 

### The database migration has been applied successfully !
![Texto alternativo](images/Screenshot_178.png) 

### Now you cant test the App. Click on the Play green button
![Texto alternativo](images/Screenshot_181.png)

### You will see the login page. 
You can use the next credentials:
username: carlosEliam@gmail.com (This is not my email, it's just a random email, it's not verified)
<br>
password: Tacos123*

![Texto alternativo](images/Screenshot_179.png) 

### The default account is in the Account Controller. You can change the default account
![Texto alternativo](images/Screenshot_180.png) 

## Inside of the App, you can create new users
![Texto alternativo](images/Screenshot_182.png) 

![Texto alternativo](images/Screenshot_183.png) 


##📜 License
This project is under MIT License
Free to use, modify and distribute

##👨‍💻 Autor
Carlos Vázquez
Email: carloseliamvazquez@gmail.com
