﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float walkSpeed;
    public float rotateSpeed;
    public float damageRate;
    public float health;
    bool IsAlive = true;


    public Animator playerAnim;
    public Rigidbody playerRb;

    public GameObject bulletPrefab;
    public GameObject bulletSpawn;


    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        //healthPointText.GetComponent<Text>().text = "Start Function";
        //healthPointText.GetComponent<Text>().text = "Health: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAlive == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) //go forward
            {
                transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
                transform.rotation = Quaternion.Euler(0, 0 + rotateSpeed, 0);
                playerAnim.SetFloat("RunSpeed", 10);
            }
            
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // go backward
            {
                transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
                transform.rotation = Quaternion.Euler(0, 180 + rotateSpeed, 0);
                playerAnim.SetFloat("RunSpeed", 10);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // go leftside
            {
                //transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
                //transform.rotation = Quaternion.Euler(0, -90 + rotateSpeed, 0);
                transform.Rotate(new Vector3(0, Time.deltaTime * -rotateSpeed, 0));
                playerAnim.SetFloat("RunSpeed", 10);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // go rightside
            {
                //transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
                //transform.rotation = Quaternion.Euler(0, 90 + rotateSpeed, 0);
                transform.Rotate(new Vector3(0, Time.deltaTime * rotateSpeed, 0));
                playerAnim.SetFloat("RunSpeed", 10);
            }

            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) // stop walking
            {
                playerAnim.SetFloat("RunSpeed", 0);
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) // stop walking
            {
                playerAnim.SetFloat("RunSpeed", 0);
            }

            if (Input.GetKeyDown(KeyCode.Space)) //Attack
            {
                Debug.Log("Hey");
                Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
                playerAnim.SetTrigger("ShootTrigger");
            }

           
        }

    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Fire" && IsAlive == true)
    //    {
    //        health -= damageRate * Time.deltaTime;
    //        healthPointText.GetComponent<Text>().text = "Health: " + health.ToString();
    //        if (health <= 0)
    //        {
    //            healthPointText.GetComponent<Text>().text = "Health: 0";
    //            playerAnim.SetTrigger("DeadTrigger");
    //            IsAlive = false;
    //        }
    //    }
    //}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Hello");
        }

    }




}