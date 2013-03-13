using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ForwarderDAL.Repositories;
using ForwarderDAL.Entity;
using Forwarder.Controllers;
using System.Collections.Generic;
using System.Linq;


namespace ForwarderTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Create_Stations()
        {
            Mock<IForwarderRepository> mock = new Mock<IForwarderRepository>();
            mock.Setup(m => m.Stations).Returns(new StationEntity[] {
                new StationEntity {ID = 1, Code = "KRG", Name = "Karagandy"},
                new StationEntity {ID = 2, Code = "MSK", Name = "Moscow"},
                new StationEntity {ID = 3, Code = "NSK", Name = "Novosibirsk"},
                new StationEntity {ID = 4, Code = "AST", Name = "Astana"},
            }.AsQueryable());

            var target = new MainController(mock.Object);

            string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();

            Assert.AreEqual(results.Length, 4);
            Assert.AreEqual(results[0], "Karagandy");
            Assert.AreEqual(results[1], "Moscow");
        }
    }
}
