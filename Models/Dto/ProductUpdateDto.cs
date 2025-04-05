using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Web.Models.Dto
{
    public class ProductUpdateDto
    {
        public Guid Id { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        public Guid B3Id { get; set; }

        [Column(TypeName = "decimal(15,0)")]
        public Decimal ZIBAIKA { get; set; }
        [Column(TypeName = "decimal(15,0)")]
        public Decimal ZOBAIKA { get; set; }
        public List<string> ListUrlImage { get; set; }
        public List<IFormFile>? NewImages { get; set; }
        public List<IFormFile>? ReplaceImages { get; set; }
        public List<int>? ReplaceImageIndexes { get; set; }
        public List<bool>? RemoveImageIndexes { get; set; }
    }
}
