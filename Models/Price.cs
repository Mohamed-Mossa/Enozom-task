using System.Diagnostics.Metrics;

namespace Enozom_task.Models
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public string Room { get; set; }


        [ForeignKey("Hotels")]
        public int HotelID { get; set; }
        public virtual Hotel Hotel { get; set; }
     



    }
}
