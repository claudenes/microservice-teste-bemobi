using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface ICentralRepository
    {
        Task<Arquivo> GetArquivo(string filename);
    }
}
