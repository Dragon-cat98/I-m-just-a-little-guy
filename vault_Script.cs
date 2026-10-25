using UnityEngine;
using TMPro;
public class vault_Script : MonoBehaviour
{
    public static vault_Script instance;
    public TextMeshProUGUI inventoryText;
    public TextMeshProUGUI buttonToolTipText;
    public bool nearVault;
    public bool openedVault;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
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
        if (other.CompareTag("Vault") && nearVault == false && RobberyScript.instance.isClearkScared == true)
        {
            buttonToolTipText.text = "Press [F]";
            nearVault = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Vault") && nearVault == true && RobberyScript.instance.isClearkScared == true)
        {
            buttonToolTipText.text = "";
            nearVault = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Vault") && nearVault == true && Input.GetKeyDown(KeyCode.F) && RobberyScript.instance.isClearkScared == true && openedVault == false)
        {
            inventoryText.text += "\n" + "A lot of Money";
            openedVault = true;
        }
    }
}
