using System.Device.Gpio;

namespace MIS.Middleware.Processor.Controllers.Interfaces;

public interface IGpioController
{
    void OpenPin(int pinNumber, PinMode mode);

    PinValue Read(int pinNumber);

    void Write(int pinNumber, PinValue value);

    void ClosePin(int pinNumber);
}