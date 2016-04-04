///Programmer:  Ryan Gowan
///Date:        4/4/2016
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

            //Set a constant for the path to the CSV File
            //const string pathToCSVFile = "../../../datafiles/winelist.csv";

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            //Create an instance of the WineItemCollection class
            IWineCollection wineItemCollection = new WineItemCollection(wineItemCollectionSize);

            //Create an instance of the CSVProcessor class
            //CSVProcessor csvProcessor = new CSVProcessor();

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
                        //string[] allItems = wineItemCollection.GetPrintStringsForAllItems();
                        //if (allItems.Length > 0)
                        //{
                        //    //Display all of the items
                        //    userInterface.DisplayAllItems(allItems);
                        //}
                        //else
                        //{
                        //    //Display error message for all items
                        //    userInterface.DisplayAllItemsError();
                        //}
                        break;

                    case 2:
                        //Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        if (wineItemCollection.FindById(newItemInformation[0]) == null)
                        {
                            wineItemCollection.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2]);
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;

                    case 3:
                        //Delete An Item From The List
                        
                        break;

                    case 4:
                        //Update An Item By Id

                        break;

                    case 5:
                        //Print Entire List Of Items
                        string[] allItems = wineItemCollection.GetPrintStringsForAllItems();
                        if (allItems.Length > 0)
                        {
                            //Display all of the items
                            userInterface.DisplayAllItems(allItems);
                        }
                        else
                        {
                            //Display error message for all items
                            userInterface.DisplayAllItemsError();
                        }
                        break;

                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
