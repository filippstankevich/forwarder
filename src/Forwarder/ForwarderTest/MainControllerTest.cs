using System.Collections.Generic;
using System.Linq;
using Forwarder.Controllers;
using ForwarderDAL.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using ForwarderDAL.Repositories;
using Forwarder.Helper;
using Forwarder.Models;
using System.Web.Mvc;
using Moq;

namespace TestFor
{
    
    
    /// <summary>
    ///Это класс теста для MainControllerTest, в котором должны
    ///находиться все модульные тесты MainControllerTest
    ///</summary>
    [TestClass()]
    public class MainControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты теста
        // 
        //При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        //ClassInitialize используется для выполнения кода до запуска первого теста в классе
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //TestInitialize используется для выполнения кода перед запуском каждого теста
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //TestCleanup используется для выполнения кода после завершения каждого теста
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        ///// <summary>
        /////Тест для StationAdd
        /////</summary>
        //[TestMethod()]
        //public void MainControllerMenuTest()
        //{
        //    Mock<IForwarderRepository> mock = new Mock<IForwarderRepository>();
        //    mock.Setup(m => m.Stations).Returns(new Station[] {
        //        new Station {Id = 1, Code = "KRG", Name = "Karagandy"},
        //        new Station {Id = 2, Code = "MSK", Name = "Moscow"},
        //        new Station {Id = 3, Code = "NSK", Name = "Novosibirsk"},
        //        new Station {Id = 4, Code = "AST", Name = "Astana"},
        //    }.AsQueryable());

        //    var target = new MainController(mock.Object);

        //    TestModel results = (TestModel)target.Menu().Model;
        //    var stationt = results.Stations.ToArray();

        //    Assert.AreEqual(stationt.Length, 4);
        //    Assert.AreEqual(stationt[0], "Karagandy");
        //    Assert.AreEqual(stationt[1], "Moscow");
        //}

        [TestMethod()]
        public void AddNewStationTest()
        {
            var target = new Station {Code = "KRG", Name = "Karagandy"};
            IForwarderRepository repo = new ForwarderRepository();
            
            Assert.IsTrue(repo.AddNewStation(target));
        }

        [TestMethod()]
        public void StationEntityTest()
        {
            var stations = new List<Station>();

            stations.Add(new Station { Id = 1, Code = "KRG", Name = "Karagandy" });
            stations.Add(new Station { Id = 2, Code = "MSK", Name = "Moscow" });
            stations.Add(new Station { Id = 3, Code = "NSK", Name = "Novosibirsk" });
            stations.Add(new Station { Id = 4, Code = "AST", Name = "Astana" });

            var target = "KRG";

            var result = stations.Single(o => o.Id == 1).Code;

            
            Assert.AreEqual(target, result);


        }

        [TestMethod()]
        public void RoadEntityTest()
        {
            var roads = new List<Road>();

            roads.Add(new Road {Id = 1, Name = "Казахстанская", ShortName = "КАЗ"});
            roads.Add(new Road {Id = 2, Name = "Кыргызстанская", ShortName = "КГЗ"});

            var target = 2;

            var result = roads.Count();

            Assert.AreEqual(target, result);
        }

        [TestMethod()]
        public void GNGEntityTest()
        {
            var gngs = new List<Gng>();

            gngs.Add(new Gng { Id = 1, Name = "Абрикосы консервированные для кратковременного хранения", Code = "08129010" });
            gngs.Add(new Gng { Id = 2, Name = "Абрикосы прочие, содержащие спиртовые добавки в первичных упаковках нетто-массой более 1 кг", Code = "20085031" });
            gngs.Add(new Gng { Id = 3, Name = "Абрикосы прочие, содержащие спиртовые добавки в первичных упаковках нетто-массой более 1 кг с фактической концентрацией спирта не более 11,85 мас.%", Code = "20085031" });

            var target = 2;

            var result = gngs.Count(o => o.Code.Contains("200"));

            Assert.AreEqual(result, target);
        }

        [TestMethod()]
        public void ExpenseTypeEntityTest()
        {
            var expTypes = new List<ExpenseType>();

            expTypes.Add(new ExpenseType { Id = 1, Name = "Перегруз"});
            expTypes.Add(new ExpenseType { Id = 2, Name = "Штраф" });
            expTypes.Add(new ExpenseType { Id = 3, Name = "Телеграмма" });

            var target = "Перегруз";

            var result = expTypes.SingleOrDefault(o => o.Name.Contains("Пере")).Name;

            Assert.AreEqual(result, target);
        }
    }
}
