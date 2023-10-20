using Shared.DataTransferObjects;
using Domain.RequestFeatures;

namespace Service.Contracts
{
    public interface IGraphicCardService
    {
        Task<(IEnumerable<GraphicCardDto> graphicCards, MetaData metaData)> GetAllGraphicCardsAsync(ProductParameters productParameters, bool trackChanges);
        Task<GraphicCardDto> GetGraphicCardAsync(int graphicCardId, bool trackChanges);
    }
}
