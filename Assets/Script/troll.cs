using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class troll : MonoBehaviour
{
    private float portalUp = -87;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.transform.position += new Vector3(0, portalUp, 0);
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
        }
    }
}
