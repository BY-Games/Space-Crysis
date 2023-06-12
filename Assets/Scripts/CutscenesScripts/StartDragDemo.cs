using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class StartDragDemo : MonoBehaviour {
    [SerializeField] private GameObject player;

    [FormerlySerializedAs("cursorDragDemo")] [SerializeField]
    private GameObject SecondDemoToPlay;

    [SerializeField] private GameObject dragArrowDemo;

    [SerializeField] private GameObject parent;
    // Start is called before the first frame update

    void Start() {
        if (player != null) {
            player.gameObject.SetActive(true);
        }


        SecondDemoToPlay.gameObject.SetActive(true);
        if (dragArrowDemo != null) {
            dragArrowDemo.gameObject.SetActive(true);
        }

        Destroy(parent.gameObject);
    }
}