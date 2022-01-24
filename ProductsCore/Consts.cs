using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsCore
{
    public static class Consts
    {
        public const char CommandStartSign = '/';
        public const char CommandElementSeprator = ' ';
        public const string ServerMessageSenderName = "System";
        public static class Commands
        {
            public const string PrivateMessage = "msg";
            public const string Help = "help";
            public const string Color = "color";

        }
        public static class ClientMethods
        {
            public const string ReceiveMessage = nameof(ReceiveMessage);
            public const string ColorChanged = nameof(ColorChanged);
        }
        public static class ServerMessages
        {
            public static  string HelpMessage = 
                "/msg <CollerId> Your message text =>send private message to client" +
                Environment.NewLine +
                 "/help => call this help" +
                 Environment.NewLine +
                "Text of your messge => send messge to all in chat";

            public static string ColorChanged(string color) =>
                string.Format("Color changed to {0}", color);
        }
    }
}
