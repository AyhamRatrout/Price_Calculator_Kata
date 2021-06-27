using System;

namespace Price_Calculator_Classes
{
    //Class responsible for printing a customer's purchase receipt
    public class Receipt 
    {
        private double Subtotal; //total before taxes and discounts
        private double Total; //amount to pay after applying taxes and discounts
        private double TotalTax; //the total amount of tax to pay
        private double TotalDiscount; //the total amount of discounts deducted

        //Makes calls to the helper methods in this class to generate and print a receipt for a customer.
        public void GenerateReceipt(Customer customer)
        {
            GenerateReceiptHeader();

            foreach(var item in customer.ShoppingCart) //enumerates over every product in a customer's shopping cart
            {
                PopulateAndFormatReceiptColumns(item.Name, item.Price);
                IncrementTotals(customer, item);                
            }

            FormatTotals();
        }

        //Creates a receipt header which contains a title and the time at which this receipt is generated.
        private void GenerateReceiptHeader()
        {
            Console.WriteLine("\t  Customer Receipt");
            Console.WriteLine("\t" + DateTime.Now);
            Console.WriteLine();
            Console.WriteLine("Item \t\t\t\tPrice");
            Console.WriteLine();
        }

        //Adds a product's name and price to the receipt. Does any necessary formatting for aesthetic reasons.
        private void PopulateAndFormatReceiptColumns(String Name, double Price)
        {
            Console.WriteLine(String.Format("{0, -10} {1, 27}", Name, "$"+ Price));
        }
        
        //Adds a product's price to subtotal, tax amount to toal tax, discount amount to total discount, and adjusted price to total.
        private void IncrementTotals(Customer customer, Product product)
        {
            Subtotal += product.Price;
            TotalTax += customer.PriceCalculator.TaxCalculator.CalculateTaxAmount(product);
            TotalDiscount += customer.PriceCalculator.DiscountCalculator.CalculateTotalDiscountAmount(product);
            Total += customer.PriceCalculator.CalculateAdjustedPrice(product);
        }


        //Does the required formatting to the total amounts at the bottom of the receipt (rounds and adds whitespace for aesthetic).
        private void FormatTotals()
        {
            Console.WriteLine("************************************************************");
            Console.WriteLine($"Subtotal: \t\t\t${Math.Round(Subtotal, 2)}");
            Console.WriteLine($"Total tax amount: \t\t${Math.Round(TotalTax, 2)}");
            Console.WriteLine($"Total discount amount: \t\t${Math.Round(TotalDiscount, 2)}");
            Console.WriteLine($"Total: \t\t\t\t${Math.Round(Total, 2)}");
            Console.WriteLine();
        }
    }
}