using System.ComponentModel;
using Xamarin.Forms;
using flowmaker.app.ViewModels;

namespace flowmaker.app.Views
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