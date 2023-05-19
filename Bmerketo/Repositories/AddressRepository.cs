using Bmerketo.Contexts;
using Bmerketo.Models.Entities;

namespace Bmerketo.Repositories;

public class AddressRepository : Repository<AddressEntity>
{
    public AddressRepository(IdentityContext context) : base(context)
    {
    }
}
