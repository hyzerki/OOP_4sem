namespace Lab2.Singletone
{
    internal class FormSettings
    {
        public const string _configPath = "config.json";

        private static FormSettings? _instance;

        private FormSettings()
        {

        }

        public Font? Font { get; set; }
        public Color FontColor { get; set; }
        public Color BGColor { get; set; }

        public static FormSettings GetInstance()
        {
            if (_instance is null)
            {
                _instance = new FormSettings();
            }
            return _instance;
        }


    }
}
