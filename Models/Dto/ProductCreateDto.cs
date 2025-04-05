using MimeKit.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Web.Models.Dto
{
    public class ProductCreateDto
    {
        [MaxLength(60)]
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public Guid B3Id { get; set; }
        [Required]
        [Column(TypeName = "decimal(15,0)")]
        public Decimal ZIBAIKA { get; set; }
        [Required]
        [Column(TypeName = "decimal(15,0)")]
        public Decimal ZOBAIKA { get; set; }
        [Required]
        public List<IFormFile> ListUrlImage { get; set; }
        /*public IFormFile ListUrlImage { get; set; }*/
    }
}
