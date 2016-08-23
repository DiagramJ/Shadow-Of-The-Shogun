using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{
    // Use this for initialization
    public int buffer;
    public Color defaultColor;
    public Color mouseOverColor;
    public GameObject popUp;
    public SpriteRenderer highlight;

    private bool mouseOver;
    private SpriteRenderer popUpRenderer;
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
        if (popUp != null)
        {
            popUpRenderer = popUp.GetComponent<SpriteRenderer>();
            popUpRenderer.enabled = false;
        }
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

    void OnMouseEnter()
    {
        if (!isEnabled)
            return;
        if (disablePopup)
            return;
        mouseOver = true;
        if(popUp != null)
            popUpRenderer.enabled = true;
        spriteRenderer.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        if (!isEnabled)
            return;
        mouseOver = false;
        if (popUp != null)
            popUpRenderer.enabled = false;
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
        if(!Enable)
        {
            if (popUp != null)
                popUpRenderer.enabled = Enable;
            if (highlight != null)
                highlight.enabled = Enable;
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
            popUpRenderer.enabled = false;
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
}
