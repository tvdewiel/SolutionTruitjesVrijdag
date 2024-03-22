using TruitjesBL.Exceptions;
using TruitjesBL.Model;

namespace UnitTestingDomain
{
    public class UnitTestTruitje
    {
        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        public void Test_Prijs_Valid(double prijs)
        {
            Truitje t = new Truitje("comp", "ploeg", "set", Maat.M, "2021-2022", 80);
            t.Prijs = prijs;
            Assert.Equal(prijs, t.Prijs);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(-0.00001)]
        public void Test_Prijs_InValid(double prijs) 
        {
            Truitje t = new Truitje("comp", "ploeg", "set", Maat.M, "2021-2022", 80);
            var ex=Assert.Throws<TruitjesException>(() => t.Prijs = prijs);
            Assert.Equal("SetPrijs",ex.Message);
        }
        [Fact]
        public void Test_ctor_Valid()
        {
            Truitje t = new Truitje("comp", "ploeg", "set", Maat.M, "2021-2022", 80);
            Assert.Equal(80,t.Prijs);
            Assert.Equal("ploeg", t.Ploeg);
        }
        [Theory]
        [InlineData("comp","ploeg","set","2024-2025",-80)]
        [InlineData("comp", "plo", "set", "2024-2025", 80)]
        public void Test_ctor_InValid(string comp,string ploeg,string set,string seizoen,double prijs)
        {
            Assert.Throws<TruitjesException>(() => new Truitje(comp, ploeg, set, Maat.M, seizoen,prijs));
        }
        [Theory]
        [InlineData("ploeg")]
        [InlineData("ploooooeg")]
        public void Test_Ploeg_Valid(string ploeg)
        {
            Truitje t = new Truitje("comp", "ploeg", "set", Maat.M, "2021-2022", 80);
            t.Ploeg = ploeg;
            Assert.Equal(ploeg, t.Ploeg);
        }
        [Theory]
        [InlineData("ploe")]
        [InlineData("plo")]
        [InlineData("      ")]
        [InlineData(null)]
        public void Test_Ploeg_InValid(string ploeg)
        {
            Truitje t = new Truitje("comp", "ploeg", "set", Maat.M, "2021-2022", 80);
            Assert.Throws<TruitjesException>(()=>t.Ploeg=ploeg);
        }
        [Fact]
        public void TestSeizoen_Valid()
        {
            string seizoen = "2021-2022";
            //test ctor
            Truitje t = new Truitje("c1", "ploeg1", "set1", Maat.L, seizoen,80);
            Assert.Equal(seizoen, t.Seizoen);
            //test setter
            seizoen = "2022-2023";
            t.Seizoen = seizoen;
            Assert.Equal(seizoen, t.Seizoen);
        }
        [Theory]
        [InlineData("202-2021")]
        [InlineData("2021a2022")]
        [InlineData("2021-2021")]
        [InlineData(null)]
        [InlineData("2022-2021")]
        [InlineData("a2020-2021")]
        [InlineData("20202021")]
        public void TestSeizoen_Invalid(string seizoen)
        {
            Assert.Throws<TruitjesException>(() => new Truitje("c1", "ploeg", "set1", Maat.L, seizoen, 80));
        }
    }
}