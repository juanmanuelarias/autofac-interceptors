using System.Threading.Tasks;

namespace InterceptorsExample
{
    public interface IProcessorAsync
    {
        Task Process();
    }
}