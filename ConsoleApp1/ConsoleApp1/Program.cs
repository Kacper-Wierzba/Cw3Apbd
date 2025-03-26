namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        KontenerPlyn kp1 = new KontenerPlyn(10, 80, 190, 100);
        KontenerChlodniczy kc1 = new KontenerChlodniczy(10, 80, 190, 100,10);
        KontenerGaz kg1 = new KontenerGaz(10, 80, 190, 100,100);
        Console.WriteLine(kp1);
        Console.WriteLine(kc1);
        Console.WriteLine(kg1);
        kp1.Fill("a",89,false);
        kp1.Fill("b",2,false);
        Console.WriteLine(kp1);
        kg1.Fill("a",1,1);
        kg1.Fill("b",1,1000);
        Console.WriteLine(kg1);
        kc1.Fill("a",1,1);
        kc1.Fill("a",2,10);
        Console.WriteLine(kc1);
        
        Console.WriteLine();

        Kontenerowiec ship = new Kontenerowiec(100, 100, 99999);
        
        ship.Load(new KontenerPlyn(1,2,3,4));
        
        Console.WriteLine(ship);
        
        List<Kontener> kontenery = new();
        kontenery.Add(kp1);
        kontenery.Add(kc1);
        kontenery.Add(kg1);
        
        ship.Load(kontenery);
        
        Console.WriteLine(ship);
        
        ship.Unload("KON-L-4");
        
        Console.WriteLine(ship);
        Console.WriteLine();
        Console.WriteLine(kp1);
        kp1.Empty();
        Console.WriteLine(kp1);
        Console.WriteLine(kc1);
        kc1.Empty();
        Console.WriteLine(kc1);
        Console.WriteLine(kg1);
        kg1.Empty();
        Console.WriteLine(kg1);
        
        Console.WriteLine();
        Console.WriteLine(ship);
        ship.Exchange(new KontenerChlodniczy(99, 99, 99, 99,99), "KON-C-2");
        Console.WriteLine(ship);
        
        Kontenerowiec ship2 = new Kontenerowiec(100, 100, 99999);
        Console.WriteLine(ship);
        Console.WriteLine(ship2);
        ship.Transfer(ship2, "KON-C-5");
        Console.WriteLine(ship);
        Console.WriteLine(ship2);

    }
}