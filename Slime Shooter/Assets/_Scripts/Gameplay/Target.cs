using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private Sprite[] whiteSprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameCore gameCore;
    [SerializeField] private SpriteRenderer flashEffect;
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

    [SerializeField] private GameObject pointsPile;
    private PointsUI pointsUI;

    private void OnEnable()
    {
        col.isTrigger = true;
        isGrowing = true;
        targetType = Random.Range(0, gameCore.maxType + 1);
        spriteRenderer.sprite = sprite[targetType];
        flashEffect.sprite = whiteSprites[targetType];
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
        for (int i = 0; i < particlePile.transform.childCount; i++)
        {
            if (!particlePile.transform.GetChild(i).gameObject.activeSelf)
            {                
                particlePile.transform.GetChild(i).transform.position = new Vector3(transform.parent.gameObject.transform.position.x, transform.parent.gameObject.transform.position.y, -1.0f);
                particlePile.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }
        SoundPlayer.instance.PlaySFX(balloonExplosion);
        tries.RemoveTry();
    }

    public void TargetDestroyed(int _points)
    {
        isGrowing = false;
        col.isTrigger = false;
        transform.parent.gameObject.SetActive(false);      
        score.AddScore(_points);

        for (int i = 0; i < particlePile.transform.childCount; i++)
        {            
            if (!particlePile.transform.GetChild(i).gameObject.activeSelf)
            {                
                particlePile.transform.GetChild(i).transform.position = new Vector3(transform.parent.gameObject.transform.position.x, transform.parent.gameObject.transform.position.y, -1.0f);
                particlePile.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }

        for (int i = 0; i < pointsPile.transform.childCount; i++)
        {
            if(!pointsPile.transform.GetChild(i).gameObject.activeSelf)
            {
                pointsUI = pointsPile.transform.GetChild(i).GetComponent<PointsUI>();
                pointsUI.pointsText.text = "+" + _points.ToString();
                pointsUI.transform.position = transform.position;
                pointsUI.gameObject.SetActive(true);
                break;
            }
        }
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
