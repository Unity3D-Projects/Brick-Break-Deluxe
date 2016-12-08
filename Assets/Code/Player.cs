﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text score;
    public float speed, gravityModifier;
    public bool speedBrickEffect = false;

    private Vector3 gravityOriginal;

    // Use this for initialization
    void Start()
    {
        gravityOriginal = new Vector3(0, -9.81f, 0);
        Physics2D.gravity = gravityOriginal;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > 3.6 || this.transform.position.x < -3.6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
        score.text = "Score: " + (3 + (int)this.transform.position.y * (-1));

        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.acceleration.x * speed, 0));
    }

    public void SpeedBrickModeEnabled()
    {
        speedBrickEffect = true;
        Physics2D.gravity = Physics2D.gravity * gravityModifier;
        StopCoroutine(SpeedBrickTimer());
        StartCoroutine(SpeedBrickTimer());
    }

    IEnumerator SpeedBrickTimer()
    {
        yield return new WaitForSeconds(15);
        speedBrickEffect = false;
        Physics2D.gravity = gravityOriginal;
    }

}