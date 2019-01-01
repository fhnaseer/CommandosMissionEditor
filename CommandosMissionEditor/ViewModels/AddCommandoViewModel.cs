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
    }
}
