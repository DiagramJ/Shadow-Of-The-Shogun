using UnityEngine;
using System.Collections;

public class FlyingText : MonoBehaviour
{
    public int lifetime;
    TextMesh text;
    Rigidbody2D body;
    int time;
    int delay;
    string message;
    void Start ()
    {
    }
	public void instantiate(int Delay)
    {
        text = transform.GetChild(0).GetComponent<TextMesh>();
        body = transform.GetComponent<Rigidbody2D>();
        time = lifetime;
        delay = Delay;
        body.gravityScale = 0;
        text.text = "";
    }
	// Update is called once per frame
	void Update ()
    {
        if (delay == 0)
        {
            body.gravityScale = 2;
            addForce();
            delay = -1;
        }
        else if(delay != -1)
            delay--;
        if(delay == -1)
        {
            time--;
            if (time == 0)
                Destroy(this.gameObject);
        }
	}
    public void addForce()
    {
        int x = GameManager.instance.random.Next(-200, 200);
        int y = GameManager.instance.random.Next(500, 600);
        body.AddForce(new Vector2(x, y));
        text.text = message;
    }
    public void setText(string Message)
    {
        message = Message;
    }
    public void setFont( FontStyle style)
    {
        text.fontStyle = style;
    }
    public void setColor(Color newColor)
    {
        text.color = newColor;
    }
}
