using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public float speed;
    public bool loyalty;
    public Color fullColor;
    public Color Over75Color;
    public Color Over50Color;
    public Color Over25Color;
    public Color Under25Color;
    private SpriteRenderer bar;
    private SpriteRenderer backGround;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer LoyaltyRendere;
    private float number;
    private float stopNumber;
    private int displayMax;
    private int displayMin;
    private TextMesh text;
    private bool isEnabled;

    private float loyaltyNumber;
    private float loyaltyStopNumber;

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        backGround = transform.GetChild(0).GetComponent<SpriteRenderer>();
        bar = transform.GetChild(1).GetComponent<SpriteRenderer>();
        LoyaltyRendere = transform.GetChild(2).GetComponent<SpriteRenderer>();
        text = transform.GetChild(3).GetComponent<TextMesh>();
        LoyaltyRendere.enabled = loyalty;
        number = 1;
        stopNumber = 1;
        displayMax = 1;
        displayMin = 0;
        isEnabled = true;

        loyaltyNumber = 1;
        loyaltyStopNumber = 1;
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

        if (loyaltyStopNumber != loyaltyNumber)
        {
            if (loyaltyStopNumber > loyaltyNumber)
            {
                loyaltyNumber += speed;
                if (loyaltyStopNumber < loyaltyNumber)
                    loyaltyNumber = loyaltyStopNumber;
            }
            else
            {
                loyaltyNumber -= speed;
                if (loyaltyStopNumber > loyaltyNumber)
                    loyaltyNumber = loyaltyStopNumber;
            }
            updateLoyalty();
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
        bar.transform.position = new Vector2(newPosition, bar.transform.position.y);
    }
    public void updateLoyalty()
    {
        if (loyalty)
        {
            if (loyaltyNumber >= 1.1)
                loyaltyNumber = 1.1f;
            if (loyaltyNumber <= 0)
                loyaltyNumber = 0;
            LoyaltyRendere.transform.localScale = new Vector3(loyaltyNumber, LoyaltyRendere.transform.localScale.y, 1);
            float newPosition = ((1 - (loyaltyNumber / 1.1f)) * -2.75f);
            newPosition *= transform.localScale.x;
            newPosition += transform.position.x;
            LoyaltyRendere.transform.position = new Vector2(newPosition, LoyaltyRendere.transform.position.y);
        }
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
        if(!Enable)
            setText("");
        if (loyalty)
            LoyaltyRendere.enabled = Enable;
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

    public void setLoyaltyStopNumber(int End)
    {
        if (!loyalty)
            return;
            loyaltyStopNumber = ((float)End / 100.0f) * 1.1f;
        if (loyaltyStopNumber > 1.1)
            loyaltyStopNumber = 1.1f;
        if (loyaltyStopNumber < 0)
            loyaltyStopNumber = 0;
    }

    public void setLoyaltyNumber(int current)
    {
        if (!loyalty)
            return;
        loyaltyNumber = ((float)current / 100.0f) * 1.1f;
        if (loyaltyNumber > 1.1)
            loyaltyNumber = 1.1f;
        if (loyaltyNumber < 0)
            loyaltyNumber = 0;
        loyaltyStopNumber = loyaltyNumber;
        updateLoyalty();
    }
    public bool isMoving()
    {
        return stopNumber != number;
    }
}
