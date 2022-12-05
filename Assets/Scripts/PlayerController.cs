using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    PhotonView pv;
    Animator anim;
    float horizontal;
    float vertical;
    Vector3 Direction;
    float CurrentTurnAngle;
    float SmoothTurnTime = 0.1f;
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    void Start()
    {
        pv = GetComponent<PhotonView>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (pv.IsMine) {
        //     // Move();
        //     // Jump();
        // }
    }
    // void Move()
    // {
    //     transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * 20f);
    //     transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * 20f);

    //     // anim.SetFloat("Running", 0.2f);
    // }

    // void Jump()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);

    //     }
    // }

    private void FixedUpdate()
    {
        if (pv.IsMine) {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            Direction = new Vector3(horizontal, 0, vertical);

            anim.SetFloat($"Running", Direction.magnitude);

            if (Direction.magnitude > 0.01f)
            {
                float TargetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg;
                float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref CurrentTurnAngle, SmoothTurnTime);
                transform.rotation = Quaternion.Euler(0, Angle, 0);

                rb.MovePosition(transform.position + (Direction * speed * Time.deltaTime));
            }
        }


    }
}
