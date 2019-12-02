using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zamboni : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D myRigidBody;
    PolygonCollider2D myPolyCollider;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myPolyCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
            if (myPolyCollider.IsTouchingLayers(LayerMask.GetMask("Zamboni")))
        {
            transform.localScale = new Vector2((Mathf.Sign(myRigidBody.velocity.x)), 1f);
        }
            if (IsFacingLeft())
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }

    }

    bool IsFacingLeft()
    {
        if (transform.localScale.x > 0)
        {
            return true;
        }
        return false;
    }

}
