using System.ComponentModel.DataAnnotations;

namespace Class_Programmation.DAL.Models.Dtos
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage ="El nombre de la categoria es obligatorio")]
        public string name { get; set; }
    }
}
