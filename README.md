# Price_Calculator_Kata

This repository contains my implementation of a Price Calculator that a store owner might use to calculate taxes, discount amounts, print reports, assign tax/discount precedence, and much more. After the completion of each task of the 10 tasks for this project, the project is tested for functionality and the XUnit tests are included in this project's repository.

As part of my internship as a Backend Development Intern at Foothill Technology Solutions, I was asked to complete a task-based training program. This training program involves taking online courses to better hone and improve an intern's programming skills and work with development teams to get a taste of what a career in software development is like all while performing tasks (doing assigned projects) that help deepen an intern's understanding of the material and the training they are receiving.

For my second task, I was asked to implement a Price Calculator console application, using C#, that performs a number of operations a store owner might need to calculate receipts for customer purchases and generate reports from that data. This exercise is meant to help interns become familiar with what a sofware development process over time might look like as well as making interns become more comfortable employing the skills that they learn during their training at the company. 

Here is a description of the instructions I received for this project:
1. Use Console application template.
2. Follow GIT best practices you learned to push your code, and submit a PR for each requirement. Once you're done with a requirement, please pass it to your trainer for a review.
3. Requirements should be implemented in order - The sequence of requirements is simulating the evolution of customer's expectations over a prolonged period of time, as customer occasionally gets “bright ideas” and hands them over to developers. Implementing requirements all at once or out of order would look like real time was flowing back and forth.
4. Mark each task with the requirement label - Include requirement label into each commit message, so that the evolution of the product can be observed later. Each requirement begins with a label in capital letters.
5. Pretend you don’t know the requirements in advance - Even though you can read all the requirements right away, try thinking of those beyond the one you’re currently solving as yet unknown. Don’t overengineer current solution because you have anticipated a future requirement.

The tasks were as follows:

1. TAX: 
There is a product, defined by: Name (string), UPC (can be a plain number) and a price.
Company is only doing business in US dollars. Money is calculated at two decimals precision (e.g. $12.34).
There is a flat-rate tax (currently 20%) added to all products’ prices. Tax is mandatory and equal for all products.
Customer wants to be able to specify tax percentage.
Write code which displays base price and price with tax for a product.


2. DISCOUNT:
Customer chooses to apply a relative discount to all products.
Discount is specified as a percentage relative to price. Tax is always applied to a price before it was deduced, i.e. discount doesn’t reduce tax amount (see example below).
Customer requires discount percentage to be configurable.
Enhance code so that it can apply discount and tax to the product’s price.


3. REPORT:
When a discount is applied, print out (or display by any convenient means) a message which reports the discounted amount.

4. SELECTIVE:
There is a special discount assigned to a product with specified (configurable) UPC.
This discount only applies to a product with UPC value equal to the value defined by the discount.
If both universal and UPC-based discounts are applicable, they both apply to original product price and then sum up.
When two discounts are applied, only the total discounted amount is printed (requirement REPORT-DISCOUNT).

5. PRECEDENCE:
By this point, tax had precedence over any discounts. That means that tax was always applied to full price of the product, not to the discounted price.
Customer is happy to announce that some discounts can legally be applied before tax. That has the consequence that the tax amount would be lower.
Extend the solution so that discounts can either be applied before tax calculation, or after tax calculation.

6. EXPENSES:
Customer wants to introduce packaging and transport costs, administrative costs, etc., which are neither subject to tax, nor to discounts.
There can be more than one cost added, each defined by a description and an amount. Amount can either be a percentage of price or an absolute value.
Program should separately report product price, tax, discounts, each cost and total.

7. COMBINING:
Customer is not satisfied with the way in which discounts are combined (simple sum).
New request is to allow the customer to select between two methods of combining discounts: (1) additive - discounts are all calculated from the original price and summed up, or (2) multiplicative - each discount is calculated from the price after applying the previous one.

8. CAP:
Customer is not satisfied with total discounted amount and wants to put a cap on it.
Cap is either a percentage of original price or an absolute amount. Either way, the discounted amount must not be larger than indicated by the cap.

9. Currency:
Customer is happy to announce expansion to other markets.
New request is to support currencies other than US dollar.
Currencies should be indicated using ISO-3 codes (e.g. USD, GBP, JPY, etc.).

10: PRECISION:
New request comes from the accounting department. All money-related calculations must be performed with four decimal digits precision and then rounded to two decimal digits before becoming final.
This means, for example, that all discounts, taxes and expenses must be calculated and combined with higher precision and then each final line rounded to lower precision (see example below).

My implementation of the Price Calculator can be found in the src/Price_Calculator_Classes folder and the testing can be found in both the src/Price_Calculator_Classes folder in the Program.cs class as well as in the test/Price_Calculator_Tests folder.

Please note that by the time this project is done, some newer features might break older features (or require them to change drastically) hence now allowing you (the viewer) to see every single feature that was added to the project here. Nonetheless, feel free to fork this project and use Git to move back in history and checkout how the progression of this project looks like.

Thanks,

Ayham R.
