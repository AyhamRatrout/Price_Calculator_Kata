using System;
using System.Collections;
using System.Collections.Generic;

namespace Price_Calculator_Classes
{
    public class ShoppingCart: IEnumerable<Product>
    {
        private List<Product> ListOfProducts;
        public PriceCalculator PriceCalculator{get; private set;}
        public double Subtotal{get; private set;}
        public double TotalTax{get; private set;}
        public double TotalDiscount{get; private set;}
        public double Total{get; private set;}
        public double TotalAdditionalCosts{get; private set;}

        public int Count
        {
            get{return this.ListOfProducts.Count;}
        }

        public ShoppingCart(PriceCalculator priceCalculator)
        {
            this.ListOfProducts = new List<Product>();
            Validate(priceCalculator);
            this.PriceCalculator = priceCalculator;
        }

        public void Add(Product product)
        {
            if(product == null)
            {
                throw new ArgumentException("Operation failed! Cannot add a null product to your shopping cart.");
            }
            else
            {
                this.ListOfProducts.Add(product);
                IncrementTotals(product);
            }
        }

        private void IncrementTotals(Product product)
        {
            this.Subtotal += product.Price;
            var BeforeTaxDiscounts = this.PriceCalculator.BeforeTaxDiscountCalculator.Calculate(product);
            this.TotalTax += this.PriceCalculator.TaxCalculator.CalculateTaxAmount(product.Price - BeforeTaxDiscounts);
            this.TotalDiscount += (BeforeTaxDiscounts + this.PriceCalculator.AfterTaxDiscountCalculator.Calculate(product.Price - BeforeTaxDiscounts, product));
            this.TotalAdditionalCosts += AdditionalCostsCalculator.CalculateAdditionalCosts(product);
            this.Total += this.PriceCalculator.CalculatePrice(product);
        }

        public void Remove(Product product)
        {
            if(this.ListOfProducts.Contains(product))
            {
                this.ListOfProducts.Remove(product);
                DecrementTotals(product);
            }
            else
            {
                Console.WriteLine("Operation failed! The product you are trying to remove is not in your shopping cart...");
            }
        }

        private void DecrementTotals(Product product)
        {
            this.Subtotal -= product.Price;
            var BeforeTaxDiscounts = this.PriceCalculator.BeforeTaxDiscountCalculator.Calculate(product);
            this.TotalTax -= this.PriceCalculator.TaxCalculator.CalculateTaxAmount(product.Price - BeforeTaxDiscounts);
            this.TotalDiscount -= BeforeTaxDiscounts + this.PriceCalculator.AfterTaxDiscountCalculator.Calculate(product.Price - BeforeTaxDiscounts, product);
            this.TotalAdditionalCosts += AdditionalCostsCalculator.CalculateAdditionalCosts(product);
            this.Total -= this.PriceCalculator.CalculatePrice(product);
        }

        public void Clear()
        {
            this.ListOfProducts.Clear();
        }

        public bool Contains(Product product)
        {
            if(this.ListOfProducts.Contains(product))
            {
                return true;
            }
            return false;
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return this.ListOfProducts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Validate(PriceCalculator priceCalculator)
        {
            if(priceCalculator == null)
            {
                throw new ArgumentException("Operation failed! Please make sure that the PriceCalculator you are providing is not null.");
            }
        }
    }
}

