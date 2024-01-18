using SimpleBank2;
using System.Security.Principal;

namespace AccountsTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Accounts_Constructor_Increments_ID()
        {
            // Arrange
            AccountsTestClass accountsTest1 = new AccountsTestClass();
            int currentID = accountsTest1.ID;

            AccountsTestClass accountsTest2 = new AccountsTestClass();

            // Act
            int expected = accountsTest1.ID + 1;
            int actual = accountsTest2.ID;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Everyday sub-class methods.
        /// </summary>
        Everyday everyday = new Everyday(2000m);
        
        [TestMethod]
        public void EverydayWithdraw_correct_balance_left()
        {
            // Arrange
            Customers customers = new Customers("AdrianNT", "021026", "Naenae");

            // Act
            decimal expected = 1001m;
            decimal actual = everyday.Withdraw(999m, customers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EverydayDeposit_correct_new_balance()
        {
            // Arrange
            Customers customers = new Customers("AdrianNT", "021026", "Naenae");

            // Act
            decimal expected = 2999m;
            decimal actual = everyday.Deposit(999m);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Everyday_getAccountDetails_correct_info()
        {
            // Arrange
            Customers customers = new Customers("AdrianNT", "021026", "Naenae");

            // Act
            string expected = "Account Info: Everyday " + everyday.ID + " | Balance: " + everyday.Balance;
            string actual = everyday.getAccountDetails();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientBalanceException))]
        public void EverydayWithdraw_insufficient_balance()
        {
            // Arrange
            Customers customers = new Customers("AdrianNT", "021026", "Naenae");

            // Act
            decimal actual = everyday.Withdraw(9999m, customers);
        }


        /// <summary>
        /// Investments sub-class methods.
        /// </summary>
        Investment investment = new Investment(2000, 0.25);

        [TestMethod]
        public void InvestmentWithdraw_correct_balance_left()
        {
            // Arrange.
            Customers customers = new Customers("AdrianNT", "021026", "Naenae");

            // Act
            decimal expected = 1001m;
            decimal actual = investment.Withdraw(999m, customers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InvestmentDeposit_correct_new_balance()
        {
            // Arrange
            Customers customers = new Customers("AdrianNT", "021026", "Naenae");

            // Act
            decimal expected = 2299m;
            decimal actual = investment.Deposit(299m);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Investment_interestValue_correct_interest_amount()
        {
            // Arrange
            Customers customers = new Customers("AdrianNT", "021026", "Naenae");

            // Act
            decimal expected = 500m;
            decimal actual = investment.interestValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }       

        [TestMethod]
        public void Investment_getAccountDetails_correct_description()
        {
            // Arrange
            Customers customers = new Customers("AdrianNT", "021026", "Naenae");

            // Act
            string expected = "Account info: Investment " + investment.ID + " | Balance: " + investment.Balance +
                " | Interest Rate: " + investment.InterestRate + " | Fee " + investment.Fee;
            string actual = investment.getAccountDetails();

            // Assert
            Assert.AreEqual(expected , actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientBalanceException))]
        public void InvestmentWithdraw_insufficient_balance()
        {
            // Arrange
            Customers customers = new Customers("AdrianNT", "021026", "Naenae");

            // Act
            decimal actual = investment.Withdraw(9999m, customers);
        }


        /// <summary>
        /// Omni sub-class methods.
        /// </summary>
        Omni omni = new Omni(2000m, 0.5);
                        
        [TestMethod]
        public void OmniWithdraw_correct_balance_left()
        {
            // Arrange
            Customers customers = new Customers("AdrianNT", "021026", "Naenae");

            // Act
            decimal expected = 1001m;
            decimal actual = omni.Withdraw(999m, customers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OmniDeposit_correct_new_balance()
        {
            // Arrange
            Customers customers = new Customers("AdrianNT", "021026", "Naenae");

            // Act
            decimal expected = 2299m;
            decimal actual = omni.Deposit(299m);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Omni_interestValue_correct_interest_amount()
        {
            // Arrange
            Customers customers = new Customers("AdrianNT", "021026", "Naenae");

            // Act
            decimal expected = 1000m;
            decimal actual = omni.interestValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Omni_getAccountDetails_correct_description()
        {
            // Arrange
            Customers customers = new Customers("AdrianNT", "021026", "Naenae");

            // Act
            string expected = "Account info: Omni " + omni.ID + " | Balance: " + omni.Balance + " | " +
                "Interest Rate: " + omni.InterestRate + " | Fee " + omni.Fee + " | Overdraft " + omni.Overdraft;
            string actual = omni.getAccountDetails();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientBalanceException))]
        public void OmniWithdraw_insufficient_balance()
        {
            // Arrange
            Customers customers = new Customers("AdrianNT", "021026", "Naenae");

            // Act
            decimal actual = omni.Withdraw(9999m, customers);
        }
    }
}