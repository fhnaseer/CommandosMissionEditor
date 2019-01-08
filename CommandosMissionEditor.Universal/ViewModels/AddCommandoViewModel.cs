using System;
using System.Collections.ObjectModel;
using Commandos.Model.Characters.Commandos;

namespace CommandosMissionEditor.Universal.ViewModels
{
    public class AddCommandoViewModel : AddItemViewModelBase<Commando>
    {
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
            set => Set(ref _selectedCommando, value);
        }

        internal override void AddItem()
        {
            var commando = Activator.CreateInstance(SelectedCommando.GetType()) as Commando;
            ItemCollection.Add(commando);
            SelectedItem = commando;
        }
    }
}
