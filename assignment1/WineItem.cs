
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment5
{
    class WineItem
    {
        //Private Class Level Variables
        private string id;
        private string name;
        private string pack;
        private decimal price;
        private bool active;

        //Public Property to Get and Set the Id
        public string Id
        {
            get
            {
                return this.id;
            }
            set { }
        }

        //Public Property to Get and Set the Name - I know this is extra unnecessary work
        public string Name
        {
            get
            {
                return this.name;
            }
            set { }
        }
        //Public Property to Get and Set the Pack - I know this is extra unnecessary work
        public string Pack
        {
            get
            {
                return this.pack;
            }
            set { }
        }
        //Public Property to Get and Set the Price - I know this is extra unnecessary work
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set { }
        }
        //Public Property to Get and Set the Active State - I know this is extra unnecessary work
        public bool Active
        {
            get
            {
                return this.active;
            }
            set { }
        }

        //Default Constuctor
        public WineItem() { }

        //3 Parameter Constructor
        public WineItem(string id, string name, string pack, decimal price, bool active)
        {
            this.id = id;
            this.name = name;
            this.pack = pack;
            this.price = price;
            this.active = active;
        }

        //Override ToString Method to concatenate the fields together.
        public override string ToString()
        {
            return "Id: " + id + ", Name: " + name + ", Pack: " + pack + ", Price: " + price + ", Active: " + active;
        }


    }
}
