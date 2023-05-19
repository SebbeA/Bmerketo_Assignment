using Bmerketo.Contexts;
using Bmerketo.Models.Entities;

namespace Bmerketo.Repositories;

public class ProductTagRepository : RepositoryDataContext<ProductTagEntity>
{
    public ProductTagRepository(DataContext context) : base(context)
    {
    }
}
