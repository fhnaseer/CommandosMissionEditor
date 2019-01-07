using System.Collections.Generic;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public abstract class MissionCollectionViewModelBase : MissionViewModelBase
    {
        public MissionCollectionViewModelBase(Mission mission) : base(mission)
        {
        }

        public abstract IList<MissionViewModelBase> GetViewModelCollection();

        private List<MissionViewModelBase> _viewModels;
        public IList<MissionViewModelBase> ViewModels => _viewModels ?? (_viewModels = new List<MissionViewModelBase>(GetViewModelCollection()));
    }
}
