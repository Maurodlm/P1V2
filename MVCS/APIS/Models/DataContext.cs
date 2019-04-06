using System.Data.Entity;

namespace APIS.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<APIS.Models.Sell> Sells { get; set; }
    }
}