using System.Net.Sockets;
using CursedServer.Interfaces;

namespace CursedServer.CursedServer.Dao;

public class ClientDao
{
    public IServer server { get; set; }
    public int coins = 0;
    public Guid UUID { get; set; }
    public Socket client { get; set; }
    public static ManualResetEvent? connectDone, receiveDone;
    public static IControllerManager? controllerManager;
    public String response = String.Empty;
    public int PlayerNumber { get; set; }
    public byte[] buffer = new byte[1024];

    public void SetBuffer(byte[] buffer) => this.buffer = buffer;
    public void SetSocket(Socket socket) => this.client = socket;
        
    public void SendMessage(byte[] bytes)
    {
    }
}