using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knowledge : MonoBehaviour
{
    public GameObject knowledge;
    public Player player;

    void Start()
    {
        knowledge.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleKnowledge();
        }
    }


    public void ToggleKnowledge()
    {
        if(!knowledge.activeSelf)
        {
            knowledge.SetActive(true);
        }
        else
        {
            knowledge.SetActive(false);
        }
    }
}
