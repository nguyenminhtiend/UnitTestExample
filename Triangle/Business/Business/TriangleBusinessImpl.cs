using DataAccess.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    using global::Business.MyException;

    public class TriangleBusinessImpl : ITriangleBusiness
    {
        private const string NotTriangle = "Not Triangle";
        private const string NormalTriangle = "Normal Triangle";
        private const string IsoscelesTriangle = "Isosceles Triangle";
        private const string RectangledTriangle = "Rectangled Triangle";
        private const string EquilateralTriangle = "Equilateral Triangle";

        private readonly IGenericRepository<Triangle> genericRepository;
        public TriangleBusinessImpl(IGenericRepository<Triangle> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public string CheckTriangle(int sideA, int sideB, int sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new InvalidInputException();
            }
            var triangle = GetTriangleBySide(sideA, sideB, sideC);
            if (triangle != null)
            {
                return triangle.TriangleType;
            }
           
            var triangleType = !IsTriangle(sideA, sideB, sideC) ? NotTriangle : NormalTriangle;
            
            //Check a triangle whether is isosceles or not
            if (sideA == sideB || sideB == sideC || sideA == sideC)
            {
                triangleType = IsoscelesTriangle;
            }

            //Check a triangle where is rectangled or not
            if (sideA * sideA + sideB * sideB == sideC * sideC
                || sideA * sideA + sideC * sideC == sideB * sideB
                || sideC * sideB + sideC * sideC == sideA * sideA)
            {
                triangleType = RectangledTriangle;
            }

            //Check a trianle where is equilateral         
            if (sideA == sideB && sideB == sideC)
            {
                triangleType = EquilateralTriangle;
            }
            this.SaveTriangle(sideA, sideB, sideC, triangleType);
            return triangleType;
        }

        private void SaveTriangle(int sideA, int sideB, int sideC, string triangleType)
        {
            this.genericRepository.Add(new Triangle { SideA = sideA, SideB = sideB, SideC = sideC, TriangleType = triangleType });
            this.genericRepository.SaveChange();
        }

        //Check Triangle or not
        private static bool IsTriangle(int sideA, int sideB, int sideC)
        {
            return ((sideA + sideB) > sideC && (sideA + sideC) > sideB && (sideB + sideC) > sideA);
        }

        //Get Triangle by 3 sides
        private Triangle GetTriangleBySide(int sideA, int sideB, int sideC)
        {
            return
                genericRepository.FindBy(
                    x => (x.SideA == sideA && x.SideB == sideB && x.SideC == sideC)
                    || (x.SideA == sideB && x.SideB == sideC && x.SideC == sideA)
                    || (x.SideA == sideC && x.SideB == sideA && x.SideC == sideB)
                    || (x.SideA == sideA && x.SideB == sideC && x.SideC == sideB)
                    || (x.SideB == sideB && x.SideA == sideC && x.SideC == sideA)
                    || (x.SideC == sideC && x.SideB == sideA && x.SideA == sideB))
                    .FirstOrDefault();
        }
    }
}
