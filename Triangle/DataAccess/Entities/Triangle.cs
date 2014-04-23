using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    [Table("Triangle")]
    public class Triangle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SideA { get; set; }
        [Required]
        public int SideB { get; set; }
        [Required]
        public int SideC { get; set; }
        [Required]
        public string TriangleType { get; set; }
    }
}
