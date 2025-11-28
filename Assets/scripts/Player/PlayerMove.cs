using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 3;
    public float sideSpeed;
    public static bool canMove = false;
    public bool isJump = false;
    public bool comingDown = false;
    public GameObject playerObject;
    public float jump_speed;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * runSpeed, Space.World);

        if (canMove == true)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * sideSpeed);
                }
            }


            if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * sideSpeed * -1);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isJump == false)
                {
                    isJump = true;
                    playerObject.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(jumpSequence());
                }
            }
        }

        if (isJump == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 7, Space.World);
                rb.AddForce(transform.up * jump_speed);
            }

            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -7.01f, Space.World);
            }
        }

    }

    IEnumerator jumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJump = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }
}
