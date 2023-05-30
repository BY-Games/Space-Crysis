using System;
using System.Collections;
using System.Threading.Tasks;
// using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    // [SerializeField] private SceneAsset[] scenes;
    [SerializeField] private String[] sceneNames;

    private int currentSceneIndex = 0;
    
    
    // LoaderCanvas and ProgressBar are the display between the scenes.
    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private Image _progressBar;
    // Detect the scene load status in any given time.
    private float _target;
    // Max value of scene loading progress is 0.9f
    private const float unityMaxLoad = 0.9f;
    private const float zeroValue = 0;
    
    public static LevelManager Instance;
    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // public IEnumerator LoadScenes(string sceneName)
    // {
    //     _target = zeroValue;
    //     _progressBar.fillAmount = zeroValue;
    //
    //     var scene = SceneManager.LoadSceneAsync(sceneName);
    //     scene.allowSceneActivation = false;
    //
    //     _loaderCanvas.SetActive(true);
    //
    //     while (scene.progress < unityMaxLoad)
    //     {
    //         
    //         _target = scene.progress;
    //         _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _target / unityMaxLoad, 3 * Time.deltaTime);
    //         yield return null;
    //     }
    //     Task.Delay(1000);
    //     scene.allowSceneActivation = true;
    //     _loaderCanvas.SetActive(false);
    //     Task.Delay(10000);
    //     GameManager.Instance.UpdateGameState(GameManager.GameState.Tutorial);
    // }
    
    public IEnumerator LoadScenes()
    {


        //this is for work only delte after work 
        //currentSceneIndex = 0;
        //////////////////////////////

        _target = zeroValue;
        _progressBar.fillAmount = zeroValue;

        // Critical
        var scene = SceneManager.LoadSceneAsync(sceneNames[currentSceneIndex++ % sceneNames.Length]);
        
        scene.allowSceneActivation = false;
        _loaderCanvas.SetActive(true);

        while (scene.progress < unityMaxLoad)
        {
            
            _target = scene.progress;
            _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _target / unityMaxLoad, 3 * Time.deltaTime);
            yield return null;
        }
        Task.Delay(1000);
        scene.allowSceneActivation = true;
        _loaderCanvas.SetActive(false);
        Task.Delay(10000);
        
        // Critical
        GameManager.Instance.UpdateGameState(GameManager.GameState.Tutorial);
    }



    
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadScenes(sceneIndex));
    }


  
    public IEnumerator LoadScenes(int sceneIndex)
    {
        _target = zeroValue;
        _progressBar.fillAmount = zeroValue;

        var scene = SceneManager.LoadSceneAsync(sceneIndex);
        scene.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);

        while (scene.progress < unityMaxLoad)
        {
            _target = scene.progress;
            _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _target / unityMaxLoad, 3 * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1);
        scene.allowSceneActivation = true;
        _loaderCanvas.SetActive(false);

        yield return new WaitForSeconds(10);

        GameManager.Instance.UpdateGameState(GameManager.GameState.Tutorial);
    }

    public void ResetCurrentSceneIndex()
    {
        currentSceneIndex = 0;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _target / unityMaxLoad, 3 * Time.deltaTime);
    // }
}
