using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;
    public GameObject bottomLeftLimitGameobject;
    public GameObject topRightLimitGameobject;
    public Vector3 bottomLeftLimit;
    public Vector3 topRightLimit;
    private Vector2 input;

    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        bottomLeftLimit = bottomLeftLimitGameobject.transform.position;
        topRightLimit = topRightLimitGameobject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
        if (transform.position.x <= bottomLeftLimit.x && input.x == -1 || transform.position.x >= topRightLimit.x && input.x == 1)
        {
            input.x = 0;
        }
        if (transform.position.y <= bottomLeftLimit.y && input.y == -1 || transform.position.y >= topRightLimit.y && input.y == 1)
        {
            input.y = 0;
        }
        // Keyboard
        // myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.fixedDeltaTime / transform.localScale.x;
        myRB.velocity = new Vector2(input.x, input.y).normalized * speed * Time.fixedDeltaTime / transform.localScale.x;

        myAnim.SetFloat("moveX", myRB.velocity.x);
        myAnim.SetFloat("moveY", myRB.velocity.y);

        // Keyboard
        /*if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }*/
        if (input.x == 1 || input.x == -1 || input.y == 1 || input.y == -1)
        {
            myAnim.SetFloat("lastMoveX", input.x);
            myAnim.SetFloat("lastMoveY", input.y);
        }
    }
}
