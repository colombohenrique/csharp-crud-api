using RestAPI.Domain.Validations;
using System.Reflection.Metadata;

namespace RestAPI.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }


        public Product(string name, string codErp, decimal price) 
        {
            Validation(name, codErp, price);
        }

        public Product(int id, string name, string codErp, decimal price) 
        {
            DomainValidationException.When(id < 0, "ID produto Inválido!");
            Id = id;

            Validation(name, codErp, price);
        }

        private void Validation(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome não pode ser vazio!");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "Código ERP não pode ser vazio!");
            DomainValidationException.When(price < 0, "O produto deve ter um preço!");

            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}
