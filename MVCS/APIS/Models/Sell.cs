using System.ComponentModel.DataAnnotations;

namespace APIS.Models
{
    public enum OptionType
    {
        Car, //0
        Houses, //1
        Phones //2
    }
    public class Sell
    {
        [Key]

        public int SellId { get; set; } 

        [Required]
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        [Required]
        public OptionType Option  { get; set; }

    }
}