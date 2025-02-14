using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FlashScreen : MonoBehaviour
{
    [Header("Panels")]
    public GameObject infoPanel;
    public GameObject welcomePanel;
    public GameObject introPanel;

    [Header("Timig Settinsgs")]
    public float splashScreenDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        infoPanel.SetActive(false);
        introPanel.SetActive(false);
        welcomePanel.SetActive(true);
        StartCoroutine(SwitchPanel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SwitchPanel()
    {
        yield return new WaitForSeconds(splashScreenDelay);
        introPanel.SetActive(true);
        welcomePanel.SetActive(false);
    }
}
