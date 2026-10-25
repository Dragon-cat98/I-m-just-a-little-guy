using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
public class pickpocketScript : MonoBehaviour
{
    public static pickpocketScript instance;
    public TextMeshProUGUI inventoryText;
    public TextMeshProUGUI buttonToolTipText;
    public bool nearNPC;
    public bool pickPocketed;

    public TextMeshProUGUI ToDoList_Text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Pedestrian") && nearNPC == false && pickPocketed == false)
        {
            buttonToolTipText.text = "Press [F]";
            nearNPC = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
                
        if(other.CompareTag("Pedestrian") && nearNPC == true)
        {
            buttonToolTipText.text = "";
            nearNPC = false;         
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Pedestrian") && nearNPC == true && Input.GetKeyDown(KeyCode.F) && pickPocketed == false)
        {
            inventoryText.text = "Inventory: \n -Lighter";
            //nearNPC = false;
            pickPocketed = true;
        }
    }

}
