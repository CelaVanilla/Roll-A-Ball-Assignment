using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //Modified in the direction of survival and collecting all pickups
    //Counter decrease included for display but deduction to counter doesn't affect victory

    public float speed;
    public Text countText;
    public Text winText;
    public Text totalText;
    public Text loseText;
    public Text hp;

    private Rigidbody rb;
    private int count;
    private int total;
    private int health = 3;
    private GameObject plane;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        total = 0;
        SetCountText();
        SetPlayerCount();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            total = total + 1;
            count = count + 1;
            SetCountText();
            SetPlayerCount();
            Health();

        }
        if (other.gameObject.CompareTag("Enemy Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            health = health - 1;
            SetCountText();
            Health();
        }
    }

    void SetPlayerCount()
    {
        totalText.text = "Total: " + total.ToString();
        if (total >= 8)
        {
            plane = GameObject.FindWithTag("Plane");
            plane.gameObject.SetActive(false);
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        hp.text = "Health: " + health.ToString() + " HP";

        if (total>= 18)
        {
                        winText.text = "You Win!";
        }
    }

    void Health()
    {
        if (health ==0)
        {
            loseText.text = "You Lose...";
            player = GameObject.FindWithTag("Player");
            player.gameObject.SetActive(false);
        }
    }
}
