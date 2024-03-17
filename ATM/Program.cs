using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardNum, int pin, String firstName, String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    { 
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        this.cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        this.pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        this.firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        this.lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        this.balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOption()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for you money. Your new balance is: "+currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw: ");
            double withdraw = Double.Parse(Console.ReadLine());
            // Check if the user has enough money
            if(currentUser.getBalance() < withdraw)
            {
                Console.WriteLine("Insuffficent balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("You are good to go! Your new balance is: " +currentUser.getBalance()+ ". Thank you :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("123456789", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("987654321", 1234, "Ashley", "Jones", 320.31));
        cardHolders.Add(new cardHolder("567693566", 1234, "Dawn", "Smith", 54.27));

        // Prompt user
        Console.WriteLine("Wlecome to SimpleATM");
        Console.WriteLine("Please insert your debit card");
        String debitCardNum = "";
        cardHolder currentUser;
        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // Check against our db
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrecnt Pin. Please try again"); }
            }
            catch
            {
                Console.WriteLine("Incorrecnt Pin. Please try again");
            }
        }

        Console.WriteLine("Welcome" + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOption();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {   }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }

        } while (option != 4);
        Console.WriteLine("Thank you! Have a nice day");
    }

}
