using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALStudent.Entities
{
    public class Student
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Student Name")]
        public string? Name { get; set; }
        [Required]
        [DisplayName("Student Class")]
        [Range(1, 12)]
        public int Class { get; set; }
        [Required]
        [DisplayName("Student Grade")]
        [Range(0, 100)]
        public int Grade { get; set; }
        [Required]
        [DisplayName("Student Address")]
        public string? Address { get; set; }
    }
}
