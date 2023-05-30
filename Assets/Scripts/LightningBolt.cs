using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    [SerializeField] GameObject lightningBolt;
    [SerializeField] GameObject lightningBolt2;
    [SerializeField] GameObject lightningBolt3;
    [SerializeField] GameObject lightningBolt4;
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
                lightningBolt2.SetActive(true);
                lightningBolt3.SetActive(false);
                lightningBolt4.SetActive(true);
                boltAvtive = false;
            }
            else
            {
                lightningBolt.SetActive(false);
                lightningBolt3.SetActive(true);
                lightningBolt4.SetActive(false);
                lightningBolt2.SetActive(false);

                boltAvtive = true;
            }

            yield return new WaitForSeconds(timeOfBreak);
        }

      
    }

}
