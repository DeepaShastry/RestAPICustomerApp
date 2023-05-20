using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace epayCustomerApp
{
    public class Customer: IValidatableObject
    {
        //Using the required attribute to validate all the required fields.
        [Required]
        public string? lastname { get; set; }
        [Required]
        public string? firstname { get; set; } 

        [Required]
        public int age { get; set; }

        [Required]
        public int id { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //This method is used to validate if the age provied is above 18.
            if(age < 18)
            {
                yield return new ValidationResult("Minimum age required is 18");
            }
        }
    }

    
}
