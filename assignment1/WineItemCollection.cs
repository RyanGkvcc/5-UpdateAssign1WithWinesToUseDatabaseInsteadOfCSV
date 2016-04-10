
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment5
{
    class WineItemCollection : IWineCollection
    {
        //Private Variables
        WineItem[] wineItems;
        int wineItemsLength;

        //Constuctor. Must pass the size of the collection.
        public WineItemCollection(int size)
        {
            wineItems = new WineItem[size];
            wineItemsLength = 0;
        }

        //Add a new item to the collection
        public void AddNewItem(string id, string name, string pack, decimal price, bool active)
        {
            //Add a new WineItem to the collection. Increase the Length variable.
            wineItems[wineItemsLength] = new WineItem(id, name, pack, price, active);
            wineItemsLength++;
        }
        
        //Get The Print String Array For All Items
        public string[] GetPrintStringsForAllItems()
        {
            //Create and array to hold all of the printed strings
            string[] allItemStrings = new string[wineItemsLength];
            //set a counter to be used
            int counter = 0;

            //If the wineItemsLength is greater than 0, create the array of strings
            if (wineItemsLength > 0)
            {
                //For each item in the collection
                foreach (WineItem wineItem in wineItems)
                {
                    //if the current item is not null.
                    if (wineItem != null)
                    {
                        //Add the results of calling ToString on the item to the string array.
                        allItemStrings[counter] = wineItem.ToString();
                        counter++;
                    }
                }
            }
            //Return the array of item strings
            return allItemStrings;
        }

        //Find an item by it's Id
        public Int32 FindById(string id)
        {
            //Declare and initialize a counter
            Int32 counter = 0;
            Int32 location = -1;
            
            //For each WineItem in wineItems
            foreach (WineItem wineItem in wineItems)
            {
                //If the wineItem is not null
                if (wineItem != null)
                {
                    //if the wineItem Id is the same as the search id
                    if (wineItem.Id == id)
                    {
                        //Establishes the location for the update/delete process
                        location = counter;
                    }
                }
                counter++;
            }
            return location;
        }

        //Remove the matching item from the wineItems array - I know this is extra unnecessary work
        public void RemoveId(Int32 location)
        {
            //Removes any information stored in the array location passed in
            Array.Clear(wineItems, location, 1);
            //Did not decrement the length of the wineItemsLength because the item removed may not be the last item of the array.
            //This may cause null locations in the array, which can be filled in later with program modifications, or everything in the 
            //array could be moved by one location. 
        }

        //Update the wineItems array to match the Beverages database - I know this is extra unnecessary work
        public void UpdateById(Int32 location, Beverage updatedBeverage)
        {
            //Overwrites the information that was stored in the array location passed in with the information of the updated Beverage
            wineItems[location] = new WineItem(updatedBeverage.id, updatedBeverage.name, updatedBeverage.pack, updatedBeverage.price, updatedBeverage.active);
        }
    }
}
