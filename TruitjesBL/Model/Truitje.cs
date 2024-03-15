using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruitjesBL.Model
{
    public class Truitje
    {
        public Truitje(string competitite, string ploeg, string set, Maat maat, string seizoen, double prijs)
        {
            Competitite = competitite;
            Ploeg = ploeg;
            Set = set;
            Maat = maat;
            Seizoen = seizoen;
            Prijs = prijs;
        }

        public int? Id { get; set; }
        public string Competitite { get; set; }
        public string Ploeg {  get; set; }
        public string Set {  get; set; }
        public Maat Maat { get; set; }
        public string Seizoen { get; set; }
        public double Prijs { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Truitje)
            {
                Truitje compTruitje=(Truitje)obj;
                if (Id.HasValue && compTruitje.Id.HasValue)
                {
                    if (Id == compTruitje.Id) return true; else return false;
                }
                else
                {
                    return Competitite == compTruitje.Competitite &&
                           Ploeg == compTruitje.Ploeg &&
                           Set == compTruitje.Set &&
                           Maat == compTruitje.Maat &&
                           Seizoen == compTruitje.Seizoen &&
                           Prijs == compTruitje.Prijs;
                }
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Competitite, Ploeg, Set, Maat, Seizoen, Prijs);
        }
    }
}
