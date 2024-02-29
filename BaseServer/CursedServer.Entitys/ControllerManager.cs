using CursedServer.Bean;
using CursedServer.Enums;
using CursedServer.Exceptions;
using CursedServer.Interfaces;

namespace CursedServer.Entitys;

public class ControllerManager : IControllerManager
{
    readonly Dictionary<RequestCode, BaseController> _controllerDict = new();
    GameController? _gameController { get; set; }
    UserController? _userController { get; set; }
    Server server { get; set; }

    public ControllerManager()
    {
    }

    public ControllerManager(Server server)
    {
        this.server = server;
        Init();
    }

    private void Init()
    {
        DefaultController defaultController = new DefaultController();
        _controllerDict.Add(defaultController.RequestCode, new DefaultController());
        _controllerDict.Add(RequestCode.User, new UserController());
        _controllerDict.Add(RequestCode.Game, new GameController());
    }

    public async void HandleRequest(RequestCode requestCode, ActionCode actionCode, string data, IPlayer client)
    {
        BaseController controller;
        bool isGet = _controllerDict.TryGetValue(requestCode, out controller);
        NotFoundException.ThrowIfNull(isGet, $"isGet '{requestCode}' Can't found controller for.");
        if (actionCode is ActionCode.ColleteXP) _userController = new UserController();
        if (_userController is not null) _userController.Action(actionCode, data, client);
        await Task.CompletedTask;
    }
}