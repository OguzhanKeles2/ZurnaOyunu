using UnityEngine;

public class hareket : MonoBehaviour
{
    public bl_Joystick joystick;
    public float speed = 5f;
    public float rotationSpeed = 10f;

    private Rigidbody rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>(); // child'da da arar
    }

    void FixedUpdate()
    {
        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        Vector3 move = new Vector3(x, 0f, z);

        // 0-1 arası değer gönderiyoruz
        float currentSpeed = move.magnitude;

        anim.SetFloat("Speed", currentSpeed);

        if (move.magnitude > 0.1f)
        {
            Vector3 moveDirection = move.normalized;

            rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.MoveRotation(
                Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime)
            );
        }
        else
        {
            anim.SetFloat("Speed", 0f);
        }
    }
}