using System.Collections.Generic;
using Commandos.Model.Characters.Enemies.Actions;
using Commandos.Model.Common;

namespace Commandos.Model.Map
{
    public class EnemyPatrol : MissionObject
    {
        public double Angle { get; set; }

        public double ColumnsCount { get; set; }

        public double RowsCount { get; set; }

        public string LeaderFile { get; set; }

        public string SoldiersFile { get; set; }

        private List<EnemyActions> _actions;
        public IList<EnemyActions> Actions => _actions ?? (_actions = new List<EnemyActions>());

        public EnemyActions DefaultAction { get; set; }

        public EnemyAction EventAction { get; set; }
    }
}
