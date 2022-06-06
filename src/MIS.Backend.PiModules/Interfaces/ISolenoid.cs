using System.Threading.Tasks;

namespace MIS.Backend.PiModules.Interfaces;

public interface ISolenoid
{
    Task SwitchOn();
    Task SwitchOff();
    Task<bool> GetState();
    Task<string> SayHello();
}