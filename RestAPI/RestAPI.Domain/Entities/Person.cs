using RestAPI.Domain.Validations;
using System.Runtime.CompilerServices;

namespace RestAPI.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Person(string document, string name, string phone) 
        {
            Validation(document, name, phone);  
        }

        public Person(int id, string document, string name, string phone) 
        {
            DomainValidationException.When(id < 0, "ID pessoa Inválido!");
            Id = id;

            Validation(document, name, phone);
        }

        private void Validation(string document, string name, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome não pode ser vazio!");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Documento não pode ser vazio!");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "O celular deve ser informado!");

            Name= name;
            Document= document;
            Phone= phone;
        }
    }
}
