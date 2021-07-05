using System;

namespace Price_Calculator_Classes
{
    /*
        This class defines a Product type. Each Product has a Name (string), a UPC (int), and a Price (double). A Product may also have
        a List of Additional Costs (AdditionalCostList) and a Discount Cap (DiscountCap). 

        Allows the user to create a Product instance providing the necessary parameters and Validates each Product instance before creation.
    */
    public class Product
    {
        public string Name { get; private set; } //Stores the Name of a Product instance.
        public int UPC { get; private set; } //Stores the UPC (Universal Product Code) of a Product instance.
        public double Price { get; private set; } //Stores the Price of a Product instance.
        public AdditionalCostsList ListOfCosts { get; private set; } //Stores a List of the Additional Costs for a Product instance.
        public DiscountCap DiscountCap { get; private set; } //Stores any DiscountCaps applied to a Product instance.

        /*
            Class constructor initializes a Product instance provided a Name, UPC, and a Price. 
            
            Creates an empty AdditionalCostsLists instance, a very high DiscountCap instance, then Validates the inputs before 
            creating the Product instance.
        */
        public Product(string Name, int UPC, double Price)
        {
            this.Name = Name;
            this.UPC = UPC;
            this.Price = Math.Round(Price, 4);
            this.ListOfCosts = new AdditionalCostsList();
            this.DiscountCap = new DiscountCap(double.MaxValue, AmountType.Absolute);
            Validate(); //validates the values above before creating a Product instance
        }

        /*
            Class constructor initializes a Product instance provided a Name, UPC, Price, and an AdditionalCostsList.
            
            Creates a very high DiscountCap instance then Validates all the inputs for validity before creating the Product instance.
        */
        public Product(string Name, int UPC, double Price, AdditionalCostsList ListOfCosts)
        {
            this.Name = Name;
            this.UPC = UPC;
            this.Price = Math.Round(Price, 4);
            this.ListOfCosts = ListOfCosts;
            this.DiscountCap = new DiscountCap(double.MaxValue, AmountType.Absolute);
            Validate(); //validates the values above before creating a Product instance
        }

        /*
            Class constructor initializes a Product instance provided a Name, UPC, a Price, and a DiscountCap instance. 
            
            Creates an empty AdditionalCostsLists instance then Validates the inputs before creating the Product instance.
        */
        public Product(string Name, int UPC, double Price, DiscountCap DiscountCap)
        {
            this.Name = Name;
            this.UPC = UPC;
            this.Price = Math.Round(Price, 4);
            this.ListOfCosts = new AdditionalCostsList();
            this.DiscountCap = DiscountCap;
            Validate();
        }

        /*
            Class constructor initializes a Product instance provided a Name, UPC, a Price, an AdditionalCostsList instance, and a DiscountCap instance. 
            
            Validates the inputs before creating the Product instance.
        */
        public Product(string Name, int UPC, double Price, DiscountCap DiscountCap, AdditionalCostsList ListOfCosts)
        {
            this.Name = Name;
            this.UPC = UPC;
            this.Price = Math.Round(Price, 4);
            this.ListOfCosts = ListOfCosts;
            this.DiscountCap = DiscountCap;
            Validate();
        }

        //Helper method checks a Products fields for validity. Throws an ArgumentException if any of the fields is not valid.
        private void Validate()
        {
            if (String.IsNullOrWhiteSpace(this.Name))
            {
                throw new ArgumentException("Invalid input! Please make sure that the Name you are providing is not null, empty, or whitespace.");
            }

            if (this.UPC <= 0)
            {
                throw new ArgumentException("Invalid input! Please make sure that the UPC you are providing is not less than or equal to zero.");
            }

            if (this.Price <= 0)
            {
                throw new ArgumentException("Invalid input! Please make sure that the Price you are providing is not less than or equal to zero.");
            }

            if (this.ListOfCosts == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the Additional Costs List you are providing is not null.");
            }

            if (this.DiscountCap == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the Discount Cap you are providing is not null.");
            }
        }
    }
}