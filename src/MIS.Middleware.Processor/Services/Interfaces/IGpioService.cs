using System.Threading.Tasks;
using JetBrains.Annotations;

namespace MIS.Middleware.Processor.Services.Interfaces;

[PublicAPI]
public interface IGpioService
{
    Task Initialize();
    Task SayHello();
    Task SwitchSolenoidOn();
    Task SwitchSolenoidOff();
    Task<bool> IsSolenoidOn();
    Task Shutdown();
}