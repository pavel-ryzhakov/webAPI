using Domain.Entities;
using Persistence.Repositories.Extensions.Utility;
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
                return graphicCards.OrderBy(e => e.Manufacture).ThenBy(o => o.Price); 
            var orderQuery = OrderQueryBuilder.CreateOrderQuery<GraphicCard>(orderByQueryString);
          
            if (string.IsNullOrWhiteSpace(orderQuery))
                return graphicCards.OrderBy(e => e.Manufacture).ThenBy(o => o.Price); 
            return graphicCards.OrderBy(orderQuery);
            
        }
    }
}
