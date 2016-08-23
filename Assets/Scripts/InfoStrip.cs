using UnityEngine;
using System.Collections;

public class InfoStrip : MonoBehaviour
{
    public int messageDelay;

    private class Message
    {
        public string message;
        public int time;
        public Message(string Message, int Time)
        {
            message = Message;
            time = Time;
        }
    }

    TextMesh text;
    SpriteRenderer spriteRenderer;
    ArrayList messages;
    int time;
    int delay;

    void Start ()
    {
        text = transform.GetChild(0).GetComponent<TextMesh>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        text.text = "";
        messages = new ArrayList();
        time = 0;
        delay = 0;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(time == 0 && delay == 0)
        {
            getNewMessage();
        }
        if (delay != 0)
        {
            delay--;
            if (messages.Count == 0)
                delay = 0;
        }
        if (time !=0)
        {
            time--;
            if (time == 0)
            {
                delay = messageDelay;
                spriteRenderer.enabled = false;
                text.text = "";
            }
        }
	}

    public void add(string message, int time)
    {
        messages.Add(new Message(message, time));
    }

    public bool isActive()
    {
        return !(messages.Count == 0 && time == 0);
    }

    private void getNewMessage()
    {
        if (messages.Count != 0)
        {
            Message message = (Message)messages[0];
            messages.RemoveAt(0);
            text.text = message.message;
            time = message.time;
            spriteRenderer.enabled = true;
        }
    }
}
