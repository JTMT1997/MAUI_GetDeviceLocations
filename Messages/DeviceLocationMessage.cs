using CommunityToolkit.Mvvm.Messaging.Messages;
using GetDeviceLocation.Models;

namespace GetDeviceLocation.Messages;

class DeviceLocationMessage : ValueChangedMessage<DeviceLocation>
{
    public DeviceLocationMessage(DeviceLocation deviceLocation) : base(deviceLocation)
    {
    }
}
