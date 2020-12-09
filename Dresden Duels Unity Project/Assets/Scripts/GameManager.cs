using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject DresdenControls;
    [SerializeField] private GameObject NicoControls;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Activate(DresdenControls, NicoControls);
        }
    }

    void Activate(GameObject obj, GameObject obj2)
    {
        if (obj.activeSelf)
        {
            obj.SetActive(false);
            obj2.SetActive(false);
        }
        else
        {
            obj.SetActive(true);
            obj2.SetActive(true);
        }
    }

}
