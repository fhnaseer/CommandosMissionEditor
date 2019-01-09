using System.Collections.Generic;
using CommandosMissionEditor.Helpers;

namespace CommandosMissionEditor.ViewModels
{
    public abstract class TabsViewModelBase : ViewModelBase
    {
        private List<ViewModelBase> _viewModels;
        public IList<ViewModelBase> ViewModels => _viewModels ?? (_viewModels = new List<ViewModelBase>(GetViewModelCollection()));

        public abstract IList<ViewModelBase> GetViewModelCollection();
    }
}
