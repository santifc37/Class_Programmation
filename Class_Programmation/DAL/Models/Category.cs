using System.ComponentModel.DataAnnotations;

namespace Class_Programmation.DAL.Models
{
    public class Category : Auditbases
    {
        [Required]
        public string Name { get; set; }
    }
}
