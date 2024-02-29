using System.Net;
using System.Net.Sockets;
using CursedServer.CursedServer.Dao;
using CursedServer.Enums;
using CursedServer.Interfaces;

namespace CursedServer.Entitys;

public class Server : ServerDao, IServer
{
    public Server(){}
    public Server(string host, int port)
    {
        controllerManager = new ControllerManager(this);
        connectDone = new ManualResetEvent(false);
        receiveDone = new ManualResetEvent(false);
        IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(host), port);
        Start(ipEndPoint);
    }
    void Start(IPEndPoint ipEndPoint)
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Bind(ipEndPoint);
        socket.Listen(0);
        socket.BeginAccept(ConnectCallback, null);
    }

    void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            Socket client = socket.EndAccept(ar);
            Client cl = new Client(client, this);
            cl.OnStart();
            clientList.Add(cl.UserID, cl);
            socket.BeginAccept(ConnectCallback, null);
        }
        catch (SocketException e)
        {
            Console.WriteLine("In Server ::> SocketException " + e.ToString());
        }
    }

    public void HandleRequest(RequestCode requestCode, ActionCode actionCode, string data, IPlayer client)
        => controllerManager.HandleRequest(requestCode, actionCode, data, client);

    public void RemoveClient(IPlayer player)
    {
        
    }

    public void CloseConnection(IPlayer player, Socket socket)
    {
        
    }
}