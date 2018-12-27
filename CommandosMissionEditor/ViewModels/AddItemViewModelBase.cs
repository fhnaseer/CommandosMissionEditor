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

        private T _currentItem;
        public T CurrentItem
        {
            get => _currentItem;
            set
            {
                _currentItem = value;
                OnPropertyChanged(nameof(CurrentItem));
            }
        }

        private ICommand _removeSelectedItemCommand;
        public ICommand RemoveSelectedItemCommand => _removeSelectedItemCommand ?? (_removeSelectedItemCommand = new RelayCommand(RemoveSelectedItem, CanRemoveSelectedItem));

        internal bool CanRemoveSelectedItem() { return SelectedItem != null; }

        internal void RemoveSelectedItem()
        {
            ItemCollection.Remove(SelectedItem);
            SelectedItem = default(T);
        }

        private ICommand _editSelectedItemCommand;
        public ICommand EditSelectedItemCommand => _editSelectedItemCommand ?? (_editSelectedItemCommand = new RelayCommand(EditSelectedItem, CanRemoveSelectedItem));

        internal void EditSelectedItem()
        {
            CurrentItem = SelectedItem;
        }

        private ICommand _addItemCommand;
        public ICommand AddItemCommand => _addItemCommand ?? (_addItemCommand = new RelayCommand(AddItem, () => !ReferenceEquals(SelectedItem, CurrentItem)));

        internal void AddItem()
        {
            ItemCollection.Add(CurrentItem);
            CurrentItem = new T();
        }

        private ICommand _clearItemCommand;
        public ICommand ClearItemCommand => _clearItemCommand ?? (_clearItemCommand = new RelayCommand(ClearItem));

        internal void ClearItem()
        {
            CurrentItem = new T();
        }
    }
}
