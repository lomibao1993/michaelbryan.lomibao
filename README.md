Questions – please put answers in the README.md of your repository
1. What other possible scenario’s would you suggest for testing the Jupiter Toys application?
  * Checkout functionality
  * Invalid Email Address Error message in Contact Page
  * Delete Items in Cart Page
  * Cart Quantity Textbox for each item in Cart Page

2. Jupiter Toys is expected to grow and expand its offering into books, tech, and modern art. We are expecting the of tests will grow to a very large number.

What approaches could you used to reduce overall execution time?
* Merge all test cases into one test automation script to reduce run time.

How will your framework cater for this?
* for additional toys, I'll be just adding items into Toys ENUM (ProductEnum.class). Add test cases/script to test additional toys.
* for expanding growth of jupiter toy, I'll be adding new ENUMS for Books, tech, and modern art to cater the additional products. 

3. Describe when to use a BDD approach to automation and when NOT to use BDD 
* I'm currently new with this BDD aprpoach, and I'm still not part of 'real' BDD approach.
* When not to use BDD approach, if the requirement/user story is not stable or always have changes. Automation tester will need to alot more time in mainting automation scripts for all changes just to sync the automation to the requirement/user story.
