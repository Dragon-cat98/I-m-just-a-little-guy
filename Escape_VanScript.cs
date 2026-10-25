using UnityEngine;
using TMPro;
using System.Collections;
public class Escape_VanScript : MonoBehaviour
{
    public TextMeshProUGUI inventoryText;
    public TextMeshProUGUI buttonToolTipText;
    public GameObject WinPanel;
    public bool nearVan;
    public Animator animator;
    public Animator animator2;
    public GameObject littleGuy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && cop_trigger_script.instance.copDefused == true && nearVan == false)
        {
            buttonToolTipText.text = "Press [F]";
            nearVan = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && cop_trigger_script.instance.copDefused == true && nearVan == true)
        {
            buttonToolTipText.text = "";
            nearVan = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player") && nearVan == true && Input.GetKeyDown(KeyCode.F))
        {
            animator.Play("escape");
            animator2.Play("Hit&Run");
            littleGuy.SetActive(false);
            StartCoroutine(winPanel());
        }
    }

    IEnumerator winPanel()
    {
        yield return new WaitForSeconds(3f);
        WinPanel.SetActive(true);
    }
}
