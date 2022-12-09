using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasicCore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 25")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100 only!!")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        [DisplayName("Post Date")]
        public DateTime PostDate { get; set; } = DateTime.Now;
    }
    //public class Category
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    [Required]
    //    [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 25")]
    //    public string Name { get; set; }
    //    [DisplayName("Display Order")]
    //    [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100 only!!")]
    //    public int DisplayOrder { get; set; }
    //    public DateTime CreatedDatetime { get; set; } = DateTime.Now;
    //    [CreditCard(ErrorMessage = "Please enter a valid card No")]
    //    public string creditCard { get; set; }
    //    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid password")]
    //    public string NewPassword { get; set; }
    //    [Compare(otherProperty: "NewPassword", ErrorMessage = "New & confirm password does not match")]
    //    public string ConfirmPassword { get; set; }
    //    [EmailAddress(ErrorMessage = "Please enter a valid email")]
    //    public string EmailID { get; set; }
    //    [RegularExpression(pattern: "^Mr\\..*|^Mrs\\..*|^Ms\\..*|^Miss\\..*", ErrorMessage = "Name must start with Mr./Mrs./Ms./Miss.")]
    //    public string FullName { get; set; }
    //    [Url(ErrorMessage = "Please enter a valid URL")]
    //    public string Url { get; set; }
    //}
}
