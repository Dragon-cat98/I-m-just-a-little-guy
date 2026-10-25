using UnityEngine;

public class cop_trigger_script : MonoBehaviour
{
    public static cop_trigger_script instance;
    public GameObject cop_trigger;
    public bool copDefused;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            cop_trigger.SetActive(false);
            copDefused = true;
        }
    }


}
