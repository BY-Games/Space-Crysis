using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAnnouncement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject announcement;
    [SerializeField] private GameObject textGuide;
    void Start()
    {
        announcement.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            announcement.gameObject.SetActive(true);
            if (textGuide)
            {
                textGuide.gameObject.SetActive(false);
            }
        }
    }
}
