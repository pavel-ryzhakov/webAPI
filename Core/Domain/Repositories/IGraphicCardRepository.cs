using Domain.Entities;
using Domain.RequestFeatures;

namespace Domain.Repositories
{
    public interface IGraphicCardRepository
    {
        Task<PagedList<GraphicCard>> GetAllGraphicCardsAsync(ProductParameters productParameters, bool trackChanges);
        Task<GraphicCard> GetGraphicCardAsync(int graphicCardId, bool trackChanges);
    }
}
