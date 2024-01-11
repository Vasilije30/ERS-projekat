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
        public void TestirajBazu()
        {
            baza.ObrisiSvePotrosnje();
            Potrosnja p1 = new Potrosnja(new DateTime(2019, 10, 10), 24, 335, "VOJ", 1, 35);
            Potrosnja p2 = new Potrosnja(new DateTime(2019, 11, 10), 25, 3150, "BGD", 1, 37);
            Potrosnja p3 = new Potrosnja(new DateTime(2019, 10, 10), 24, 331, "VOJ", 1, 36);
            baza.UbaciPotrosnju(p1);
            baza.UbaciPotrosnju(p2);
            baza.UbaciPotrosnju(p3);

            List<Potrosnja> potrosnje = new List<Potrosnja>();
            potrosnje = baza.VratiPotrosnje();

            //Assert.That(result, Is.True, "The result should be true");

        }
    }
}
