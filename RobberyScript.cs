using UnityEngine;
using TMPro;
public class RobberyScript : MonoBehaviour
{
    public static RobberyScript instance;
    public bool nearClerk;
    public TextMeshProUGUI inventoryText;
    public TextMeshProUGUI buttonToolTipText;
    public SpriteRenderer bankClerk;
    public Sprite scaredSprite;
    public bool isClearkScared;
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
        if (other.CompareTag("Robbery") && nearClerk == false)
        {
            buttonToolTipText.text = "Press [F]";
            nearClerk = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Robbery") && nearClerk == true)
        {
            buttonToolTipText.text = "";
            nearClerk = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Robbery") && nearClerk == true && TrashCanScript.instance.trashLooted == true && Input.GetKeyDown(KeyCode.F) && isClearkScared == false)
        {
            bankClerk.sprite = scaredSprite;
            inventoryText.text += "\n" + "vault code";
            isClearkScared = true;
        }
    }
}
