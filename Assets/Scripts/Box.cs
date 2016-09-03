using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{
    // Use this for initialization
    public int buffer;
    public Color defaultColor;
    public Color mouseOverColor;
    public PopUp popUp;
    public SpriteRenderer highlight;

    private bool mouseOver;
    private SpriteRenderer spriteRenderer;
    private int input;
    private bool isEnabled;
    private bool disablePopup;

    void Start()
    {
        mouseOver = false;
        input = 0;
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
        if (highlight != null)
            highlight.enabled = false;
        isEnabled = true;
        disablePopup = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnabled)
            return;
        if (input != 0)
            input--;
    }

    void OnMouseOver()
    {
        if (!isEnabled)
            return;
        if (disablePopup)
            return;
        mouseOver = true;
        if (popUp != null)
            popUp.show();
        spriteRenderer.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        if (!isEnabled)
            return;
        mouseOver = false;
        if (popUp != null)
            popUp.hide();
        spriteRenderer.color = defaultColor;
    }

    void OnMouseDown()
    {
        if (!isEnabled)
            return;
        input = buffer;
    }

    public void highlightOn(Color color)
    {
        if (!isEnabled)
            return;
        if (highlight != null)
        {
            highlight.enabled = true;
            highlight.color = color;
        }
    }
    public void highlightOff()
    {
        if (!isEnabled)
            return;
        if (highlight != null)
        {
            highlight.enabled = false;
        }
    }
    public bool MouseOver
    {
        get { return mouseOver; }
    }
    public int Input
    {
        get { return input; }
    }
    public void inputOff()
    {
        input = 0;
    }
    public void enable(bool Enable)
    {
        isEnabled = Enable;
        spriteRenderer.enabled = Enable;
        spriteRenderer.color = defaultColor;
        if (!Enable)
        {
            if (popUp != null)
                popUp.hide();
            if (highlight != null)
                highlight.enabled = Enable;
            mouseOver = Enable;
        }
    }

    public void setSprite(Sprite Image, Sprite Highlight)
    {
        spriteRenderer.sprite = Image;
        highlight.sprite = Highlight;
    }
    public void DisablePopup()
    {
        if(popUp != null)
            popUp.hide();
        disablePopup = true;
    }
    public void EnablePopup()
    {
        disablePopup = false;
    }
    public Vector3 position()
    {
        return new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    public bool isHighlighted()
    {
        return highlight.enabled;
    }
    public void setText(Message message)
    {
        if(popUp != null)
            popUp.setText(message);
    }

}
