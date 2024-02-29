using System.Net.Sockets;

namespace CursedServer.Interfaces;

public interface IPlayer
{
    int PlayerNumber { get; set; }
    int handNumber { get; set; }
    Guid UserID { get; }
    Socket socket { get; }
    int PlayerCoins { get; }
    int BuyIn { get; }
    
    void SendMessage(byte[] bytes);
    bool IsHouseOwner();
    void Send(byte[] bytes);
    void SendData(object? obj);
    void Remove(IPlayer player);
}