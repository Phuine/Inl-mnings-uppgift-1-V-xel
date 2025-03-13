using System;

class Program
{
    static void Main()
    {
        //Välkoms medelande som välkomnar och berätta vad programet används till
        Console.WriteLine("Hej kära kund tack att du använder vårt program för att beräkna växel för ditt köp!");

        //Secton som kunden anväder för att skriva in hur mycket kunden har köpt för, och kolla efter om det är gilltigt eller ej tal
        decimal price = 0;
        bool valid = true;
        do
        {
            valid = true;
            Console.Write("Skriv in hur mycket det kostade: ");
            if (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Behövs ett giltigt tal!");
                valid = false;
            }
        }
        while (valid);

        //Section hur mycket kunden har betalat, och kolla efter om det är gilltigt eller ej tal
        decimal paid = 0;
        do
        {
           Console.Write("Skriv in hur mycket du har betalat: ");

            Console.WriteLine("Behövs ett giltigt tal!");
            valid = false;
        }
        while (!decimal.TryParse(Console.ReadLine(), out paid));

        //kolla så at kunden har bettalat tillräckligt
        if (paid < price)
        {
            Console.WriteLine("Otillräcklig betalning.");
            return;
        }

        //Programet räknar ut hur mycket växel kunden får tillbaka sammanlagt
        decimal change = paid - price;


        decimal ore = (change * 100) % 100;
        if (ore < 25)
        {
            change = Math.Floor(change);
        }
        else if (ore >= 25 && ore <= 75)
        {
            change = Math.Floor(change) + 0.50m;
        }
        else
        {
            change = Math.Ceiling(change);
        }

        int changeOre = (int)(change * 100);

        int[] denominations = { 1000, 500, 200, 100, 50, 20, 10, 5, 1, 0};
        string[] denominationNames = { "1000 sedel", "500 sedel", "200 sedel", "100 sedel", "50 sedel", "20 sedel", "10 kr", "5 kr", "1 kr", "50 öre" };
       
        //Programet räknar ut hur mycket kunden får tillbaka i sedelar, kr och ören
        Console.WriteLine("Växel som du får tillbaka: " + change + " kr");

        for (int i = 0; i < denominations.Length; i++)
        {
            int numberOre = 0;
            if (denominations[i] == 0) numberOre = 50;
            else numberOre = denominations[i] * 100;
            int count = changeOre / numberOre;
            if (count > 0)
            {
                Console.WriteLine(count + " x " + denominationNames[i]);
                changeOre -= denominations[i]*100*count;
            }
        }
    }
}

