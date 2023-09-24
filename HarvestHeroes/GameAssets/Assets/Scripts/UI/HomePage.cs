using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePage : MonoBehaviour
{
    public GameObject homePage;
    public Player player;

    void Start()
    {
        homePage.SetActive(true);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            homePage.SetActive(false);
        }
    }

}