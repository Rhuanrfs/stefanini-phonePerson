
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IExampleFacade
    {
        Task<ExampleListResponse> FindAllAsync();
        Task<ExampleListResponse> FindID(int id);
    }
}
