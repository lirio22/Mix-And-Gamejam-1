using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Color selected;
    [SerializeField] private Color deselected;

    [SerializeField] private AudioClip mouseOver;
    [SerializeField] private AudioClip mouseClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundPlayer.instance.PlaySFX(mouseClick);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = selected;
        SoundPlayer.instance.PlaySFX(mouseOver);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = deselected;
    }
}
