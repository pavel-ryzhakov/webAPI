
using Domain.Entities;
using Domain.Repositories;
using Domain.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Extensions;

namespace Persistence.Repositories
{
    public class GraphicCardRepository : RepositoryBase<GraphicCard>, IGraphicCardRepository
    { 
        public GraphicCardRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<PagedList<GraphicCard>> GetAllGraphicCardsAsync(ProductParameters productParameters, bool trackChanges)
        {

            var count = await FindByCondition(e => e.Price >= productParameters.MinPrice && e.Price <= productParameters.MaxPrice,
                trackChanges)
                .FilterProduct(productParameters.MinPrice, productParameters.MaxPrice)
                .Search(productParameters.SearchTerm)
                .Sort(productParameters.OrderBy)
                .CountAsync();


            var graphicCards = await FindByCondition(e => e.Price >= productParameters.MinPrice && e.Price <= productParameters.MaxPrice,
                trackChanges)
                .FilterProduct(productParameters.MinPrice, productParameters.MaxPrice)
                .Search(productParameters.SearchTerm)
            //.OrderBy(c => c.Id)
            .Sort(productParameters.OrderBy)
            .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)           
            .Take(productParameters.PageSize)
            .ToListAsync();
            
            return new PagedList<GraphicCard> (graphicCards, count, productParameters.PageNumber, productParameters.PageSize);
            //return  PagedList<GraphicCard>.ToPagedList(graphicCards, productParameters.PageNumber, productParameters.PageSize);
                
        }
           
        public async Task<GraphicCard> GetGraphicCardAsync(int graphicCardId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(graphicCardId), trackChanges).SingleOrDefaultAsync();
    }
}
