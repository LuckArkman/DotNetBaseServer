using System.Net;
using System.Net.Sockets;
using CursedServer.Interfaces;

namespace CursedServer.CursedServer.Dao;

public class ServerDao
{
    public IPAddress ipAddress;
    public IPEndPoint ipEndPoint;
    public Socket socket;
    public IControllerManager controllerManager;
    public static ManualResetEvent connectDone, receiveDone;
    public Dictionary<Guid,IPlayer> clientList = new Dictionary<Guid, IPlayer>();
    public byte[] buffer = new byte[1024];
}