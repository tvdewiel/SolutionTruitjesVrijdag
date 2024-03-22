using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TruitjesBL.Exceptions;

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
        private string ploeg;
        public string Ploeg { get { return ploeg; }
            set { 
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5) throw new TruitjesException("Ploeg"); ploeg = value; } }
        public string Set {  get; set; }
        public Maat Maat { get; set; }
        private string seizoen;
        public string Seizoen
        {
            get { return seizoen; }
            set
            {
                if ((string.IsNullOrWhiteSpace(value))
                    || !IsValidSeizoen(value)
                    ) throw new TruitjesException("Seizoen");
                seizoen = value;
            }
        }
        private double prijs;
        public double Prijs
        {
            get { return prijs; }
            set { if (value < 0) throw new TruitjesException("SetPrijs"); prijs = value; }
        }

        public override bool Equals(object? obj)
        {
            if (obj is Truitje)
            {
                Truitje compTruitje = (Truitje)obj;
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
        private bool IsValidSeizoen(string seizoen)
        {
            if (!Regex.IsMatch(seizoen, @"^\d{4}-\d{4}$")) return false;
            int jaar1 = Int32.Parse(Regex.Match(seizoen, @"^\d{4}").Value);
            int jaar2 = Int32.Parse(Regex.Match(seizoen, @"\d{4}$").Value);
            if (jaar2 - jaar1 == 1) return true; else return false;
        }
    }
}
