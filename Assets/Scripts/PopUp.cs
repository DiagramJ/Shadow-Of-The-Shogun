using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private TextMesh text;
    string message;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = transform.GetChild(0).GetComponent<TextMesh>();
        message = "";
        text.text = message;
        spriteRenderer.enabled = false;
        text.richText = true;
    }

    void Update()
    {

    }
    public void show()
    {
        spriteRenderer.enabled = true;
        text.text = message;
    }
    public void hide()
    {
        spriteRenderer.enabled = false;
        text.text = "";
    }
    public void setText(Message Text)
    {
        message = Text.message;
        text.characterSize = Text.size;
    }
}
