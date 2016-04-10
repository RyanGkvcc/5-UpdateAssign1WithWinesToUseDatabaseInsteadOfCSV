
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment5
{
    class UserInterface
    {
        const int maxMenuChoice = 6;
        const int MAXBOOLCHOICE = 2;
        const int MAXUPDATEMENUCHOICE = 5;
        //---------------------------------------------------
        //Public Methods
        //---------------------------------------------------

        //Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.WriteLine("Welcome to the beverage program");
        }

        //Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            //declare variable to hold the selection
            string selection;

            //Display menu, and prompt
            this.displayMenu();
            this.displayPrompt();

            //Get the selection they enter
            selection = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(selection, maxMenuChoice))
            {
                //display error message
                this.displayErrorMessage();

                //display the prompt again
                this.displayPrompt();

                //get the selection again
                selection = this.getSelection();
            }
            //Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        //Get the search query from the user
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What Id would you like to search for?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //Get the id to delete from the user
        public string GetSearchDeleteQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What Id would you like to delete?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //Get the id to update from the user
        public string GetSearchUpdateQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What Id would you like to update?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //Get New Item Information From The User.
        public string[] GetNewItemInformation()
        {
            Console.WriteLine();
            Console.WriteLine("What is the new items Id?");
            Console.Write("> ");
            string id = Console.ReadLine();
            Console.WriteLine("What is the new items Name?");
            Console.Write("> ");
            string description = Console.ReadLine();
            Console.WriteLine("What is the new items Pack?");
            Console.Write("> ");
            string pack = Console.ReadLine();


            return new string[] { id, description, pack };
        }

        //Get New Item Price Form The User
        public decimal GetNewItemPrice()
        {
            //Declares and initializes the price decimal to be returned
            decimal price = 0;
            Console.WriteLine("What is the new items Price?");
            Console.Write("> ");
            //Tries to parse the user input
            try
            {
                price = decimal.Parse(this.getSelection());
            }
            //If the user input can not be parsed, an error message is displayed and uses recursion
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a valid price.");
                Console.WriteLine();
                GetNewItemPrice();
            }
            return price;

        }

        //Get New Item Active State Form The User
        public bool GetNewItemActiveState()
        {
            //Initializes the state variable to a non-valid choice
            string state;
            //Declares and initializes the boolean to be returned
            bool activeState = true;

            //Display menu, and prompt
            this.displayActiveStateMenu();
            this.displayPrompt();

            //Get the selection they enter
            state = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(state, MAXBOOLCHOICE))
            {
                //display error message
                this.displayErrorMessage();

                //display the prompt again
                this.displayPrompt();

                //get the selection again
                state = this.getSelection();
            }
            //The user made a valid selection, now we will check if the boolean should be changed from the initial state
            //Changes the activeState boolean if the user has selected "No"
            if (Int32.Parse(state) == 2)
            {
                activeState = false;
            }
            return activeState;
        }

        //Display Delete Success
        public void DisplayDeleteSuccess(string deleteID, string process)
        {
            Console.WriteLine();
            Console.WriteLine("Beverage Id: " + deleteID + " has Successfully been " + process + "d");
        }

        //Display Delete/Update Error
        public void DisplayDeleteUpdateError(string deleteID, string process)
        {
            Console.WriteLine();
            Console.WriteLine("The " + process + " process of Beverage Id: " + deleteID + " has failed.");
            Console.WriteLine("Please try again");
        }

        //Display No Matching Items to Delete/Update
        public void DisplayNothingToDoError(string deleteID, string process)
        {
            Console.WriteLine();
            Console.WriteLine("There are no Beverages matching Id: " + deleteID + " in the database to " + process);
        }

        //Display a message that the active state of the beverage has not changed
        public void DisplayNoChangeInState()
        {
            Console.WriteLine();
            Console.WriteLine("The active state of the beverage has not changed");
        }

        public Int32 DisplayUpdateMenuAndGetResponse(Beverage beverageToFindForUpdate)
        {
            //declare variable to hold the selection
            string selection;

            //Display menu, and prompt
            this.displayUpdateMenu(beverageToFindForUpdate);
            this.displayPrompt();

            //Get the selection they enter
            selection = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(selection, MAXUPDATEMENUCHOICE))
            {
                //display error message
                this.displayErrorMessage();

                //display the prompt again
                this.displayPrompt();

                //get the selection again
                selection = this.getSelection();
            }
            //Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        //Prompts for an update to a string
        public string PromptForStringUpdate(string information)
        {
            string update;
            Console.WriteLine("Please enter a new " + information);
            update = this.getSelection();
            return update;
        }

        //Prompts for an update to a decimal
        public decimal PromptForDecimalUpdate(string information)
        {
            decimal update = 0m;
            Console.WriteLine("Please enter a new " + information);
            //Tries to parse the user input
            try
            {
                update = decimal.Parse(this.getSelection());
            }
            //If the user input can not be parsed, an error message is displayed and uses recursion
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a valid price.");
                Console.WriteLine();
                PromptForDecimalUpdate(information);
            }
            if (update <= 0m)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a valid price.");
                Console.WriteLine();
                PromptForDecimalUpdate(information);
            }
            return update;
        }

        //Display All Items
        public void DisplayAllItems(string[] allItemsOutput)
        {
            Console.WriteLine();
            foreach (string itemOutput in allItemsOutput)
            {
                Console.WriteLine(itemOutput);
            }
        }

        //Display All Items Error
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.WriteLine("There are no items in the list to print");
        }

        //Display Item Found Header
        public void DisplayItemFoundHeader()
        {
            Console.WriteLine();
            Console.WriteLine("Item Found!");
            this.DisplayAllItemsHeader();
        }
        //Display All Items Header
        public void DisplayAllItemsHeader()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------Beverage Information----------------------");
        }
        //Display Item Information
        public void DisplayItemInfo(Beverage itemInformation)
        {
            Console.WriteLine();
            Console.WriteLine("Beverage Id: " + itemInformation.id);
            Console.WriteLine("Beverage Name: " + itemInformation.name.Trim());
            Console.WriteLine("Beverage Pack: " + itemInformation.pack);
            Console.WriteLine("Beverage Price: " + itemInformation.price.ToString("C"));
            Console.WriteLine("Beverage Active: " + itemInformation.active);
        }

        //Display Item Found Error
        public void DisplayItemFoundError(String searchID)
        {
            Console.WriteLine();
            Console.WriteLine("A Match was not found for Id: " + searchID);
        }

        //Display Add Wine Item Success
        public void DisplayAddWineItemSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The Item was successfully added");
        }

        //Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.WriteLine("An Item With That Id Already Exists");
        }

        
        //---------------------------------------------------
        //Private Methods
        //---------------------------------------------------

        //Display the Menu
        private void displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Find An Item By Id And Print It");
            Console.WriteLine("2. Add New Item To The List");
            Console.WriteLine("3. Delete An Item From The List");
            Console.WriteLine("4. Update An Item By Id");
            Console.WriteLine("5. Print The Entire List Of Items");
            Console.WriteLine("6. Exit Program");
        }
        //Display the update menu
        private void displayUpdateMenu(Beverage beverageToFindForUpdate)
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to update on this Beverage?");
            Console.WriteLine();
            Console.WriteLine("1: Name: " + beverageToFindForUpdate.name.Trim());
            Console.WriteLine("2: Pack: " + beverageToFindForUpdate.pack);
            Console.WriteLine("3: Price: " + beverageToFindForUpdate.price.ToString("C"));
            Console.WriteLine("4: Active: " + beverageToFindForUpdate.active);
            Console.WriteLine("5: Update Complete");
        }

        //Display the active state menu
        private void displayActiveStateMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Is this an active item?");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");
            Console.Write("> ");
        }

        //Display the Prompt
        private void displayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        //Display the Error Message
        private void displayErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("That is not a valid option. Please make a valid choice");
        }

        //Get the selection from the user
        private string getSelection()
        {
            return Console.ReadLine();
        }

        //Verify that a selection from the main menu is valid
        private bool verifySelectionIsValid(string selection, int maxChoice)
        {
            //Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                //Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                //If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= maxChoice)
                {
                    //set the return value to true
                    returnValue = true;
                }
            }
            //If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                //set return value to false even though it should already be false
                returnValue = false;
            }

            //Return the reutrnValue
            return returnValue;
        }
    }
}
