using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class Move : MonoBehaviour
{
    public float speed, jumpHeight;

    Rigidbody rb;
    Vector2 input;

    public bool isGrounded;

    List<Vector3> normals;


    // Start is called before the first frame update
    void Start()
    {
        normals = new List<Vector3>(); 
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;

        }
        
    }
    void FixedUpdate()
    {


        normals.Clear();


            Vector3 move = input.x * Vector3.right + input.y * Vector3.forward;
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint cpoint in collision.contacts)
        {
            normals.Add(cpoint.normal);
            if(cpoint.normal.y > 0)
                isGrounded = true;
        }


    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        if(normals != null)
        {
            foreach (Vector3 normal in normals)
            {
                Gizmos.DrawLine(transform.position, transform.position + normal * 3);
            }

        }

    }

}
