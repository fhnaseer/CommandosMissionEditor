using System.Collections.ObjectModel;
using System.Windows.Input;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public abstract class AddItemViewModelBase<T> : MissionViewModelBase where T : new()
    {
        public AddItemViewModelBase(Mission mission) : base(mission)
        {
        }

        public abstract ObservableCollection<T> ItemCollection { get; }

        private T _selectedItem;
        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private T _defaultItem;
        public T DefaultItem
        {
            get
            {
                if (_defaultItem == null)
                    LoadDefaultItem();
                return _defaultItem;
            }
            set
            {
                _defaultItem = value;
                UpdateDefaultItem();
                OnPropertyChanged(nameof(DefaultItem));
            }
        }

        public virtual void LoadDefaultItem() { }
        public virtual void UpdateDefaultItem() { }

        private ICommand _removeSelectedItemCommand;
        public ICommand RemoveSelectedItemCommand => _removeSelectedItemCommand ?? (_removeSelectedItemCommand = new RelayCommand(RemoveSelectedItem, CanRemoveSelectedItem));

        internal bool CanRemoveSelectedItem() { return SelectedItem != null; }

        internal void RemoveSelectedItem()
        {
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

        private ICommand _clearItemCommand;
        public ICommand ClearItemCommand => _clearItemCommand ?? (_clearItemCommand = new RelayCommand(ClearItem));

        public virtual void ClearItem() { }
    }
}
