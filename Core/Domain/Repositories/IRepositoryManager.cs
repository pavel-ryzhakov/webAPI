namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IGraphicCardRepository GraphicCard { get; }
        IProcessorRepository Processor { get; }
        Task SaveAsync();
    }
}
