# Pet Shop Inventory

## Overview
The **Pet Shop Inventory** is a software application designed for pet shop owners to efficiently manage their inventory of pets, sales, and purchases. The system allows the shop owner to track pets, feeding schedules, purchase records, and sales reports to understand profit/loss.

## Features
- **User Authentication:**
  - Shop owner can log in using a predefined admin account.
  - Shop owner can change the password.
  
- **Inventory Management:**
  - View, add, update, and delete pets from inventory.
  - Each pet is assigned to a cage or an aquarium.
  
- **Feeding Schedule Management:**
  - Maintain a feeding schedule for pets based on their cages or aquariums.
  - Add, update, or remove feeding schedules using an ID.
  
- **Pet Purchase Records:**
  - Add purchase records including seller contact details and pet type.
  - Purchase records are maintained separately from inventory.
  
- **Sales Records Management:**
  - Add sales records similar to the purchase process.
  
- **Monthly Reports:**
  - View separate lists of monthly sales and purchases.
  - Displays purchase/sale dates, prices, and pet types.
  - Shows profit/loss calculation at the bottom of the report.
  
- **User Logout:**
  - Shop owner can securely log out.

## Technologies Used
- **Application Type:** Console Application 
- **Database:** Microsoft SQL Server (Entity Framework)
- **ORM:** Entity Framework Core
- **Authentication:** Simple login system with predefined admin credentials

## Setup & Installation
1. **Clone the Repository:**
   ```sh
   git clone https://github.com/adir-jscode/CharlieSoft.git
   ```
2. **Configure the Database:**
   - Ensure SQL Server is installed and running.
   - Update the connection string in `appsettings.json` if necessary:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=.\\SQLEXPRESS;Database=CSharpB15;User Id=csharpb15;Password=123456;Trust Server Certificate=True"
     }
     ```
3. **Apply Database Migrations:**
   ```sh
   dotnet ef database update
   ```
4. **Run the Application:**
   ```sh
   dotnet run
   ```

## Default Admin Credentials
- **Username:** `admin`
- **Password:** `123456`
- (These credentials are seeded via database migrations.)

## Usage
1. Log in using the admin credentials.
2. Manage inventory, feeding schedules, purchases, and sales records.
3. Generate monthly sales reports to analyze profit/loss.
4. Log out securely.

## Contribution
Feel free to fork this repository, raise issues, and submit pull requests for improvements.

## License
This project is licensed under the MIT License.

