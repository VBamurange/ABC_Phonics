using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    public string sceneName;
    public Button levelButton;
    public Button backButton;
    public string targetPanel;

    void Start()
    {
        if (levelButton != null)
        {
            levelButton.onClick.AddListener(() => ChangeScene());
        }

        if (backButton != null)
        {
            backButton.onClick.AddListener(() => BackToPreviousScene());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);

        PlayerPrefs.SetString("ActivePanel", "TermsPanel");
        PlayerPrefs.Save();
        
    }

    public void BackToPreviousScene()
    {
        PlayerPrefs.SetString("ActivePanel", targetPanel);
        PlayerPrefs.SetString("ReturningFromScene", "true");
        PlayerPrefs.Save();
        
        SceneManager.LoadScene("IntroScene");
    }
    public void QuitGameMethod()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
