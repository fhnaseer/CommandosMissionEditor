using System.Collections.Generic;
using CommandosMissionEditor.Helpers;

namespace CommandosMissionEditor.ViewModels
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
