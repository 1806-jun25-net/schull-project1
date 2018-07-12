using Pizzeria.Library.Interfaces;
using Pizzeria.Library.Models;
using System;
using System.Collections.Generic;

namespace Pizzeria.UI
{
    public class Program
    {
        static User newUser = new User("", "");
        static Location pizzeria = new Location();
        static Order order = new Order();
        static Pizza pizza = new Pizza();
        static int numericInput = 1;
        static char charInput = 'n';
        
        static void Main(string[] args)
        {
            /*
             *I normally hate having variables out in the open program like this, but in order for
             *these to stay relatively constant throughout and be able to be processed in the console,
             *they have to be instantiated and stored at the base level of the program.
             *I don't like it, but it's the only way I can think to do this.
             *It will absolutely be cleaner for the webapp; I know how to make those a /little/ better.
             */
            order.Pizzas = new List<Pizza>();
            Console.WriteLine("Pizzeria App: Console ver 1.0\n" +
                "Your input for this application will be based on numeric values.\n");
            
            while (numericInput != 0)
            {
                ShowCommandReference();
                string temp = Console.ReadLine();
                while(temp == null || temp == "")
                {
                    Console.WriteLine("You didn't input anything! Please try again.\n");
                    temp = Console.ReadLine();
                }
                numericInput = int.Parse(temp);
                switch (numericInput)
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
                        newUser = new User(userInfo[0], userInfo[1]);
                        Console.WriteLine("Where would you prefer to order from? (Enter store location ID number)");
                        newUser.DefaultLocationID = Int32.Parse(Console.ReadLine());
                        Console.WriteLine($"Here's what we know currently: Your name is {newUser.FirstName} {newUser.LastName}, " +
                            $"and you will be ordering from {newUser.DefaultLocationID}. You may change this location any time!\n");
                        break;
                    case 3: // Create New Order
                        Console.WriteLine("Before we proceed, you cannot have more than one active order at any " +
                            "one given time. If you use this command after already creating an order, that " +
                            "previous order will be overwritten.\n" +
                            "Would you like to proceed with this command? [ Y / N ]\n");
                        charInput = char.Parse(Console.ReadLine().ToLower());
                        if(charInput == 'y') // Proceed to Create New Order / Overwrite Previous Order
                        {
                            order = new Order();
                            order.Pizzas = new List<Pizza>();
                            Console.WriteLine("You have begun your new order, but it's currently empty. " +
                                "You can use Command 4 to begin creating a new pizza!\n");
                        }
                        else if(charInput == 'n') // Cancel New Order Creation Process
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
                        charInput = char.Parse(Console.ReadLine().ToLower());
                        if (charInput == 'y') // Proceed to Create New Order / Overwrite Previous Order
                        {
                            pizza = new Pizza();
                            Console.WriteLine("You have begun creating your new pizza. There's only cheese on it for now. " +
                                "Once you've added your toppings, you can use Command 5 to save it to your order!\n");
                        }
                        else if (charInput == 'n') // Cancel New Order Creation Process
                        {
                            break;
                        }
                        else // Invalid Input
                        {
                            Console.WriteLine("Incorrect input: aborting operation and returning to safe zone.");
                            break;
                        }
                        AddToppingToPizzaSequence(pizza);
                        break;
                    case 5: // Add Pizza to Order
                        if(pizza != null && order.Pizzas.Count < 12 || (order.Value + pizza.Price) < 500.00M)
                        {
                            pizza.PizzaID = order.Pizzas.Count;
                            order.Pizzas.Add(pizza);
                            Console.WriteLine("Your pizza has been added to the order!\n" +
                                "NOTE: If you use this command again, you will add a completely " +
                                "blank pizza with no toppings. This could work as a cheese pizza!\n");
                            order.Value = order.RecalculateValue();
                            pizza = new Pizza();
                            //pizzeria.AddOrderToHistory(order);
                        }
                        else if (order.Pizzas.Count >= 12)
                        {
                            Console.WriteLine("You cannot have more than 12 pizzas in an order.\n");
                        }
                        else if ((order.Value + pizza.Price) > 500.00M)
                        {
                            Console.WriteLine("Your order cannot exceed a value of $500.00.");
                        }
                        else
                        {
                            Console.WriteLine("This pizza is non-existent (null)");
                        }
                        break;
                    case 6:
                        // Add Topping to Pizza
                        AddToppingToPizzaSequence(pizza);
                        break;
                    case 7:
                        // Remove Topping from Pizza
                        while (numericInput != 0)
                        {
                            RemoveToppingFromPizzaSequence(pizza);
                        }
                        break;
                    case 8:
                        // Remove Pizza from Order
                        order.ViewOrder();
                        Console.WriteLine("Which pizza would you like to remove?");
                        numericInput = int.Parse(Console.ReadLine());
                        order.RemovePizza(numericInput);
                        break;
                    case 9:
                        // Show Order Information
                        order.ViewOrder();
                        break;
                    case 10:
                        // Show Pizza Information
                        pizza.ShowPizzaDetails();
                        break;
                    case 11:
                        // Show Location Inventory
                        pizzeria.LocationInventory.Display();
                        break;
                    case 12:
                        // Add an Item to Location Inventory
                        int inputInt;
                        Console.WriteLine("What topping would you like to add? You can choose from the following:\n" +
                            "0 : <GO BACK>\n" +
                            "1 : Pepperoni\n" +
                            "2 : Sausage\n" +
                            "3 : Ham\n" +
                            "4 : Bacon\n" +
                            "5 : Jalapenos\n" +
                            "6 : Green Bell Peppers\n" +
                            "7 : Black Olives\n" +
                            "8 : Pineapple\n" +
                            "9 : Mushrooms\n" +
                            "10 : Onions\n");
                        inputInt = int.Parse(Console.ReadLine());
                        switch (inputInt)
                        {
                            case 0:
                                Console.WriteLine("Aborting Inventory Addition Process.");
                                break;
                            case 1:
                                Console.WriteLine("How much?");
                                inputInt = int.Parse(Console.ReadLine());
                                pizzeria.AddToInventory("pepperoni", inputInt);
                                break;
                            case 2:
                                Console.WriteLine("How much?");
                                inputInt = int.Parse(Console.ReadLine());
                                pizzeria.AddToInventory("sausage", inputInt);
                                break;
                            case 3:
                                Console.WriteLine("How much?");
                                inputInt = int.Parse(Console.ReadLine());
                                pizzeria.AddToInventory("ham", inputInt);
                                break;
                            case 4:
                                Console.WriteLine("How much?");
                                inputInt = int.Parse(Console.ReadLine());
                                pizzeria.AddToInventory("bacon", inputInt);
                                break;
                            case 5:
                                Console.WriteLine("How much?");
                                inputInt = int.Parse(Console.ReadLine());
                                pizzeria.AddToInventory("jalapenos", inputInt);
                                break;
                            case 6:
                                Console.WriteLine("How much?");
                                inputInt = int.Parse(Console.ReadLine());
                                pizzeria.AddToInventory("green bell peppers", inputInt);
                                break;
                            case 7:
                                Console.WriteLine("How much?");
                                inputInt = int.Parse(Console.ReadLine());
                                pizzeria.AddToInventory("black olives", inputInt);
                                break;
                            case 8:
                                Console.WriteLine("How much?");
                                inputInt = int.Parse(Console.ReadLine());
                                pizzeria.AddToInventory("pineapple", inputInt);
                                break;
                            case 9:
                                Console.WriteLine("How much?");
                                inputInt = int.Parse(Console.ReadLine());
                                pizzeria.AddToInventory("mushrooms", inputInt);
                                break;
                            case 10:
                                Console.WriteLine("How much?");
                                inputInt = int.Parse(Console.ReadLine());
                                pizzeria.AddToInventory("onions", inputInt);
                                break;
                            default:
                                Console.WriteLine("Incorrect input: aborting operation and returning to safe zone.\n");
                                break;
                        }
                        break;
                    case 13:
                        // Remove an Item from Location Inventory
                        int removeInt;
                        Console.WriteLine("What topping would you like to remove? You can choose from the following:\n" +
                            "0 : <GO BACK>\n" +
                            "1 : Pepperoni\n" +
                            "2 : Sausage\n" +
                            "3 : Ham\n" +
                            "4 : Bacon\n" +
                            "5 : Jalapenos\n" +
                            "6 : Green Bell Peppers\n" +
                            "7 : Black Olives\n" +
                            "8 : Pineapple\n" +
                            "9 : Mushrooms\n" +
                            "10 : Onions\n");
                        removeInt = int.Parse(Console.ReadLine());
                        switch (removeInt)
                        {
                            case 0:
                                break;
                            case 1:
                                Console.WriteLine("How much?");
                                removeInt = int.Parse(Console.ReadLine());
                                pizzeria.RemoveFromInventory("pepperoni", removeInt);
                                break;
                            case 2:
                                Console.WriteLine("How much?");
                                removeInt = int.Parse(Console.ReadLine());
                                pizzeria.RemoveFromInventory("sausage", removeInt);
                                break;
                            case 3:
                                Console.WriteLine("How much?");
                                removeInt = int.Parse(Console.ReadLine());
                                pizzeria.RemoveFromInventory("ham", removeInt);
                                break;
                            case 4:
                                Console.WriteLine("How much?");
                                removeInt = int.Parse(Console.ReadLine());
                                pizzeria.RemoveFromInventory("bacon", removeInt);
                                break;
                            case 5:
                                Console.WriteLine("How much?");
                                removeInt = int.Parse(Console.ReadLine());
                                pizzeria.RemoveFromInventory("jalapenos", removeInt);
                                break;
                            case 6:
                                Console.WriteLine("How much?");
                                removeInt = int.Parse(Console.ReadLine());
                                pizzeria.RemoveFromInventory("green bell peppers", removeInt);
                                break;
                            case 7:
                                Console.WriteLine("How much?");
                                removeInt = int.Parse(Console.ReadLine());
                                pizzeria.RemoveFromInventory("black olives", removeInt);
                                break;
                            case 8:
                                Console.WriteLine("How much?");
                                removeInt = int.Parse(Console.ReadLine());
                                pizzeria.RemoveFromInventory("pineapple", removeInt);
                                break;
                            case 9:
                                Console.WriteLine("How much?");
                                removeInt = int.Parse(Console.ReadLine());
                                pizzeria.RemoveFromInventory("mushrooms", removeInt);
                                break;
                            case 10:
                                Console.WriteLine("How much?");
                                removeInt = int.Parse(Console.ReadLine());
                                pizzeria.RemoveFromInventory("onions", removeInt);
                                break;
                            default:
                                Console.WriteLine("Incorrect input: aborting operation and returning to safe zone.\n");
                                break;
                        }
                        break;
                    case 14:
                        // Delete Location Inventory (Requires Confirmation)
                        Console.WriteLine("Are you sure? This action is completely irreversible. [ Y / N ]");
                        charInput = char.Parse(Console.ReadLine().ToLower());
                        if (charInput == 'y')
                        {
                            pizzeria.LocationInventory.EmptyInventory();
                            Console.WriteLine("Location emptied.\n");
                            pizzeria.LocationInventory.Display();
                        }
                        else if (charInput == 'n')
                        {
                            Console.WriteLine("Operation Aborted.");
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input: aborting operation and returning to safe zone.\n");
                        }
                        break;
                    case 15:
                        // Change User Default Location
                        Console.WriteLine("Please input your preferred location's ID number");
                        numericInput = int.Parse(Console.ReadLine());
                        newUser.DefaultLocationID = numericInput;
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
                            charInput = char.Parse(Console.ReadLine().ToLower());
                            if (charInput == 'y')
                            {
                                order.DeleteOrder();
                                Console.WriteLine("Your order has been erased.");
                            }
                            else if (charInput == 'n')
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
                "2 - Create New User\n" +
                "3 - Create/Overwrite Your Order\n" +
                "4 - Create Your Pizza\n" +
                "5 - Add Pizza to Order\n" +
                "6 - Add Topping to Pizza\n" +
                "7 - Remove Topping from Pizza\n" +
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

        // Allows a user to add one of 10 different toppings; exits after each addition
        static Pizza AddToppingToPizzaSequence(Pizza pizza)
        {
            int inputInt;
            Console.WriteLine("Please choose from the following to add to your pizza:\n" +
                "0 : <GO BACK>\n" +
                "1 : Pepperoni\n" +
                "2 : Sausage\n" +
                "3 : Ham\n" +
                "4 : Bacon\n" +
                "5 : Jalapenos\n" +
                "6 : Green Bell Peppers\n" +
                "7 : Black Olives\n" +
                "8 : Pineapple\n" +
                "9 : Mushrooms\n" +
                "10 : Onions\n");
            inputInt = int.Parse(Console.ReadLine());
            switch (inputInt)
            {
                case 0: // Done adding toppings; break from method
                    break;
                case 1:
                    if (pizza.toppings.Pepperoni == 0)
                    {
                        pizza.toppings.Pepperoni = 1;
                        pizza.Price += 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("This pizza already has that on it!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 2:
                    if (pizza.toppings.Sausage == 0)
                    {
                        pizza.toppings.Sausage = 1;
                        pizza.Price += 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("This pizza already has that on it!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 3:
                    if (pizza.toppings.Ham == 0)
                    {
                        pizza.toppings.Ham = 1;
                        pizza.Price += 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("This pizza already has that on it!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 4:
                    if (pizza.toppings.Bacon == 0)
                    {
                        pizza.toppings.Bacon = 1;
                        pizza.Price += 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("This pizza already has that on it!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 5:
                    if (pizza.toppings.Jalapenos == 0)
                    {
                        pizza.toppings.Jalapenos = 1;
                        pizza.Price += 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("This pizza already has that on it!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 6:
                    if (pizza.toppings.GreenBellPeppers == 0)
                    {
                        pizza.toppings.GreenBellPeppers = 1;
                        pizza.Price += 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("This pizza already has that on it!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 7:
                    if (pizza.toppings.BlackOlives == 0)
                    {
                        pizza.toppings.BlackOlives = 1;
                        pizza.Price += 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("This pizza already has that on it!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 8:
                    if (pizza.toppings.Pineapple == 0)
                    {
                        pizza.toppings.Pineapple = 1;
                        pizza.Price += 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("This pizza already has that on it!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 9:
                    if (pizza.toppings.Mushrooms == 0)
                    {
                        pizza.toppings.Mushrooms = 1;
                        pizza.Price += 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("This pizza already has that on it!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 10:
                    if (pizza.toppings.Onions == 0)
                    {
                        pizza.toppings.Onions = 1;
                        pizza.Price += 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("This pizza already has that on it!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                default:
                    Console.WriteLine("Incorrect input: aborting operation and returning to safe zone.\n");
                    break;
            }
            return pizza;
        }

        // Allows a user to remove one of 10 different toppings; exits after each removal
        static Pizza RemoveToppingFromPizzaSequence(Pizza pizza)
        {
            int inputInt;
            Console.WriteLine("Please choose from the following to remove from your pizza:\n" +
                "0 : <GO BACK>\n" +
                "1 : Pepperoni\n" +
                "2 : Sausage\n" +
                "3 : Ham\n" +
                "4 : Bacon\n" +
                "5 : Jalapenos\n" +
                "6 : Green Bell Peppers\n" +
                "7 : Black Olives\n" +
                "8 : Pineapple\n" +
                "9 : Mushrooms\n" +
                "10 : Onions\n");
            inputInt = int.Parse(Console.ReadLine());
            switch (inputInt)
            {
                case 0: // Done removing toppings; break from method
                    break;
                case 1:
                    if (pizza.toppings.Pepperoni == 1)
                    {
                        pizza.toppings.Pepperoni = 0;
                        pizza.Price -= 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("That topping isn't on this pizza!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 2:
                    if (pizza.toppings.Sausage == 1)
                    {
                        pizza.toppings.Sausage = 0;
                        pizza.Price -= 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("That topping isn't on this pizza!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 3:
                    if (pizza.toppings.Ham == 1)
                    {
                        pizza.toppings.Ham = 0;
                        pizza.Price -= 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("That topping isn't on this pizza!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 4:
                    if (pizza.toppings.Bacon == 1)
                    {
                        pizza.toppings.Bacon = 0;
                        pizza.Price -= 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("That topping isn't on this pizza!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 5:
                    if (pizza.toppings.Jalapenos == 1)
                    {
                        pizza.toppings.Jalapenos = 0;
                        pizza.Price -= 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("That topping isn't on this pizza!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 6:
                    if (pizza.toppings.GreenBellPeppers == 1)
                    {
                        pizza.toppings.GreenBellPeppers = 0;
                        pizza.Price -= 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("That topping isn't on this pizza!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 7:
                    if (pizza.toppings.BlackOlives == 1)
                    {
                        pizza.toppings.BlackOlives = 0;
                        pizza.Price -= 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("That topping isn't on this pizza!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 8:
                    if (pizza.toppings.Pineapple == 1)
                    {
                        pizza.toppings.Pineapple = 0;
                        pizza.Price -= 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("That topping isn't on this pizza!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 9:
                    if (pizza.toppings.Mushrooms == 1)
                    {
                        pizza.toppings.Mushrooms = 0;
                        pizza.Price -= 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("That topping isn't on this pizza!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                case 10:
                    if (pizza.toppings.Onions == 1)
                    {
                        pizza.toppings.Onions = 0;
                        pizza.Price -= 1.00M;
                    }
                    else
                    {
                        Console.WriteLine("That topping isn't on this pizza!\n");
                    }
                    pizza.ShowPizzaDetails();
                    break;
                default:
                    Console.WriteLine("Incorrect input: aborting operation and returning to safe zone.\n");
                    break;
            }
            return pizza;
        }
    }
}
