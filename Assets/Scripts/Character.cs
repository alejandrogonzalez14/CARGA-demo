using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator anim;
    public CharacterController characterController;
    public float speed = 5f;
    public float rotationSpeed = 700f;  // Rotation speed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (move.magnitude > 0)  // Only rotate if moving
        {
            // Create a rotation based on the movement direction
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);

            // Smoothly rotate towards the movement direction
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            // manage animation
            anim.SetBool("walking", true);
            anim.SetBool("idle", false);
        } else
        {
            // manage animation
            anim.SetBool("idle", true);
            anim.SetBool("walking", false);
        }

        characterController.Move(move * Time.deltaTime * speed);
    }
}
