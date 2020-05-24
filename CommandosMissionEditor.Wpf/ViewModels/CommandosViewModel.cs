using System.Collections.Generic;
using CommandosMissionEditor.Helpers;
using CommandosMissionEditor.ViewModels;

namespace CommandosMissionEditor.Wpf.ViewModels
{
    public class CommandosViewModel : TabsViewModelBase
    {
        public override string TabName => "Commandos";

        public override IList<ViewModelBase> GetViewModelCollection()
        {
            return new List<ViewModelBase>{
                new AddCommandoViewModel(),
            };
        }
    }
}
