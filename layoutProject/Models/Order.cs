using System.ComponentModel.DataAnnotations;

namespace layoutProject.Models
{
    public class Order
    {
        [Required(ErrorMessage = "Order Id cannot be Empty ")]
        [RegularExpression("[0-9]{4}", ErrorMessage = "ID have to be 4 digits")]
        public int OrderId { get; set; }
        [Required]
        [RegularExpression("[A-Z]{2}[0-9]{3,5}", ErrorMessage = "OrderKey has to be AA123 format ")]
        public required string OrderKey { get; set; }
        [Required]
        //[RegularExpression(@"(00962){1}(78|77|79){1}[0-9]{7}", ErrorMessage = "Phone format should comply with 00962780055124")]
        [RegularExpression(@"(078|077|079){1}[-][0-9]{4}[-]{1}[0-9]{3}", ErrorMessage = "Phone format should comply with 078/0055124")]
        
        public required string Phone { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        [RegularExpression(@"[A-Za-z0-9]{1,100}[@]{1}[a-z]{2,9}[.]{1}[a-z]{3,5}", ErrorMessage = "Email format should comply with Example@info.com")]
        public required string Email { get; set; }
        [DataType(DataType.Currency)]
        public required string Payment { get; set; }
        [Range(1, 5)]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool Packaging { get; set; }
        public bool Tracking { get; set; }
        public required string Location { get; set; }
        [MaxLength(100)]
        public required string Address { get; set; }
       



    }
}
