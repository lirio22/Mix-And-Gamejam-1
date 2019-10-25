using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public Rigidbody2D rb2d;
    public Sprite icon;

    public int slimeType;

    [SerializeField] private AudioClip bounceSound;
    [SerializeField] private AudioClip balloonPoped;

    public int scoreMultiplier = 1;

    private void Start()
    {
        animator.Play("SlimeShowing");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("ComboReset"))
        {
            scoreMultiplier = 1;
        }

        if(other.CompareTag("Target"))
        {
            //Gets target component from object
            Target target = other.GetComponent<Target>();

            //If the slime and target are from the same type, and if the target is still active
            if(target.targetType == slimeType && target.isGrowing)
            {
                //Calls the event that destroys the target and gives points
                SoundPlayer.instance.PlaySFX(balloonPoped);
                target.TargetDestroyed(100 * scoreMultiplier);
                scoreMultiplier++;
            }
        }       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            SoundPlayer.instance.PlaySFX(bounceSound);
        }
    }
}