using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruitjesBL.Exceptions;
using TruitjesBL.Model;

namespace UnitTestingDomain
{
    public class UnitTestBestelling
    {
        private Truitje t1, t2;
        private Klant k1, k2;

        public UnitTestBestelling()
        {
            t1 = new Truitje("c1", "ploeg1", "set1", Maat.L, "2022-2023", 80);
            t2 = new Truitje("c1", "ploeg2", "set1", Maat.L, "2022-2023", 80);
            k1 = new Klant("jos", "Gent");
            k2 = new Klant("Marcel", "Lokeren");
        }

        [Fact]
        public void Test_VoegTruitjeToe_Valid()
        {
            Bestelling b = new Bestelling(DateTime.Now);
            
            //init
            b.VoegTruitjeToe(t1, 5);
            Assert.Contains(t1, b.Truitjes.Keys);
            Assert.Equal(5, b.Truitjes[t1]);
            Assert.Equal(1, b.Truitjes.Count);
            //scenario 2 - voeg 3 extra aan toe
            b.VoegTruitjeToe(t1, 3);
            Assert.Contains(t1, b.Truitjes.Keys);
            Assert.Equal(8, b.Truitjes[t1]);
            Assert.Equal(1, b.Truitjes.Count);
            //scenario 3 - nieuw truitje
            b.VoegTruitjeToe(t2, 2);
            Assert.Contains(t1, b.Truitjes.Keys);
            Assert.Equal(8, b.Truitjes[t1]);
            Assert.Contains(t2, b.Truitjes.Keys);
            Assert.Equal(2, b.Truitjes[t2]);
            Assert.Equal(2, b.Truitjes.Count);
        }
        [Fact]
        public void Test_VoegTruitjeToe_InValid()
        {
            Bestelling b = new Bestelling(DateTime.Now);
            Assert.Throws<TruitjesException>(() => b.VoegTruitjeToe(null, 10));
            Assert.Throws<TruitjesException>(() => b.VoegTruitjeToe(t1, 0));
            Assert.Throws<TruitjesException>(() => b.VoegTruitjeToe(t1, -10));
        }
        [Fact]
        public void Test_SetKlant_Valid()
        {
            Bestelling b = new Bestelling(DateTime.Now);
            b.VoegTruitjeToe(t1, 2);
            //scenario 1
            b.Klant = k1;
            Assert.Equal(k1, b.Klant);
            Assert.True(k1.HeeftBestelling(b));
            //scenario 2 - klant veranderen
            b.Klant = k2;
            Assert.Equal(k2, b.Klant);
            Assert.True(k2.HeeftBestelling(b));
            Assert.False(k1.HeeftBestelling(b));
        }
    }
}
