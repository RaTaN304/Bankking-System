using System;
using System.Collections;
namespace ConsoleApp5
{
    class Clinet
    {
        // Felds 
        private string fullname;
        public long Clint_Id { set; get; }
        private string job;
        private long phonenum;
        private string addres;
        public Account Current { get; set; }
        public Account Business { set; get; }

        //Constructer
        public Clinet() { }
        public Clinet(string fullname, long clint_id, string job, long phonenum, string addres)
        {
            this.fullname = fullname;
            Clint_Id = clint_id;
            this.job = job;
            this.phonenum = phonenum;
            this.addres = addres;
            Current = null;
            Business = null;

        }
        public void Print_info()
        {

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n" +
                                  "                    ####___________________________________________________________________###\n" +
                                  "                    ####___________________________________________________________________###\n" +
                                  "                    ####___________________________________________________________________###\n\n" +
                                  $"                                        Name is        {fullname}\n " +
                                  $"                                       Clint_ID is    {Clint_Id}\n" +
                                  $"                                        Job is         {job}\n" +
                                  $"                                        PhoneNumber is {phonenum}\n" +
                                  $"                                        Addres is      {addres}\n\n" +
                                  $"                                        __________________________\n" +
                                   "                                        Accounts Detalis\n");

            if (Current == null) Console.WriteLine("                                         No Current Account yet");
            else Current.Print();
            if (Business == null) Console.WriteLine("                                         No Business Account yet");
            else Business.Print();

            Console.WriteLine("                    ####___________________________________________________________________###\n" +
                              "                    ####___________________________________________________________________###\n" +
                              "                    ####___________________________________________________________________###\n");


        }

    }

    class Account : Clinet
    {
        public string Account_ID { get; set; }
        public long Balance { get; set; }
        public DateTime Time_Modifed { set; get; }
        public string Type { set; get; }



        //Constructer

        public Account(long account_ID, long balance, string type, long clint_Id)
        {
            if (type == "Business")
                Account_ID = "0BuAc" + Convert.ToString(account_ID);

            else Account_ID = "0CuAc" + Convert.ToString(account_ID);

            Balance = balance;
            Time_Modifed = DateTime.Now;
            Type = type;
            Clint_Id = clint_Id;
        }

        public void Print()
        {
            Console.WriteLine($"                                         {Type} Detalis\n" +
                              $"                                          Account_ID:   { Account_ID}\n" +
                              $"                                          Client Id:    {Clint_Id}\n" +
                              $"                                          Balance:      {Balance}\n" +
                              $"                                          Time modifed: {Time_Modifed}\n");

        }

    }

    static class BankingSystems
    {
        //felds
        private static long Account_ID;
        private static long Clint_ID;
        private static ArrayList Accounts;
        private static ArrayList Clinets;
        //constructor
        static BankingSystems()
        {

            Clint_ID = 20201000;
            Account_ID = 2020101000;
            Clinets = new ArrayList();
            Accounts = new ArrayList();

        }
        //methods
        public static void Add_Clint()
        {
            Console.Write("\n\n\n\n\n                    ####___________________________________________________________________###\n" +
                                    "                    ####_________________________ Add Client ______________________________###\n\n\n");

            // Ask the Client Fo It Detalies
            Console.Write("                                        FullName: ");
            string fullName = Console.ReadLine();

            Console.Write("                                        Job: ");
            string job = Console.ReadLine();

            Console.Write("                                        PhoneNumber: ");
            long phonenum = Chick_input(100000000, 999999999, "Phone Number Must Be 9 Digits");

            Console.Write("                                        Addres: ");
            string addres = Console.ReadLine();

            Clinet c = new Clinet(fullName, Clint_ID, job, phonenum, addres);

            Console.Write("\n\n                                        Choice 1 to Add a current account\n" +
                              "                                        And    2 to Add business account: ");
            long x = Chick_input(1, 2, "1 OR 2");

            Console.Write("                                        Enter Balance : ");
            long balance = Chick_input(10000, 999999999, "At Lest 10000");

            Account Ac = null;

            if (x == 1)
            {
                Ac = new Account(Account_ID, balance, "Current", c.Clint_Id);
                // attack the account to to Accounts list
                c.Current = Ac;

            }
            else if (x == 2)
            {

                Ac = new Account(Account_ID, balance, "Business", c.Clint_Id);
                // attack the account to Accounts list
                c.Business = Ac;

            }

            c.Print_info();
            Console.Write("                                 Is this Your Correct Detalis ? press Enter  to continue\n" +
                          "                                 or press any other button else to dismass: ");
            string Userbermatchion = Console.ReadLine();
            // user permatchion to add account
            if (Userbermatchion == "")
            {
                // increac the Accounts Id
                Account_ID++;
                // add account to accounts list
                Accounts.Add(Ac);
                //increase th e Clint_ID
                Clint_ID++;
                //Add the Client to Clients list
                Clinets.Add(c);

                Console.WriteLine("\n\n                                        Client has been add successsfully");

            }
            else Console.WriteLine("\n\n                                        Clint Dismiss");

            Console.WriteLine("\n                                        Press Any key to go to main menu");
            Console.ReadKey();
        }
        public static void Add_Account()
        {
            Console.Write("\n\n                    ####___________________________________________________________________###\n" +
                              "                    ####_________________________ Add Account _____________________________###\n\n\n");
            // Seach abount client
            Clinet c = search_client();
            // if client found
            if (c != null)
            {
                //Chick if the Client have no Current Account OR Business Account
                // if bouth accounts had been addedd
                if (c.Current == null || c.Business == null)
                {
                    Account Ac = null;

                    if (c.Current == null)
                    {
                        Console.Write("\n\n\n                    ####___________________________________________________________________###\n" +
                                            "                    ####______________________ Add Current Account ________________________###\n\n\n");
                        Console.Write("                                        Enter Balance: ");
                        // Balance that user input
                        long balance = Chick_input(10000, 999999999, "At Lest 10000");
                        Ac = new Account(Account_ID, balance, "Current", c.Clint_Id);
                        // attack the account to to Accounts list

                    }

                    else if (c.Business == null)
                    {
                        Console.Write("\n\n\n                    ####___________________________________________________________________###\n" +
                                            "                    ####______________________ Add Business Account _______________________###\n\n\n");

                        Console.Write("                                        Enter Balance: ");
                        // Balance that user input
                        long balance = Chick_input(10000, 999999999, "At Lest 10000");
                        Ac = new Account(Account_ID, balance, "Business", c.Clint_Id);
                        // attack the account to to Accounts list

                    }

                    Ac.Print();
                    Console.Write("                                 This is Your Account Detalis ? press Enter  to continue\n" +
                                  "                                 or any other button else to dismass: ");
                    string Userbermatchion = Console.ReadLine();
                    // user permatchion to add account
                    if (Userbermatchion == "")
                    {
                        // increac the Accounts Id
                        Account_ID++;
                        // add account to accounts list
                        if (Ac.Type == "Business")
                            c.Business = Ac;
                        else if (Ac.Type == "Current")
                            c.Current = Ac;
                        //add account to accounts
                        Accounts.Add(Ac);

                        Console.WriteLine("\n\n                                        Account has been add successfully");

                    }
                    else Console.WriteLine("\n\n                                        Account Dismiss");


                }

                else Console.WriteLine("                                        Business And Current Accounts has been Added");

            }
            else Console.WriteLine("\n                                        Client Not Found");


            Console.WriteLine("\n                                        Press Any key to go to main menu");
            Console.ReadKey();
        }
        public static void Search_Clint()
        {
            Console.Write("\n\n\n\n\n                    ####___________________________________________________________________###\n" +
                                    "                    ####_________________________ Search Client ___________________________###\n\n\n");

            // use function search_client to search about client
            Clinet c = search_client();
            if (c != null)
                c.Print_info();
            else
                Console.WriteLine("                                        Not Found\n" +
                                  "                                        Please Chick the ID ");
            Console.WriteLine("\n                                        Press Any key to go to main menu");
            Console.ReadKey();
        }
        public static void Search_Account()
        {
            //Function to search about Account
            Console.Write("\n\n\n\n\n                    ####___________________________________________________________________###\n" +
                                    "                    ####_________________________ Search_Account __________________________###\n\n\n");

            Account Ac = search_account();
            if (Ac != null)
                Ac.Print();

            else Console.WriteLine("                                        No Found\n" +
                                   "                                        Please Chick the ID ");

            Console.WriteLine("\n                                        Press Any key to go to main menu");
            Console.ReadKey();
        }
        public static void Despost_Money()
        {
            Console.Write("\n\n\n\n\n                    ####___________________________________________________________________###\n" +
                                    "                    ####_________________________ Despost_Money ___________________________###\n\n\n");


            // Search About Account
            Account Ac = search_account();
            //Chick if the account is found
            if (Ac != null)
            {
                Console.Write("                    Enter Cash: ");
                //int balance = Convert.ToInt32(Console.ReadLine());
                long balance = Chick_input(1, 999999999, "1-999999999");
                //Add the cash to balance
                Ac.Balance += balance;
                Console.WriteLine($"Despost {balance} Successsfully");
            }
            else Console.WriteLine("Not found");

            Console.WriteLine("\n                                        Press  any key to go to main menu");
            Console.ReadKey();

        }

        public static void Withdraw_Money()
        {

            //Function to search about Account
            Console.Write("\n\n\n\n\n                    ####___________________________________________________________________###\n" +
                                    "                    ####_________________________ Withdraw Money __________________________###\n\n\n");
            Account Ac = search_account();

            //Chick if the account is found
            if (Ac != null)
            {

                Console.Write("                    Enter Cash: ");
                long balance = Chick_input(1, 999999999, "1-999999999");
                if (Ac.Type == "Current" && Ac.Balance >= balance)
                {
                    //subtract from balance
                    Ac.Balance -= balance;
                    Console.WriteLine("                    WidthDrew done Successsfully");

                }
                else if (Ac.Type == "Business" && -1000000 <= (Ac.Balance - balance))
                {
                    //subtract from balance
                    Ac.Balance -= balance;
                    Console.WriteLine("                    WidthDrew done Successsfully");

                }
                else
                    Console.WriteLine("\a                    No Enought Money");



            }
            else Console.WriteLine("\a                    Not found");
            Console.WriteLine("\n                                        Press  any key to go to main menu");
            Console.ReadKey();
        }
        public static void Treansfer_money()
        {
            Account from = null;
            Account To = null;
            Console.Write("\n\n\n\n\n                    ####___________________________________________________________________###\n" +
                                    "                    ####_________________________ Treansfer_money _________________________###\n\n\n");

            //Chick if the Account is found
            while (true)
            {
                Console.WriteLine("                                        From: ");
                from = search_account();
                if (from != null)
                {
                    from.Print();
                    break;
                }
                Console.Write("                                        This Account not found\n" +
                              "                                        press 1 to Exit: ");
                if (Console.ReadLine() == "1") break;


            }

            while ((from != null))
            {
                Console.WriteLine("                                        To: ");
                To = search_account();
                if (To != null)
                {
                    To.Print();
                    break;
                }
                Console.Write("                                        This Account not found\n" +
                              "                                        press 1 to Exit: ");
                if (Console.ReadLine() == "1") break;
            }
            if (To != null)
            {
                if (from.Type == To.Type)
                {
                    Console.Write("                                        Enter Cash: ");
                    long balance = Chick_input(1, 999999999, "1-999999999");
                    if (from.Type == "Current")
                    {
          
                        if (from.Balance >= balance)
                        {
                            from.Balance -= balance;
                            To.Balance += balance;
                            Console.WriteLine("                                        Treansfer Done Successsfully");

                        }
                        else
                            Console.WriteLine("                                        \aNo Enought Money");

                    }
                    else
                    {

                        if (from.Balance - balance >= -1000000)
                        {
                            from.Balance -= balance;
                            To.Balance += balance;
                            Console.WriteLine("                                        Treansfer Done Successsfully");

                        }
                        else
                            Console.WriteLine("                                        \aNo Enought Money");

                    }

                }
                else Console.WriteLine("                                     Treansfer only between accounts with the same type");
            }
            else Console.WriteLine("                                     Both Accounts Not Found");

            Console.WriteLine("\n                                        Press  any key to go to main menu");
            Console.ReadKey();
        }
        public static void Display_Clint()

        {
            foreach (Clinet c in Clinets)
                c.Print_info();

            Console.WriteLine("\n                                        Press  any key to go to main menu");
            Console.ReadKey();
        }
        public static void Display_Accounts()

        {
            foreach (Account a in Accounts)
                a.Print();

            Console.WriteLine("\n                                        Press  any key to go to main menu");
            Console.ReadKey();
        }

        public static void Close_Accounts()
        {
            Console.Write("\n\n\n\n\n                    ####___________________________________________________________________###\n" +
                                    "                    ####_________________________ Close Accounts __________________________###\n\n\n");

            Account Ac = search_account();
            // if found the account print it is informatchion
            if (Ac != null)
            {
                Ac.Print();
                //chick if the balance's account

                if (Ac.Balance < 0)
                    Console.WriteLine($"\a                    You can not delete this Account because your Balance is {Ac.Balance}");

                else if (Ac.Balance >= 0)
                {
                    // تاكيد الحذف
                    Console.WriteLine("                    Is That The Account You Looking For ?\n" +
                                      "                    press 1 to Continue\n" +
                                     $"                    Your Balance is {Ac.Balance}\n");

                    if (Console.ReadLine() == "1")
                    {
                        // delet the account
                        Accounts.Remove(Ac);

                        Console.WriteLine("                    Account Deleted Successfully");
                        //search about client
                        Clinet c = null;
                        foreach (Clinet i in Clinets)
                        {
                            if (i.Clint_Id == Ac.Clint_Id)
                            {
                                c = i;

                            }
                        }

                        if (Ac.Type == "Business")
                        {
                            c.Business = null;
                        }
                        else if (Ac.Type == "Current")
                        {
                            c.Current = null;
                        }

                        // to chick if the client has no accounts

                        if (c.Current == null && c.Business == null)
                        {
                            c.Print_info();
                            Console.WriteLine("                    Client deleted\n" +
                                              "                    because he Has no Accounts");
                            Clinets.Remove(c);

                        }


                    }
                }
            }

            else Console.WriteLine("\n                                        Not Found");

            Console.WriteLine("\n                                        Press  any key to go to main menu");
            Console.ReadKey();

        }
        public static void Display_Account_Time()
        {
            Console.Write("\n\n\n\n\n                    ####___________________________________________________________________###\n" +
                                    "                    ####_________________________ Search By Data __________________________###\n\n\n");

            Console.WriteLine("Enter Date");
            Console.WriteLine("Start At");

            try
            {
                DateTime from = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("To");
                DateTime to = Convert.ToDateTime(Console.ReadLine());




                foreach (Account a in Accounts)
                {
                    if (a.Time_Modifed.CompareTo(from) == 1 && a.Time_Modifed.CompareTo(to) == -1)
                    {
                        a.Print();
                    }
                }

            }
            catch
            {
                Console.WriteLine("\n                                        Enter Data Like Month/Days/years");

            }
            Console.WriteLine("\n                                        Done...");


            Console.WriteLine("\n                                        Press  any key to go to main menu");
            Console.ReadKey();

        }
        //
        private static Clinet search_client()
        {
            Console.Write("                    Enter Id client: ");
            long id = Chick_input(20201000, 99999999, "Clients ID stat at 20201000");
            Clinet c = null;
            foreach (Clinet f in Clinets)
                if (f.Clint_Id == id)
                    c = f;
            return c;
        }

        private static Account search_account()
        {
            Console.Write("                    Enter ID account: ");

            string id = Console.ReadLine();
            Account c = null;
            foreach (Account f in Accounts)
                if (f.Account_ID == id)
                    c = f;
            return c;
        }

        private static long Chick_input(int from, int to, string message)
        {
            int x = 0;
            while (true)
            {
                try
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    if (x >= from && x <= to)
                        break;
                    else Console.WriteLine("\a                                                       Error\n" +
                                            $"                                        Number Should Be Between {message}\n");

                }
                catch
                {
                    Console.WriteLine($"\a                                                       Error\n" +
                                        $"                                              Enter Number Not String");
                }
            }
            return x;
        }



    }

    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n                                         Welcome to GID Banking System\n");
            Console.ReadKey();
            while (true)
            {
                Console.Clear();
                Console.Write(
             "\n\n\n\n\n\n" +
             "                    ####___________________________________________________________________###\n" +
             "                    ####___________________________________________________________________###\n" +
             "                    ####___________________________________________________________________###\n\n" +
             "                                        Enter  1  Add Clint   \n" +
             "                                        Enter  2  Open New Account \n" +
             "                                        Enter  3  Search Clint\n" +
             "                                        Enter  4  Search Account\n" +
             "                                        Enter  5  Despost Money\n" +
             "                                        Enter  6  Withdraw Money\n" +
             "                                        Enter  7  Display list of Accounts\n" +
             "                                        Enter  8  Display list of Clients\n" +
             "                                        Enter  9  Treansfer money\n" +
             "                                        Enter  10 Close Account\n" +
             "                                        Enter  11 Display list of Account \n" +
             "                                                  in specifed Time\n" +
             "                                        Enter 12 to Exit\n" +
             "                    ####___________________________________________________________________###\n" +
             "                    ####___________________________________________________________________###\n" +
             "                    ####___________________________________________________________________###\n" +
             "                                                         ");
                string x = Convert.ToString(Console.ReadLine());
                Console.Clear();
                if (x == "1")
                    BankingSystems.Add_Clint();
                else if (x == "2")
                    BankingSystems.Add_Account();
                else if (x == "3")
                    BankingSystems.Search_Clint();
                else if (x == "4")
                    BankingSystems.Search_Account();
                else if (x == "5")
                    BankingSystems.Despost_Money();
                else if (x == "6")
                    BankingSystems.Withdraw_Money();
                else if (x == "7")
                    BankingSystems.Display_Accounts();
                else if (x == "8")
                    BankingSystems.Display_Clint();
                else if (x == "9")
                    BankingSystems.Treansfer_money();
                else if (x == "10")
                    BankingSystems.Close_Accounts();
                else if (x == "11")
                    BankingSystems.Display_Account_Time();
                else if (x == "12")
                    break;
                else
                { 
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n                                        Error enter a number bettwen 1-12");
                    Console.WriteLine("\n                                        Press  any key to go to main menu");
                    Console.ReadKey();
                }
            }

        }
    }
}
