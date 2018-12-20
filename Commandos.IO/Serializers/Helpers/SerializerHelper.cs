using Commandos.IO.Serializers.Map;

namespace Commandos.IO.Serializers.Helpers
{
    public class SerializerHelper
    {
        private SerializerHelper() { }

        private static SerializerHelper _instance;
        public static SerializerHelper Instance => _instance ?? (_instance = new SerializerHelper());

        private BriefingSerializer _breifeingSerializer;
        public BriefingSerializer BriefingSerializer => _breifeingSerializer ?? (_breifeingSerializer = new BriefingSerializer());

        private CameraSerializer _cameraSerializer;
        public CameraSerializer CameraSerializer => _cameraSerializer ?? (_cameraSerializer = new CameraSerializer());

        private FicherosSerializer _ficherosSerializer;
        public FicherosSerializer FicherosSerializer => _ficherosSerializer ?? (_ficherosSerializer = new FicherosSerializer());

        private MusicSerializer _musicSerializer;
        public MusicSerializer MusicSerializer => _musicSerializer ?? (_musicSerializer = new MusicSerializer());

    }
}
