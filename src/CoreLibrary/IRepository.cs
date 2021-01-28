using System.Threading.Tasks;

namespace CoreLibrary
{
    public interface IRepository<T> where T : class
    {
        public Task<T> ReadAsync();
        public Task WriterAsync(T saveObject);
    }
}
