using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IProcessorService
    {
        Task<IEnumerable<ProcessorDto>> GetAllProcessorsAsync(bool trackChanges);
        Task<ProcessorDto> GetProcessorAsync(int id, bool trackChanges);
    }
}
