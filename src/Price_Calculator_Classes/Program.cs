using System;

namespace Price_Calculator_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestPriceCalculatorWithAdditiveCombining();
            //TestPriceCalculatorWithMultiplicativeCombining();
            TestPriceCalculatorWithAdditiveCombiningWithDiscountCap();
            TestPriceCalculatorWithMultiplicativeCombiningWithDiscountCap();
        }

        /*
            Tests the Additive Combining feature for a ShoppingCart instance's PriceCalculator.            
        */
        public static void TestPriceCalculatorWithAdditiveCombining()
        {
            //create two discocunt lists: a RelativeDiscountList and a SpecialDiscountList
            var relativeDiscountList = new RelativeDiscountList();
            var specialDiscountList = new SpecialDiscountList();

            //Add two Discounts to each list (four discounts total). One Discount is applied before tax while the other is applied after tax.
            relativeDiscountList.Add(new RelativeDiscount(20, Precedence.BeforeTax));
            relativeDiscountList.Add(new RelativeDiscount(10, Precedence.AfterTax));
            specialDiscountList.Add(new SpecialDiscount(1122331, 15, Precedence.BeforeTax));
            specialDiscountList.Add(new SpecialDiscount(1122331, 10, Precedence.AfterTax));

            //Create a PriceCalculator instance. Set the Tax amount to 25% and pass in the RelativeDiscountList and the SpecialDiscountList from above. Make Calculator Additive.
            var PriceCalculator = new PriceCalculator(25, relativeDiscountList, specialDiscountList, DiscountCombining.Additive);

            //Create different Product instance to be added to the ShoppingCart later in the method.
            var Apples = new Product("Apples", 11223344, 17.25);
            var Bananas = new Product("Bananas", 1122331, 20.25);
            var Lofas = new Product("Lofas", 1122331, 14.25);
            var Orbees = new Product("Orbees", 1122331, 10.25);

            //Add some AdditionalCosts to the Apple Product.
            Apples.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Apples.ListOfCosts.Add(new AdditionalCost("Shining", 5, AmountType.Absolute));
            Apples.ListOfCosts.Add(new AdditionalCost("Washing", 2, AmountType.Absolute));

            //Add some AdditionalCosts to the Bananas Product.
            Bananas.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Bananas.ListOfCosts.Add(new AdditionalCost("Shipping", 5, AmountType.Absolute));
            Bananas.ListOfCosts.Add(new AdditionalCost("Administritive costs", 2, AmountType.Absolute));

            //Add some AdditionalCosts to the Lofas Product.
            Lofas.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Lofas.ListOfCosts.Add(new AdditionalCost("Shipping", 5, AmountType.Absolute));
            Lofas.ListOfCosts.Add(new AdditionalCost("Marketing", 2, AmountType.Absolute));

            //Add some AdditionalCosts to the Orbees Product.
            Orbees.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Orbees.ListOfCosts.Add(new AdditionalCost("Shipping", 5, AmountType.Absolute));
            Orbees.ListOfCosts.Add(new AdditionalCost("Fun cost", 2, AmountType.Absolute));

            //Create a ShoppingCart instance and populate it with the items (Products) initialized above.
            var shoppingCart = new ShoppingCart(PriceCalculator);
            shoppingCart.Add(Apples);
            shoppingCart.Add(Bananas);
            shoppingCart.Add(Lofas);
            shoppingCart.Add(Orbees);

            //Generate a Receipt and a Report for the ShoppingCart to view the results of the different calculations.
            var receipt = new Receipt(shoppingCart);
            receipt.Print();
            var report = new Report(shoppingCart);
            report.Print();
        }

        /*
            Tests the Multiplicative Combining feature for a ShoppingCart instance's PriceCalculator.
        */
        public static void TestPriceCalculatorWithMultiplicativeCombining()
        {
            //create two discocunt lists: a RelativeDiscountList and a SpecialDiscountList
            var relativeDiscountList = new RelativeDiscountList();
            var specialDiscountList = new SpecialDiscountList();

            //Add two Discounts to each list (four discounts total). One Discount is applied before tax while the other is applied after tax.
            relativeDiscountList.Add(new RelativeDiscount(20, Precedence.BeforeTax));
            relativeDiscountList.Add(new RelativeDiscount(10, Precedence.AfterTax));
            specialDiscountList.Add(new SpecialDiscount(1122331, 15, Precedence.BeforeTax));
            specialDiscountList.Add(new SpecialDiscount(1122331, 10, Precedence.AfterTax));

            //Create a PriceCalculator instance. Set the Tax amount to 25% and pass in the RelativeDiscountList and the SpecialDiscountList from above. Make calculator Multiplicative.
            var PriceCalculator = new PriceCalculator(25, relativeDiscountList, specialDiscountList, DiscountCombining.Multiplicative);

            //Create different Product instance to be added to the ShoppingCart later in the method.
            var Apples = new Product("Apples", 11223344, 17.25);
            var Bananas = new Product("Bananas", 1122331, 20.25);
            var Lofas = new Product("Lofas", 1122331, 14.25);
            var Orbees = new Product("Orbees", 1122331, 10.25);

            //Add some AdditionalCosts to the Apple Product.
            Apples.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Apples.ListOfCosts.Add(new AdditionalCost("Shining", 5, AmountType.Absolute));
            Apples.ListOfCosts.Add(new AdditionalCost("Washing", 2, AmountType.Absolute));

            //Add some AdditionalCosts to the Bananas Product.
            Bananas.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Bananas.ListOfCosts.Add(new AdditionalCost("Shipping", 5, AmountType.Absolute));
            Bananas.ListOfCosts.Add(new AdditionalCost("Administritive costs", 2, AmountType.Absolute));

            //Add some AdditionalCosts to the Lofas Product.
            Lofas.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Lofas.ListOfCosts.Add(new AdditionalCost("Shipping", 5, AmountType.Absolute));
            Lofas.ListOfCosts.Add(new AdditionalCost("Marketing", 2, AmountType.Absolute));

            //Add some AdditionalCosts to the Orbees Product.
            Orbees.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Orbees.ListOfCosts.Add(new AdditionalCost("Shipping", 5, AmountType.Absolute));
            Orbees.ListOfCosts.Add(new AdditionalCost("Fun cost", 2, AmountType.Absolute));

            //Create a ShoppingCart instance and populate it with the items (Products) initialized above.
            var shoppingCart = new ShoppingCart(PriceCalculator);
            shoppingCart.Add(Apples);
            shoppingCart.Add(Bananas);
            shoppingCart.Add(Lofas);
            shoppingCart.Add(Orbees);

            //Generate a Receipt and a Report for the ShoppingCart to view the results of the different calculations.
            var receipt = new Receipt(shoppingCart);
            receipt.Print();
            var report = new Report(shoppingCart);
            report.Print();
        }

        //Tests the DiscountCap feature for a ShoppingCart instance with Additive Combining.
        public static void TestPriceCalculatorWithAdditiveCombiningWithDiscountCap()
        {
            //create two discocunt lists: a RelativeDiscountList and a SpecialDiscountList
            var relativeDiscountList = new RelativeDiscountList();
            var specialDiscountList = new SpecialDiscountList();

            //Add two Discounts to each list (four discounts total). One Discount is applied before tax while the other is applied after tax.
            relativeDiscountList.Add(new RelativeDiscount(20, Precedence.BeforeTax));
            relativeDiscountList.Add(new RelativeDiscount(10, Precedence.AfterTax));
            specialDiscountList.Add(new SpecialDiscount(1122331, 15, Precedence.BeforeTax));
            specialDiscountList.Add(new SpecialDiscount(1122331, 10, Precedence.AfterTax));

            //Create a PriceCalculator instance. Set the Tax amount to 25% and pass in the RelativeDiscountList and the SpecialDiscountList from above. Make Calculator Additive.
            var PriceCalculator = new PriceCalculator(25, relativeDiscountList, specialDiscountList, DiscountCombining.Additive);

            //Create different Product instance to be added to the ShoppingCart later in the method. Add a DiscountCap instance to each Product.
            var Apples = new Product("Apples", 11223344, 17.25, new DiscountCap(3, AmountType.Absolute));
            var Bananas = new Product("Bananas", 1122331, 20.25, new DiscountCap(8, AmountType.Absolute));
            var Lofas = new Product("Lofas", 1122331, 14.25, new DiscountCap(30, AmountType.Percentage));
            var Orbees = new Product("Orbees", 1122331, 10.25, new DiscountCap(40, AmountType.Percentage));

            //Add some AdditionalCosts to the Apple Product.
            Apples.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Apples.ListOfCosts.Add(new AdditionalCost("Shining", 5, AmountType.Absolute));
            Apples.ListOfCosts.Add(new AdditionalCost("Washing", 2, AmountType.Absolute));

            //Add some AdditionalCosts to the Bananas Product.
            Bananas.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Bananas.ListOfCosts.Add(new AdditionalCost("Shipping", 5, AmountType.Absolute));
            Bananas.ListOfCosts.Add(new AdditionalCost("Administritive costs", 2, AmountType.Absolute));

            //Add some AdditionalCosts to the Lofas Product.
            Lofas.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Lofas.ListOfCosts.Add(new AdditionalCost("Shipping", 5, AmountType.Absolute));
            Lofas.ListOfCosts.Add(new AdditionalCost("Marketing", 2, AmountType.Absolute));

            //Add some AdditionalCosts to the Orbees Product.
            Orbees.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Orbees.ListOfCosts.Add(new AdditionalCost("Shipping", 5, AmountType.Absolute));
            Orbees.ListOfCosts.Add(new AdditionalCost("Fun cost", 2, AmountType.Absolute));

            //Create a ShoppingCart instance and populate it with the items (Products) initialized above.
            var shoppingCart = new ShoppingCart(PriceCalculator);
            shoppingCart.Add(Apples);
            shoppingCart.Add(Bananas);
            shoppingCart.Add(Lofas);
            shoppingCart.Add(Orbees);

            //Generate a Receipt and a Report for the ShoppingCart to view the results of the different calculations.
            var receipt = new Receipt(shoppingCart);
            receipt.Print();
            var report = new Report(shoppingCart);
            report.Print();
        }

        //Tests the DiscountCap feature for a ShoppingCart instance with Multiplicative Combining.
        public static void TestPriceCalculatorWithMultiplicativeCombiningWithDiscountCap()
        {
            //create two discocunt lists: a RelativeDiscountList and a SpecialDiscountList
            var relativeDiscountList = new RelativeDiscountList();
            var specialDiscountList = new SpecialDiscountList();

            //Add two Discounts to each list (four discounts total). One Discount is applied before tax while the other is applied after tax.
            relativeDiscountList.Add(new RelativeDiscount(20, Precedence.BeforeTax));
            relativeDiscountList.Add(new RelativeDiscount(10, Precedence.AfterTax));
            specialDiscountList.Add(new SpecialDiscount(1122331, 15, Precedence.BeforeTax));
            specialDiscountList.Add(new SpecialDiscount(1122331, 10, Precedence.AfterTax));

            //Create a PriceCalculator instance. Set the Tax amount to 25% and pass in the RelativeDiscountList and the SpecialDiscountList from above. Make calculator Multiplicative.
            var PriceCalculator = new PriceCalculator(25, relativeDiscountList, specialDiscountList, DiscountCombining.Multiplicative);

            //Create different Product instance to be added to the ShoppingCart later in the method. Add a DiscountCap instance to each Product.
            var Apples = new Product("Apples", 11223344, 17.25, new DiscountCap(3, AmountType.Absolute));
            var Bananas = new Product("Bananas", 1122331, 20.25, new DiscountCap(8, AmountType.Absolute));
            var Lofas = new Product("Lofas", 1122331, 14.25, new DiscountCap(30, AmountType.Percentage));
            var Orbees = new Product("Orbees", 1122331, 10.25, new DiscountCap(40, AmountType.Percentage));

            //Add some AdditionalCosts to the Apple Product.
            Apples.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Apples.ListOfCosts.Add(new AdditionalCost("Shining", 5, AmountType.Absolute));
            Apples.ListOfCosts.Add(new AdditionalCost("Washing", 2, AmountType.Absolute));

            //Add some AdditionalCosts to the Bananas Product.
            Bananas.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Bananas.ListOfCosts.Add(new AdditionalCost("Shipping", 5, AmountType.Absolute));
            Bananas.ListOfCosts.Add(new AdditionalCost("Administritive costs", 2, AmountType.Absolute));

            //Add some AdditionalCosts to the Lofas Product.
            Lofas.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Lofas.ListOfCosts.Add(new AdditionalCost("Shipping", 5, AmountType.Absolute));
            Lofas.ListOfCosts.Add(new AdditionalCost("Marketing", 2, AmountType.Absolute));

            //Add some AdditionalCosts to the Orbees Product.
            Orbees.ListOfCosts.Add(new AdditionalCost("Packaging", 10, AmountType.Percentage));
            Orbees.ListOfCosts.Add(new AdditionalCost("Shipping", 5, AmountType.Absolute));
            Orbees.ListOfCosts.Add(new AdditionalCost("Fun cost", 2, AmountType.Absolute));

            //Create a ShoppingCart instance and populate it with the items (Products) initialized above.
            var shoppingCart = new ShoppingCart(PriceCalculator);
            shoppingCart.Add(Apples);
            shoppingCart.Add(Bananas);
            shoppingCart.Add(Lofas);
            shoppingCart.Add(Orbees);

            //Generate a Receipt and a Report for the ShoppingCart to view the results of the different calculations.
            var receipt = new Receipt(shoppingCart);
            receipt.Print();
            var report = new Report(shoppingCart);
            report.Print();
        }
    }
}
