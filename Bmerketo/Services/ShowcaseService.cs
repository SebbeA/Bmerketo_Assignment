using Bmerketo.Models;

namespace Bmerketo.Services;

public class ShowcaseService
{
    private readonly List<ShowcaseModel> _showcases = new() 
    {
        new ShowcaseModel() 
        {
            Ingress = "WELCOME TO BMERKETO SHOP",
            Title = "Exclusive Chair gold Collection",
            LinkContent = "SHOP NOW",
            LinkUrl = "/products",
            ImageUrl = "images/placeholders/625x647.svg"
        }
    };

    public ShowcaseModel GetLatest()
    {
        return _showcases.LastOrDefault()!;
    }
}
