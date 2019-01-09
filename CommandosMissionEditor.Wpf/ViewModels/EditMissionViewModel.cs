using System.Collections.Generic;
using CommandosMissionEditor.Helpers;

namespace CommandosMissionEditor.ViewModels
{
    public class EditMissionViewModel : TabsViewModelBase
    {
        public override string TabName => "Mission";

        public override IList<ViewModelBase> GetViewModelCollection()
        {
            return new List<ViewModelBase>{
                new LoadMissionViewModel(),
                new FilesViewModel(),
                new MusicViewModel(),
                new CameraViewModel(),
                new CommandosViewModel(),
                new EnemiesViewModel(),
                new SaveMissionViewModel()
            };
        }
    }
}
