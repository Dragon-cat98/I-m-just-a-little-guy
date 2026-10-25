using UnityEngine;
using TMPro;
public class bank_Script : MonoBehaviour
{
    public static bank_Script instance;
    public GameObject bank_Scene;
    public GameObject main_Scene;
    public TextMeshProUGUI inventoryText;
    public TextMeshProUGUI buttonToolTipText;
    public bool nearBank;
    public bool nearBankInside;
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
        if (other.CompareTag("Bank_Door") && nearBank == false)
        {
            buttonToolTipText.text = "Press [F]";
            nearBank = true;
        }
        else if(other.CompareTag("BankDoor_Inside") && nearBankInside == false)
        {
            buttonToolTipText.text = "Press [F]";
            nearBankInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bank_Door") && nearBank == true)
        {
            buttonToolTipText.text = "";
            nearBank = false;
        }
        else if(other.CompareTag("BankDoor_Inside") && nearBankInside == true)
        {
            buttonToolTipText.text = "";
            nearBankInside = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Bank_Door") && nearBank == true && Input.GetKeyDown(KeyCode.F))
        {
            bank_Scene.SetActive(true);
            main_Scene.SetActive(false);
            transform.position = new Vector2(-0.48f, -4.46f);
        }
        else if(other.CompareTag("BankDoor_Inside") && nearBankInside == true && Input.GetKeyDown(KeyCode.F))
        {
            bank_Scene.SetActive(false);
            main_Scene.SetActive(true);
            transform.position = new Vector2(4.91f, 1.45f);
        }
    }

}
