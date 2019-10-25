using UnityEngine;

public class Vacuum : MonoBehaviour
{
    [SerializeField] private Effector2D effector;
    [SerializeField] private GameObject particles;
    [SerializeField] private Animator animator;

    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform spawnPoint;
    public float force;

    private bool canShoot = true;

    [SerializeField] private AudioClip canonShoot;

    private void Update()
    {
        Suction();
        Reverse();
    }

    private void Suction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {            
            effector.enabled = true;
            particles.SetActive(true);
            animator.enabled = true;
            SoundPlayer.instance.PlayVacuumLoop();
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            effector.enabled = false;
            particles.SetActive(false);
            animator.enabled = false;
            SoundPlayer.instance.StopVacuumLoop();
        }        
    }

    private void Reverse()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            Slime slime = inventory.GetSlime();
            if (slime != null)
            {
                slime.transform.position = spawnPoint.position;
                slime.gameObject.SetActive(true);
                slime.rb2d.AddForce(transform.right * force, ForceMode2D.Impulse);

                SoundPlayer.instance.PlaySFX(canonShoot);
            }
            else
            {
                //Toca som de tiro seco?
            }
        }
    }

    public void SetCanShoot(bool _canShoot)
    {
        canShoot = _canShoot;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(effector.enabled && other.CompareTag("Slime"))
        {
            inventory.AddSlime(other.GetComponent<Slime>());
        }
    }
}
