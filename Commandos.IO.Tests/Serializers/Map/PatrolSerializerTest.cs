using System;
using System.Collections.ObjectModel;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Map;
using Commandos.Model.Characters.Enemies.Actions;
using Commandos.Model.Common;
using Commandos.Model.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Map
{
    [TestClass]
    public class PatrolSerializerTest
    {
        [TestMethod]
        public void Serialize_Works()
        {
            // Arrange,
            const string text = "[         .ENTES ( ( EntePatrulla [ .PATRULLAJE [ .RECPATRULLA [ .RUTAS ( [ " +
                                    ".NOMBRE DEFAULT .VEL 1.5 .TIPO STOPPED .ESCALAS ( ( IR_A_PUNTO [ .MODO ANDANDO .XYZ ( -154.0 337.0 0 ) .ESC EXTERIOR ] ) ) " +
                                    "] ) .RUTA_POR_DEFECTO DEFAULT ] ] .TOKEN PAT0001 .XYZ ( -160.0 335.0 0 ) .ESC EXTERIOR .ANGULO 0 .EMPIEZA PATRULLANDO .NCOLUMNAS 3.0 " +
                                    ".NSOLDADOSCOLUMNA 3.0 .ANIMSOLDADO ALEMET.ANI .ANIMSARGENTO ALEOFI.ANI .DETIENE 0 ] ) ) ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = new EnemyPatrol
            {
                TokenId = "PAT0001",
                Angle = "0",
                ColumnsCount = "3.0",
                RowsCount = "3.0",
                SoldiersFileName = "ALEMET.ANI",
                LeaderFileName = "ALEOFI.ANI",
                Area = "EXTERIOR",
                DefaultRoute = "DEFAULT",
                Position = new Position("-160.0", "335.0", "0")
            };
            var route = new EnemyRoute
            {
                RouteName = "DEFAULT",
                Speed = "1.5",
                ActionRepeatType = "STOPPED"
            };
            route.Actions.Add(new MoveAction
            {
                Area = "EXTERIOR",
                Position = new Position("-154.0", "337.0", "0"),
                MovementType = "ANDANDO"
            });
            expected.Routes.Add(route);
            var record = TokenParser.ParseTokens(tokens).GetRecord(PatrolsSerializer.Patrols);
            var target = new PatrolsSerializer();

            // Act,
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual[0]);
        }

        [TestMethod]
        public void Serialize_Deserialize_Works()
        {
            // Arrange,
            var expected = new EnemyPatrol
            {
                TokenId = "PAT0001",
                Angle = "0",
                ColumnsCount = "3.0",
                RowsCount = "3.0",
                SoldiersFileName = "ALEMET.ANI",
                LeaderFileName = "ALEOFI.ANI",
                Area = "EXTERIOR",
                DefaultRoute = "DEFAULT",
                Position = new Position("-160.0", "335.0", "0")
            };
            var route = new EnemyRoute
            {
                RouteName = "DEFAULT",
                Speed = "1.5",
                ActionRepeatType = "STOPPED"
            };
            route.Actions.Add(new MoveAction
            {
                Area = "EXTERIOR",
                Position = new Position("-154.0", "337.0", "0"),
                MovementType = "ANDANDO"
            });
            expected.Routes.Add(route);
            var target = new PatrolsSerializer();

            // Act,
            var record = target.Deserialize(new ObservableCollection<EnemyPatrol> { expected });
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual[0]);
        }
    }
}
