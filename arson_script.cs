using UnityEngine;
using TMPro;
public class arson_script : MonoBehaviour
{
    public static arson_script instance;
    public TextMeshProUGUI inventoryText;
    public TextMeshProUGUI buttonToolTipText;
    public bool nearArson;
    public bool CommittedArson;
    public GameObject Fire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        Fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("arson") && nearArson == false && CommittedArson == false && pickpocketScript.instance.pickPocketed == true)
        {
            buttonToolTipText.text = "Press [F]";
            nearArson = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
                
        if(other.CompareTag("arson") && nearArson == true)
        {
            buttonToolTipText.text = "";
            nearArson = false;         
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("arson") && nearArson == true && Input.GetKeyDown(KeyCode.F) && CommittedArson == false && pickpocketScript.instance.pickPocketed == true)
        {
            inventoryText.text = inventoryText.text.Replace("-Lighter", "");
            //nearArson = false;
            CommittedArson = true;
            Fire.SetActive(true);
        }
    }

        
}
