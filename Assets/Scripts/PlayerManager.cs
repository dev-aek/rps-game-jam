using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

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

    public GameObject steirsLav;

    [SerializeField] TextMeshProUGUI kristalText;

    [SerializeField] int kristal;
    [SerializeField] int buzBall;

    [SerializeField] GameObject Steirs;

    public bool[] elements;
    //public int buzTýlsýmý;
    //public int LavaTýlsýmý;
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
        if (other.transform.CompareTag("ChestArea") && number == 2 && kristal >= 3)
        {
            chestAnimator.SetBool("OpenChest", true);
            Steirs.SetActive(true);
            Debug.Log("Test");  
            // ilk adý mor
        }
        if (other.transform.CompareTag("ChestArea") && number == 3)
        {
            chestAnimator.SetBool("OpenChest", true);
            Debug.Log("Buz Týlsýmýný aldýk");
            //DefultMap(1);
            elements[0] = true;
            // mor adanýn üstü
        }
        if (other.gameObject.CompareTag("BuzBall"))
        {
            buzBall += 1;
            UpdateBuz();
            Destroy(other.gameObject);
            if (buzBall >= 3)
            {
                steirsLav.SetActive(false);
            }
        }
        if (other.transform.CompareTag("ChestArea") && number == 1)
        {
            chestAnimator.SetBool("OpenChest", true);
            elements[1] = true;
            Debug.Log("Lav Týlsýmýný aldýk");
        }
        if (other.transform.CompareTag("ChestArea") && number == 4)
        {
            chestAnimator.SetBool("OpenChest", true);
            elements[2] = true;
            Debug.Log("Toprak Týlsýmýný aldýk");
        }
        if (other.transform.CompareTag("ChestArea") && number == 5)
        {
            chestAnimator.SetBool("OpenChest", true);
            elements[3] = true;
            Debug.Log("Hava Týlsýmýný aldýk");
        }
        if (other.transform.CompareTag("ChestArea") && number == 6)
        {
            chestAnimator.SetBool("OpenChest", true);
            elements[4] = true;
            Debug.Log("Default Týlsýmýný aldýk");
            other.transform.DOMoveY(0,2f);

        }

        if (other.gameObject.CompareTag("Dead"))
        {
            Debug.Log("Öldün");
            this.transform.position = new Vector3(-7, 2, 10);
        }

        if (other.gameObject.tag == "Boost")
        {
            if (BallManager.isBoosed)
            {
                transform.DOMoveY(13, 3f);
                //gravity = 5;
                Debug.Log("Boost");
            }

        }
    }

    public void UpdateKristal()
    {
        kristalText.text = kristal.ToString();
    }
    public void UpdateBuz()
    {
        kristalText.text = buzBall.ToString();
    }

    public void SunakCheck()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i])
            {
                elements[i] = false;
                //sunak açýlacak
                
            } 
        }
    }


}