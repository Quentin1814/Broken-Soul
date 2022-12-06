using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeroGravity : MonoBehaviour
{
    public float gravity = 1.4f;
    public Rigidbody2D rb;
    public bool isZeroGravity = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            isZeroGravity = true;
            rb.gravityScale = -gravity;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            isZeroGravity = false;
            rb.gravityScale = gravity;
        }
    }
}
