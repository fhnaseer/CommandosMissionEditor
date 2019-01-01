using System.Collections.Generic;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class CommandosViewModel : MissionCollectionViewModelBase
    {
        public CommandosViewModel(Mission mission) : base(mission)
        {
        }

        internal CommandosViewModel() : base(null) { }

        public override string TabName => "Commandos";

        public override IList<MissionViewModelBase> GetViewModelCollection()
        {
            return new List<MissionViewModelBase>{
                new AddCommandoViewModel(Mission),
            };
        }
    }
}
