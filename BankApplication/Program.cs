﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// This program uses an Account hierachy to implement a banking application.
    /// </summary>
    /// <Student>Jonathan Woods</Student>
    /// <Class>CIS297</Class>
    /// <Semester>Winter 2022</Semester>
    class Program
    {
        /// <summary>
        /// The program allows a user to deposit and withdraw from savings and checking accounts.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // create array of accounts
            Account[] accounts = new Account[4];

            // initialize array with Accounts
            accounts[0] = new SavingsAccount(25M, .03M);
            accounts[1] = new CheckingAccount(80M, 1M);
            accounts[2] = new SavingsAccount(200M, .015M);
            accounts[3] = new CheckingAccount(400M, .5M);

            // loop through array, prompting user for debit and credit amounts
            for (int i = 0; i < accounts.Length; i++)
            {
                Console.WriteLine($"Account {i + 1} balance: {accounts[i].Balance:C}");

                Console.Write($"\nEnter an amount to withdraw from Account {i + 1}: $");
                decimal withdrawalAmount = decimal.Parse(Console.ReadLine());

                accounts[i].Debit(withdrawalAmount); // attempt to debit

                Console.Write($"\nEnter an amount to deposit into Account {i + 1}: $");
                decimal depositAmount = decimal.Parse(Console.ReadLine());

                // credit amount to Account
                accounts[i].Credit(depositAmount);

                // if Account is a SavingsAccount, calculate and add interest
                if (accounts[i] is SavingsAccount)
                {
                    // downcast
                    SavingsAccount currentAccount = (SavingsAccount)accounts[i];

                    decimal interestEarned = currentAccount.CalculateInterest();
                    Console.WriteLine($"Adding {interestEarned:C} interest to Account {i + 1} (a SavingsAccount)");
                    currentAccount.Credit(interestEarned);
                }

                Console.WriteLine($"\nUpdated Account {i + 1} balance: ${accounts[i].Balance:C}\n\n");
            }

            Console.WriteLine("Press \"Enter\" to end the program.");

            Console.ReadLine();
        }
    }
}