using Project.Domain.Validation;

namespace Project.Domain.Entities.Validations
{
    public class UserValidator : User
    {
        public UserValidator(string name, string nickname, string email, string password, string number)
        {
            Validation(name, nickname, email, password, number);
        }
        public UserValidator(int id, string name, string nickname, string email, string password, string number)
        {
            DomainValidationException.When(id < 0, "Id inválido");
            Id = id;
            Validation(name, nickname, email, password, number);
        }
        private void Validation(string name, string nickname, string email, string password, string number)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(nickname), "Apelido deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(email), "Email deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(password), "Senha deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(number), "Número deve ser informado.");

            Name = name;
            Nickname = nickname;
            Email = email;  
            Password = password;
            Number = number;
        }
    }
}
