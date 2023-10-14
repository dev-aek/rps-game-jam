using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform cam;
    private float turnSpeedTime = .1f;
    private float turnSmoothVelocity;
    Rigidbody rgb;
    CharacterController controller;
    public Animator animator;
    public Animator chestAnimator;
    int number;
    public float jumpHeight;
    public float gravity;
    bool isGrounded;
    Vector3 velocity;
    private ChestManager chest;

    [SerializeField] TextMeshProUGUI kristalText;

    [SerializeField] int kristal;

    [SerializeField] GameObject Steirs;


    private void Awake()
    {
        rgb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, .1f, 1);

        animator.SetBool("Jump", !isGrounded);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1;
        }


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            //
            if (isGrounded)
            {
                animator.SetBool("Run", true);
            }
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSpeedTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            // ýdle
            animator.SetBool("Run", false);
        }
        //jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt((jumpHeight * 10) * -2f * gravity);
            animator.SetBool("Run", false);
        }

        if (velocity.y > -20)
        {
            velocity.y += (gravity * 10) * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<ChestManager>() != null)
        {
            number = other.gameObject.GetComponent<ChestManager>().ChestNumber;
        }
        if (other.GetComponentInChildren<Animator>() != null)
        {
            chestAnimator = other.GetComponentInChildren<Animator>();
        }

        if (other.gameObject.CompareTag("KristalBall"))
        {
            kristal += 1;
            UpdateKristal();
            Destroy(other.gameObject);
        }
        if (other.transform.CompareTag("ChestArea") && number == 1)
        {
            chestAnimator.SetBool("OpenChest", true);
        }
        if (other.transform.CompareTag("ChestArea") && number == 2 && kristal >= 3)
        {
            chestAnimator.SetBool("OpenChest", true);
            Steirs.SetActive(true);
            Debug.Log("Test");  
        }

    }

    public void UpdateKristal()
    {
        kristalText.text = kristal.ToString();
    }

}