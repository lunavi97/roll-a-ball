using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text score;
    public Text endOfGameText;
    private Rigidbody rb;
    private int pointCounter;
    private int initialQuantityOfItems;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        pointCounter = 0;
        UpdateScore();
        endOfGameText.gameObject.SetActive(false);
        initialQuantityOfItems = CountItems();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter (Collider other)
    {
        Destroy(other.gameObject);
        pointCounter++;
        UpdateScore();

        if (IsEndOfGame())
        {
            endOfGameText.gameObject.SetActive(true);
        }
    }

    private void UpdateScore ()
    {
        score.text = "Points: " + pointCounter;
    }

    private int CountItems()
    {
        return GameObject.FindGameObjectsWithTag("Item").Length;
    }

    private bool IsEndOfGame()
    {
        return pointCounter >= initialQuantityOfItems; 
    }

}
