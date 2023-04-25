using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAnnouncement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject announcement;
    void Start()
    {
        announcement.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            announcement.gameObject.SetActive(true);
        }
    }
}
