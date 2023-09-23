using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Cow : MonoBehaviour
{
    public float speedcow = 1;
    public float delay = 2;
    float timer = 0;
    public Animator animatorcow;

    private Vector3 directioncow;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > delay)
        {
            Movecow();
            timer = 0;
        }
    }
    public void Movecow()
    {
        float horizontalcow = Random.Range(-1,2);
        float verticalcow = Random.Range(-1,2);
        directioncow = new Vector2(horizontalcow, verticalcow);
        directioncow = directioncow.normalized;

        AnimateMovement(directioncow);

        transform.position += directioncow * speedcow * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        this.transform.position += directioncow * speedcow * Time.deltaTime;
    }

    void AnimateMovement(Vector3 directioncow)
    {
        if(animatorcow != null)
        {
            if(directioncow.magnitude > 0)
            {
                animatorcow.SetBool("isMovingcow", true);
                animatorcow.SetFloat("horizontalcow", directioncow.x);
                animatorcow.SetFloat("verticalcow", directioncow.y);
            }
            else
            {
                animatorcow.SetBool("isMovingcow", false);
            }
        }
    }
}

