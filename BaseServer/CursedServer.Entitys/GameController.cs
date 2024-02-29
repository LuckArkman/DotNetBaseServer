using CursedServer.Bean;
using CursedServer.Enums;

namespace CursedServer.Entitys;

public class GameController : BaseController
{
    public GameController()
    {
        requestCode = RequestCode.Game;
    }
}