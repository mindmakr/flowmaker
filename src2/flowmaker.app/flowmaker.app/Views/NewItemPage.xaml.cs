using Xamarin.Forms;
using flowmaker.app.ViewModels;
using flowmaker.models;
using ContentPage = Xamarin.Forms.ContentPage;

namespace flowmaker.app.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Flow Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}