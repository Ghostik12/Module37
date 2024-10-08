﻿using HomeApp2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceListPage : ContentPage
    {
        public ObservableCollection<Group<string, HomeDevice>> DeviceGroups { get; set; } = new ObservableCollection<Group<string, HomeDevice>>();
        HomeDevice SelectedDevice;

        public DeviceListPage()
        {
            InitializeComponent();

            // Первоначальные данные сохраним в обычном листе
            var initialList = new List<HomeDevice>();
            initialList.Add(new HomeDevice("Чайник", "Chainik.png", "LG, объем 2л.", "Кухня"));
            initialList.Add(new HomeDevice("Стиральная машина", "StiralnayaMashina.png", description: "BOSCH", "Ванная"));
            initialList.Add(new HomeDevice("Посудомоечная машина", "PosudomoechnayaMashina.png", "Gorenje", "Кухня"));
            initialList.Add(new HomeDevice("Мультиварка", "Multivarka.png", "Philips", "Кухня"));

            // Сгруппируем по комнатам
            var devicesByRooms = initialList.GroupBy(d => d.Room).Select(g => new Group<string, HomeDevice>(g.Key, g));

            // Сохраним
            DeviceGroups = new ObservableCollection<Group<string, HomeDevice>>(devicesByRooms);
            BindingContext = this;
        }

        /// <summary>
        /// Обработчик нажатия
        /// </summary>
        private void deviceList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // распаковка модели из объекта
            var tappedDevice = (HomeDevice)e.Item;
            // уведомление
            DisplayAlert("Нажатие", $"Вы нажали на элемент {tappedDevice.Name}", "OK"); ; ;
        }

        /// <summary>
        /// Обработчик выбора
        /// </summary>
        private void deviceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedDevice = (HomeDevice)e.SelectedItem;
        }

        /// <summary>
        /// Обработчик добавления нового устройства
        /// </summary>
        private async void AddDevice(object sender, EventArgs e)
        {
            // Запрос и валидация имени устройства
            var newDeviceName = await DisplayPromptAsync("Новое устройство", "Введите имя устройства", "Продолжить", "Отмена");
            if (DeviceGroups.Any(d => d.Name.CompareTo(newDeviceName.Trim()) == 0))
            {
                await DisplayAlert("Ошибка", $"Устройство '{newDeviceName}' уже существует", "ОК");
                return;
            }

            //// Запрос описания устройства
            //var newDeviceDescription = await DisplayPromptAsync(newDeviceName, "Добавьте краткое описание устройства", "Сохранить", "Отмена");

            //// Добавление устройства и уведомление пользователя
            //Devices.Add(new HomeDevice(newDeviceName, description: newDeviceDescription));
            //await DisplayAlert(null, $"Устройство '{newDeviceName}' успешно добавлено", "ОК");
        }

        /// <summary>
        /// Обработчик удаления устройства
        /// </summary>
        private async void RemoveDevice(object sender, EventArgs e)
        {
            // Получаем и "распаковываем" выбранный элемент
            //var deviceToRemove = deviceList.SelectedItem as HomeDevice;
            //if (deviceToRemove != null)
            //{
            //    // Удаляем
            //    Devices.Remove(deviceToRemove);
            //    // Уведомляем пользователя
            //    await DisplayAlert(null, $"Устройство '{deviceToRemove.Name}' удалено", "ОК");
            //}
        }

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            // Возврат на первую страницу стека навигации (корневую страницу приложения) - экран логина
            await Navigation.PopAsync();
        }

        private async void NewDeviceButton_Clicked(object sender, EventArgs e)
        {
            // Переход на следующую страницу - страницу нового устройства (и помещение её в стек навигации)
            await Navigation.PushAsync(new NewDevicePage());
        }

        private async void EditDeviceButton_Clicked(object sender, EventArgs e)
        {
            // проверяем, выбрал ли пользователь устройство из списка
            if (SelectedDevice == null)
            {
                await DisplayAlert(null, $"Пожалуйста, выберите устройство!", "OK");
                return;
            }

            // Переход на следующую страницу - страницу нового устройства (и помещение её в стек навигации)
            await Navigation.PushAsync(new DevicesPage("Изменить устройство", SelectedDevice));
        }

    }
}