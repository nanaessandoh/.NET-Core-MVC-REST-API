using System.ComponentModel.DataAnnotations;

namespace Commander.DTOs
{
    public class CommandUpdateDTO
    {
        // Id will be created Automatically so leave it out
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform {get; set;}
        
    }
    
}