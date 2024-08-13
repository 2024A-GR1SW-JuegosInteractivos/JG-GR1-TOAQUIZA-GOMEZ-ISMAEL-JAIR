using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranjeroScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, moveY, 0);
        // Cambiar la posición
        if (moveX != 0 || moveY != 0)
        {
            animator.SetFloat("Horizontal", moveX);
            animator.SetFloat("Vertical", moveY);
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed",0);
        }
    }
}