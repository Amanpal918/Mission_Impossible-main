using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public PlayerController controller;
    public Animator anim;

    void Update()
    {
        // Sends data to the Animator window
        // Make sure your Animator Parameters match these names EXACTLY:
        // "IsRunning" (Bool)
        // "IsGrounded" (Bool)
        // "yVelocity" (Float)

        anim.SetBool("IsRunning", controller.IsRunning);
        anim.SetBool("IsGrounded", controller.IsGrounded);
        anim.SetFloat("yVelocity", controller.VerticalVelocity);
    }
}