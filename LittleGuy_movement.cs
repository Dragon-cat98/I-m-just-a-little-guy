using UnityEngine;

public class LittleGuy_movement : MonoBehaviour
{
    static LittleGuy_movement instance;
    public float speed = 5;
    private float movementX;
    private float movementY;
    private Vector2 MoveInput;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        MoveInput = new Vector2(movementX, movementY).normalized;

        rb.MovePosition(rb.position + MoveInput * speed * Time.deltaTime);

        if (DialogueManager.Instance.isDialogueActive)
        {
            speed = 0;
            return;
        }
        else
        {
            speed = 8.5f;
        }
    }
}
