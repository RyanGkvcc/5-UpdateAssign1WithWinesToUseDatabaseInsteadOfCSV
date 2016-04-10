using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment5
{
    interface IWineCollection
    {
        void AddNewItem(string id, string name, string pack, decimal price, bool active);

        string[] GetPrintStringsForAllItems();

        Int32 FindById(string id);

        void RemoveId(Int32 location);//I know this is extra unnecessary work

        void UpdateById(Int32 location, Beverage updatedBeverage);//I know this is extra unnecessary work
    }
}
