using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{

    [SerializeField] private FadeManager fadeManager;
    [SerializeField] private GameObject pauseContent;
    [SerializeField] private Button buttonContinue;
    [SerializeField] private Button buttonHome;

    private bool inPause;

    void Start()
    {
        inPause = false;
        pauseContent.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        buttonContinue.onClick.AddListener(delegate{
            OnContinue();
        });

        buttonHome.onClick.AddListener(delegate{
            OnHome();
        });
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            inPause = !inPause;
        }

        Time.timeScale = inPause? 0 : 1;
        pauseContent.SetActive(inPause);

        Cursor.visible = inPause;
        Cursor.lockState = inPause? CursorLockMode.None : CursorLockMode.Locked;
    }

    void OnContinue(){
        inPause = false;
    }

    void OnHome(){
        inPause = false;
        fadeManager.Fade(1,1,ChangeScene);
    }

    void ChangeScene(){
        SceneManager.LoadScene("Menu");
    }
}
