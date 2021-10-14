using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Nmae { get; set; }
    }
}
