///Programmer:  Ryan Gowan
///Date:        4/10/2016
///POV:         What are you suppossed to learn from this project.
///                 Update the Assignment 1 with Wines to use a database instead of a CSV.
///                 Console app, if/else statements, switch statements, 
///                 Database, User Interface, Collections, Interface, CRUD, and Entity Framework.
///             Populate a list of beverages that have the following properties: id, name, pack, price and active.
///             Must have the ability to Read, Insert, Update, and Delete any of the items by the primary key(id).
///                            
///BOV:         Purpose of this project, if any.
///                 The ability to utilize Entity Framework using a database.
///                 The ability to implement a interface.
///                 The ability to Read, Insert, Update, and Delete items within the database.
///                 The ability to display information within the console terminal.

//  This project shows Documentation comments, above.
/*  Notes:
 *  ???/100
 */
/*
 * The Menu Choices Displayed By The UI
 * 1. Find An Item By Id And Print It
 * 2. Add New Item To The List
 * 3. Delete An Item From The List
 * 4. Update An Item By Id
 * 5. Print The Entire List Of Items
 * 6. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set a constant for the size of the collection
            const int wineItemCollectionSize = 4000;

            //Set Console Buffer Size
            Console.SetBufferSize(80, 1200);

            //Set a constant for the path to the CSV File
            //const string pathToCSVFile = "../../../datafiles/winelist.csv";

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            //Create a new instance of the Beverage Collection
            BeverageRGowanEntities beverageRGowanEntities = new BeverageRGowanEntities();

            //Create an instance of the WineItemCollection class
            IWineCollection wineItemCollection = new WineItemCollection(wineItemCollectionSize);

            //Create an instance of the CSVProcessor class
            //CSVProcessor csvProcessor = new CSVProcessor();

            //Populate the WineItemsCollection with the items in the database - I know this is extra unnecessary work
            foreach (Beverage beverage in beverageRGowanEntities.Beverages)
            {
                wineItemCollection.AddNewItem(beverage.id, beverage.name, beverage.pack, beverage.price, beverage.active);
            }

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        //Find An Item By Id And Print It
                        //Get the user input
                        String searchID = userInterface.GetSearchQuery();
                        //Try to find a item matching the user input
                        try
                        {
                            //Find the first location if there is one
                            Beverage beverageToFind = beverageRGowanEntities.Beverages.Where(beverage => beverage.id == searchID).First();
                            //Display matching item found message
                            userInterface.DisplayItemFoundHeader();
                            //Display the matching item if found
                            userInterface.DisplayItemInfo(beverageToFind);
                        }
                        catch
                        {
                            //Display a message if no matches found
                            userInterface.DisplayItemFoundError(searchID);
                        }
                        break;

                    case 2:
                        //Add A New Item To The List
                        //Get the user input
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        decimal price = userInterface.GetNewItemPrice();
                        bool activeState = userInterface.GetNewItemActiveState();

                        //Create a new instance
                        Beverage newBeverageToAdd = new Beverage();

                        //Assign the properties
                        newBeverageToAdd.id = newItemInformation[0];
                        newBeverageToAdd.name = newItemInformation[1];
                        newBeverageToAdd.pack = newItemInformation[2];
                        newBeverageToAdd.price = price;
                        newBeverageToAdd.active = activeState;

                        try
                        {
                            //Add item to database
                            beverageRGowanEntities.Beverages.Add(newBeverageToAdd);
                            beverageRGowanEntities.SaveChanges();
                            //Add item to collection - I know this is extra unnecessary work
                            wineItemCollection.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2], price, activeState);
                            //Display a Success Message
                            userInterface.DisplayAddWineItemSuccess();

                        }
                        catch
                        {
                            //Remove the item
                            beverageRGowanEntities.Beverages.Remove(newBeverageToAdd);
                            //Display an error message
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;

                    case 3:
                        //Delete An Item From The List
                        //Get the user input
                        String deleteID = userInterface.GetSearchDeleteQuery();
                        //Find a matching item if it exists
                        Beverage beverageToFindForDelete = beverageRGowanEntities.Beverages.Find(deleteID);
                        string deleteProcess = "delete";
                        if (beverageToFindForDelete != null)
                        {
                            try
                            {
                                //Remove the item from the database and try to save the changes
                                beverageRGowanEntities.Beverages.Remove(beverageToFindForDelete);
                                beverageRGowanEntities.SaveChanges();
                                //Remove the Item from the WineItemsCollection - I know this is extra unnecessary work
                                Int32 deleteLocation = wineItemCollection.FindById(deleteID);
                                wineItemCollection.RemoveId(deleteLocation);
                                //Display a Success Message
                                userInterface.DisplayDeleteSuccess(deleteID, deleteProcess);

                            }
                            catch
                            {
                                //Display an Error Message
                                userInterface.DisplayDeleteUpdateError(deleteID, deleteProcess);
                            }
                        }
                        else
                        {
                            //Display a Message stating that there were no matches found to delete
                            userInterface.DisplayNothingToDoError(deleteID, deleteProcess);
                        }
                        
                        break;

                    case 4:
                        //Update An Item By Id
                        //Get the user input
                        String updateID = userInterface.GetSearchUpdateQuery();
                        //Find a matching item if it exists
                        Beverage beverageToFindForUpdate = beverageRGowanEntities.Beverages.Find(updateID);
                        string updateProcess = "update";
                        if (beverageToFindForUpdate != null)
                        {
                            try
                            {
                                //Find the location of the id within the array
                                Int32 updateLocation = wineItemCollection.FindById(updateID);
                                //Get the users choice of what to update
                                Int32 updateChoice = userInterface.DisplayUpdateMenuAndGetResponse(beverageToFindForUpdate);
                                while (updateChoice != 5)
                                {
                                    //Create and initialize a string for information
                                    string information = null;
                                    switch (updateChoice)
                                    {
                                        
                                        case 1:
                                            //Update name of beverage
                                            information = "name";
                                            //Get the user input
                                            string tempName = userInterface.PromptForStringUpdate(information);
                                            //Verify that the name has changed
                                            if (tempName != beverageToFindForUpdate.name)
                                            {
                                                //Update the Beverage database name
                                                beverageToFindForUpdate.name = tempName;
                                            }
                                            else
                                            {
                                                //Let the user know that they haven't updated the name
                                                userInterface.DisplayDeleteUpdateError(updateID, updateProcess);
                                            }
                                            break;
                                        case 2:
                                            //Update pack of beverage
                                            information = "pack";
                                            //Get the user input
                                            string tempPack = userInterface.PromptForStringUpdate(information);
                                            //Verify that the pack has changed
                                            if (tempPack != beverageToFindForUpdate.pack)
                                            {
                                                //Update the Beverage database pack
                                                beverageToFindForUpdate.pack = tempPack;
                                            }
                                            else
                                            {
                                                //Let the user know that they haven't updated the pack
                                                userInterface.DisplayDeleteUpdateError(updateID, updateProcess);
                                            }
                                            break;
                                        case 3:
                                            information = "price";
                                            //Get the user input
                                            decimal tempPrice = userInterface.PromptForDecimalUpdate(information);
                                            //Verify that the price has changed
                                            if (tempPrice != beverageToFindForUpdate.price)
                                            {
                                                //Update the Beverage database price
                                                beverageToFindForUpdate.price = tempPrice;
                                            }
                                            else
                                            {
                                                //Let the user know that they haven't updated the price
                                                userInterface.DisplayDeleteUpdateError(updateID, updateProcess);
                                            }
                                            break;
                                        case 4:
                                            information = "active state";
                                            //Get the user input
                                            bool tempActive = userInterface.GetNewItemActiveState();
                                            //Verify that the state has changed
                                            if (tempActive != beverageToFindForUpdate.active)
                                            {
                                                //Update the Beverage database active state
                                                beverageToFindForUpdate.active = tempActive;
                                            }
                                            else
                                            {
                                                //Let the user know that they haven't updated the active state
                                                userInterface.DisplayNoChangeInState();
                                            }
                                            break;
                                    }
                                    //Get the new update menu choice of what to do from the user
                                    updateChoice = userInterface.DisplayUpdateMenuAndGetResponse(beverageToFindForUpdate);
                                }
                                //Save the changes to the database
                                beverageRGowanEntities.SaveChanges();
                                //Overwrite the contents of the array with the updated information
                                wineItemCollection.UpdateById(updateLocation, beverageToFindForUpdate);
                                //Display a Success Message
                                userInterface.DisplayDeleteSuccess(updateID, updateProcess);
                            }
                            catch
                            {
                                //Display an Error Message
                                userInterface.DisplayDeleteUpdateError(updateID, updateProcess);
                            }
                        }
                        else
                        {
                            //Display a Message stating that there were no matches found to update
                            userInterface.DisplayNothingToDoError(updateID, updateProcess);
                        }
                        break;

                    case 5:
                        //Print Entire List Of Items
                        userInterface.DisplayAllItemsHeader();
                        foreach (Beverage beverage in beverageRGowanEntities.Beverages)
                        {
                            //Print the information of each Beverage
                            userInterface.DisplayItemInfo(beverage);
                        }
                        break;

                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
