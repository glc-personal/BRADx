using Core;

namespace Camera;

public interface ICamera : IHardware
{
    void SnapImage();
}