using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public float speed;
    public Color fullColor;
    public Color Over75Color;
    public Color Over50Color;
    public Color Over25Color;
    public Color Under25Color;
    private SpriteRenderer bar;
    private SpriteRenderer backGround;
    private SpriteRenderer spriteRenderer;
    private float number;
    private float stopNumber;
    private int displayMax;
    private int displayMin;
    private TextMesh text;
    private bool isEnabled;
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        backGround = transform.GetChild(0).GetComponent<SpriteRenderer>();
        bar = transform.GetChild(1).GetComponent<SpriteRenderer>();
        text = transform.GetChild(2).GetComponent<TextMesh>();
        number = 1;
        stopNumber = 1;
        displayMax = 1;
        displayMin = 0;
        isEnabled = true;
    }

	void Update ()
    {
        if (!isEnabled)
            return;
       if(stopNumber != number)
       {
            if (stopNumber > number)
            {
                number += speed;
                if (stopNumber < number)
                    number = stopNumber;
            }
            else
            {
                number -= speed;
                if (stopNumber > number)
                    number = stopNumber;
            }
            updateBar();
            updateColor();
            updateText();
       }
    }

    public void updateBar()
    {
        if (number >= 1)
            number = 1;
        if (number <= 0)
            number = 0;
        bar.transform.localScale = new Vector3(number, 1, 1);
        float newPosition = ((1 - number) * -3);
        newPosition *= transform.localScale.x;
        newPosition += transform.position.x;
        bar.transform.position = new Vector2(newPosition, transform.position.y);
    }

    public void updateColor()
    {
        if (number == 1)
            bar.color = fullColor;
        else if (number >= .75)
            bar.color = Over75Color;
        else if (number >= .50)
            bar.color = Over50Color;
        else if (number >= .25)
            bar.color = Over25Color;
        else
            bar.color = Under25Color;
    }

    public void updateText()
    {
        float current = displayMax * number;
        if (current + 1 > displayMin && current - 1 < displayMin)
            text.text = displayMin + "/" + displayMax;
        else
            text.text = (int)current + "/" + displayMax;
    }

    public void setText(string Text)
    {
        text.text = Text;
    }

    public void enable(bool Enable)
    {
        isEnabled = Enable;
        bar.enabled = Enable;
        backGround.enabled = Enable;
        spriteRenderer.enabled = Enable;
        setText("");
    }
    public void setStopNumber(int End, int Max)
    {
        stopNumber = (float)End / (float)Max;
        if (stopNumber > 1)
            stopNumber = 1;
        if (stopNumber < 0)
            stopNumber = 0;
        displayMax = Max;
        displayMin = End;
    }

    public void setNumber(int current, int Max)
    {
        number = (float)current / (float)Max;
        if (number > 1)
            number = 1;
        if (number < 0)
            number = 0;
        stopNumber = number;
        displayMax = Max;
        displayMin = current;
        updateBar();
        updateColor();
        updateText();
    }
}
