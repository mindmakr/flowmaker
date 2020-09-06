using System;
using flowmaker.models;
using Xamarin.Forms;

namespace flowmaker.app.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string _name;
        private string _title;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_name)
                && !String.IsNullOrWhiteSpace(_title);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public new string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Flow newItem = new Flow()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Title = Title
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
