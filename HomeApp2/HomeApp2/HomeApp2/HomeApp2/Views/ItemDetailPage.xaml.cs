using HomeApp2.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HomeApp2.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}