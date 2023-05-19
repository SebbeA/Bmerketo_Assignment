using Bmerketo.Contexts;
using Bmerketo.Models.Entities;

namespace Bmerketo.Repositories;

public class UserAddressRepository : Repository<UserAddressEntity>
{
    public UserAddressRepository(IdentityContext context) : base(context)
    {
    }
}
