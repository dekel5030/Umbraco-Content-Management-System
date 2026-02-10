using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyContentSite.Models;

public class HomePageViewModel
{
    public HomePage Page { get; set; }

    public string SearchTerm { get; set; } = string.Empty;
    public string SearchPlaceholder { get; set; }
    public IEnumerable<IPublishedContent> SearchResults { get; set; } = [];

    public HomePageViewModel(HomePage page)
    {
        Page = page;
        SearchPlaceholder = page.SearchPlaceholder ?? "חפש מאמרים...";
    }
}
