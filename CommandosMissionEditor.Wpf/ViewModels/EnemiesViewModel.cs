using System.Collections.Generic;
using CommandosMissionEditor.Helpers;

namespace CommandosMissionEditor.ViewModels
{
    public class EnemiesViewModel : TabsViewModelBase
    {
        public override string TabName => "Enemies";

        public override IList<ViewModelBase> GetViewModelCollection()
        {
            return new List<ViewModelBase>{
                new AddEnemySoldierViewModel(),
                new AddEnemyPatrolViewModel(),
                new AddEnemyRouteViewModel(),
                new AddEnemyActionViewModel()
            };
        }
    }
}
