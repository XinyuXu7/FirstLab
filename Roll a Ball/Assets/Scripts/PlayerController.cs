using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public Vector3 position1;
    public Vector3 position2;
    public float speed;
    private int count;
    private int numPickups = 5;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI velocity;
    public float v;
    public TextMeshProUGUI position;
    public TextMeshProUGUI Distance;

    private void Start()
    {
        count = 0;
        winText.text = " ";
        SetCountText ();
        position1 = this.transform.position;
    }


    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();
        if(count >= numPickups)
        {
            winText.text = "You win!";
        }
    }

    void Setposition()
    {
        position.text = "position: " + this.transform.localPosition.ToString();
    }

    void Setvelocity()
    {
        position2 = this.transform.position;
        v = (position2 - position1).magnitude / Time.deltaTime;
        velocity.text = "velocity: " + v;
        position1 = position2;
    }

    private void Update()
    {
        Setposition();
        Setvelocity();
    }

}
