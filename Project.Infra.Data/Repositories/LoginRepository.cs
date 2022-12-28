using Project.Domain.Entities;
using Project.Domain.Repositories;
using Project.Infra.Data.Context;

namespace Project.Infra.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ProjectContext _context;

        public LoginRepository(ProjectContext context)
        {
            _context = context;
        }

        public bool LoginUser(string email, string password)
        {
            var result = _context.Users.Where(x => x.Email == email && x.Password == password);

            return result.Any();
        }
    }
}
