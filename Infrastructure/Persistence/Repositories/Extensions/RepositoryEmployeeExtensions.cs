using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
