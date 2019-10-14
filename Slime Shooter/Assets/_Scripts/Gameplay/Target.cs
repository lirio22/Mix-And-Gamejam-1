using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameCore gameCore;
    public int targetType;

    public Collider2D col;
    public bool isGrowing = true;

    private float lifeTime;
    private float soundTimer = 0.6f;
    [SerializeField] private AudioClip alarm;

    [SerializeField] private Score score;
    [SerializeField] private Tries tries;

    [SerializeField] private GameObject particlePile;
    private ParticleSystem particle;

    [SerializeField] private AudioClip balloonExplosion;
    [SerializeField] private GameObject flashAnimation;

    private void OnEnable()
    {
        col.isTrigger = true;
        isGrowing = true;
        targetType = Random.Range(0, gameCore.maxType + 1);
        spriteRenderer.sprite = sprite[targetType];
        lifeTime = 8.0f;
    }

    private void Update()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 3)
            {
                soundTimer -= Time.deltaTime;
                if(soundTimer < 0)
                {
                    SoundPlayer.instance.PlaySFX(alarm);
                    soundTimer = 0.6f;
                }
            }
        }
    }

    public void TargetExplosion()
    {
        isGrowing = false;
        transform.parent.gameObject.SetActive(false);
        particle = particlePile.transform.GetChild(0).GetComponent<ParticleSystem>();
        particle.gameObject.transform.position = new Vector3(transform.parent.gameObject.transform.position.x, transform.parent.gameObject.transform.position.y, -1.0f);
        particle.Play();
        SoundPlayer.instance.PlaySFX(balloonExplosion);
        tries.RemoveTry();
    }

    public void TargetDestroyed()
    {
        isGrowing = false;
        col.isTrigger = false;
        particle = particlePile.transform.GetChild(0).GetComponent<ParticleSystem>();
        particle.gameObject.transform.position = transform.parent.gameObject.transform.position;
        particle.Play();
        transform.parent.gameObject.SetActive(false);      
        score.AddScore();
    }

    public void ActivateFlashAnimation()
    {
        flashAnimation.SetActive(true);
    }

    private void OnDisable()
    {
        flashAnimation.SetActive(false);
        gameCore.balloonQtd--;
    }
}
