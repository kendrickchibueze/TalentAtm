using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace TalentAtm
{
    //implementing multiple inheritance through interfaces
    internal class Atm : ILoginUser, IBalance, IDeposit, IWithdrawal, ITransfer, ITransaction
    {
        private static int _tries;

        private const int _maxTries = 3;

        private const decimal _minimumKeptAmount = 10;

        private static decimal _transactAmt;

        private bool _passverification;

        private static List<BankAccount> _accountList;

        private static List<Transaction> _listOfTransactions;

        private static BankAccount _selectedAccount;

        private static BankAccount _inputAccount;



        public  void AtmExecute()
        {

            //initialization
            LangChoice.ChooseLang();
          

            while (true)
            {
              
                switch (Utility.GetIntInputAmount(LangChoice.morechoice( LangChoice._option)))
                {
                    case 1:
                        verifyCardNumberPassword();

                        _listOfTransactions = new List<Transaction>();

                        while (true)
                        {
                            switch (LangChoice._choice)
                            {
                                case 1:
                                    Screen.ShowMenuTwo();
                                    break;
                                case 2:
                                    LangChoice.ShowMenuIgboSecureMenu();
                                    break;
                                case 3:
                                    LangChoice.ShowMenupidginSecure();
                                    break;
                                default:
                                    Screen.ShowMenuTwo();
                                    break;


                            }
                            

                            switch (Utility.GetIntInputAmount(LangChoice._option))
                            {
                                //using explicit casting
                                case (int)Menu.CheckBalance:

                                    CheckBalance(_selectedAccount);

                                    break;

                                case (int)Menu.PlaceDeposit:

                                    DepositMoney(_selectedAccount);

                                    break;

                                case (int)Menu.MakeWithdrawal:

                                    MakeWithdrawal(_selectedAccount);

                                    break;

                                case (int)Menu.Transfer:

                                    var Transfer = new VmTransfer();

                                    Transfer = Screen.TransferMoney();

                                    performTransfer(_selectedAccount, Transfer);

                                    break;

                                case (int)Menu.ViewTransaction:

                                    ViewTransaction(_selectedAccount);

                                    break;

                                case (int)Menu.Logout:
                                    switch (LangChoice._choice)
                                    {
                                        case 1:
                                            Utility.PrintMessage("You have succesfully logout. Please collect your ATM card..", true);
                                         
                                            break;
                                        case 2:
                                            Utility.PrintMessage("ipugo nke oma, nwere atm cardi gi", true);
                                            
                                            break;
                                        case 3:
                                            Utility.PrintMessage("oga you don commot, abeg collect your card", true);
                                            
                                            break;
                                        default:
                                            Utility.PrintMessage("You have succesfully logout. Please collect your ATM card..", true);
                                            
                                            break;


                                    }

                                    Environment.Exit(0);

                                    break;

                                default:
                                    switch (LangChoice._choice)
                                    {
                                        case 1:
                                            Utility.PrintMessage("Invalid Option Entered.", false);
                                            break;
                                        case 2:
                                            Utility.PrintMessage("optionu gi adiro correcti", false);
                                            break;
                                        case 3:
                                            Utility.PrintMessage("option no dey correct, change am", false);
                                            break;
                                        default:
                                            Utility.PrintMessage("Invalid Option Entered.", false);
                                            break;


                                    }


                                    break;
                            }
                        }

                    case 2:
                        switch (LangChoice._choice)
                        {
                            case 1:
                                Utility.PrintColorMessage(ConsoleColor.Cyan, "\nThank you for using Talent bank. Exiting program now .");

                                Utility.printDotAnimation(15);
                                
                                break;
                            case 2:
                                Utility.PrintColorMessage(ConsoleColor.Cyan, "\nAnyi ekele gi maka ibia na Talent bank. ngwa jee nke oma...");

                                Utility.printDotAnimation(15);
                                break;
                            case 3:
                                Utility.PrintColorMessage(ConsoleColor.Cyan, "\n we wan thank you because say u come Talent bank. you don commot .");

                                Utility.printDotAnimation(15);
                                break;
                            default:
                                Utility.PrintColorMessage(ConsoleColor.Cyan, "\nThank you for using Talent bank. Exiting program now .");

                                Utility.printDotAnimation(15);
                                break;

                               
                        }

                        Environment.Exit(0);
                        break;

                    default:
                        switch (LangChoice._choice)
                        {
                            case 1:
                                Utility.PrintMessage("Invalid Option Entered.", false);
                                break;
                            case 2:
                                Utility.PrintMessage("optionu gi adiro correcti", false);
                                break;
                            case 3:
                                Utility.PrintMessage("option no dey correct, change am", false);
                                break;
                            default:
                                Utility.PrintMessage("Invalid Option Entered.", false);
                                break;


                        }


                        break;
                }
            }
        }

        public void verifyCardNumberPassword()
        {
            while (!_passverification)
            {
                _inputAccount = new BankAccount();
                switch (LangChoice._choice)
                {
                    case 1:
                        _inputAccount.CardNumber = Utility.GetIntInputAmount("ATM Card Number");
                        Utility.PrintColorMessage(ConsoleColor.Yellow, "Enter 4 Digit PIN: ");

                        break;
                    case 2:
                        _inputAccount.CardNumber = Utility.GetIntInputAmount("ATM Card Nomba gi");
                        Utility.PrintColorMessage(ConsoleColor.Yellow, "Tinye digiti ano pini gi: ");
                        break;
                    case 3:
                        _inputAccount.CardNumber = Utility.GetIntInputAmount("ATM Card Number");
                        Utility.PrintColorMessage(ConsoleColor.Yellow, "Abeg make you put  your 4 digit pin: ");
                        break;
                    default:
                        _inputAccount.CardNumber = Utility.GetIntInputAmount("ATM Card Number");
                        Utility.PrintColorMessage(ConsoleColor.Yellow, "Enter 4 Digit PIN: ");
                        break;


                }
         

                _inputAccount.PinCode = int.Parse(Console.ReadLine());

                switch (LangChoice._choice)
                {
                    case 1:

                        Utility.PrintColorMessage(ConsoleColor.Cyan, "\nChecking card number and password...");
                        Utility.printDotAnimation();
                        break;
                    case 2:

                        Utility.PrintColorMessage(ConsoleColor.Cyan, "\nka olele card number gi ya na password gi...");
                        Utility.printDotAnimation();
                        break;
                    case 3:

                        Utility.PrintColorMessage(ConsoleColor.Cyan, "\n i de check your card number and password...");
                        Utility.printDotAnimation();
                        break;
                    default:
                       Utility.PrintColorMessage(ConsoleColor.Cyan, "\nChecking card number and password...");
                        Utility.printDotAnimation();
                        break;


                }

                foreach (BankAccount account in _accountList)
                {
                    if (_inputAccount.CardNumber.Equals(account.CardNumber))
                    {
                        _selectedAccount = account;

                        if (_inputAccount.PinCode.Equals(account.PinCode))
                        {
                            if (_selectedAccount.isLocked)
                                BlockAccount();
                            else
                                _passverification = true;
                        }
                        else
                        {
                            _passverification = false;
                            _tries++;

                            if (_tries >= _maxTries)
                            {
                                _selectedAccount.isLocked = true;

                                BlockAccount();
                            }

                        }
                    }

                }
                if (!_passverification)
                    switch (LangChoice._choice)
                    {
                        case 1:
                            Utility.PrintMessage("Invalid Card number or Pin.", false);
                            Console.Clear();
                            break;
                        case 2:
                            Utility.PrintMessage("Anyi awotara card nomba gi ya na pin gi.", false);
                            Console.Clear();
                            break;
                        case 3:
                            Utility.PrintMessage("i be like say your card number or pin no dey valid", false);
                            Console.Clear();
                            break;
                        default:
                            Utility.PrintMessage("Invalid Card number or Pin.", false);
                            Console.Clear();
                            break;


                    }
            }
        }


        public void CheckBalance(BankAccount bankAccount)
        {
            switch (LangChoice._choice)
            {
                case 1:
                    Utility.PrintMessage($"Your bank account balance amount is: {Utility.FormatAmount(bankAccount.Balance)}", true);
                    break;
                case 2:
                    Utility.PrintMessage($"Ego gi foro na accountu gi bu: {Utility.FormatAmount(bankAccount.Balance)}", true);
                    break;
                case 3:
                    Utility.PrintMessage($"Your money e remain : {Utility.FormatAmount(bankAccount.Balance)}", true);

                    break;
                default:
                    Utility.PrintMessage($"Your bank account balance amount is: {Utility.FormatAmount(bankAccount.Balance)}", true);

                    break;


            }
          
        }

        public void DepositMoney(BankAccount account)
        {

            _transactAmt = Utility.GetIntInputAmount("amount");
            switch (LangChoice._choice)
            {
                case 1:
                    Utility.PrintColorMessage(ConsoleColor.Cyan, "\nCheck and counting bank notes.");

                    Utility.printDotAnimation();
                    break;
                case 2:
                    Utility.PrintColorMessage(ConsoleColor.Cyan, "\n nwee ndidi, O na elele mana agu bank note gi.");

                    Utility.printDotAnimation();
                    break;
                case 3:
                    Utility.PrintColorMessage(ConsoleColor.Cyan, "\n i dey Check and dey  count bank notes.");

                    Utility.printDotAnimation();
                    break;
                default:
                    Utility.PrintColorMessage(ConsoleColor.Cyan, "\nCheck and counting bank notes.");

                    Utility.printDotAnimation();
                    break;


            }


            if (_transactAmt <= 0)
                switch (LangChoice._choice)
                {
                    case 1:
                        Utility.PrintMessage("Amount needs to be more than zero. Try again.", false);
                        break;
                    case 2:
                        Utility.PrintMessage("Ego ina-etinye ga akariri zero. megharia ya.", false);
                        break;
                    case 3:
                        Utility.PrintMessage("The amount wey you put suppose pass zero. Try am again.", false);
                        break;
                    default:
                        Utility.PrintMessage("Amount needs to be more than zero. Try again.", false);
                        break;


                }

            else if (_transactAmt % 10 != 0)
                switch (LangChoice._choice)
                {
                    case 1:
                        Utility.PrintMessage($"Key in the deposit amount only with multiple of 10. Try again.", false);
                        break;
                    case 2:
                        Utility.PrintMessage($"Ego iga etinye ga adi na-ekpupo iri. Megharia ya.", false);
                        break;
                    case 3:
                        Utility.PrintMessage($"make you key in the deposit amount only with multiple of 10. Try  am again.", false);
                        break;
                    default:
                        Utility.PrintMessage($"Key in the deposit amount only with multiply of 10. Try again.", false);
                        break;


                }


            else if (!PreviewBankNotesCount(_transactAmt))

                switch (LangChoice._choice)
                {
                    case 1:
                        Utility.PrintMessage($"You have cancelled your action.", false);
                        break;
                    case 2:
                        Utility.PrintMessage($"Imebi wo ihe ichoro ime.", false);
                        break;
                    case 3:
                        Utility.PrintMessage($"i don cancel your action.", false);
                        break;
                    default:
                        Utility.PrintMessage($"You have cancelled your action.", false);
                        break;


                }
            else
            {
                // Bind _transactAmt to Transaction object

                // Add transaction record - Start

                var transaction = new Transaction()
                {
                    BankAccountNoFrom = account.AccountNumber,

                    BankAccountNoTo = account.AccountNumber,

                    TransactionType = TransactionType.Deposit,

                    TransactionAmount = _transactAmt,

                    TransactionDate = DateTime.Now
                };

                InsertTransaction(account, transaction);
                // Add transaction record - End



                // Another method to update account balance.

                account.Balance += _transactAmt;

                switch (LangChoice._choice)
                {
                    case 1:
                        Utility.PrintMessage($"You have successfully deposited {Utility.FormatAmount(_transactAmt)}", true);
                        break;
                    case 2:
                        Utility.PrintMessage($"Ogara nke oma, i tinye nwo ego  {Utility.FormatAmount(_transactAmt)}", true);
                        break;
                    case 3:
                        Utility.PrintMessage($"You done deposit {Utility.FormatAmount(_transactAmt)}", true);
                        break;
                    default:
                        Utility.PrintMessage($"You have successfully deposited {Utility.FormatAmount(_transactAmt)}", true);
                        break;


                }

            }
        }

        public void MakeWithdrawal(BankAccount account)
        {

            _transactAmt = Utility.GetDecimalInputAmt("amount");

            if (_transactAmt <= 0)
                switch (LangChoice._choice)
                {
                    case 1:
                        Utility.PrintMessage("Amount needs to be more than zero. Try again.", false);
                        break;
                    case 2:
                        Utility.PrintMessage("Ego ina-etinye ga akariri zero. megharia ya.", false);
                        break;
                    case 3:
                        Utility.PrintMessage("The amount wey you put suppose pass zero. Try am again.", false);
                        break;
                    default:
                        Utility.PrintMessage("Amount needs to be more than zero. Try again.", false);
                        break;


                }


            else if (_transactAmt > account.Balance)
                switch (LangChoice._choice)
                {
                    case 1:
                        Utility.PrintMessage($"Withdrawal failed. You do not have enough fund to withdraw {Utility.FormatAmount(_transactAmt)}", false);
                        break;
                    case 2:
                        Utility.PrintMessage($"Inweta ego agara-nke oma. i nwezuro ego na accountu gi{Utility.FormatAmount(_transactAmt)}", false);
                        break;
                    case 3:
                     Utility.PrintMessage($"Withdrawal don  failed. enough fund no dey your account  {Utility.FormatAmount(_transactAmt)}", false);
                        break;
                    default:
                        Utility.PrintMessage($"Withdrawal failed. You do not have enough fund to withdraw {Utility.FormatAmount(_transactAmt)}", false);
                        break;


                }

            else if ((account.Balance - _transactAmt) < _minimumKeptAmount)
                switch (LangChoice._choice)
                {
                    case 1:
                        Utility.PrintMessage($"Withdrawal failed. Your account needs to have minimum {Utility.FormatAmount(_minimumKeptAmount)}", false);
                        break;
                    case 2:
                        Utility.PrintMessage($"Inweta ego agara-nke oma. accountu gi kwesiri inwe ego di opekata mpe {Utility.FormatAmount(_minimumKeptAmount)}", false);
                        break;
                    case 3:
                        Utility.PrintMessage($"Withdrawal don failed. Your account suppose get upto {Utility.FormatAmount(_minimumKeptAmount)}", false);
                        break;
                    default:
                        Utility.PrintMessage($"Withdrawal failed. Your account needs to have minimum {Utility.FormatAmount(_minimumKeptAmount)}", false);
                        break;


                }

            else if (_transactAmt % 10 != 0)
                switch (LangChoice._choice)
                {
                    case 1:
                        Utility.PrintMessage($"Key in the deposit amount only with multiple of 10. Try again.", false);
                        break;
                    case 2:
                        Utility.PrintMessage($"Ego iga etinye ga adi na-ekpupo iri. Megharia ya.", false);
                        break;
                    case 3:
                        Utility.PrintMessage($"make you key in the deposit amount only with multiple of 10. Try  am again.", false);
                        break;
                    default:
                        Utility.PrintMessage($"Key in the deposit amount only with multiply of 10. Try again.", false);
                        break;


                }

            else
            {
                // Bind _transactAmt to Transaction object
                // Add transaction record - Start

                var transaction = new Transaction()
                {
                    BankAccountNoFrom = account.AccountNumber,

                    BankAccountNoTo = account.AccountNumber,

                    TransactionType = TransactionType.Withdrawal,

                    TransactionAmount = _transactAmt,

                    TransactionDate = DateTime.Now
                };

                InsertTransaction(account, transaction);

                // Add transaction record - End



                // Another method to update account balance.
                account.Balance -= _transactAmt;

                switch (LangChoice._choice)
                {
                    case 1:
                        Utility.PrintMessage($"Please collect your money. You have successfully withdraw {Utility.FormatAmount(_transactAmt)}", true);
                        break;
                    case 2:
                        Utility.PrintMessage($"Nwere ego gi. inwetere ego ruru {Utility.FormatAmount(_transactAmt)}", true);
                        break;
                    case 3:
                        Utility.PrintMessage($"abeg collect your moni. You don successfully withdraw {Utility.FormatAmount(_transactAmt)}", true);
                        break;
                    default:
                        Utility.PrintMessage($"Please collect your money. You have successfully withdraw {Utility.FormatAmount(_transactAmt)}", true);
                        break;


                }

                
            }
        }

        private void BlockAccount()
        {
            Console.Clear();
            switch (LangChoice._choice)
            {
                case 1:
                    Utility.PrintMessage("Your account is locked.", true);
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "Please go to the nearest branch to unlocked your account.");
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "Thank you for using Talentbank. ");
                    Console.ReadKey();
                    Environment.Exit(1);
                    break;
                case 2:
                    Utility.PrintMessage("Akpochiri accountu gi.", true);
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "Biko jee na branchi anyi di gi nso ka ikpoghe ya.");
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "Ekele maka i bia Talent Bank. ");
                    Console.ReadKey();
                    Environment.Exit(1);
                    break;
                case 3:
                    Utility.PrintMessage("Your account dey locked.", true);
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "Abeg go  nearest branch make you unlocked your account.");
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "Thank you jaire for  using Talentbank. ");
                    Console.ReadKey();
                    Environment.Exit(1);
                    break;
                default:
                    Utility.PrintMessage("Your account is locked.", true);
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "Please go to the nearest branch to unlocked your account.");
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "Thank you for using Talentbank. ");
                    Console.ReadKey();
                    Environment.Exit(1);
                    break;


            }
         
            Environment.Exit(1);
        }


        //this seeded data stored in a list serves as a mock database
        public void SeedData()
        {
            _transactAmt = 0;

            _accountList = new List<BankAccount>
            {
                new BankAccount() { FullName = "Charlse", AccountNumber=333111, CardNumber = 123, PinCode = 1111, Balance = 2000.00m, isLocked = false },

                new BankAccount() { FullName = "Mike", AccountNumber=111222, CardNumber = 456, PinCode = 2222, Balance = 1500.30m, isLocked = true },

                new BankAccount() { FullName = "Leo", AccountNumber=888555, CardNumber = 789, PinCode = 3333, Balance = 2900.12m, isLocked = false }
            };
        }

        public void InsertTransaction(BankAccount bankAccount, Transaction transaction)
        {
            _listOfTransactions.Add(transaction);
        }



        private static bool PreviewBankNotesCount(decimal amount)
        {
            int hundredNotesCount = (int)amount / 100;

            int fiftyNotesCount = ((int)amount % 100) / 50;

            int tenNotesCount = ((int)amount % 50) / 10;

            switch (LangChoice._choice)
            {
                case 1:
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "\nSummary");

                    break;
                case 2:
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "\nNchikota ya");
                    break;
                case 3:
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "\nSummary");
                    break;
                default:
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "\nSummary");
                    break;


            }
            Utility.PrintColorMessage(ConsoleColor.Yellow, "-------");

            Utility.PrintColorMessage(ConsoleColor.Yellow, $"{Screen._currency} 100 x {hundredNotesCount} = {100 * hundredNotesCount}");

            Utility.PrintColorMessage(ConsoleColor.Yellow, $"{Screen._currency} 50 x {fiftyNotesCount} = {50 * fiftyNotesCount}");

            Utility.PrintColorMessage(ConsoleColor.Yellow, $"{Screen._currency} 10 x {tenNotesCount} = {10 * tenNotesCount}");

            Utility.PrintColorMessage(ConsoleColor.Yellow, $"Total amount: {Utility.FormatAmount(amount)}\n\n");
     

            switch (LangChoice._choice)
            {
                
                case 1:
                     string opt = Utility.GetIntInputAmount("1 to confirm or 0 to cancel").ToString();
                    return (opt.Equals("1")) ? true : false;

                case 2:
                    string opt1 = Utility.GetIntInputAmount("pia otu ma obu zero maka ikagbu ihe ina-eme").ToString();
                    return (opt1.Equals("1")) ? true : false;
                case 3:
                    string opt2 = Utility.GetIntInputAmount(" you fit press 1 to confirm or 0 to cancel").ToString();
                    return (opt2.Equals("1")) ? true : false;
                default:
                    string opt3 = Utility.GetIntInputAmount("1 to confirm or 0 to cancel").ToString();
                    return (opt3.Equals("1")) ? true : false;

            }


        }

        public void performTransfer(BankAccount bankAccount, VmTransfer Transfer)
        {
            if (Transfer.TransferAmount <= 0)
                switch (LangChoice._choice)
                {
                    case 1:
                        Utility.PrintMessage("Amount needs to be more than zero. Try again.", false);
                        break;
                    case 2:
                        Utility.PrintMessage("Ego ina-etinye ga akariri zero. megharia ya.", false);
                        break;
                    case 3:
                        Utility.PrintMessage("The amount wey you put suppose pass zero. Try am again.", false);
                        break;
                    default:
                        Utility.PrintMessage("Amount needs to be more than zero. Try again.", false);
                        break;


                }


            else if (Transfer.TransferAmount > bankAccount.Balance)

                // Check giver's account balance - Start
                switch (LangChoice._choice)
                {
                    case 1:
                        Utility.PrintMessage($"Transfer failed. You do not have enough fund to transfer {Utility.FormatAmount(_transactAmt)}", false);
                        break;
                    case 2:
                        Utility.PrintMessage($" i transfer ego gi agaro niru. i nwezuro ego inye mmadu {Utility.FormatAmount(_transactAmt)}", false);
                        break;
                    case 3:
                        Utility.PrintMessage($"Transfer failed. you no get enough money wey go fund transfer {Utility.FormatAmount(_transactAmt)}", false);
                        break;
                    default:
                        Utility.PrintMessage($"Transfer failed. You do not have enough fund to transfer {Utility.FormatAmount(_transactAmt)}", false);
                        break;


                }


            else if ((bankAccount.Balance - Transfer.TransferAmount) < 10)
                switch (LangChoice._choice)
                {
                    case 1:
                        Utility.PrintMessage($"Transfer failed. Your account needs to have minimum of {Utility.FormatAmount(_minimumKeptAmount)}", false);
                        break;
                    case 2:
                        Utility.PrintMessage($"i transfer ego gi agaro niru. account gi kwesiri inweriri opekata mpe {Utility.FormatAmount(_minimumKeptAmount)}", false);
                        break;
                    case 3:
                        Utility.PrintMessage($"Transfer failed. you suppose get upto  {Utility.FormatAmount(_minimumKeptAmount)}", false);
                        break;
                    default:
                        Utility.PrintMessage($"Transfer failed. Your account needs to have minimum of {Utility.FormatAmount(_minimumKeptAmount)}", false);
                        break;


                }

            // Check giver's account balance - End

            else
            {
                // Check if receiver's bank account number is valid.

                var selectedBankAccountReceiver = (from b in _accountList
                                                   where b.AccountNumber == Transfer.RecipientBankAccountNumber
                                                   select b).FirstOrDefault(); //FirstOrDefault returns the first element of a sequence or default element if the sequence contains no element

                if (selectedBankAccountReceiver == null)

                    switch (LangChoice._choice)
                    {
                        case 1:
                            Utility.PrintMessage($" Money Transfer failed. Receiver bank account number is invalid.", false);
                            break;
                        case 2:
                            Utility.PrintMessage($" i transfer ego gi agaro niru. Accountu nomba onye i choro ihe ego adiro ka okwesiri.", false);
                            break;
                        case 3:
                            Utility.PrintMessage($" Money Transfer don fail. Receiver bank account number no dey invalid.", false);
                            break;
                        default:
                            Utility.PrintMessage($" Money Transfer failed. Receiver bank account number is invalid.", false);
                            break;


                    }

                

                else if (selectedBankAccountReceiver.FullName != Transfer.RecipientBankAccountName)

                    switch (LangChoice._choice)
                    {
                        case 1:
                            Utility.PrintMessage($"Transfer failed. Recipient's account name does not match.", false);
                            break;
                        case 2:
                            Utility.PrintMessage($" i transfer ego gi agaro niru. Ahughi aha accountu onye i na-enye ego .", false);
                            break;
                        case 3:
                            Utility.PrintMessage($"Transfer don fail. Recipient's account name no match.", false);
                            break;
                        default:
                            Utility.PrintMessage($"Transfer failed. Recipient's account name does not match.", false);
                            break;


                    }

                

                else
                {

                    // Bind transaction_amt to Transaction object
                    // Add transaction record - Start

                    Transaction transaction = new Transaction()
                    {
                        BankAccountNoFrom = bankAccount.AccountNumber,

                        BankAccountNoTo = Transfer.RecipientBankAccountNumber,

                        TransactionType = TransactionType.Transfer,

                        TransactionAmount = Transfer.TransferAmount,

                        TransactionDate = DateTime.Now
                    };

                    _listOfTransactions.Add(transaction);

                    switch (LangChoice._choice)
                    {
                        case 1:
                            Utility.PrintMessage($"You have successfully transferred out {Utility.FormatAmount(Transfer.TransferAmount)} to {Transfer.RecipientBankAccountName}", true);
                            break;
                        case 2:
                            Utility.PrintMessage($"Transfer gi gara nke oma, i nyere {Utility.FormatAmount(Transfer.TransferAmount)} to {Transfer.RecipientBankAccountName}", true);
                            break;
                        case 3:
                            Utility.PrintMessage($"You don successfully transfer out {Utility.FormatAmount(Transfer.TransferAmount)} to {Transfer.RecipientBankAccountName}", true);
                            break;
                        default:
                            Utility.PrintMessage($"You have successfully transferred out {Utility.FormatAmount(Transfer.TransferAmount)} to {Transfer.RecipientBankAccountName}", true);
                            break;


                    }

                   
                    // Add transaction record - End

                    // Update balance amount (Giver)
                    bankAccount.Balance = bankAccount.Balance - Transfer.TransferAmount;

                    // Update balance amount (Receiver)
                    selectedBankAccountReceiver.Balance = selectedBankAccountReceiver.Balance + Transfer.TransferAmount;
                }
            }

        }


        public void ViewTransaction(BankAccount bankAccount)
        {

            if (_listOfTransactions.Count <= 0)
                switch (LangChoice._choice)
                {
                    case 1:
                        Utility.PrintMessage($"There is no transaction yet.", true);
                        break;
                    case 2:
                        Utility.PrintMessage($"Imebeghi transactionu.", true);
                        break;
                    case 3:
                        Utility.PrintMessage($"you no get transaction.", true);
                        break;
                    default:
                        Utility.PrintMessage($"There is no transaction yet.", true);
                        break;


                }
            
            else
            {
   
                foreach (var trans in _listOfTransactions)
                {

                    switch (LangChoice._choice)
                    {
                        case 1:
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"The transaction Type is {trans.TransactionType} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"The Sender BankAccount No is {trans.BankAccountNoFrom} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"The Receipient BankAccount No is {trans.BankAccountNoTo} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"The transaction Amount is ${trans.TransactionAmount} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"The transaction Date is {trans.TransactionDate} ");
                            break;
                        case 2:
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"Taipu transaction gi bu {trans.TransactionType} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"Accountu nomba onye na-enye enye bu{trans.BankAccountNoFrom} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"Accountu nomba onye na-anara anara bu {trans.BankAccountNoTo} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"Ego ana transacti bu ${trans.TransactionAmount} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"Deeti Eji mee ya bu {trans.TransactionDate} ");
                            break;
                        case 3:
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"The transaction Type be {trans.TransactionType} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"Bank Account no of the  person wey dey Send  be {trans.BankAccountNoFrom} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"Bank Account no of the  person wey dey receive  be {trans.BankAccountNoTo} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"una transaction Amount be ${trans.TransactionAmount} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"The transaction Date be {trans.TransactionDate} ");
                            break;
                        default:
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"The transaction Type is {trans.TransactionType} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"The Sender BankAccount No is {trans.BankAccountNoFrom} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"The Receipient BankAccount No is {trans.BankAccountNoTo} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"The transaction Amount is {trans.TransactionAmount} ");
                            Utility.PrintColorMessage(ConsoleColor.Yellow, $"The transaction Date is {trans.TransactionDate} ");
                            break;


                    }

                }
                switch (LangChoice._choice)
                {
                    case 1:
                        Utility.PrintMessage($"You have performed {_listOfTransactions.Count} transactions.", true);
                        break;
                    case 2:
                        Utility.PrintMessage($"I mere  {_listOfTransactions.Count} transacshonus.", true);
                        break;
                    case 3:
                        Utility.PrintMessage($"You  don perform upto {_listOfTransactions.Count} transactions.", true);
                        break;
                    default:
                        Utility.PrintMessage($"You have performed {_listOfTransactions.Count} transactions.", true);
                        break;


                }

                
            }
        }
    }
}
