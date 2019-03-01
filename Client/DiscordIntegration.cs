using DiscordRPC;

namespace RoboRadio
{
    class DiscordIntegration
    {
        public static DiscordRpcClient clientRPC;
        private const string clientID = "481723842088271902";

        public static void Init()
        {
            clientRPC = new DiscordRpcClient(clientID, true, -1);     
            clientRPC.Initialize();
        }
    }
}
