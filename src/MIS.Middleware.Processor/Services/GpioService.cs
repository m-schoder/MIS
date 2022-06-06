using System.Device.Gpio;
using System.Threading;
using System.Threading.Tasks;
using MIS.Middleware.Processor.Controllers.Interfaces;
using MIS.Middleware.Processor.Services.Interfaces;

namespace MIS.Middleware.Processor.Services;

public class GpioService : IGpioService
{
    private readonly SemaphoreSlim _semaphore = new(1, 1);
    private readonly IGpioController _gpioController;
    private const int PIN = 17;
    private bool _initialized;

    public GpioService(IGpioController gpioController)
    {
        _gpioController = gpioController;
    }

    public async Task Initialize()
    {
        try
        {
            await _semaphore.WaitAsync();
            if (!_initialized)
            {
                _gpioController.OpenPin(PIN, PinMode.Output);
                _initialized = true;
            }
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task SayHello()
    {
        int i = 0;
        while (i <= 3)
        {
            await Write(PIN, PinValue.High);
            await Task.Delay(250);
            await Write(PIN, PinValue.Low);
            await Task.Delay(250);
            i++;
        }
    }

    public Task SwitchSolenoidOn()
    {
        return Write(PIN, PinValue.High);
    }

    public Task SwitchSolenoidOff()
    {
        return Write(PIN, PinValue.Low);
    }

    public Task<bool> IsSolenoidOn()
    {
        return Read(PIN);
    }

    public async Task Shutdown()
    {
        try
        {
            await _semaphore.WaitAsync();
            if (_initialized)
            {
                _gpioController.ClosePin(PIN);
                _initialized = false;
            }
        }
        finally
        {
            _semaphore.Release();
        }
    }

    private async Task Write(int pinNumber, PinValue value)
    {
        try
        {
            await _semaphore.WaitAsync();
            if (_initialized)
            {
                _gpioController.Write(pinNumber, value);
            }
        }
        finally
        {
            _semaphore.Release();
        }
    }

    private async Task<bool> Read(int pinNumber)
    {
        try
        {
            await _semaphore.WaitAsync();
            if (_initialized)
            {
                return _gpioController.Read(pinNumber) == PinValue.High;
            }
            return false;
        }
        finally
        {
            _semaphore.Release();
        }
    }
}