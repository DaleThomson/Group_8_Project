using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform playerCam;
    [SerializeField] float mouseSens = 3.5f;
    [SerializeField] float mouseMinY = -90.0f;
    [SerializeField] float mouseMaxY = 90.0f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float sprintSpeed = 9.0f;
    [SerializeField] float gravScale = -.0f;
    [SerializeField] float jumpForce = 20.0f;
    [SerializeField] float slopeGrav;
    [SerializeField] float slopeGravRay;
    [SerializeField] [Range(0.0f, 0.5f)] float camSmooth = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmooth = 0.03f;
    [SerializeField] float stamina = 10.0f;
    [SerializeField] float exhaustion = 20.0f;
    [SerializeField] bool exhausted = false;
    [SerializeField] public static bool camera = true;
    private bool playerMoving;

    public GameObject hireUI;
    public AudioSource playerAudio, surfaceAudio;
    public AudioClip jumpSound, exhaustionSound, carpetWalk, concreteWalk, metalWalk, currentClip;
    float camPitch = 0.0f;
    float velY = 0.0f;
    CharacterController player;

    Vector2 currDirection = Vector2.zero;
    Vector2 currDirectionVel = Vector2.zero;

    Vector2 currMouseDelta = Vector2.zero;
    Vector2 currMouseDeltaVel = Vector2.zero;

    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void hireMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (hireUI.active)
            {
                camera = true;
                hireUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
            else if (!hireUI.active)
            {
                camera = false;
                hireUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        hireMenu();
        updateMouseLook();
        updatePlayerMovement();
        currentClip = playerAudio.clip;
    }

    bool onSlope()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, player.height / 2 * slopeGravRay))
        {
            if (hit.normal != Vector3.up)
            {
                return true;
            }
        }
        return false;
    }

    bool sprinting()
    {
        if (!exhausted)
        {
            if (Input.GetAxisRaw("Sprint") == 1)
            {
                return true;
            }
        }
        return false;
    }

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.tag == "Carpet")
        {
            if (playerMoving && player.isGrounded)
            {
                surfaceAudio.clip = carpetWalk;
                if (!surfaceAudio.isPlaying)
                {
                    surfaceAudio.Play();
                }
            }
        }

        if (col.gameObject.tag == "Concrete")
        {
            if (playerMoving && player.isGrounded)
            {
                surfaceAudio.clip = concreteWalk;
                if (!surfaceAudio.isPlaying)
                {
                    surfaceAudio.Play();
                }
            }
        }

        if (col.gameObject.tag == "Metal")
        {
            if (gameObject.transform.position.y >= col.gameObject.transform.position.y + 2)
            {
                if (playerMoving && player.isGrounded)
                {
                    surfaceAudio.clip = metalWalk;
                    if (!surfaceAudio.isPlaying)
                    {
                        surfaceAudio.Play();
                    }
                }
            }
        }

        if (col.gameObject.tag == "Walkway")
        {
            if (playerMoving && player.isGrounded)
            {
                surfaceAudio.clip = metalWalk;
                if (!surfaceAudio.isPlaying)
                {
                    surfaceAudio.Play();
                }
            }
        }
    }

    void updateMouseLook()
    {
        if (camera)
        {
            Vector2 target = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            currMouseDelta = Vector2.SmoothDamp(currMouseDelta, target, ref currMouseDeltaVel, camSmooth);

            camPitch -= target.y * mouseSens;

            camPitch = Mathf.Clamp(camPitch, mouseMinY, mouseMaxY);

            playerCam.localEulerAngles = Vector3.right * camPitch;

            transform.Rotate(Vector3.up * target.x * mouseSens);
        }
    }

    void updatePlayerMovement()
    {
        Vector2 target = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        target.Normalize();

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            playerMoving = true;
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            playerMoving = true;
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            playerMoving = false;
        }

        currDirection = Vector2.SmoothDamp(currDirection, target, ref currDirectionVel, moveSmooth);

        if ((currDirection.x != 0 || currDirection.y != 0) && onSlope())
        {
            player.Move(Vector3.down * player.height / 2 * slopeGrav * Time.deltaTime);
        }


        float velY = velocity.y;
        velocity = (transform.forward * currDirection.y + transform.right * currDirection.x) * walkSpeed;
        velocity.y = velY;

        if (player.isGrounded && !exhausted)
        {
            if (Input.GetButtonDown("Jump"))
            {
                playerAudio.clip = jumpSound;
                playerAudio.Play();
                velocity.y = jumpForce;
            }
        }


        //velY += Physics.gravity.y * Time.deltaTime;

        stamina = Mathf.Clamp(stamina, 0f, 10f);

        if (sprinting())
        {
            stamina -= Time.deltaTime;
            walkSpeed = sprintSpeed;
        }
        else if (!sprinting())
        {
            stamina += Time.deltaTime;
            walkSpeed = 6.0f;
        }

        if (stamina <= 0)
        {
            exhaustion = 20.0f;
            exhausted = true;
        }

        if (exhausted)
        {
            exhaustion -= Time.deltaTime;
            if (!playerAudio.isPlaying)
            {
                playerAudio.clip = exhaustionSound;
                playerAudio.Play();
            }
            if (exhaustion <= 0)
            {
                playerAudio.Stop();
                exhausted = false;
                exhaustion = 20.0f;
            }
        }

        if (!player.isGrounded)
        {
            velocity.y = velocity.y + (Physics.gravity.y * 5 * Time.deltaTime);
        }


        player.Move(velocity * Time.deltaTime);
    }
}
