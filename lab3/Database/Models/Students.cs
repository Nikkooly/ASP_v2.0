using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public partial class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        public string Patronymic { get; set; }
        [Required]
        [StringLength(13)]
        public string Phone { get; set; }
    }
}
