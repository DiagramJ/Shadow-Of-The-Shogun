using UnityEngine;
using System.Collections;

public class FlyingText : MonoBehaviour
{
    public int lifetime;
    TextMesh text;
    Rigidbody2D body;
    int time;
	void Start ()
    {
        instantiate();
    }
	public void instantiate()
    {
        text = transform.GetChild(0).GetComponent<TextMesh>();
        body = transform.GetComponent<Rigidbody2D>();
        int x = GameManager.instance.random.Next(-100, 100);
        int y = GameManager.instance.random.Next(200, 300);
        body.AddForce(new Vector2(x, y));
        time = lifetime;
    }
	// Update is called once per frame
	void Update ()
    {
        time--;
        if (time == 0)
            Destroy(this.gameObject);	
	}
    public void setText(string message)
    {
        text.text = message;
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
