using CursedServer.Enums;

namespace CursedServer.Bean;

public abstract class BaseController
{
    
    protected RequestCode requestCode = RequestCode.None;

    public RequestCode RequestCode
        =>requestCode;
}