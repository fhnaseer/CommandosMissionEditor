using System.Collections.ObjectModel;
using System.Windows.Input;
using CommandosMissionEditor.Universal.Helpers;

namespace CommandosMissionEditor.Universal.ViewModels
{
    public abstract class AddItemViewModelBase<T> : ViewModelBase where T : new()
    {
        public AddItemViewModelBase()
        {
        }

        public abstract ObservableCollection<T> ItemCollection { get; }

        private T _selectedItem;
        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                Set(ref _selectedItem, value);
                OnSelectedItemChanged();
            }
        }

        public virtual void OnSelectedItemChanged() { }

        private T _defaultItem;
        public T DefaultItem
        {
            get => _defaultItem;
            set
            {
                Set(ref _defaultItem, value);
                OnDefaultItemChanged();
            }
        }

        public virtual void LoadDefaultItem() { }
        public virtual void OnDefaultItemChanged() { }

        private ICommand _removeSelectedItemCommand;
        public ICommand RemoveSelectedItemCommand => _removeSelectedItemCommand ?? (_removeSelectedItemCommand = new RelayCommand(RemoveSelectedItem));

        internal void RemoveSelectedItem()
        {
            if (SelectedItem == null) return;
            ItemCollection.Remove(SelectedItem);
            SelectedItem = default(T);
        }

        private ICommand _addItemCommand;
        public ICommand AddItemCommand => _addItemCommand ?? (_addItemCommand = new RelayCommand(AddItem));

        internal virtual void AddItem()
        {
            var item = new T();
            ItemCollection.Add(item);
            SelectedItem = item;
        }
    }
}
