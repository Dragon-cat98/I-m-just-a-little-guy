using UnityEngine;
using TMPro;

public class TrashCanScript : MonoBehaviour
{
    public static TrashCanScript instance;
    public string[] randomWeapons;
    public bool nearTrash;
    public bool trashLooted;
    public TextMeshProUGUI inventoryText;
    public TextMeshProUGUI buttonToolTipText;
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
        if (other.CompareTag("TrashCan") && nearTrash == false && arson_script.instance.CommittedArson == true && pickpocketScript.instance.pickPocketed == true)
        {
            buttonToolTipText.text = "Press [F]";
            nearTrash = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
                
        if(other.CompareTag("TrashCan") && nearTrash == true)
        {
            buttonToolTipText.text = "";
            nearTrash = false;         
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("TrashCan") && nearTrash == true && Input.GetKeyDown(KeyCode.F) && arson_script.instance.CommittedArson == true && pickpocketScript.instance.pickPocketed == true && trashLooted == false)
        {
            int I = Random.Range(0, randomWeapons.Length);
            inventoryText.text = "Inventory: \n" + randomWeapons[I];
            trashLooted = true;
        }
    }
}
