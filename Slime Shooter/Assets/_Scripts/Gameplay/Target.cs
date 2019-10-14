using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameCore gameCore;
    public int targetType;

    public Collider2D col;
    public bool isGrowing = true;

    [SerializeField] private Score score;
    [SerializeField] private Tries tries;

    [SerializeField] private GameObject particlePile;
    private ParticleSystem particle;

    [SerializeField] private AudioClip balloonExplosion;

    private void OnEnable()
    {
        col.isTrigger = true;
        isGrowing = true;
        targetType = Random.Range(0, gameCore.maxType + 1);
        spriteRenderer.sprite = sprite[targetType];
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
        //Toca sons felizes
    }

    private void OnDisable()
    {
        gameCore.balloonQtd--;
    }
}
