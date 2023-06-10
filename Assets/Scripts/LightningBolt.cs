using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour {
    [SerializeField] GameObject[] firstGroupLightningBolt;
    [SerializeField] GameObject[] secondGroupLightningBolt;


    [SerializeField] float timeOfBreak;

    bool boltActive;

    // Start is called before the first frame update
    void Start() {
        boltActive = true;
        StartCoroutine(LightBoltBreaks());
    }


    public IEnumerator LightBoltBreaks() {
        while (true) {
            

            if (boltActive) {
                foreach (GameObject lightningBolt in firstGroupLightningBolt) {
                    lightningBolt.SetActive(true);
                    SoundManager.instance.PlayEffect(1);

                }

                foreach (GameObject lightningBolt in secondGroupLightningBolt) {
                    lightningBolt.SetActive(false);

                }

                boltActive = false;
            }
            else {
                foreach (GameObject lightningBolt in secondGroupLightningBolt) {
                    lightningBolt.SetActive(true);
                    SoundManager.instance.PlayEffect(1);

                }

                foreach (GameObject lightningBolt in firstGroupLightningBolt) {
                    lightningBolt.SetActive(false);
                }


                boltActive = true;
            }

            yield return new WaitForSeconds(timeOfBreak);
        }
    }
}