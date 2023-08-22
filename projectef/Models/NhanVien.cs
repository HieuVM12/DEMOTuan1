using System.ComponentModel.DataAnnotations;

namespace projectef.Models
{
    public class NhanVien
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
