using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



public class ElephantController : MonoBehaviour
{
    // Declare Variables
    private Rigidbody rb;
    private Animator anim;
    public float moveSpeed;
    
    public float turnSmoothTime = 0.1f;
    public Transform cam;
    float turnSmoothVelcoity;

    private Vector3 takePos;
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
    }


    private void LateUpdate()
    {
       //Animal Walk Animation Control

      if (takePos != transform.position && rectTransform.position != joyStickPos)
      {
          anim.SetBool("walk", true);
      }
      else
      {
          anim.SetBool("walk", false);
      }
     }

    void Movement()
    {
        //Get Axis
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        //Calculate Direction
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
}
