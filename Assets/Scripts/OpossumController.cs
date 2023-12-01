using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    private Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFacingRight())
        {
            myRB.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRB.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRB.velocity.x)), transform.localScale.y);
    }
}
