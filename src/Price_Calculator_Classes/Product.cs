using System;

namespace Price_Calculator_Classes
{
    /*
        This class defines a Product type. Each Product has a Name (string), a UPC (int), a Price (double), and a List of Additional Costs
        (AdditionalCostList).

        Allows the user to create a Product instance providing the necessary parameters and Validates each Product instance before creation.
    */
    public class Product
    {
        public string Name { get; private set; } //Stores the Name of a Product instance.
        public int UPC { get; private set; } //Stores the UPC (Universal Product Code) of a Product instance.
        public double Price { get; private set; } //Stores the Price of a Product instance.
        public AdditionalCostsList ListOfCosts { get; private set; } //Stores a List of the Additional Costs for a Product instance.

        /*
            Class constructor initializes a Product instance provided a Name, UPC, and a Price. 
            
            Creates an empty AdditionalCostsLists instance and Validates the inputs before creating the Product instance.
        */
        public Product(string Name, int UPC, double Price)
        {
            this.Name = Name;
            this.UPC = UPC;
            this.Price = Math.Round(Price, 2);
            this.ListOfCosts = new AdditionalCostsList();
            Validate(); //validates the values above before creating a Product instance
        }

        /*
            Class constructor initializes a Product instance provided a Name, UPC, Price, and an AdditionalCostsList.
            
            Validates all the inputs for validity before creating the Product instance.
        */
        public Product(string Name, int UPC, double Price, AdditionalCostsList ListOfCosts)
        {
            this.Name = Name;
            this.UPC = UPC;
            this.Price = Math.Round(Price, 2);
            this.ListOfCosts = ListOfCosts;
            Validate(); //validates the values above before creating a Product instance
        }

        //Helper method checks a Products fields for validity. Throws an ArgumentException if any of the fields is not valid.
        private void Validate()
        {
            if (!String.IsNullOrWhiteSpace(this.Name))
            {
                if (this.UPC > 0)
                {
                    if (this.Price > 0)
                    {
                        if (this.ListOfCosts != null)
                        {
                            return;
                        }
                    }
                }
            }
            throw new ArgumentException("Invalid inputs! Please make sure that the product's name is not null, empty, or whitespace, the product's UPC is greater than zero, the product's price is also greater than zero, and that the AdditionalCostList you are providing is not null.");
        }
    }
}