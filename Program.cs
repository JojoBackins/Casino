using System;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        double odds = .75;
        Guy player = new Guy() { Name = "The player", Cash = 100 };

        Console.WriteLine("Welcome man. You odds are " + odds);

        while (player.Cash > 0)
        {
            player.WriteMyInfo();
            Console.WriteLine("How much do you want to bet: ");
            string howMuch = Console.ReadLine();

            if (int.TryParse (howMuch, out int amount))
            {
                int pot = player.GiveCash(amount) * 2;
                if (pot > 0)
                {
                    if( rand.NextDouble() > odds)
                    {
                        int winner = pot;
                        Console.WriteLine("You win !");
                            player.ReceiveCash(winner);
                    } else
                    {
                        Console.WriteLine("not today buddy...");
                    }
                }
            }else
            {
                Console.WriteLine("Please enter a valid number.");
            }

        }
        Console.WriteLine("The house always wins.");



    }

    class Guy
    {
        public string Name;
        public int Cash;

        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " has " + Cash + " bucks.");
        }
        public int GiveCash(int amount)
        {

            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't a valid amount");
                return 0;
            }
            if (amount > Cash)
            {
                Console.WriteLine(Name + " says: " + "I don't have enough cash to give you " + amount);
                return 0;
            }
            Cash -= amount;
            return amount;


        }
        public void ReceiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't an amount I'll take");
            }
            else
            {
                Cash += amount;
            }
        }
    }
}


