using Java.Nio.Channels;
using System;
using System.Linq;
using Xamarin.Forms;


namespace HomeApp2.Views
{
    public partial class LoginPage : ContentPage
    {
        // Константа для текста кнопки
        public const string BUTTON_TEXT = "Войти";
        // Переменная счетчика
        public static int loginCouner = 0;

        // Создаем объект, возвращающий свойства устройства
        IDeviceDetector detector = DependencyService.Get<IDeviceDetector>();

        public LoginPage()
        {
            InitializeComponent();

            // Изменяем внешний вид кнопки для Desktop-версии
            if (Device.Idiom == TargetIdiom.Desktop)
                loginButton.CornerRadius = 0;

            // Передаем информацию о платформе на экран
            runningDevice.Text = detector.GetDevice();
        }

        /// <summary>
        /// По клику обрабатываем счётчик и выводим разные сообщения
        /// </summary>
        private void Login_Click(object sender, EventArgs e)
        {
            if (loginCouner == 0)
            {
                loginButton.Text = $"Выполняется вход..";
            }
            else if (loginCouner > 5)
            {
                loginButton.IsEnabled = false;

                // Получаем последний дочерний элемент, используя свойство Children, затем выполняем распаковку
                var infoMessage = (Label)stackLayout.Children.Last();
                // Задаем текст элемента
                infoMessage.Text = "Слишком много попыток! Попробуйте позже";

            }
            else
            {
                loginButton.Text = $"Выполняется вход...   Попыток входа: {loginCouner}";
            }

            loginCouner += 1;
        }
    }
}