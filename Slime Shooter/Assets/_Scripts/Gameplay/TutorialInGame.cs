using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialInGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    [SerializeField] private GameObject howToPlay;
    [SerializeField] private Vacuum vacuum;

    [SerializeField] private AudioClip mouseOver;
    [SerializeField] private AudioClip mouseClick;

    public void OnPointerEnter(PointerEventData eventData)
    {
        vacuum.SetCanShoot(false);
        SoundPlayer.instance.PlaySFX(mouseOver);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        vacuum.SetCanShoot(true);        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundPlayer.instance.PlaySFX(mouseClick);
    }

    public void OpenTutorial()
    {
        howToPlay.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseTutorial()
    {
        howToPlay.SetActive(false);
        Time.timeScale = 1;
    }    
}