using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace flowmaker.app.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private Guid itemId;
        private string _name;
        private string _title;
        public Guid Id { get; set; }

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

        public Guid ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(Guid itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Name = item.Name;
                Title = item.Title;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Flow");
            }
        }
    }
}
