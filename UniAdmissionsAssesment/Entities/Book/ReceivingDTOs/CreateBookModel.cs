using System.ComponentModel.DataAnnotations;

namespace UniAdmissionsAssesment.Entities.ViewModels
{
    public class CreateBookModel
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]
        public string Author { get; set; }
    }
}
