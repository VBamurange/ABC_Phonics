using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject[] allPanels;
    public string activePanelName;
    public string defaultPanel;

    void Start()
    {
        if (PlayerPrefs.HasKey("ActivePanel") && PlayerPrefs.GetString("ReturningFromScene") == "true")
        {
            activePanelName = PlayerPrefs.GetString("ActivePanel");
            ActivatePanel(activePanelName);

            PlayerPrefs.SetString("ReturningFromScene", "false");
            PlayerPrefs.Save();
        }
        else
        {
            ActivatePanel(activePanelName);
        }
    }

    void ActivatePanel(string panelName)
    {
        foreach (GameObject panel in allPanels)
        {
            panel.SetActive(panel.name == panelName);
        }
    }
}

