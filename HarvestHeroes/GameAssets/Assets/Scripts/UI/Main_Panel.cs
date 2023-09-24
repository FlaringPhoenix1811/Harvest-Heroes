using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Main_Panel : MonoBehaviour
{
    public GameObject mainPanel;
    public Player player;

    void Start()
    {
        mainPanel.SetActive(true);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMainPanel();
        }
    }


    public void ToggleMainPanel()
    {
        if(!mainPanel.activeSelf)
        {
            mainPanel.SetActive(true);
        }
        else
        {
            mainPanel.SetActive(false);
        }
    }
}
