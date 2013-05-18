using System.IO;
using Forwarder.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using ForwarderDAL.Entity;
using System.Collections.Generic;

namespace ForwarderTest
{
    
    
    /// <summary>
    ///Это класс теста для ExcelImporterTest, в котором должны
    ///находиться все модульные тесты ExcelImporterTest
    ///</summary>
    [TestClass()]
    public class ExcelImporterTest
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
        /////Тест для Import
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem(@"data\loadd2007.XLS")]
        //public void ImportTestCount()
        //{
        //    const string fileName = "loadd2007.XLS";

        //    const int expectedCount = 4;

        //    FileInfo file = new FileInfo(fileName);
        //    ExcelImporter importer = new ExcelImporter();

        //    List<Shipment> shipments = importer.Import(file.FullName);

        //    Assert.AreEqual(expectedCount, shipments.Count);
        //}

        /// <summary>
        ///Тест для Import
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ImportTestFileNotFound()
        {
            const string fileName = "invalid.XLS";

            FileInfo file = new FileInfo(fileName);
            ExcelImporter importer = new ExcelImporter();

            importer.Import(file.FullName);
        }
    }
}
