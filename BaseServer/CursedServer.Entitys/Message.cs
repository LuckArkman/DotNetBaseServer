using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using CursedServer.Enums;
using CursedServer.Exceptions;
using Newtonsoft.Json;

namespace CursedServer.Entitys;

public class Message
{
    public Message(){}
    public byte[] PackData(object? obj)
    {
        NotFoundException.ThrowIfNull(obj, $"{obj} Is Null");
        string msg = JsonConvert.SerializeObject(obj);
        return Encoding.UTF8.GetBytes(msg);
    }
    
    public void ReadMessage(string _string, Action<RequestCode, ActionCode, string> processDataCallback)
    {
        var obj = DeserializeFromString<Msg>(_string);
        NotFoundException.ThrowIfNull(obj, $"{obj} Is not Deserialize From String");
        processDataCallback(obj.requestCode, obj.actionCode, obj._string);
    }

    T? DeserializeFromString<T>(string s)
        =>JsonConvert.DeserializeObject<T>(s);
}