using PetShop;

Console.Title = "Pet Shop";

string option;

do
{
    Login adminLogin = new Login();
    adminLogin.LogIn();
    Thread.Sleep(500);
    Console.Clear();
    Console.Write("Press 1 To Login Again & Another Key To Exit: ");
    option = Console.ReadLine();
}
while (option == "1");