using System;

namespace PufferSoftware.SecureSave
{
    [Serializable]
    public class DemoPlayer
    {
        public string playerName { get; set; } = "";
        public int clickCount { get; set; } = 0;
    }
}