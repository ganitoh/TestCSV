namespace TestCSV.Infrastructure.Services.Repositories.Abstracton
{
    public interface IRepository <TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);
    }
}
