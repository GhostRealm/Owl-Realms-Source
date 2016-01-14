#region

using wServer.realm.entities;
using wServer.realm.entities.player;

#endregion

namespace wServer.realm.commands
{
    internal interface ICommand
    {
        string Command { get; }
        int RequiredRank { get; }

        void Execute(Player player, string[] args);
    }
}

namespace wServer.realm.commands
{
    internal interface ICCommand
    {
        string Command { get; }
        int RequiredDonation { get; }

        void Execute(Player player, string[] args);
    }
}