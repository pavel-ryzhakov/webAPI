using Domain.Entities;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace Persistence.Repositories.Extensions
{
    public static class RepositoryProductExtensions
    {
        public static IQueryable<GraphicCard> FilterProduct(this IQueryable<GraphicCard> graphicCards, uint minPrice, uint maxPrice) =>
            graphicCards.Where(e => (e.Price >= minPrice && e.Price <= maxPrice));
        public static IQueryable<GraphicCard> Search(this IQueryable<GraphicCard> graphicCards,
            string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return graphicCards;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return graphicCards.Where(e => e.GpuName.ToLower().Contains(lowerCaseTerm));
        }
        public static IQueryable<GraphicCard> Sort(this IQueryable<GraphicCard> graphicCards, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return graphicCards.OrderBy(e => e.Price);
            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(GraphicCard).GetProperties(BindingFlags.Public | BindingFlags.Instance); 
            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
                var propertyFromQueryModel = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi =>
                pi.Name.Equals(propertyFromQueryModel, StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null)
                    continue;
                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return graphicCards.OrderBy(e => e.Power);
            return graphicCards.OrderBy(orderQuery);
        }
    }
}
