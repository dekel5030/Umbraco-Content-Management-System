using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MyContentSite.ArticleService;
using MyContentSite.Models;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyContentSite.Controllers;

public class HomePageController : RenderController
{
    private readonly IArticleService _articleService;

    public HomePageController(
        ILogger<RenderController> logger,
        ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor,
        IArticleService articleService)
        : base(logger, compositeViewEngine, umbracoContextAccessor)
    {
        _articleService = articleService;
    }

    public override IActionResult Index()
    {
        if (CurrentPage is not HomePage homePage)
        {
            return NotFound();
        }

        string searchTerm = HttpContext.Request.Query["q"].ToString();

        PagedArticleResult searchResult = _articleService.SearchArticles(searchTerm);

        var viewModel = new HomePageViewModel(homePage)
        {
            SearchTerm = searchTerm,
            SearchResults = searchResult.Articles
        };

        return CurrentTemplate(viewModel);
    }
}