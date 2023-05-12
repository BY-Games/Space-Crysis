using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    [SerializeField] private SceneAsset[] scenes;

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

    public async void LoadScene(string sceneName) {
        _target = zeroValue;
        _progressBar.fillAmount = zeroValue;
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);
        do
        {
            await Task.Delay(100);
            _target = scene.progress;
        } while (scene.progress < unityMaxLoad);
        await Task.Delay(1000); // need to DISCARD
        // Loading complete we can activate the next scene.
        scene.allowSceneActivation = true;
        // No need anymnore for loader canvas to be shown.
        _loaderCanvas.SetActive(false);

    }
    
    public IEnumerator LoadScenes(string sceneName)
    {
        _target = zeroValue;
        _progressBar.fillAmount = zeroValue;

        var scene = SceneManager.LoadSceneAsync(sceneName);
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
        GameManager.Instance.UpdateGameState(GameManager.GameState.Tutorial);
    }
    
    public IEnumerator LoadScenes()
    {
        _target = zeroValue;
        _progressBar.fillAmount = zeroValue;

        var scene = SceneManager.LoadSceneAsync(scenes[currentSceneIndex++ % scenes.Length].name);
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
        GameManager.Instance.UpdateGameState(GameManager.GameState.Tutorial);
    }



    // Update is called once per frame
    // void Update()
    // {
    //     _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _target / unityMaxLoad, 3 * Time.deltaTime);
    // }
}
