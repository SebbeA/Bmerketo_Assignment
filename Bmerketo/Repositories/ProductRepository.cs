using Bmerketo.Contexts;
using Bmerketo.Models.Entities;

namespace Bmerketo.Repositories;

public class ProductRepository : RepositoryDataContext<ProductEntity>
{
    public ProductRepository(DataContext context) : base(context)
    {
    }
}
