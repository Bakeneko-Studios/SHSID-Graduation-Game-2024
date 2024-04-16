using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodOnClick : MonoBehaviour
{
    private float initialUpwardForce;
    private bool clicked;
    private float rotationSpeed;

    private Rigidbody2D rb;

    void Awake(){
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer, true);
        initialUpwardForce = Random.Range(0f, 4f);
        rotationSpeed = Random.Range(-50f, 50f);        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(clicked){
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if(gameObject.transform.position.y < -15){
            Destroy(gameObject);
        }
    }
    private void OnMouseDown(){
        clicked = true;
        gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Falling Food");
        rb.gravityScale = 1.3f;
        rb.AddForce(Vector2.up * initialUpwardForce, ForceMode2D.Impulse);
        Destroy(gameObject.GetComponent<PolygonCollider2D>());
    }
}
