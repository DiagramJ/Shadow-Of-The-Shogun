using UnityEngine;
public class Message
{
    public string message;
    public float size;
    public FontStyle style;
    public Message()
    {
        message = "";
        size = 0.4f;
        style = FontStyle.Normal;
    }
    public Message(string Message)
    {
        message = Message;
        size = 0.4f;
        style = FontStyle.Normal;
    }
    public Message(Message Message)
    {
        message = Message.message;
        size = Message.size;
        style = Message.style;
    }
}
