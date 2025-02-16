using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    public string sceneName;
    public Button beginnerButton;
    void Start()
    {
        if (beginnerButton != null)
        {
            beginnerButton.onClick.AddListener(() => ChangeScene());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
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
