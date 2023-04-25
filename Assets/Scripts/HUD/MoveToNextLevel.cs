using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class MoveToNextLevel : MonoBehaviour
{
        [SerializeField] InputAction nextLevel = new InputAction(type: InputActionType.Button);


 void OnEnable()  {
        nextLevel.Enable();
    }

    void OnDisable()  {
        nextLevel.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(nextLevel.WasPressedThisFrame()) {
            SceneManager.LoadScene("Level 1");
            gameObject.SetActive(false);
        }
    }
}
