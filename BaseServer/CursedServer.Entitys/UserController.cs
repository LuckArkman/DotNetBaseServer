using CursedServer.Bean;
using CursedServer.Enums;
using CursedServer.Interfaces;

namespace CursedServer.Entitys;

public class UserController : BaseController
{
    public UserController()
    {
        requestCode = RequestCode.User;
    }
    
    public void Action(ActionCode actionCode, string data, IPlayer client)
    {
        
    }
}