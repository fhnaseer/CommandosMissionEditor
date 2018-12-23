using System.Collections.ObjectModel;
using Commandos.Model.Common;

namespace Commandos.Model.Characters.Enemies.Actions
{
    public class EnemyActions
    {
        public string ActionsName { get; set; }

        public string Speed { get; set; }

        public ActionRepeatType ActionRepeatType { get; set; }

        private ObservableCollection<EnemyAction> _actions;
        public ObservableCollection<EnemyAction> Actions => _actions ?? (_actions = new ObservableCollection<EnemyAction>());
    }
}
