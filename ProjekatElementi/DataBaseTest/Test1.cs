using DataBase;
using Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataBaseTest
{
    [TestFixture]
    public class Test1
    {
        private DataBaseImpl baza;

        [SetUp]
        public void setUp()
        {
            var database = new Mock<DataBaseImpl>();
            baza = database.Object;
        }

        [Test]
        public void TestirajPotrosnju()
        {
            baza.ObrisiSvePotrosnje();
            Potrosnja p1 = new Potrosnja(new DateTime(2019, 10, 10), 24, 335, "VOJ", 1, 0);
            Potrosnja p2 = new Potrosnja(new DateTime(2019, 11, 10), 25, 3150, "BGD", 0, 0);
            Potrosnja p3 = new Potrosnja(new DateTime(2019, 10, 10), 24, 331, "VOJ", 1, 0);
            baza.UbaciPotrosnju(p1);
            baza.UbaciPotrosnju(p2);
            baza.UbaciPotrosnju(p3);

            List<Potrosnja> potrosnje = new List<Potrosnja>();
            potrosnje = baza.VratiPotrosnje();

            Assert.That(potrosnje.Count == 3, Is.True, "Test ubacivanja je uspjesan");

        }

        [Test]
        public void TestirajPotrosnju2()
        {
            Potrosnja p1 = new Potrosnja(new DateTime(2019, 10, 10), 24, 335, "VOJ", 1, 0);
            Potrosnja p2 = new Potrosnja(new DateTime(2019, 11, 10), 25, 3150, "BGD", 0, 0);
            Potrosnja p3 = new Potrosnja(new DateTime(2019, 10, 10), 24, 331, "VOJ", 1, 0);
            baza.UbaciPotrosnju(p1);
            baza.UbaciPotrosnju(p2);
            baza.UbaciPotrosnju(p3);

            List<Potrosnja> potrosnje = new List<Potrosnja>();
            potrosnje = baza.VratiPotrosnje();

            baza.ObrisiSvePotrosnje();
            potrosnje = baza.VratiPotrosnje();

            Assert.That(potrosnje.Count == 0, Is.True, "Test brisanja je uspjesan");
        }

        [Test]
        public void TestirajPotrosnju3()
        {
            Potrosnja p1 = new Potrosnja(new DateTime(2019, 10, 10), 24, 335, "VOJ", 1, 0);
            Potrosnja p2 = new Potrosnja(new DateTime(2019, 11, 10), 25, 3150, "BGD", 0, 0);
            Potrosnja p3 = new Potrosnja(new DateTime(2019, 10, 10), 24, 331, "VOJ", 1, 0);

            List<Potrosnja> potrosnje = new List<Potrosnja>();
            potrosnje = baza.VratiPotrosnje();

            baza.ObrisiSvePotrosnje();
            baza.UbaciPotrosnju(p1);
            baza.UbaciPotrosnju(p2);
            baza.UbaciPotrosnju(p3);

            baza.ObrisiPotrosnju(new DateTime(2019, 10, 10), "VOJ");
            potrosnje = baza.VratiPotrosnje();

            Assert.That(potrosnje.Count == 2, Is.True, "Test brisanja jedne potrosnje je uspjesan");

        }

        [Test]
        public void TestirajAudit()
        {
            Audit a1 = new Audit(new DateTime(2018, 10, 10), "fajlPrvi", "VOJ", 18);
            Audit a2 = new Audit(new DateTime(2018, 11, 10), "fajlDrugi", "BGD", 17);

            baza.UbaciAudit(a1);
            baza.UbaciAudit(a2);

            List<Audit> auditi = new List<Audit>();
            auditi = baza.VratiAudit();

            Assert.That(auditi.Count == 2, Is.True, "Test ubacivanja audita je uspjesan");

            baza.ObrisiSveAudit();
            auditi = baza.VratiAudit();
            Assert.That(auditi.Count == 0, Is.True, "Test brisanja audita je uspjesan");

            baza.UbaciAudit(a1);
            baza.UbaciAudit(a2);
            auditi = baza.VratiAudit();

            baza.ObrisiAudit("fajlPrvi");
            auditi = baza.VratiAudit();
            Assert.That(auditi.Count == 1, Is.True, "Test brisanja audita je uspjesan");

            baza.UpdateAudit(a2);


        }
        [Test]
        public void TestirajPodrucje()
        {
            Podrucje p1 = new Podrucje("1805", "VRB", 100);
            Podrucje p2 = new Podrucje("2610", "DBJ", 90);

            baza.UbaciPodrucje(p1);
            baza.UbaciPodrucje(p2);

            List<Podrucje> podrucja = new List<Podrucje>();
            podrucja = baza.VratiPodrucje();

            Assert.That(podrucja.Count == 2, Is.True, "Test ubacivanja je uspjesan");

            baza.ObrisiSvaPodrucja();
            podrucja = baza.VratiPodrucje();
            Assert.That(podrucja.Count == 0, Is.True, "Test brisanja svih podrucja je uspjesan.");

            baza.UbaciPodrucje(p1);
            baza.UbaciPodrucje(p2);
            podrucja = baza.VratiPodrucje();

            baza.ObrisiPodrucje(100);
            podrucja = baza.VratiPodrucje();
            Assert.That(podrucja.Count == 1, Is.True, "Test brisanja jednog podrucja je uspjesan.");
        }
        
    }
}
