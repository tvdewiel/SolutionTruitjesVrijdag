using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruitjesBL.Exceptions;

namespace TruitjesBL.Model
{
    public class Bestelling
    {
        public int? Id { get; set; }
        public DateTime Datum { get; set; }
        public bool IsBetaald { get; private set; }
        public double? AfgerekendePrijs { get; private set; }
        private Klant klant;
        public Klant Klant { get { return klant; }
            set { 
                if ((value!=null) && (value != klant))
                {
                    if (klant!=null && klant.HeeftBestelling(this))
                    {
                        klant.VerwijderBestelling(this);
                    }
                    klant = value;
                    if (!klant.HeeftBestelling(this)) klant.VoegBestellingToe(this);
                }
            } }
        private Dictionary<Truitje,int> truitjes = new Dictionary<Truitje,int>();

        public IReadOnlyDictionary<Truitje,int> Truitjes => truitjes;

        public Bestelling(DateTime datum)
        {
            Datum = datum;
            IsBetaald = false;
        }

        public void VoegTruitjeToe(Truitje truitje,int aantal)
        {
            if ((truitje == null) || (aantal<=0)) throw new TruitjesException("VoegTruitjeToe");
            if (truitjes.ContainsKey(truitje))
            {
                truitjes[truitje] += aantal;
            }
            else
            {
                truitjes.Add(truitje, aantal);
            }
        }
        public void VerwijderTruitje(Truitje truitje,int aantal)
        {
            if ((truitje == null) 
                || (aantal <= 0)
                || (!truitjes.ContainsKey(truitje))
                || (truitjes[truitje]<aantal)) throw new TruitjesException("VerwijderTruitje");
            if (truitjes[truitje] == aantal) truitjes.Remove(truitje);
            else truitjes[truitje]-=aantal;
        }
        public void RekenAf()
        {
            IsBetaald = true;
            AfgerekendePrijs = Prijs();
        }
        public double Prijs()
        {
            double prijs = 0.0;
            foreach(var x in truitjes)
            {
                prijs += (x.Key.Prijs * x.Value);
            }
            prijs = prijs * (1-(Klant.Korting()/100));
            return prijs;
        }
    }
}
