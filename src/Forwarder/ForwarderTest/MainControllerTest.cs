using System.Collections.Generic;
using System.Linq;
using Forwarder.Controllers;
using ForwarderDAL.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using ForwarderDAL.Repositories;
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


        /// <summary>
        ///Тест для StationAdd
        ///</summary>
        [TestMethod()]
        public void MainControllerMenuTest()
        {
            Mock<IForwarderRepository> mock = new Mock<IForwarderRepository>();
            mock.Setup(m => m.Stations).Returns(new Station[] {
                new Station {Id = 1, Code = "KRG", Name = "Karagandy"},
                new Station {Id = 2, Code = "MSK", Name = "Moscow"},
                new Station {Id = 3, Code = "NSK", Name = "Novosibirsk"},
                new Station {Id = 4, Code = "AST", Name = "Astana"},
            }.AsQueryable());

            var target = new MainController(mock.Object);

            TestModel results = (TestModel)target.Menu().Model;
            var stationt = results.Stations.ToArray();

            Assert.AreEqual(stationt.Length, 4);
            Assert.AreEqual(stationt[0], "Karagandy");
            Assert.AreEqual(stationt[1], "Moscow");
        }
    }
}
