using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;
using Unity.VisualScripting;

public class PlayerAnimationState : MonoBehaviour {
    
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

        else if (state == GameManager.GameState.Eliminated) {
            if (gameObject != null) {
                if (_playerAnim != null) {
                    _playerAnim.enabled = true;
                }

                _playerAnim.runtimeAnimatorController = eliminatedState;
                StartCoroutine(WaitAndDeactivate());
            }
        }
    }



    private IEnumerator WaitAndDeactivate() {
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }
    
    public void ScaredAnimation() {
        if (_playerAnim != null) {
            _playerAnim.enabled = true;
        }

        _playerAnim.runtimeAnimatorController = scaredAnimation ;
    }
    
    public void StopScaredAnimation() {
        if (_playerAnim != null) {
            _playerAnim.enabled = false;
        }

        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = defaultSprite;
    }


    // Start is called before the first frame update
    [FormerlySerializedAs("_idleState")] [SerializeField]
    private RuntimeAnimatorController idleState;

    [SerializeField]
    private Sprite defaultSprite;
    [SerializeField] private RuntimeAnimatorController throwState;
    [SerializeField] private RuntimeAnimatorController winState;
    [SerializeField] private RuntimeAnimatorController eliminatedState;
    [SerializeField] private RuntimeAnimatorController scaredAnimation;



    private Animator _playerAnim;

    void Start() {
        _playerAnim = gameObject.GetComponent<Animator>();
        // _playerAnim.runtimeAnimatorController = idleState;
    }

    // Update is called once per frame
    void Update() { }
}