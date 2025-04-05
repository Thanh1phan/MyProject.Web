using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Web.Models.Dto
{
    public class InfoProductDto
    {
        public Guid M01CId { get; set; }
        public string Name { get; set; }
        public string B3Name { get; set; }
        [Column(TypeName = "decimal(10,0)")]
        public decimal ZOBAIKA { get; set; }

        [Column(TypeName = "decimal(10,0)")]
        public decimal ZIBAIKA { get; set; }
        public IEnumerable<string> ListUrlImage { get; set; }
    }
}
