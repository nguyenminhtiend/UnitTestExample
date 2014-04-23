using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Business.Business;
using DataAccess.Entities;
using DataAccess.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Business.MyException;

namespace UnitTest.Business
{
    [TestClass]
    public class TriangleBusinessTest
    {
        private Mock<IGenericRepository<Triangle>> mock;
        [TestInitialize()]
        public void Initialize()
        {
            this.mock = new Mock<IGenericRepository<Triangle>>();
            mock.Setup(x => x.Add(It.IsAny<Triangle>())).Verifiable();
            mock.Setup(x => x.SaveChange()).Verifiable();
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void InvalidInputShouldReturnInvalidInputException()
        {
            var triangleBusiness = new TriangleBusinessImpl(mock.Object);
            var result = triangleBusiness.CheckTriangle(-1, 3, 4);
        }

        [TestMethod]
        public void CalculateTriangleShouldReturnNotTriangle()
        {
            var queryable = Enumerable.Empty<Triangle>().AsQueryable();
            mock.Setup(x => x.FindBy(It.IsAny<Expression<Func<Triangle, bool>>>())).Returns(queryable);
            var triangleBusiness = new TriangleBusinessImpl(mock.Object);

            var result = triangleBusiness.CheckTriangle(1, 2, 3);
            Assert.AreEqual("Not Triangle", result);

        }
        [TestMethod]
        public void CalculateTriangleShouldReturnNormalTriangle()
        {
            var queryable =  Enumerable.Empty<Triangle>().AsQueryable();
            mock.Setup(x => x.FindBy(It.IsAny<Expression<Func<Triangle, bool>>>())).Returns(queryable);
            var triangleBusiness = new TriangleBusinessImpl(mock.Object);

            var result = triangleBusiness.CheckTriangle(2, 3, 4);
            Assert.AreEqual("Normal Triangle", result);

        }
        [TestMethod]
        public void CalculateTriangleShouldReturnIsoscelesTriangle()
        {
            var queryable = Enumerable.Empty<Triangle>().AsQueryable();
            mock.Setup(x => x.FindBy(It.IsAny<Expression<Func<Triangle, bool>>>())).Returns(queryable);
            var triangleBusiness = new TriangleBusinessImpl(mock.Object);

            var result = triangleBusiness.CheckTriangle(3, 3, 4);
            Assert.AreEqual("Isosceles Triangle", result);

        }
        [TestMethod]
        public void CalculateTriangleShouldReturnRectangledTriangle()
        {
            var queryable = Enumerable.Empty<Triangle>().AsQueryable();
            mock.Setup(x => x.FindBy(It.IsAny<Expression<Func<Triangle, bool>>>())).Returns(queryable);
            var triangleBusiness = new TriangleBusinessImpl(mock.Object);

            var result = triangleBusiness.CheckTriangle(3, 4, 5);
            Assert.AreEqual("Rectangled Triangle", result);

        }
        [TestMethod]
        public void CalculateTriangleShouldReturnEquilateralTriangle()
        {
            var queryable = Enumerable.Empty<Triangle>().AsQueryable();
            mock.Setup(x => x.FindBy(It.IsAny<Expression<Func<Triangle, bool>>>())).Returns(queryable);
            var triangleBusiness = new TriangleBusinessImpl(mock.Object);

            var result = triangleBusiness.CheckTriangle(3, 3, 3);
            Assert.AreEqual("Equilateral Triangle", result);

        }
        [TestMethod]
        public void GetTriangleFromDatabaseShouldReturnNotTriangle()
        {
            var queryable = new List<Triangle>
                                {
                                    new Triangle { SideA = 1, SideB = 2, SideC = 3, TriangleType = "Not Triangle" }
                                };
            mock.Setup(x => x.FindBy(It.IsAny<Expression<Func<Triangle, bool>>>())).Returns(queryable.AsQueryable());
            var triangleBusiness = new TriangleBusinessImpl(mock.Object);

            var result = triangleBusiness.CheckTriangle(1, 2, 3);
            Assert.AreEqual("Not Triangle", result);

        }
        [TestMethod]
        public void GetTriangleFromDatabaseShouldReturnNormalTriangle()
        {
            var queryable = new List<Triangle>
                                {
                                    new Triangle { SideA = 2, SideB = 3, SideC = 4, TriangleType = "Normal Triangle" }
                                };
            mock.Setup(x => x.FindBy(It.IsAny<Expression<Func<Triangle, bool>>>())).Returns(queryable.AsQueryable());
            var triangleBusiness = new TriangleBusinessImpl(mock.Object);

            var result = triangleBusiness.CheckTriangle(2, 3, 4);
            Assert.AreEqual("Normal Triangle", result);

        }
        [TestMethod]
        public void GetTriangleFromDatabaseShouldReturnIsoscelesTriangle()
        {
            var queryable = new List<Triangle>
                                {
                                    new Triangle { SideA = 2, SideB = 2, SideC = 3, TriangleType = "Isosceles Triangle" }
                                };
            mock.Setup(x => x.FindBy(It.IsAny<Expression<Func<Triangle, bool>>>())).Returns(queryable.AsQueryable());
            var triangleBusiness = new TriangleBusinessImpl(mock.Object);

            var result = triangleBusiness.CheckTriangle(2, 2, 3);
            Assert.AreEqual("Isosceles Triangle", result);

        }
        [TestMethod]
        public void GetTriangleFromDatabaseShouldReturnRectangledTriangle()
        {
            var queryable = new List<Triangle>
                                {
                                    new Triangle { SideA = 3, SideB = 4, SideC = 5, TriangleType = "Rectangled Triangle" }
                                };
            mock.Setup(x => x.FindBy(It.IsAny<Expression<Func<Triangle, bool>>>())).Returns(queryable.AsQueryable());
            var triangleBusiness = new TriangleBusinessImpl(mock.Object);

            var result = triangleBusiness.CheckTriangle(3, 4, 5);
            Assert.AreEqual("Rectangled Triangle", result);

        }
        [TestMethod]
        public void GetTriangleFromDatabaseShouldReturnEquilateralTriangle()
        {
            var queryable = new List<Triangle>
                                {
                                    new Triangle { SideA = 1, SideB = 1, SideC = 1, TriangleType = "Equilateral Triangle" }
                                };
            mock.Setup(x => x.FindBy(It.IsAny<Expression<Func<Triangle, bool>>>())).Returns(queryable.AsQueryable());
            var triangleBusiness = new TriangleBusinessImpl(mock.Object);

            var result = triangleBusiness.CheckTriangle(1, 1, 1);
            Assert.AreEqual("Equilateral Triangle", result);

        }
    }
}
