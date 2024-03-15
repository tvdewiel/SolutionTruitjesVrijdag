using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruitjesBL.Exceptions;

namespace TruitjesBL.Model
{
    public class Klant
    {
        public Klant(string naam, string adres)
        {
            Naam = naam;
            Adres = adres;
        }

        public int? Id { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        private List<Bestelling> bestellingen=new List<Bestelling>();
       

        public void VoegBestellingToe(Bestelling bestelling)
        {
            if ((bestelling==null) || (bestellingen.Contains(bestelling))) throw new TruitjesException("Voegbestellingtoe");
            bestellingen.Add(bestelling);
            if (bestelling.Klant!=this) bestelling.Klant = this;
        }
        public void VerwijderBestelling(Bestelling bestelling)
        {
            if ((bestelling == null) || (!bestellingen.Contains(bestelling))) throw new TruitjesException("VerwijderBestelling");
            bestellingen.Remove(bestelling);
            if (bestelling.Klant==this) bestelling.Klant = null;
        }
        public double Korting() //in procent
        {
            return 10;
        }
        public bool HeeftBestelling(Bestelling b)
        {
            return bestellingen.Contains(b);
        }
    }
}
