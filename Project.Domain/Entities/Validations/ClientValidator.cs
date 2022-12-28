using Project.Domain.Validation;

namespace Project.Domain.Entities.Validations
{
    public class ClientValidator : Client
    {
        public ClientValidator(string enterprise, string name, string cnpj, string cep, string county, string district, string street, string number)
        {
            Validation(enterprise, name, cnpj, cep, county, district, street, number);
        }
        public ClientValidator(int id, string enterprise, string name, string cnpj, string cep, string county, string district, string street, string number)
        {
            DomainValidationException.When(id <= 0, "Id inválido");
            Id = id;
            Validation(enterprise, name, cnpj, cep, county, district, street, number);
        }

        private void Validation(string enterprise, string name, string cnpj, string cep, string county, string district, string street, string number)
        {
            DomainValidationException.When(string.IsNullOrEmpty(enterprise), "Empresa deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(cnpj), "CNPJ deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(cep), "CEP deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(county), "Cidade deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(district), "Bairro deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(street), "Rua deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(number), "Número deve ser informado.");

            Enterprise = enterprise;
            Name = name;
            CNPJ = cnpj;
            CEP = cep;
            County = county;
            District = district;
            Street = street;
            Number = number;
        }
    }
}
