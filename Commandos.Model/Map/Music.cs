using System.Collections.Generic;

namespace Commandos.Model.Map
{
    public class Music
    {
        private List<string> _musicList;
        public List<string> MusicList => _musicList ?? (_musicList = new List<string>());

        public string DefaultMusic { get; set; }
    }
}
