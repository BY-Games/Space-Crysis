using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    [SerializeField] GameObject lightningBolt;
  
    [SerializeField] float timeOfBreak; 
    bool boltAvtive;
    // Start is called before the first frame update
    void Start()
    {
        boltAvtive = true;
        StartCoroutine(LightBoltBreaks());
    }

   

    public IEnumerator LightBoltBreaks()
    {

        while (true)
        {
            if (boltAvtive)
            {
                lightningBolt.SetActive(true);
             
                boltAvtive = false;
            }
            else
            {
                lightningBolt.SetActive(false);
        

                boltAvtive = true;
            }

            yield return new WaitForSeconds(timeOfBreak);
        }

      
    }

}
