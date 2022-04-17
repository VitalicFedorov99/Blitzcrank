using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{   
    [SerializeField] private Scrollbar progressBar;
    [SerializeField] private Text loadingText;
    [SerializeField] private GameObject loadingScreen;
    private static SceneTransitionManager instance;
    private AsyncOperation loadingSceneOperation;
    private Animator loadingScreenAnimator;
    private bool isLoadingOver = false;
    private string currentSceneName = null;
    

    private void Awake(){ 
        DontDestroyOnLoad(this);         
        instance = this;
        if(!TryGetComponent<Animator>(out loadingScreenAnimator)) Debug.Log("Аниматора нет");
    }
    private void Update() {
        if(loadingSceneOperation != null) 
        {    
            progressBar.size = loadingSceneOperation.progress;
            if (loadingSceneOperation.progress>=0.9f) LoadingOver();
            Debug.LogError(loadingSceneOperation.progress);
            if (Input.GetKeyDown(KeyCode.Return)) {
                instance.loadingSceneOperation.allowSceneActivation = true;
                HideLoadingScreen();
                isLoadingOver = false;
            }
        }
    }
    public static void SwitchToLevel(string levelName){
        instance.loadingScreenAnimator.SetTrigger("Appears");
        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(levelName);
        instance.loadingSceneOperation.allowSceneActivation = false;
        instance.currentSceneName = levelName;
    }

    public static void RestartLevel(){
        SceneManager.LoadScene(instance.currentSceneName);
    }

    private void LoadingOver(){
        progressBar.gameObject.SetActive(false);
        loadingText.text = "Press ENTER to continue.";
        isLoadingOver = true;
    }

    private void HideLoadingScreen(){
        instance.loadingScreenAnimator.SetTrigger("Hidding");
        instance.loadingSceneOperation.allowSceneActivation = true;
    }
}
