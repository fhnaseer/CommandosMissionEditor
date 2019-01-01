using System;
using System.Collections.ObjectModel;
using Commandos.Model.Characters.Commandos;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class AddCommandoViewModel : AddItemViewModelBase<Commando>
    {
        public AddCommandoViewModel(Mission mission) : base(mission)
        {
        }

        internal AddCommandoViewModel() : base(null) { }

        public override string TabName => "Commandos";

        public override ObservableCollection<Commando> ItemCollection => Mission.World.MissionObjects.Commandos;

        private ObservableCollection<Commando> _commandos;
        public ObservableCollection<Commando> Commandos => _commandos ?? (_commandos = new ObservableCollection<Commando>
        {
            new GreenBeret(),
            new Sniper(),
            new Marine(),
            new Sapper(),
            new Driver(),
            new Spy(),
            new Natasha(),
            new Thief()
        });

        private Commando _selectedCommando;
        public Commando SelectedCommando
        {
            get => _selectedCommando;
            set
            {
                _selectedCommando = value;
                OnPropertyChanged(nameof(SelectedCommando));
            }
        }

        internal override void AddItem()
        {
            var commando = Activator.CreateInstance(SelectedCommando.GetType()) as Commando;
            ItemCollection.Add(commando);
            SelectedItem = commando;
        }
    }
}
