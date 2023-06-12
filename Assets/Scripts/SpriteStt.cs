using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteStt : MonoBehaviour
{

    [SerializeField] Sprite[] buttonSprtie;
    [SerializeField] Image targetButton;

    [SerializeField] bool music, effect;

    private void Start()
    {
        if (music)
        {

            if (SoundManager.instance.musicSoundMuted)
            {
                SpriteChange();
            }
        }
        else if (effect)
        {
            if (SoundManager.instance.effectSoundMuted)
            {
                SpriteChange();
            }
        }

    }

    public void SpriteChange()
    {

        if (targetButton.sprite == buttonSprtie[0])
        {

            targetButton.sprite = buttonSprtie[1];
            return;
        }
        targetButton.sprite = buttonSprtie[0];

    }
}
