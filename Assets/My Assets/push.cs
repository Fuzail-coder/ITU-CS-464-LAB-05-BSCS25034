using UnityEngine;

public class push : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rb;
    //bool kick = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            kick = true;
        }
    }*/
    void FixedUpdate()
    {
        //if (!kick) return;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(x, 0, z) * speed);
    }
}
