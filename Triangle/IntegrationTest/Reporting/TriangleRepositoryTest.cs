using System.Transactions;

using DataAccess.Context;
using DataAccess.Repository;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTest.Reporting
{
    [TestClass]
    public class TriangleRepositoryTest
    {
        private IReportingTriangle reportingTriangle;
        private TransactionScope transactionScope;
        [TestInitialize()]
        public void Initiallize()
        {
            this.transactionScope = new TransactionScope();
            this.reportingTriangle = new ReportingTriangleImpl(new TriangleContext());
        }
        [TestCleanup()]
        public void Cleanup()
        {
            this.transactionScope.Dispose();
        }
        [TestMethod]
        public void CallReportThroughStoreProcedureShouldReturnTotal5Record()
        {
            var record = reportingTriangle.GetAllTriangle().Count;
            Assert.AreEqual(5,record);
        }
        [TestMethod]
        public void CallReportThroughStoreProcedureShouldReturn1RecordOfNotTriangle()
        {
            var record = reportingTriangle.GetAllTriangle()[3];
            Assert.AreEqual(1, record.Amount);
            Assert.AreEqual("Not Triangle", record.TriangleType);
        }
        [TestMethod]
        public void CallReportThroughStoreProcedureShouldReturn1RecordOfNormalTriangle()
        {
            var record = reportingTriangle.GetAllTriangle()[2];
            Assert.AreEqual(1, record.Amount);
            Assert.AreEqual("Normal Triangle", record.TriangleType);
        }
        [TestMethod]
        public void CallReportThroughStoreProcedureShouldReturn1RecordOfRectangledTriangle()
        {
            var record = reportingTriangle.GetAllTriangle()[4];
            Assert.AreEqual(1, record.Amount);
            Assert.AreEqual("Rectangled Triangle", record.TriangleType);
        }
        [TestMethod]
        public void CallReportThroughStoreProcedureShouldReturn1RecordOfIsoscelesTriangle()
        {
            var record = reportingTriangle.GetAllTriangle()[1];
            Assert.AreEqual(1, record.Amount);
            Assert.AreEqual("Isosceles Triangle", record.TriangleType);
        }
        [TestMethod]
        public void CallReportThroughStoreProcedureShouldReturn1RecordOfEquilateralTriangle()
        {
            var record = reportingTriangle.GetAllTriangle()[0];
            Assert.AreEqual(1, record.Amount);
            Assert.AreEqual("Equilateral Triangle", record.TriangleType);
        }
    }
}
