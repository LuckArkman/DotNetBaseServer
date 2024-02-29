using CursedServer.Enums;

namespace CursedServer.Interfaces;

public interface IControllerManager
{
    void HandleRequest(RequestCode requestCode, ActionCode actionCode, string data, IPlayer client);
}