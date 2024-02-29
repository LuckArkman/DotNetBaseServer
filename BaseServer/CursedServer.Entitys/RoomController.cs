using CursedServer.Bean;
using CursedServer.Enums;

namespace CursedServer.Entitys;

public class RoomController : BaseController
{
    public RoomController()
    {
        requestCode = RequestCode.Room;
    }
}