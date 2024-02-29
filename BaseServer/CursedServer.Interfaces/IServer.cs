using System.Net.Sockets;
using CursedServer.Enums;

namespace CursedServer.Interfaces;

public interface IServer
{
    void HandleRequest(RequestCode requestCode, ActionCode actionCode, string data, IPlayer client);
    void RemoveClient(IPlayer player);
    void CloseConnection(IPlayer player, Socket socket);
}