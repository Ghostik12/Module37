using Android.OS;
using Xamarin.Forms;

[assembly: Dependency(typeof(HomeApp2.Droid.DeviceDetector))]
namespace HomeApp2.Droid
{
    public class DeviceDetector : IDeviceDetector
    {
        public string GetDevice()
        {
            // Сообщаем строку с информацией о платформе
            return $"Запущено на устройстве {Build.Product},{System.Environment.NewLine} платформа {Device.RuntimePlatform}";
        }
    }
}
