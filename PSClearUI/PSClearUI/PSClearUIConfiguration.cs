using Rocket.API;

namespace papershredder432.PSClearUI
{
    public class PSClearUIConfiguration : IRocketPluginConfiguration
    {
        public bool PSClearUIEnabled;

        public void LoadDefaults()
        {
            PSClearUIEnabled = true;
        }
    }
}