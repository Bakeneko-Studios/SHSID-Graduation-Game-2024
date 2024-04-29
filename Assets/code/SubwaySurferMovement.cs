using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwaySurferMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public float laneSpeed = 25f;
    public float distanceTraveled;
    private float[] LanePosition;
    private int currentLane = 1;
    private Rigidbody rb;
    public float jumpForce = 5f;
    public float groundCheckDistance = 0.01f;
    public LayerMask groundLayer;
    public Transform Player;
    //public bool isGrounded = true;

    void Start() {
        LanePosition = GameObject.Find("GameManager").GetComponent<SubwaySurferGameManager>().LanePosition;
        distanceTraveled = transform.position.z;
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.D) && currentLane < LanePosition.Length) {
            currentLane ++;
        }
        else if (Input.GetKeyDown(KeyCode.A) && currentLane > 0) {
            currentLane --;
        }
        moveCharacter();
        
        if(Input.GetKeyDown(KeyCode.W) && isGrounded()) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        } 
        else if(Input.GetKeyDown(KeyCode.S) && isGrounded()) {
            Player.localScale = new Vector3(1f,0.4f,1f);
        }
        if (Input.GetKeyUp(KeyCode.S)) {
            Player.localScale = new Vector3(1f,1f,1f);
        }
    }

    void moveCharacter() {
        distanceTraveled += speed * Time.deltaTime; 
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, LanePosition[currentLane], Time.deltaTime * laneSpeed), transform.position.y, distanceTraveled);
    }
    bool isGrounded() {
        // Perform a raycast downwards to check if the character is grounded
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }
    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.gameObject.layer==groundLayer)
    //         isGrounded=true;
    // }
    // private void OnCollisionExit2D(Collision2D other) {
    //     Debug.Log("e");
    //     if(other.gameObject.layer==groundLayer)
    //     isGrounded=false;
    // }
}
