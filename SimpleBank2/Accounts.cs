using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank2
{
    using System;
    using System.Security.Cryptography;

    public abstract class Accounts
    {
        // Declare attributes.
        protected static int nextID = 1;
        protected int _id;
        private decimal _balance;

        // Constructor.
        public Accounts()
        {
            _id = nextID;
            nextID++;
        }

        public Accounts(decimal balance) : this()
        {
            _balance = balance;
        }

        // Read-only
        public int ID { get => _id; }

        // Public properties to access the private attributes within the class.
        public decimal Balance { get => _balance; set => _balance = value; }


        // Simple deposit method generalised for each account type.
        public virtual decimal Deposit(decimal deposit)
        {
            return Balance += deposit;
        }

        // Simkple Withdraw method which is override by each types for specialisation.
        public virtual decimal Withdraw(decimal withdraw, Customers customer)
        {
            return Balance -= withdraw;
        }

        // Declared abstract for specialisation of description since accounts have
        //  different attributes to print out to the user.
        public abstract string getAccountDetails();
    }


    // Subclasses to inherit from Accounts super/base class.
    public class Everyday : Accounts
    {
        // No interest, no overdraft, no fees.
        // Constructor
        public Everyday(decimal balance)
            : base(balance)
        {
        }

        // Withdrawing cannot exceed their balance.
        // Override the normal withdraw method to check if amount > balance.
        public override decimal Withdraw(decimal amount, Customers customer)
        {
            if (amount > Balance)
                // Throw exception with appropriate message with account type..
                throw new InsufficientBalanceException("Insufficient balance from your Everyday account!");

            return base.Withdraw(amount, customer);
        }

        public override decimal Deposit(decimal amount)
        {
            return base.Deposit(amount);
        }

        public override string getAccountDetails()
        {
            return ($"Account Info: Everyday {ID} | Balance: {Balance}");
        }
    }



    // Interest rates, no overdraft, fee for failed transaction.
    public class Investment : Accounts
    {
        private double _interestRate;
        private decimal _fee = 10m;

        public double InterestRate { get => _interestRate; set => _interestRate = value; }
        public decimal Fee { get => _fee; set => _fee = value; }

        // Constructor.
        public Investment(decimal balance, double interest)
            : base(balance)
        {
            _interestRate = interest;
        }

        public override decimal Withdraw(decimal amount, Customers customer)
        {
            if (amount > Balance)
            {
                base.Withdraw(_fee * (decimal)customer.FeeReduction, customer);
                // Throw exception with appropriate message with account type..
                throw new InsufficientBalanceException("Insufficient balance from your Investment account!");
            }

            return base.Withdraw(amount, customer);
        }
        public override decimal Deposit(decimal amount)
        {
            return base.Deposit(amount);
        }
        
        public decimal interestValue()
        {
            decimal tempBal = Balance;
            Balance += (Balance * (decimal)_interestRate);
            return Balance - tempBal;
        }

        public override string getAccountDetails()
        {
            return ($"Account info: Investment {ID} | Balance: {Balance} | Interest Rate: {_interestRate} | Fee {_fee}");
        }
    }



    // Interest rates paid only on balances over $1000, overdraft permitted, 
    //  fee for failed transaction.
    public class Omni : Accounts
    {
        private double _interestRate;
        private decimal _overdraft = 200m;
        private decimal _fee = 10m;

        public double InterestRate { get => _interestRate; set => _interestRate = value; }
        public decimal Overdraft { get => _overdraft; set => _overdraft = value; }
        public decimal Fee { get => _fee; set => _fee = value; }


        public Omni(decimal balance, double interest)
            : base(balance)
        {
            _interestRate = interest;
        }

        // Withdraws the amount provided from the balance.
        // Calculates the fee for invlalid transaction and determines whether customer type has fee reduction.
        public override decimal Withdraw(decimal amount, Customers customer)
        {
            // Incur a fee when amount > balance including overdraft.
            if (amount > Balance + _overdraft)
            {           
                base.Withdraw(_fee * (decimal)customer.FeeReduction, customer);
                // Throw exception with appropriate message with account type..
                throw new InsufficientBalanceException("Insufficient balance from your Omni account!");
            }
            return base.Withdraw(amount, customer);
        }

        // Simple deposit method and prints the current account info.
        public override decimal Deposit(decimal amount)
        {
            return base.Deposit(amount);
        }

        // Adds interest for the account. Applicable with Investment and Omni account types.
        public decimal interestValue()
        {
            decimal tempBal = Balance;
            if (Balance > 1000m)
                Balance += (Balance * (decimal)_interestRate);
            return Balance - tempBal;
        }

        // Prints out the account info.
        // Shows the type of the account, the balance, the interest rate as well as the fee for invalid transactions.
        public override string getAccountDetails()
        {
            return ($"Account info: Omni {ID} | Balance: {Balance} | Interest Rate: {_interestRate} | Fee {_fee} | Overdraft {_overdraft}");
        }
    }

    /// <summary>
    /// For testing purposes only of the abstract Accounts class.
    /// </summary>
    public class AccountsTestClass : Accounts
    {
        public override string getAccountDetails()
        {
            return "";
        }
    }
}
