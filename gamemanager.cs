using UnityEngine;
using TMPro;
public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;
    public GameObject cop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        cop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(vault_Script.instance.openedVault == true)
        {
            cop.SetActive(true);
        }
    }
}