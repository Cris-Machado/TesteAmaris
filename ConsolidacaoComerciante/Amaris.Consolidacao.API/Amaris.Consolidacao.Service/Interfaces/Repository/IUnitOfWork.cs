namespace Amaris.Consolidacao.Service.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task<int> SaveChangesAsync();
    }
}
