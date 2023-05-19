using Bmerketo.Contexts;
using Bmerketo.Models.Entities;

namespace Bmerketo.Repositories;

public class AddressRepository : RepositoryIdentityContext<AddressEntity>
{
    public AddressRepository(IdentityContext context) : base(context)
    {
    }
}
