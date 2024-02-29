using System.Net.Sockets;
using System.Text;
using CursedServer.CursedServer.Dao;
using CursedServer.Enums;
using CursedServer.Interfaces;

namespace CursedServer.Entitys;

public class Client : ClientDao, IPlayer
{
    public int handNumber { get; set; }
    public Guid UserID => UUID;
    public Socket socket { get; }
    public int PlayerCoins { get; }
    public int BuyIn { get; }

    public bool IsHouseOwner()
        => false;
    
    public Client(Socket clientSocket, Server sv)
    {
        this.client = clientSocket;
        this.server = sv;
        UUID = Guid.NewGuid();
        
        
    }

    public void Send(byte[] bytes)
    {
        try
        {
            if (bytes is not null) client.Send(bytes);
        }
        catch (SocketException e)
        {
            Console.WriteLine(e.Message);
            if (e.NativeErrorCode.Equals(10035)) server.RemoveClient(this);
            if (e.NativeErrorCode.Equals(10054)) server.RemoveClient(this);
            if (e.ErrorCode.Equals(32)) server.RemoveClient(this);
        }
        finally
        {

        }
    }

    public void SendData(object? obj)
    {
        Send((byte[])obj!);
    }

    public void Remove(IPlayer player)
    {
        
    }

    public void OnStart()
    {
        receiveDone = new ManualResetEvent(false);
        controllerManager = new ControllerManager();
        Console.WriteLine($"{UUID} Is Connected !");
        if (client.Connected)
        {
            SendData( new Message().PackData(new Msg(RequestCode.User, ActionCode.UserId, UserID.ToString())));
            client.BeginReceive(buffer, 0, 1024, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
        }
    }

    private void ReceiveCallback(IAsyncResult ar)
    {
        Message msg = new Message();
        try
        {
            int count = client.EndReceive(ar);
            if (count > 0)
            {
                msg.ReadMessage(Encoding.UTF8.GetString(buffer, 0, count), OnProcessMessage);
                client.BeginReceive(buffer, 0, 1024, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
            }
        }
        catch (SocketException e)
        {
            if (e.NativeErrorCode.Equals(10035)) server.RemoveClient(this);
            if (e.NativeErrorCode.Equals(10054)) server.RemoveClient(this);
            if (e.ErrorCode.Equals(32)) server.RemoveClient(this);
        }
    }

    void OnProcessMessage(RequestCode requestCode, ActionCode actionCode, string data)
        => server.HandleRequest(requestCode, actionCode, data, this);
}