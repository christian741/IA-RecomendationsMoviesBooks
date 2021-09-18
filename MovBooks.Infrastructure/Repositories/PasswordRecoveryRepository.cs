using Microsoft.EntityFrameworkCore;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MovBooks.Infrastructure.Repositories
{
    public class PasswordRecoveryRepository : BaseRepository<PasswordRecovery>, IPasswordRecoveryRepository
    {
        public PasswordRecoveryRepository(MovBooksContext context) : base(context)
        {
        }

        public async Task<PasswordRecovery> FindByToken(string token)
        {
            var passwordRecovery = await _entities
                            .FirstOrDefaultAsync(x => x.Token == token);
            return passwordRecovery;
        }

        public async Task DeleteRange(string email)
        {
            // Eliminar los anteriores registros del email, para no acumular basura sino tener el último nada más
            var recordsToDelete = await _entities
                                    .Where(x => x.Email == email).ToListAsync();
            _entities.RemoveRange(recordsToDelete);
        }
    }
}
