using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBoltSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayEffect(1);
        SoundManager.instance.effectSource.loop = true;
   

    }
    private void OnDestroy()
    {
        SoundManager.instance.effectSource.loop = false;
    }


}
