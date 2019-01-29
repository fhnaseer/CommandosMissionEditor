using System.Collections.ObjectModel;
using System.Linq;

namespace CommandosMissionEditor.Helpers
{
    public abstract class AddItemViewModelBase<T> : ViewModelBase where T : new()
    {
        public abstract ObservableCollection<T> ItemCollection { get; }

        public bool EditingEnabled => SelectedItem != null;

        private T _selectedItem;
        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                Set(ref _selectedItem, value);
                OnPropertyChanged(nameof(EditingEnabled));
                RemoveSelectedItemCommand.RaiseCanExecuteChanged();
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

        private RelayCommand _removeSelectedItemCommand;
        public RelayCommand RemoveSelectedItemCommand => _removeSelectedItemCommand ?? (_removeSelectedItemCommand = new RelayCommand(RemoveSelectedItem, CanRemoveItem));

        protected virtual bool CanRemoveItem()
        {
            return EditingEnabled;
        }

        internal void RemoveSelectedItem()
        {
            if (SelectedItem == null) return;
            ItemCollection.Remove(SelectedItem);
            SelectedItem = ItemCollection.FirstOrDefault();
        }

        private RelayCommand _addItemCommand;
        public RelayCommand AddItemCommand => _addItemCommand ?? (_addItemCommand = new RelayCommand(AddItem, CanAddItem));

        protected virtual bool CanAddItem()
        {
            return true;
        }

        protected virtual void AddItem()
        {
            var item = new T();
            ItemCollection.Add(item);
            SelectedItem = item;
        }
    }
}
