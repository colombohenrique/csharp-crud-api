using RestAPI.Domain.Entities;
using System.Data.Entity;

namespace RestAPI.Infra.Data.Context
{
    public class RestAPIContext : DbContext 
    {
        public RestAPIContext()
            :base("Conexao") { }
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

}
}
