using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProcessorRepository
    {
        Task<IEnumerable<Processor>> GetAllProcessorsAsync(bool trackChanges);
        Task<Processor> GetProcessorAsync(int processorCardId, bool trackChanges);
    }
}
