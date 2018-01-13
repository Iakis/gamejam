using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockPlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    int color;
    int colour;
    int shape;
    private Material m_Material;

    private Color[] colo = { Color.red, Color.blue, Color.green, Color.yellow };

    // Use this for initialization
    void Start ()
    {
        color = 0;
        shape = 0;
        rb = GetComponent<Rigidbody>();
        m_Material = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            colour = Random.Range(0, 3);
            m_Material.color = colo[colour];

        }

        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(dirX, 0.0f, dirY);
        rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, -0.24f - 16.55f / 2f + 2f, -0.24f + 16.55f / 2f - 2f),
            rb.position.y,
            rb.position.z
         );

        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Wall wall = other.gameObject.GetComponent<Wall>();
            int wall_color = wall.colour;
            int wall_shape = wall.shape;

            if (color != wall_color)
            {
                Debug.Log("Wrong shape!");
                transform.localPosition = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z - 1);
            }
        }
    }
}
