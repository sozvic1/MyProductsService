using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsCore.Models
{
    public class ChatUserSettings
    {
        public string ClientId { get; set; }
        public string Nickname { get; set; }
        public ConsoleColor UserConsoleColor { get; set; }
        public HashSet<string> MuteList { get; set; }

        public override bool Equals(object obj)
        {
            var otherSettings = obj as ChatUserSettings;
            return otherSettings != null && otherSettings.ClientId == ClientId;
        }
        public ChatUserSettings()
        {
            UserConsoleColor = ConsoleColor.Yellow;
            MuteList = new HashSet<string>();
        }
    }
}
