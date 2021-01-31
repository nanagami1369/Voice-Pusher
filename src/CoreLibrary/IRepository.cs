using System.Threading.Tasks;

namespace CoreLibrary
{
    public interface IRepository<T>
    {
        public Task<T> ReadAsync();
        public Task WriterAsync(T saveObject);
    }
}
