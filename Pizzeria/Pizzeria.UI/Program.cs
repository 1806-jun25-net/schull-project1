using Pizzeria.Library.Interfaces;
using Pizzeria.Library.Models;
using System;

namespace Pizzeria.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
             *I normally hate having variables out in the open program like this, but in order for
             *these to stay relatively constant throughout and be able to be processed in the console,
             *they have to be instantiated and stored at the base level of the program.
             *I don't like it, but it's the only way I can think to do this.
             *It will absolutely be cleaner for the webapp; I know how to make those a /little/ better.
             */        
            Order order = new Order();
            Pizza pizza = new Pizza();
            Ingredient ingredient = new Ingredient("", 0);
            var input = 1;

            Console.WriteLine("Pizzeria App: Console ver 1.0\n" +
                "Your input for this application will be based on numeric values.\n");
            
            while (input != 0)
            {
                ShowCommandReference();
                string temp = Console.ReadLine();
                while(temp == null || temp == "")
                {
                    Console.WriteLine("You didn't input anything! Please try again.\n");
                    temp = Console.ReadLine();
                }
                input = int.Parse(temp);
                switch (input)
                {
                    case 0: // Exit Application
                        Environment.Exit(0);
                        break;
                    case 1: // Show Command Menu
                        ShowCommandReference();
                        break;
                    case 2: // Create New User and Read Back Creation Info
                        Console.WriteLine("Please input your information in the following format:\n" +
                            "Firstname Lastname");
                        string[] userInfo = Console.ReadLine().Split(' ');
                        User newUser = new User(userInfo[0], userInfo[1]);
                        Console.WriteLine("Where would you prefer to order from?");
                        newUser.DefaultLocation = Console.ReadLine();
                        Console.WriteLine($"Here's what we know currently: Your name is {newUser.FirstName} {newUser.LastName}," +
                            $"and you will be ordering from {newUser.DefaultLocation}. You may change this location any time!\n");
                        break;
                    case 3: // Create New Order
                        Console.WriteLine("Before we proceed, you cannot have more than one active order at any " +
                            "one given time. If you use this command after already creating an order, that " +
                            "previous order will be overwritten.\n" +
                            "Would you like to proceed with this command? [ Y / N ]\n");
                        string orderDecision = Console.ReadLine().ToLower();
                        if(orderDecision == "y") // Proceed to Create New Order / Overwrite Previous Order
                        {
                            order = new Order();
                            Console.WriteLine("You have begun your new order, but it's currently empty. " +
                                "You can use Command 4 to begin creating a new pizza!\n");
                        }
                        else if(orderDecision == "n") // Cancel New Order Creation Process
                        {
                            break;
                        }
                        else // Invalid Input
                        {
                            Console.WriteLine("Incorrect input: aborting operation and returning to safe zone.");
                            break;
                        }
                        break;
                    case 4: // Create Your Pizza
                        Console.WriteLine("Before we proceed, you cannot have more than one active pizza at any " +
                            "one given time. If you use this command after already creating a pizza, that " +
                            "previous pizza will be overwritten.\n" +
                            "Would you like to proceed with this command? [ Y / N ]\n");
                        string pizzaDecision = Console.ReadLine().ToLower();
                        if (pizzaDecision == "y") // Proceed to Create New Order / Overwrite Previous Order
                        {
                            pizza = new Pizza();
                            Console.WriteLine("You have begun creating your new pizza, but there's nothing on it. " +
                                "Once you've added your toppings, you can use Command 5 to save it to your order!\n");
                        }
                        else if (pizzaDecision == "n") // Cancel New Order Creation Process
                        {
                            break;
                        }
                        else // Invalid Input
                        {
                            Console.WriteLine("Incorrect input: aborting operation and returning to safe zone.");
                            break;
                        }
                        
                        Ingredient topping = new Ingredient("", 0);
                        Console.WriteLine("Please choose from the following to add to your pizza:\n" +
                            "0 - Finished Adding Toppings\n" +
                            "1 - Pepperoni\n" +
                            "2 - Sausage\n" +
                            "3 - Ham\n");
                        input = int.Parse(Console.ReadLine());
                        switch(input){
                            case 0: // Done adding toppings; break from method
                                break;
                            case 1:
                                // Check for Ingredient(Pepperoni, 1) on this pizza.
                                topping.Name = "Pepperoni";
                                topping.Count = 1;
                                if (pizza.Toppings.Contains(topping))
                                {
                                    Console.WriteLine("This pizza already has pepperoni on it!\n");
                                }
                                else
                                {
                                    pizza.AddTopping(topping);
                                    Console.WriteLine($"This is your pizza currently: {pizza.ToString()}\n");
                                }
                                break;
                            case 2:
                                // Check for Ingredient(Pepperoni, 1) on this pizza.
                                topping.Name = "Sausage";
                                topping.Count = 1;
                                if (pizza.Toppings.Contains(topping))
                                {
                                    Console.WriteLine("This pizza already has sausage on it!\n");
                                }
                                else
                                {
                                    pizza.AddTopping(topping);
                                    Console.WriteLine($"This is your pizza currently: {pizza.ToString()}\n");
                                }
                                break;
                            case 3:
                                // Check for Ingredient(Pepperoni, 1) on this pizza.
                                topping.Name = "Ham";
                                topping.Count = 1;
                                if (pizza.Toppings.Contains(topping))
                                {
                                    Console.WriteLine("This pizza already has ham on it!\n");
                                }
                                else
                                {
                                    pizza.AddTopping(topping);
                                    Console.WriteLine($"This is your pizza currently: {pizza.ToString()}\n");
                                }
                                break;
                            default:
                                Console.WriteLine("Incorrect input: aborting operation and returning to safe zone.\n");
                                break;
                        }
                        //order.AddPizza(pizza);
                        break;
                    case 5: // Add Pizza to Order
                        break;
                    case 6:
                        // Add Topping to Pizza
                        break;
                    case 7:
                        // Remove Topping from Pizza (Requires Confirmation)
                        break;
                    case 8:
                        // Remove Pizza from Order (Requires Confirmation)
                        break;
                    case 9:
                        // Show Order Information
                        break;
                    case 10:
                        // Show Pizza Information
                        break;
                    case 11:
                        // Show Location Inventory
                        break;
                    case 12:
                        // Add an Item to Location Inventory
                        break;
                    case 13:
                        // Remove an Item from Location Inventory
                        break;
                    case 14:
                        // Delete Location Inventory (Requires Confirmation)
                        break;
                    case 15:
                        // Change User Default Location
                        break;
                    case 16:
                        // Delete Current Order
                        if(order.Pizzas == null)
                        {
                            Console.WriteLine("There is no order currently.");
                        }
                        else if(order.Pizzas.Count == 0)
                        {
                            Console.WriteLine("This order is already blank; cannot delete nothing.");
                        }
                        else
                        {
                            Console.WriteLine("Are you sure? [ Y / N ]\n");
                            string deleteDecision = Console.ReadLine().ToLower();
                            if (deleteDecision == "y")
                            {
                                order.DeleteOrder();
                                Console.WriteLine("Your order has been erased.");
                            }
                            else if (deleteDecision == "n")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input: aborting operation and returning to safe zone.\n");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("ERROR: Invalid input.");
                        break;
                }
            }
        }

        static void ShowCommandReference()
        {
            Console.WriteLine(
                "0 - Exit Program\n" +
                "1 - Show Command Reference\n" +
                "2 - Input Username\n" +
                "3 - Create/Overwrite Your Order\n" +
                "4 - Create Your Pizza\n" +
                "5 - Add Pizza to Order\n" +
                "6 - Add Topping to Pizza\n" +
                "7 - Remove Topping from Pizza (Requires Confirmation)\n" +
                "8 - Remove Pizza from Order (Requires Confirmation)\n" +
                "9 - Show Order Information\n" +
                "10 - Show Pizza Information\n" +
                "11 - Show Location Inventory\n" +
                "12 - Add an Item to Location Inventory\n" +
                "13 - Remove an Item from Location Inventory\n" +
                "14 - Delete Location Inventory (Requires Confirmation)\n" +
                "15 - Change User Default Location\n" +
                "16 - Delete Current Order\n");
        }
    }
}
