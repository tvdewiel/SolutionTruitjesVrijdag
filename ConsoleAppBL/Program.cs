using TruitjesBL.Model;

namespace ConsoleAppBL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Truitje t1 = new Truitje("comp","ploeg1","set1",Maat.M,"2023-2024",100);
            Truitje t2 = new Truitje("comp", "ploeg2", "set1", Maat.M, "2023-2024", 110);
            Klant k1 = new Klant("jos", "gent");
            Klant k2 = new Klant("jossianne", "gent");
            Bestelling b1=new Bestelling(DateTime.Now);
            Bestelling b2 = new Bestelling(DateTime.Now);
            b1.VoegTruitjeToe(t1, 2);
            b1.VoegTruitjeToe(t2, 3);
            b2.VoegTruitjeToe(t1, 1);
            b2.VoegTruitjeToe(t2, 1);
            //b1.Klant = k1;
            //b1.Klant = k2;
            k1.VoegBestellingToe(b1);
            k2.VoegBestellingToe(b2);
            k1.VoegBestellingToe(b2);
        }
    }
}
