using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnimationState : MonoBehaviour
{
    private void Awake() {
        GameManager.OnGameStateChange += SetAnimationOnState;
    }

    private void OnDestroy() {
        GameManager.OnGameStateChange -= SetAnimationOnState;
    }

    private void SetAnimationOnState(GameManager.GameState state) {
        if (state == GameManager.GameState.Win) {
            if (_playerAnim != null) {
                _playerAnim.enabled = true;
            }
            _playerAnim.runtimeAnimatorController = winState;
        }
    }

    // Start is called before the first frame update
    [FormerlySerializedAs("_idleState")] [SerializeField] private AnimatorController idleState;
    [SerializeField] private AnimatorController throwState;
    [SerializeField] private AnimatorController winState;
    private Animator _playerAnim;
    void Start() {
        _playerAnim = gameObject.GetComponent<Animator>();
        // _playerAnim.runtimeAnimatorController = idleState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
