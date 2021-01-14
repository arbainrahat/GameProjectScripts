using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;

public class CatController : MonoBehaviour
{
    // Declare Variables
    private Rigidbody rb;
    private Animator anim;
    public float rotateSpeed;
    public float moveSpeed;
    public float jumpHieght;
    public float jumpDelay;
    public float runSpeed;
    public float jumpMultiplier;
    public GameObject catHand;
    public GameObject freeLoockCamera;
    //Ground Check Distance
    public float groundDistance = 1f;

     public float turnSmoothTime = 0.1f;
    public Transform cam;
    float turnSmoothVelcoity;
    bool grounded = true;
    private Vector3 direction;
    private Vector3 takePos;
  [SerializeField] bool runBtnPressed=false;
   bool jumpCheck = false;
  
   Vector3 joyStickPos;

    public RectTransform rectTransform;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        joyStickPos = rectTransform.GetComponent<RectTransform>().position;
    }


    private void FixedUpdate()
    {
      
        takePos = transform.position;
       
       
            Movement();
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpMobileButton();
        }

        if (runBtnPressed == true)
        {
            transform.position += transform.forward * runSpeed * Time.deltaTime;     
        }

        if (jumpCheck == true && rectTransform.position!=joyStickPos)
        {
            transform.position += transform.forward * jumpMultiplier * Time.deltaTime;
        }
    }


    private void LateUpdate()
    {
       
            if (takePos != transform.position && rectTransform.position != joyStickPos)
            {
                anim.SetBool("walk", true);
            }
            else
            {
                anim.SetBool("walk", false);
            }
     
    }

    //Detect walls and stop run
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            runEnd();
            //Debug.Log("Hit wall");
        }
    }

    void Movement()
    {

        //float horizontalMove = Input.GetAxis("Horizontal");
        //float verticalMove = Input.GetAxis("Vertical");


        // float horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal");
        // float verticalMove = CrossPlatformInputManager.GetAxis("Vertical");
        // direction = new Vector3(horizontalMove, 0f, verticalMove);
        //
        // if (direction != Vector3.zero)
        // {
        //     transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
        // }


        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelcoity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //rotate the player with camera;
            Vector3 movDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

            //controller.Move(movDir * speed * Time.deltaTime);

            rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * movDir);

        }
    }

    //Jump with Touchbutton

     public  void JumpMobileButton()
     {
        //Set Camera speed 1f
       // freeLoockCamera.GetComponent<FreeLookCam>().SetSpeed1();
     jumpCheck = true;
     anim.SetBool("jump", true);
        // grounded = true;
        GroundStatus();
     StartCoroutine(jumpHieghtDelay());
        Invoke("animJumpStop", jumpDelay);
     }

    void animJumpStop()
    {
        jumpCheck = false;
        
        anim.SetBool("jump", false);
        //Set Camera speed 120f
       // freeLoockCamera.GetComponent<FreeLookCam>().SetSpeed120();
    }

    IEnumerator jumpHieghtDelay()
    {

        //  yield return new WaitForSeconds(0.2f);

        //  transform.position = new Vector3(transform.position.x, transform.position.y+jumpHieght, transform.position.z);
        yield return null;
        if (grounded == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHieght, rb.velocity.z);
            grounded = false;
        }
    }
    
    //Ground check
    void GroundStatus()
    {
        RaycastHit hitInfo;
        Ray hit = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(hit, out hitInfo, groundDistance))
        {
            grounded = true;
        }
    }

   public void runStart()
    {
        runBtnPressed = true;
        anim.SetBool("run", true);

        
    }

    public void runEnd()
    {
        runBtnPressed = false;
        anim.SetBool("run", false);
    }
    //Attack Function
    public void Attack()
    {
        StartCoroutine(attack());
    }
    IEnumerator attack()
    {
        gameObject.GetComponent<Animator>().SetTrigger("punch");
        AttackBegin();
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Animator>().SetTrigger("idle");
        AttackEnd();

    }

     void AttackBegin()
    {
        catHand.GetComponent<CapsuleCollider>().enabled = true;

    }
    void AttackEnd()
    {

        catHand.GetComponent<CapsuleCollider>().enabled = false;
    }
}
