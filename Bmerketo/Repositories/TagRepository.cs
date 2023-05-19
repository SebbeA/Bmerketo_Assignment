using Bmerketo.Contexts;
using Bmerketo.Models.Entities;

namespace Bmerketo.Repositories;

public class TagRepository : RepositoryDataContext<TagEntity>
{
    public TagRepository(DataContext context) : base(context)
    {
    }
}
