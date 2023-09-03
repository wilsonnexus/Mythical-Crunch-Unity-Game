using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;

    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Keyboard
        // myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.fixedDeltaTime / transform.localScale.x;
        myRB.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")).normalized * speed * Time.fixedDeltaTime / transform.localScale.x;

        myAnim.SetFloat("moveX", myRB.velocity.x);
        myAnim.SetFloat("moveY", myRB.velocity.y);

        // Keyboard
        /*if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }*/
        if (CrossPlatformInputManager.GetAxis("Horizontal") == 1 || CrossPlatformInputManager.GetAxis("Horizontal") == -1 || CrossPlatformInputManager.GetAxis("Vertical") == 1 || CrossPlatformInputManager.GetAxis("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", CrossPlatformInputManager.GetAxis("Horizontal"));
            myAnim.SetFloat("lastMoveY", CrossPlatformInputManager.GetAxis("Vertical"));
        }
    }
}
