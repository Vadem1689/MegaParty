using UnityEngine;

public class SpeenButton : AbstractButton
{
    protected override void OnClick()
    {
        
    }

    public void ActivateButton()
    {
        Button.interactable = true;
    }

    public void DeactivateButton()
    {
        Button.interactable = false;
    }
}
