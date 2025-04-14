using System.ComponentModel.DataAnnotations;

namespace MyProject.Web.Models.Dto
{
    public class OrderCreateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }

        [RegularExpression(@"^(0?)(3[2-9]|5[6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])[0-9]{7}$",
        ErrorMessage = "Phone number invalid!")]
        public string PhoneNumber { get; set; }
        public Guid M01CId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than 0.")]
        public int Quantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Value must be greater than 0.")]
        public decimal UnitPrice { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Value must be greater than 0.")]
        public decimal TotalAmount { get; set; }
    }
}
