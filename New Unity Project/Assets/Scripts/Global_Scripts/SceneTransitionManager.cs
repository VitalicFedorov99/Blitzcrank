using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    private static SceneTransitionManager instance;
    private AsyncOperation loadingSceneOperation;
    private Animator loadingScreenAnimator;
    private bool isAnimEnd = false;

    [SerializeField] private Scrollbar progressBar;
    [SerializeField] private Text loadingText;
    [SerializeField] private GameObject loadingScreen;
    

    private void Awake(){ 
        DontDestroyOnLoad(this);         
        instance = this;
        if(!TryGetComponent<Animator>(out loadingScreenAnimator)) Debug.Log("Аниматора нет");
    }
    private void Update() {
        if(loadingSceneOperation != null) 
        {
            progressBar.size = loadingSceneOperation.progress;
            if (isAnimEnd && Input.GetKeyDown(KeyCode.Return)) {
                instance.loadingSceneOperation.allowSceneActivation = true;
                HideLoadingScreen();
                isAnimEnd = false;
            }
        }
    }
    public static void SwitchToLevel(string levelName){
        instance.loadingScreenAnimator.SetTrigger("Appears");
        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(levelName);
        instance.loadingSceneOperation.allowSceneActivation = false;
        
    }
    public void OnAnimationOver(){
        progressBar.gameObject.SetActive(false);
        loadingText.text = "Press ENTER to continue.";
        isAnimEnd = true;
    }

    public void HideLoadingScreen(){
        instance.loadingScreenAnimator.SetTrigger("Hidding");
        instance.loadingSceneOperation.allowSceneActivation = true;
    }
}
