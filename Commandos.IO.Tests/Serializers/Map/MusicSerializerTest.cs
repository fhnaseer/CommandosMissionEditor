using System;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Map;
using Commandos.Model.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Map
{
    [TestClass]
    public class MusicSerializerTest
    {
        [TestMethod]
        public void GetMusic_Works()
        {
            // Arrange,
            const string text = "[ .MUSICA  [ .MUSICAS (  ( M_BU_Ext.WAV EXTERIOR ) ( M_BU_Agu.WAV AGUA ) ( M_BU_Int.WAV INTERIOR ) ) .MUSICA_POR_DEFECTO INTERIOR ] ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = new Music
            {
                StartingMusicEnvironment = "INTERIOR"
            };
            expected.BackgroundMusics.Add(new Model.Common.BackgroundMusic { Environment = "EXTERIOR", MusicFileName = "M_BU_Ext.WAV" });
            expected.BackgroundMusics.Add(new Model.Common.BackgroundMusic { Environment = "AGUA", MusicFileName = "M_BU_Agu.WAV" });
            expected.BackgroundMusics.Add(new Model.Common.BackgroundMusic { Environment = "INTERIOR", MusicFileName = "M_BU_Int.WAV" });
            var record = TokenParser.ParseTokens(tokens).GetRecord(MusicSerializer.Music);
            var target = new MusicSerializer();

            // Act,
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Read_Write_Works()
        {
            // Arrange,
            var expected = new Music
            {
                StartingMusicEnvironment = "INTERIOR"
            };
            expected.BackgroundMusics.Add(new Model.Common.BackgroundMusic { Environment = "EXTERIOR", MusicFileName = "M_BU_Ext.WAV" });
            expected.BackgroundMusics.Add(new Model.Common.BackgroundMusic { Environment = "AGUA", MusicFileName = "M_BU_Agu.WAV" });
            expected.BackgroundMusics.Add(new Model.Common.BackgroundMusic { Environment = "INTERIOR", MusicFileName = "M_BU_Int.WAV" });
            var target = new MusicSerializer();

            // Act,
            var record = target.Deserialize(expected);
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
