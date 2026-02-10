using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyContentSite.ArticleService;

public interface IArticleService
{
    IEnumerable<Article> SearchArticles(string searchTerm);
}
