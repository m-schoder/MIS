using System.Threading.Tasks;

namespace MIS.Backend.PiModules.Interfaces
{
    public interface IConfigurationProxy
    {
        Task<string> GetString(string name);

        Task<int> GetInt32(string name);
    }
}