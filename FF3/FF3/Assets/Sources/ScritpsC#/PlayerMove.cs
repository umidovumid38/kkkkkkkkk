using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private int Speed;
    public int SpeedWalk;
    public int SpeedRun;
    public int jumpForce = 10;
    public Transform Pivot;
    public Rigidbody playerRigidbody;
    public GameObject PanelDead;
    private bool isGround;
    public float luchDistance = 0.2f;
    public AudioClip djPlayerMove;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PanelDead.SetActive(false);
    }

    void FixedUpdate()
    {
        Move();
        jumb();
    }
    private void jumb()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, luchDistance);
        // &&  = и еще 
        if (Input.GetKey(KeyCode.Space) && isGround == true)
        {
            DJ.Instance.PlayAudio(djPlayerMove);
            playerRigidbody.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
        }
    }


    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal") * Run();
        float inputZ = Input.GetAxis("Vertical") * Run();

        Vector3 direction = Pivot.forward * inputZ + Pivot.right * inputX;
        direction.y = playerRigidbody.velocity.y;
        playerRigidbody.velocity = direction;
    }
    public float Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return SpeedRun * Time.deltaTime;
        }
        else
        {
            return SpeedWalk * Time.deltaTime;
        }
    }
    public void Dead()
    {
        PanelDead.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Destroy(gameObject);
    }
}

