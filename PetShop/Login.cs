using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class Login 
    {

        PetDbContext _petDbContext = new PetDbContext();
        Admin admin = new Admin();
        

        public void LogIn()
        {

            Console.WriteLine("Welcome Back, Provide Valid Username & Password");
            Console.Write("Username :");
            var userName = Console.ReadLine();
            Console.Write("Password :");
            var password = Console.ReadLine();

            var user = _petDbContext.Admin.Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();
            if(user !=null)
            {
               
                Console.Clear();
                Console.WriteLine("Login Successful");
                Display();
            }
            else
            {
               
                Console.WriteLine("Invalid Username or Password");
                Thread.Sleep(1000);
                Console.Clear();
                LogIn();
            }
        }

       

        //Change Password
        public void ChangePassword()
        {
            Console.WriteLine("Enter Previous Password");
            var oldPassword = Console.ReadLine();

            var admin = _petDbContext.Admin.Where(u => u.UserName == "admin" && u.Password == oldPassword).FirstOrDefault();
            if(admin !=null)
            {

                Console.WriteLine("Enter New Password");
                var newPassword = Console.ReadLine();
                Console.WriteLine("Confirm New Password");
                var confirmPassword = Console.ReadLine();
                if (newPassword == confirmPassword)
                {
                    admin.Password = newPassword;
                    _petDbContext.Admin.Update(admin);
                    _petDbContext.SaveChanges();
                    Console.WriteLine("Password Changed Successfully");
                    Thread.Sleep(1000);
                    Console.Clear();
                    LogIn();

                }
                else
                {
                    Console.WriteLine("Password Mismatch");
                    Thread.Sleep(1000);
                    Console.Clear();
                    ChangePassword();
                }
            }
            else
            {
                Console.WriteLine("Incorrct Password");
                Thread.Sleep(1000);
                Console.Clear();
                return;
            }


        }

        public void Logout()
        {
            Console.WriteLine("Logout Successful");
            Thread.Sleep(1000);
            Console.Clear();
            LogIn();
        }

        

        public void Display()
        {

            bool condition = true;
            while (condition)
            {

                Console.WriteLine(@"
Welcome Admin,
 1. Change Password
 2. Inventory
 3. Feeding Schedule
 4. Purchase
 5. Sell Pet
 6. Sales Record Of Pets
 7. Monthly Sales Report
 8. Manage Cage
 9. Manage Aquarium
 10.Log Out
 x. Exit
");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ChangePassword();
                        break;
                    case "2":
                        DisplayInventory();
                        
                        break;
                    case "3":
                        DisplayFeedingSchedule();
                        
                        break;
                    case "4":
                        DisplayPurchase();
                        
                        break;
                    case "5":
                        admin.SalePet();
                        
                        break;
                    case "6":
                        admin.SalePetRecord();
                        
                        break;
                    case "7":
                        admin.MonthlySales();
                        break;
                    case "8":
                        DisplayCage();
                        break;
                    case "9":
                        DisplayAquarium();
                        break;
                    case "10":
                        Logout();
                        break;
                    case "x":
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Display();
                        break;
                }
            }
            


        }

        public void DisplayInventory()
        {
            bool condition = true;
            while (condition)
            {
                Console.WriteLine(@$"
Inventory

List Of Pets
                                    
                                    ");
                admin.DisplayAllPets();
                Console.WriteLine(@"
                                    
List Of Fish
                                   
                                    ");
                admin.DisplayAllFishes();
                Console.WriteLine(@"
                                    
1. Add Pet to Cage
2. Add Fish to Aquarium
3. Update Pet Info
4. Update Fish Info
5. Delete Pet
6. Delete Fish
7. Back
x. Exit");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        admin.AddPetToCage();
                        
                        break;
                    case "2":
                        admin.AddFishToAquarium();
                       
                        break;
                    case "3":
                        admin.UpdatePetInCage();
                        
                        break;
                    case "4":
                        admin.UpdateFishInAquarium();
                        
                        break;
                    case "5":
                        admin.DeletePetFromCage();
                        
                        break;

                    case "6":
                        admin.DeleteFishFromAquarium();
                        
                        break;
                    case "7":
                        Thread.Sleep(1000);
                        Console.Clear();
                        Display();
                        
                        break;
                    case "8":
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        DisplayInventory();
                        break;
                }
            }
           


        }

        public void DisplayFeedingSchedule()
        {
            while(true)
            {
                admin.DisplaySchedule();
                Console.WriteLine(@"



                                    Feeding Schedule
                                   
                                    1. Add Feeding Schedule
                                    2. Update Feeding Schedule
                                    3. Delete Feeding Schedule
                                    4. Back
                                    5. Exit");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        admin.FeedingSchedule();

                        break;
                    case "2":
                        admin.UpdateSchedule();

                        break;
                    case "3":
                        admin.DeleteSchedule();

                        break;
                    case "4":
                        Thread.Sleep(1000);
                        Console.Clear();
                        Display();
                        break;
                    case "5":
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
           
        }

        public void DisplayPurchase()
        {
            while(true)
            {
                admin.PurchasePetRecord();
                Console.WriteLine(@"
                                    

                                              Purchase
                                   
                                    1. Purchase Pet
                                    2. Delete Purchase
                                    3. Back
                                    4. Exit
                                           ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        admin.PurchasePet();

                        break;
                    case "2":
                        admin.DeletePurchaseRecord();

                        break;
                    case "3":
                        Thread.Sleep(1000);
                        Console.Clear();
                        Display();
                        break;
                    case "4":
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
            


        }

        public void DisplayCage()
        {
            
            while(true)
            {
                admin.DisplayCage();
                Console.WriteLine(@"
                                    

                                              Cage
                                   
                                    1. Add New Cage
                                    2. Update Cage
                                    3. Delete Cage
                                    4. Back
                                    5. Exit
                                           ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        admin.AddNewCage();
                        break;
                    case "2":
                        admin.UpdateCage();
                        break;
                    case "3":
                        admin.DeleteCage();
                        break;
                    case "4":
                        Thread.Sleep(1000);
                        Console.Clear();
                        Display();
                        break;
                    case "5":
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }

        public void DisplayAquarium()
        {
            while (true)
            {
                admin.DisplayAquarium();
                Console.WriteLine(@"
                                    

                                              Aquarium
                                   
                                    1. Add New Aquarium
                                    2. Update Aquarium
                                    3. Delete Aquarium
                                    4. Back
                                    5. Exit
                                           ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        admin.AddNewAquarium();
                        break;
                    case "2":
                        admin.UpdateAquarium();
                        break;
                    case "3":
                        admin.DeleteAquarium();
                        break;
                    case "4":
                        Thread.Sleep(1000);
                        Console.Clear();
                        Display();
                        break;
                    case "5":
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
            
        }




    }
}
