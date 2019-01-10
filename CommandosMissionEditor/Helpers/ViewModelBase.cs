using System.ComponentModel;
using System.Runtime.CompilerServices;
using Commandos.Model.Map;

namespace CommandosMissionEditor.Helpers
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
                return;

            storage = value;
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public virtual string TabName { get; } = string.Empty;

        private static Mission _mission = new Mission();
        public Mission Mission
        {
            get => _mission;
            set => Set(ref _mission, value);
        }
    }
}
