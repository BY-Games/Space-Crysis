using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteStt : MonoBehaviour
{

    [SerializeField] Sprite[] buttonSprtie;
    [SerializeField] Image targetButton;



    public void SpriteChange()
    {
      if(targetButton.sprite == buttonSprtie[0]) { 
        
            targetButton.sprite = buttonSprtie[1];
            return;
        }
      targetButton.sprite = buttonSprtie[0];

    }
}
