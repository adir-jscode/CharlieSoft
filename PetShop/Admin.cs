using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set;}
        public string Password { get; set; }

        PetDbContext _petDbContext = new PetDbContext();


        //Pet
        public void AddPetToCage()
        {
            try
            {
                DisplayCage();
                Console.WriteLine("Enter Cage Number :");
                var CageNumber = int.Parse(Console.ReadLine());

                //check if cage is available or not 

                var cage = _petDbContext.Cages.Where(c => c.CageNo == CageNumber).FirstOrDefault();

                if (cage != null)
                {
                    Console.WriteLine($"{CageNumber} is Found!, Please Provide Pet Information");
                    Console.WriteLine("Enter Pet Name :");
                    string PetName = Console.ReadLine();
                    Console.WriteLine("Enter Pet Type :");
                    string PetType = Console.ReadLine();
                    Console.WriteLine("Enter Pet Age :");
                    var PetAge = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Pet Color :");
                    string PetColor = Console.ReadLine();
                    Console.WriteLine("Enter Pet Price :");
                    var PetPrice = decimal.Parse(Console.ReadLine());
                    var pet = new Pet()
                    {
                        Name = PetName,
                        Type = PetType,
                        Color = PetColor,
                        Age = PetAge,
                        Price = PetPrice,
                        CageId = cage.Id

                    };

                    _petDbContext.Pets.Add(pet);
                    _petDbContext.SaveChanges();
                    Console.WriteLine("Pet Added Sucessfully");
                    Thread.Sleep(1000);
                    Console.Clear();
                }

                else
                {

                    Console.WriteLine($"Cage Number {CageNumber} is  Not Found, Want to Make a new Cage?");
                    Console.WriteLine("Press y for Yes and n for No");
                    var choice = Console.ReadLine();
                    if (choice == "y")
                    {
                        Console.WriteLine("Enter New Cage Number :");
                        var NewCageNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Cage Type :");
                        var CageType = Console.ReadLine();
                        Console.WriteLine("Enter Pet Name :");
                        string PetName = Console.ReadLine();
                        Console.WriteLine("Enter Pet Type :");
                        string PetType = Console.ReadLine();
                        Console.WriteLine("Enter Pet Age :");
                        var PetAge = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Pet Color :");
                        string PetColor = Console.ReadLine();
                        Console.WriteLine("Enter Pet Price :");
                        var PetPrice = decimal.Parse(Console.ReadLine());
                        var newCage = new Cage()
                        {
                            CageNo = NewCageNumber,
                            CageType = CageType,
                            Pets = new List<Pet>() { new Pet() { Name = PetName, Type = PetType, Color = PetColor, Age = PetAge, Price = PetPrice } }
                        };

                        _petDbContext.Cages.Add(newCage);
                        _petDbContext.SaveChanges();
                        Console.WriteLine("Pet Added Sucessfully");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    else
                    {

                        return;
                    }
                    
                    
                       
                    }
                    
                        
                   

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

  
        public void UpdatePetInCage()
        {
            Console.WriteLine("Enter Pet Id :");
            var PetId = int.Parse(Console.ReadLine());
            var pet = _petDbContext.Pets.Where(p => p.Id == PetId).FirstOrDefault();
            if(pet != null)
            {
                
                Console.WriteLine("Enter Pet Name :");
                string PetName = Console.ReadLine();
                Console.WriteLine("Enter Pet Type :");
                string PetType = Console.ReadLine();
                Console.WriteLine("Enter Pet Age :");
                var PetAge = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Pet Color :");
                string PetColor = Console.ReadLine();
                Console.WriteLine("Enter Pet Price :");
                var PetPrice = decimal.Parse(Console.ReadLine());

                pet.Name = PetName;
                pet.Type = PetType;
                pet.Age = PetAge;
                pet.Color = PetColor;
                pet.Price = PetPrice;
                _petDbContext.Pets.Update(pet);
                _petDbContext.SaveChanges();
                Console.WriteLine("Pet Updated Successfully");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Pet Not Found");
                Thread.Sleep(1000);
                Console.Clear();

            }
            
        }
        
        public void DeletePetFromCage()
        {
            Console.WriteLine("Enter Pet Id :");
            var PetId = int.Parse(Console.ReadLine());
            var pet = _petDbContext.Pets.Where(p => p.Id == PetId).FirstOrDefault();
            if(pet != null)
            {
                Console.WriteLine("Pet is Found");
                Console.WriteLine("Are you sure (y/n)?");
                string choice = Console.ReadLine();
                if(choice == "y") 
                {
                    _petDbContext.Pets.Remove(pet);
                    _petDbContext.SaveChanges();
                    Console.WriteLine("Pet Deleted Successfully");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    return;
                }
                
            }
            else
            {
                Console.WriteLine("Pet Not Found");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        
        public void DisplayAllPets()
        {
            int count = 0;
            var pets = _petDbContext.Pets.Include(f=>f.Cage).ToList();
           

            if(pets.Count !=0)
            {
                foreach (var pet in pets)
                {
                    count++;
                    Console.WriteLine($@"

{count}.PetId : {pet.Id}, Name : {pet.Name}, Type : {pet.Type}, Color: {pet.Color},
Age: {pet.Age}, Price : {pet.Price} BDT, CageNo : {pet.Cage.CageNo}");

                }
                Console.WriteLine($@"
                                
Total Pets : {count}
");
            }

            else
            {
                Console.WriteLine("No Pets Available!");
            }

        }

        //Fish
        public void AddFishToAquarium()
        {
            DisplayAquarium();
            Console.WriteLine("Enter Aquarium Number :");
           
            var AquirumNumber = int.Parse(Console.ReadLine());

            var aqurirum = _petDbContext.Aquarium.Where(a => a.AquariumNumber == AquirumNumber).FirstOrDefault();
            if (aqurirum != null)
            {
                Console.WriteLine($"{AquirumNumber} is Found! , Please Add Fish Information");
                Console.WriteLine("Enter Fish Name :");
                string FishName = Console.ReadLine();
                Console.WriteLine("Enter Fish Type :");
                string FishType = Console.ReadLine();
                Console.WriteLine("Enter Fish Price :");
                var FishPrice = decimal.Parse(Console.ReadLine());

                var fish = new Fish()
                {
                    Name = FishName, 
                    Type = FishType, 
                    Price = FishPrice, 
                    Aquarium = aqurirum
                };
                _petDbContext.Fish.Add(fish);
                _petDbContext.SaveChanges();
                Console.WriteLine("Fish Added Successfully");
                Thread.Sleep(1000);
                Console.Clear();
            }

            else
            {
                Console.WriteLine($"Aquarium No : {AquirumNumber}  is not Found, Do you want to add new Aquarium?");
                Console.WriteLine("Press y for Yes and n for No");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    Console.WriteLine("Enter New Aquarium Number :");
                    var NewAquirumNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Aquarium Type :");
                    var AquirumType = Console.ReadLine();
                    Console.WriteLine("Enter Fish Name :");
                    string FishName = Console.ReadLine();
                    Console.WriteLine("Enter Fish Type :");
                    string FishType = Console.ReadLine();
                    Console.WriteLine("Enter Fish Price :");
                    var FishPrice = decimal.Parse(Console.ReadLine());
                    var aquarium = new Aquarium()
                    {
                        AquariumNumber = NewAquirumNumber,
                        AquariumType = AquirumType,
                        Fish = new List<Fish>() { new Fish { Name = FishName,Type = FishType,Price = FishPrice } }
                    };

                    _petDbContext.Aquarium.Add(aquarium);
                    _petDbContext.SaveChanges();
                    Console.WriteLine($"Fish Added Successfully in Aquarium No : {NewAquirumNumber}");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    return;
                }
            }



            
        }

        public void UpdateFishInAquarium()
        {
            Console.WriteLine("Enter Fish Id :");
            var FishId = int.Parse(Console.ReadLine());

            var fish = _petDbContext.Fish.Where(f => f.Id == FishId).FirstOrDefault();
            if (fish != null)
            {
                Console.WriteLine("Enter Fish Name :");
                string FishName = Console.ReadLine();
                Console.WriteLine("Enter Fish Type :");
                string FishType = Console.ReadLine();
                Console.WriteLine("Enter Fish Price :");
                var FishPrice = decimal.Parse(Console.ReadLine());

                fish.Name = FishName;
                fish.Type = FishType;
                fish.Price = FishPrice;
                _petDbContext.Fish.Update(fish);
                _petDbContext.SaveChanges();
                Console.WriteLine("Fish Updated Successfully");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Fish Not Found");
                Thread.Sleep(1000);
                Console.Clear();
            }

        }

        
        public void DeleteFishFromAquarium()
        {
            Console.WriteLine("Enter Fish Id :");
            var FishId = int.Parse(Console.ReadLine());
            var fish = _petDbContext.Fish.Where(f => f.Id == FishId).FirstOrDefault();
            if (fish != null)
            {
                Console.WriteLine("Fish is Found");
                Console.WriteLine("Are you sure (y/n)?");
                string choice = Console.ReadLine();
                if(choice =="y")
                {
                    _petDbContext.Fish.Remove(fish);
                    _petDbContext.SaveChanges();
                    Console.WriteLine("Fish Deleted Successfully");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    return;
                }
                

            }
            else
            {
                Console.WriteLine("Fish Not Found");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        

        public void DisplayAllFishes()
        {
            var fishes = _petDbContext.Fish
                            .Include(f => f.Aquarium)
                            .ToList();
            
            int count = 0;

            if(fishes.Count !=0)
            {
                foreach (var fish in fishes)
                {
                    count++;
                    Console.WriteLine($"{count}.FishId : {fish.Id}, Name : {fish.Name}, Type : {fish.Type}, Price : {fish.Price}, AquariumNo : {fish.Aquarium.AquariumNumber}, Aquarium Type : {fish.Aquarium.AquariumType} ");
                    Console.WriteLine("");
                }
                Console.WriteLine($@"
Total Fish : {count}
");
            }
            else
            {
                Console.WriteLine("No Fish Available!");
            }
            
        }

        //Cage Info

        public void DisplayCage()
        {
            int count = 0;
            var cages = _petDbContext.Cages.ToList();

            Console.WriteLine("Availabe Cages : ");

            if (cages.Count != 0)
            {
                foreach (var cage in cages)
                {
                    count++;
                    Console.WriteLine($@"

{count}.CageId : {cage.Id}, Type : {cage.CageType},  CageNo : {cage.CageNo}");

                }
                Console.WriteLine($@"
                                
Total Cage Available : {count}
");
            }

            else
            {
                Console.WriteLine("No Cage Available!");
            }
        }

        public void AddNewCage()
        {

            var cages = _petDbContext.Cages.ToList();
            Console.WriteLine("Enter Cage Type :");
            var CageType = Console.ReadLine();
            Console.WriteLine("Enter Cage No :");
            var CageNo = int.Parse(Console.ReadLine());
            var cage = new Cage()
            {
                CageType = CageType,
                CageNo = CageNo
            };
            _petDbContext.Cages.Add(cage);
            _petDbContext.SaveChanges();
            Console.WriteLine("Cage Added Successfully");
            Thread.Sleep(1000);
            Console.Clear();
            
        }

        public void DeleteCage()
        {
            Console.WriteLine("Enter Cage Id :");
            var CageId = int.Parse(Console.ReadLine());
            var cage = _petDbContext.Cages.Where(c => c.Id == CageId).FirstOrDefault();
            if (cage != null)
            {
                Console.WriteLine("Cage is Found");
                Console.WriteLine("Are you sure (y/n)?");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    _petDbContext.Cages.Remove(cage);
                    _petDbContext.SaveChanges();
                    Console.WriteLine("Cage Deleted Successfully");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    return;
                }
            }
            else
            {
                Console.WriteLine("Cage Not Found");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        
        public void UpdateCage()
        {
            Console.WriteLine("Enter Cage Id :");
            var CageId = int.Parse(Console.ReadLine());

            var cage = _petDbContext.Cages.Where(c => c.Id == CageId).FirstOrDefault();
            if (cage != null)
            {
                Console.WriteLine("Enter Cage Type :");
                string CageType = Console.ReadLine();
                Console.WriteLine("Enter Cage No :");
                var CageNo = int.Parse(Console.ReadLine());

                cage.CageType = CageType;
                cage.CageNo = CageNo;
                _petDbContext.Cages.Update(cage);
                _petDbContext.SaveChanges();
                Console.WriteLine("Cage Updated Successfully");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Cage Not Found");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        
        
        
        //Aquarium Info

        public void DisplayAquarium()
        {
            int count = 0;
            var aquariums = _petDbContext.Aquarium.ToList();

            Console.WriteLine("Availabe Aquariums : ");

            if (aquariums.Count != 0)
            {
                foreach (var aquarium in aquariums)
                {
                    count++;
                    Console.WriteLine($@"
{count}.AquariumId : {aquarium.Id}, Type : {aquarium.AquariumType},  AquariumNo : {aquarium.AquariumNumber}");
                }
                Console.WriteLine($@"Total Aquarium Available : {count}");
            }
            else
            { 
                Console.WriteLine("No Aquarium Available!");
             }
        }
        public void AddNewAquarium()
        {

            Console.WriteLine("Enter Aquarium Type :");
            var AquariumType = Console.ReadLine();
            Console.WriteLine("Enter Aquarium No :");
            var AquariumNo = int.Parse(Console.ReadLine());
            var aquarium = new Aquarium()
            {
                AquariumType = AquariumType,
                AquariumNumber = AquariumNo
            };
            _petDbContext.Aquarium.Add(aquarium);
            _petDbContext.SaveChanges();
            Console.WriteLine("Aquarium Added Successfully");
            Thread.Sleep(1000);
            Console.Clear();
        }

        public void DeleteAquarium()
        {
            Console.WriteLine("Enter Aquarium Id :");
            var AquariumId = int.Parse(Console.ReadLine());
            var aquarium = _petDbContext.Aquarium.Where(a => a.Id == AquariumId).FirstOrDefault();
            if (aquarium != null)
            {
                Console.WriteLine("Aquarium is Found");
                Console.WriteLine("Are you sure (y/n)?");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    _petDbContext.Aquarium.Remove(aquarium);
                    _petDbContext.SaveChanges();
                    Console.WriteLine("Aquarium Deleted Successfully");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    return;
                }
            }
            else
            {
                Console.WriteLine("Aquarium Not Found");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        public void UpdateAquarium()
        {
            Console.WriteLine("Enter Aquarium Id :");
            var AquariumId = int.Parse(Console.ReadLine());
            var aquarium = _petDbContext.Aquarium.Where(a => a.Id == AquariumId).FirstOrDefault();
            if (aquarium != null)
            {
                Console.WriteLine("Enter Aquarium Type :");
                string AquariumType = Console.ReadLine();
                Console.WriteLine("Enter Aquarium No :");
                var AquariumNo = int.Parse(Console.ReadLine());

                aquarium.AquariumType = AquariumType;
                aquarium.AquariumNumber = AquariumNo;
                _petDbContext.Aquarium.Update(aquarium);
                _petDbContext.SaveChanges();
                Console.WriteLine("Aquarium Updated Successfully");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Aquarium Not Found");
                Thread.Sleep(1000);
                Console.Clear();
            }

        }

        //Sale Pet
        public void SalePet()
        {
            
            var allPets = _petDbContext.Pets.ToList();
            if(allPets.Count != 0)
            {
                DisplayAllPets();
                Console.WriteLine("Provide Information to Sell Pet :");
                Console.WriteLine("Enter Pet Id :");
                var PetId = int.Parse(Console.ReadLine());


                var pet = _petDbContext.Pets.Where(p => p.Id == PetId).FirstOrDefault();
                if (pet != null)
                {
                    Console.WriteLine("Enter Customer Name :");
                    string CustomerName = Console.ReadLine();
                    Console.WriteLine("Enter Customer Phone :");
                    string CustomerPhone = Console.ReadLine();
                    Console.WriteLine("Enter Customer Address :");
                    string CustomerAddress = Console.ReadLine();
                    Console.WriteLine("Enter Sale Price :");
                    var SalePrice = decimal.Parse(Console.ReadLine());
                    var SalePet = new SalePet()
                    {
                        CustomerName = CustomerName,
                        CustomerPhone = CustomerPhone,
                        CustomerAddress = CustomerAddress,
                        PetId = PetId,
                        SalePrice = SalePrice,
                        SaleDate = DateTime.Now
                    };
                    _petDbContext.SalePets.Add(SalePet);
                    _petDbContext.SaveChanges();
                    Console.WriteLine($"Pet Sold Successfully to Mr.{CustomerName}!");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Pet Not Found");
                    Console.WriteLine("Are you want to Insert New Pet? (y/n)?");
                    var choice = Console.ReadLine();
                    if (choice == "y")
                    {
                        AddPetToCage();
                        SalePet();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("No Pets Available..!");
                Console.WriteLine("Are you want to Insert New Pet? (y/n)?");
                var choice = Console.ReadLine();
                if(choice == "y" ) 
                {
                    AddPetToCage();
                    SalePet();
                }
                else
                {
                    return;
                }
            }
            
        }

        public void SalePetRecord()
        {
            var SalePets = _petDbContext.SalePets.Include(p => p.Pet).ToList();
            if(SalePets.Count !=0)
            {
                int count = 0;
                foreach (var salePet in SalePets)
                {
                    count++;
                    Console.WriteLine($"{count}.SaleId : {salePet.Id}, Customer Name : {salePet.CustomerName}, Customer Phone : {salePet.CustomerPhone}, Customer Address : {salePet.CustomerAddress}, Pet Name : {salePet.Pet.Name}, Sale Price : {salePet.SalePrice}, Sale Date : {salePet.SaleDate.ToString("dd-MM-yyyy")}");
                    Console.WriteLine("");
                }
                Console.WriteLine("Total Sale : " + count);
            }
            else 
            {
                Console.WriteLine("No Sales Data Availabe");
                Console.WriteLine("Are you want sell a pet?(y/n)?");
                var choice = Console.ReadLine();
                if(choice == "y" )
                {
                    SalePet();
                }
                else
                {
                    return;
                }
                //Thread.Sleep(1000);
                //Console.Clear();
            }
            
        }

        //Purchase Pet
        public void PurchasePet()
        {
            Console.WriteLine("Enter Seller Name :");
            string SellerName = Console.ReadLine();
            Console.WriteLine("Enter Seller Phone :");
            string SellerPhone = Console.ReadLine();
            Console.WriteLine("Enter Seller Address :");
            string SellerAddress = Console.ReadLine();
            var PurchaseDate = DateTime.Now;
            Console.WriteLine("Enter Pet Name:");
            string PetName = Console.ReadLine();
            Console.WriteLine("Enter Pet Type :");
            string PetType = Console.ReadLine();
            Console.WriteLine("Enter Pet Color :");
            string PetColor = Console.ReadLine();
            Console.WriteLine("Enter Pet Age :");
            var PetAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Pet Price :");
            var PurchasePrice = decimal.Parse(Console.ReadLine());

            var purchasePet = new PetPurchaseRecord()
            {
                SellerName = SellerName,
                SellerPhone = SellerPhone,
                SellerAddress = SellerAddress,
                PurchaseDate = PurchaseDate,
                PetName = PetName,
                PetType = PetType,
                PetColor = PetColor,
                PetAge = PetAge,
                PetPrice = PurchasePrice
                
            };
            _petDbContext.PetPurchaseRecords.Add(purchasePet);
            _petDbContext.SaveChanges();
            Console.WriteLine($"Pet Purchased Successfully from Mr.{SellerName}!");
            Thread.Sleep(1000);
            Console.Clear();


        }

        public void PurchasePetRecord()
        {
            var PurchasePets = _petDbContext.PetPurchaseRecords.ToList();
            Console.WriteLine("Purchase Record : ");
            if(PurchasePet !=null)
            {
                int count = 0;
                foreach (var purchasePet in PurchasePets)
                {
                    count++;
                    Console.WriteLine($"{count}.PurchaseId : {purchasePet.Id}, Seller Name : {purchasePet.SellerName}, Seller Phone : {purchasePet.SellerPhone}, Seller Address : {purchasePet.SellerAddress}, Purchase Date : {purchasePet.PurchaseDate.ToString("dd-MM-yyyy")}, Pet Name : {purchasePet.PetName}, Pet Type : {purchasePet.PetType}, Pet Color : {purchasePet.PetColor}, Pet Age : {purchasePet.PetAge}, Pet Price : {purchasePet.PetPrice}");
                    Console.WriteLine("");
                }

                decimal totalAmount = PurchasePets.Sum(s=>s.PetPrice);
                Console.WriteLine("Total Purchase : " + count);
                Console.WriteLine("Total Amount : " + totalAmount);
            }
            else
            {
                Console.WriteLine("No Purchase Data Available");
                Thread.Sleep(1000);
                Console.Clear();
            }
            
        }

        public void DeletePurchaseRecord()
        {
            Console.WriteLine("Enter Purchase Id :");
            var id = int.Parse(Console.ReadLine());

            var purchase = _petDbContext.PetPurchaseRecords.Where(p=>p.Id == id).FirstOrDefault();
            if(purchase !=null)
            {
                Console.WriteLine($"{purchase.Id} Found");
                Console.WriteLine("Are you sure? (y/n)?");
                string choice = Console.ReadLine();
                if(choice == "y")
                {
                    _petDbContext.PetPurchaseRecords.Remove(purchase);
                    _petDbContext.SaveChanges();
                    Console.WriteLine("Deleted SuccessFully");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    return;
                }
            }
            
            else
            {
                Console.WriteLine("No Data Found!");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        //Schedule

        public void DisplaySchedule()
        {
            var schedule = _petDbContext.feedingSchedules.Include(c=>c.Cage).ToList();
            int count = 0;

            if(schedule != null )
            {
                foreach (var s in schedule)
                {
                    count++;
                    Console.WriteLine($"{count}. Id : {s.Id}, DateTime : {s.DateTime.ToString("dd-MM-yyy")},CageId : {s.CageId}, CageNo : {s.Cage.CageNo}");
                }

                Console.WriteLine($"Total Pet Feeding Schedule {count}");

            }
            else
            {
                Console.WriteLine("No Schedule Available");
                Thread.Sleep(1000);
                Console.Clear();
            }


            
        }


        public void FeedingSchedule()
        {
            DisplayCage();
            Console.WriteLine("Creating a Schedule...");
            Console.WriteLine("Enter a Cage Number: ");
            var cageNo = int.Parse(Console.ReadLine());
            var scheduled = _petDbContext.feedingSchedules.Where(c=>c.Cage.CageNo == cageNo).FirstOrDefault();
            var cage = _petDbContext.Cages.Where(c => c.CageNo == cageNo).FirstOrDefault();

            if(cage !=null && scheduled == null)
            {
                Console.WriteLine("Enter Date :");
                var date = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter  Month:");
                var month = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Year:");
                var year = int.Parse(Console.ReadLine());

                var time = new DateTime(year, month, date);
                
                //time clashed or not
                var scheduleTime = _petDbContext.feedingSchedules.Where(c => c.DateTime == time).FirstOrDefault();
                if(scheduleTime != null)
                {
                    Console.WriteLine("Schedule Time Clashed");
                    return;
                }

                var schedule = new FeedingSchedule()
                {
                    DateTime = time,
                    CageId = cage.Id

                };
                _petDbContext.feedingSchedules.Add(schedule);
                _petDbContext.SaveChanges();
                Console.WriteLine($"Schedule Created At {date}-{month}-{year}");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else if(scheduled != null)
            {
                Console.WriteLine("Schedule Already Created");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Cage not Found..");
                Thread.Sleep(1000);
                Console.Clear();
            }

            
        }

        public void UpdateSchedule()
        {
            Console.WriteLine("Enter Schedule Id : ");
            var Id = int.Parse(Console.ReadLine());

            var schedule = _petDbContext.feedingSchedules.Where(c => c.Id == Id).FirstOrDefault();
            if(schedule != null)
            {
                Console.WriteLine("Enter Date :");
                var date = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter  Month:");
                var month = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Year:");
                var year = int.Parse(Console.ReadLine());


                schedule.DateTime = new DateTime(year, month, date);
               

                _petDbContext.feedingSchedules.Update(schedule);
                _petDbContext.SaveChanges();
                Console.WriteLine("Schedule Updated");
            }
            else
            {
                Console.WriteLine("No Data Available!");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        public void DeleteSchedule()
        {
            Console.WriteLine("Enter Schedule Id :");
            var id = int.Parse(Console.ReadLine());

            var schedule = _petDbContext.feedingSchedules.Where(c=>c.Id == id).FirstOrDefault();
            if(schedule !=null)
            {
                Console.WriteLine("Schedule Id Found");
                Console.WriteLine("Are you sure (y/n)?");
                var choice = Console.ReadLine();
                if(choice =="y")
                {
                    _petDbContext.feedingSchedules.Remove(schedule);
                    _petDbContext.SaveChanges();
                    Console.WriteLine("Deleted Successfully!");
                    Thread.Sleep(1000);
                    
                }
                else
                {
                    return;
                }
                
            }
            else
            {
                Console.WriteLine("Schedule Not Found");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        //monthly sale,profit loss

        public void MonthlySales()
        {
            
            DateTime currentDate = DateTime.Today;
            int currentMonth = currentDate.Month;
            int currentYear = currentDate.Year;

            var sales = _petDbContext.SalePets.Where(m=>m.SaleDate.Month == currentMonth && m.SaleDate.Year == currentYear).Include(p=>p.Pet).ToList();
            var purchase = _petDbContext.PetPurchaseRecords.Where(m => m.PurchaseDate.Month == currentMonth && m.PurchaseDate.Year == currentYear).ToList();

            decimal totalSales = sales.Sum(s => s.SalePrice);
            decimal totalPurchase = purchase.Sum(p => p.PetPrice);
            int count = 0;
            int countPurcahse = 0;

            if(sales.Count !=0)
            {
                Console.WriteLine($"Sales of {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(currentMonth)} {currentYear}:");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Total Item Sold: {sales.Count}");
                foreach (var s in sales)
                {
                    count++;
                    Console.WriteLine($"{count}. Date: {s.SaleDate.Date.ToString("dd-MM-yyyy")} {s.SaleDate.DayOfWeek}, Pet Name : {s.Pet.Name} Pet Type :{s.Pet.Type} Price: {s.SalePrice} BDT");
                }
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Total Sales: {totalSales} BDT");

            }
            else
            {
                Console.WriteLine("No Monthly Sales Record Available");
                Thread.Sleep(1000);
                Console.Clear();
            }

            if(purchase.Count !=0)
            {
                Console.WriteLine($"Purchase of {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(currentMonth)} {currentYear}:");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Total Item Purchased: {purchase.Count}");
                foreach (var p in purchase)
                {
                    countPurcahse++;
                    Console.WriteLine($"{countPurcahse}. Date: {p.PurchaseDate.ToString("dd-MM-yyyy")}, {p.PurchaseDate.DayOfWeek}, Pet Name : {p.PetName} Pet Type :{p.PetType} Price: {p.PetPrice}");
                }
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Total Purchase: {totalPurchase} BDT");

            }

            else
            {
                Console.WriteLine("No Purchase Records Available");

            }

            

            decimal ProfitLoss = totalSales - totalPurchase;

            if (totalPurchase > totalSales)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Loss = {ProfitLoss} BDT");
            }
            else
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Profit = {ProfitLoss} BDT");
            }
        }







    }

}
