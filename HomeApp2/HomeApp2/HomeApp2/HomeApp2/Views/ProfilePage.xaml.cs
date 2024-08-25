using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void NotifyUser(object sender, ToggledEventArgs e)
        {
            if (gasSwitch.On && climateSwitch.On && electroSwitch.On)
                DisplayAlert("Внимание!", "Пользователь получит полный доступ ко всем системам", "OK");
        }
    }
}