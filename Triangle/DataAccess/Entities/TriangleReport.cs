using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    
    public class TriangleReport
    {
        public string TriangleType { get; set; }
        public int Amount { get; set; }
    }
}
