using UnityEngine;
using System.Collections;

public class InfoBox : MonoBehaviour
{
    public Box soloBackButton;
    public Box backButton;
    public Box confirmButtion;
    public TextMesh soloBackButtonText;
    public TextMesh backButtonText;
    public TextMesh confirmButtionText;
    private TextMesh text;
    private Message message;
    private SpriteRenderer spriteRenderer;
    private int input;
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = transform.GetChild(0).GetComponent<TextMesh>();
        text.text = "";
        text.richText = true;
        message = new Message();
    }
	
	void Update ()
    {
        if (confirmButtion.Input != 0)
        {
            input = 1;
            confirmButtion.inputOff();
        }
        else if (soloBackButton.Input != 0)
        {
            input = -1;
            soloBackButton.inputOff();
        }
        else if (backButton.Input != 0)
        {
            input = -1;
            backButton.inputOff();
        }
    }
    public void setState(int state)
    {
        switch(state)
        {
            case -1:
                setNone();
                break;
            case 0:
                setSoloBack();
                break;
            case 1:
                setConfirmAndBack();
                break;
        }
    }
    private void setSoloBack()
    {
        backButton.enable(false);
        confirmButtion.enable(false);
        backButtonText.text = "";
        confirmButtionText.text = "";
        soloBackButton.enable(true);
        soloBackButtonText.text = "Back";
    }
    private void setConfirmAndBack()
    {
        soloBackButton.enable(false);
        soloBackButtonText.text = "";
        backButton.enable(true);
        confirmButtion.enable(true);
        backButtonText.text = "Back";
        confirmButtionText.text = "Confirm";
    }
    private void setNone()
    {
        soloBackButton.enable(false);
        soloBackButtonText.text = "";
        backButton.enable(false);
        confirmButtion.enable(false);
        backButtonText.text = "";
        confirmButtionText.text = "";
    }
    public void show(int state)
    {
        setState(state);
        spriteRenderer.enabled = true;
        text.text = message.message;
        text.characterSize = message.size;
        text.fontStyle = message.style;
        input = 0;
    }
    public void hide()
    {
        setState(-1);
        spriteRenderer.enabled = false;
        text.text = "";
        input = 0;
    }
    public bool isActive()
    {
        return spriteRenderer.enabled;
    }
    public void setText(Message Text)
    {
        message = Text;
    }
    public int Input
    {
        get { return input; }
    }
}
