using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{


    public CharacterController controller;
    public CharacterController characterCollider;
    public Camera camera;

    private bool crouching_fixed;

    private float lastRegen;
    private float staminaRegenSpeed = 1f;
    private float staminaRegenAmount = 1f;
    private bool isSprinting = false;
    private bool isCrouching = false;

    public float speed = 8.3f;
    public float sprintMultiplier = 1.2f;
    public float stamina = 5f;
    private float stamina_limit;
    private float sprint_speed;
    public float gravity = -9.81f;
    public float jumpStrength = 3f;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool jumpCheck;

    private void Start()
    {
        stamina_limit = stamina;
        sprint_speed = sprintMultiplier;
        characterCollider = gameObject.GetComponent<CharacterController>();

    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded == true)
        {
            jumpCheck = true;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (isCrouching == true)
        {
            controller.Move(move * speed/2 * Time.deltaTime);
        } else
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0.1 && isCrouching == false) //sprint
        {
            controller.Move(move * speed * Time.deltaTime * sprintMultiplier);
            stamina -= 0.8f * Time.deltaTime;
            Debug.Log("Sprinting");
            isSprinting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }

        if (Input.GetKey(KeyCode.C)) //crouch 
        {
            isCrouching = true;
            characterCollider.height = 1.5f;
            Vector3 temp = new Vector3(0, 0.366f, 0.334f);
            camera.transform.localPosition = temp;
            crouching_fixed = false;
        }
        else if (crouching_fixed == false)
        {
            isCrouching = false;
            characterCollider.height = 2.0f;
            Vector3 temp = new Vector3(0, 0.681f, 0.334f);
            camera.transform.localPosition = temp;
            crouching_fixed = true;
        }

        if (stamina < stamina_limit && isSprinting == false)   //only recovers stamina if its below limit
        {
            RecoverStamina();
        }
        


        if (Input.GetButtonDown("Jump") && jumpCheck == true) //jump
        {
            velocity.y = Mathf.Sqrt(jumpStrength * -2f * gravity);
            jumpCheck = false;
            Debug.Log("Jump!");
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    void RecoverStamina()
    {
        if(Time.time - lastRegen > staminaRegenSpeed)
        {
            stamina += staminaRegenAmount;
            lastRegen = Time.time;
        }

        if (stamina > 5f)
        {
            stamina = 5f;
        }
    }


}