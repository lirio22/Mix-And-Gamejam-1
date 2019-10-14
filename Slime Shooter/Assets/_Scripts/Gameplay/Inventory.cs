using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image[] slotIcon = new Image[3];
    [SerializeField] private Image[] slotBackground = new Image[3];
    [SerializeField] private Slime[] slot = new Slime[3];
    private int index = 0;

    [SerializeField] private Sprite empty;

    [SerializeField] private Color selectedColor;
    [SerializeField] private Color deselectedColor;

    [SerializeField] private AudioClip slimeCatch;

    private void Update()
    {
        ChangeSlot();
    }

    private void ChangeSlot()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 || Input.GetKeyDown(KeyCode.E))
        {
            slotBackground[index].color = deselectedColor;
            index++;
            if (index > slot.Length - 1)
            {
                index = 0;
            }
            slotBackground[index].color = selectedColor;
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 || Input.GetKeyDown(KeyCode.Q))
        {
            slotBackground[index].color = deselectedColor;
            index--;
            if (index < 0)
            {
                index = slot.Length - 1;
            }
            slotBackground[index].color = selectedColor;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotBackground[index].color = deselectedColor;
            index = 0;
            slotBackground[index].color = selectedColor;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotBackground[index].color = deselectedColor;
            index = 1;
            slotBackground[index].color = selectedColor;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotBackground[index].color = deselectedColor;
            index = 2;
            slotBackground[index].color = selectedColor;
        }
    }

    public void AddSlime(Slime _slime)
    {
        for(int i = 0; i < slot.Length; i++)
        {
            if(slot[i] == null)
            {
                slot[i] = _slime;
                slotIcon[i].gameObject.SetActive(true);
                slotIcon[i].sprite = _slime.icon;
                _slime.gameObject.SetActive(false);
                SoundPlayer.instance.PlaySFX(slimeCatch);
                break;
            }
        }
    }

    public Slime GetSlime()
    {
        Slime slime = slot[index];
        slot[index] = null;
        slotIcon[index].sprite = empty;
        return slime;
    }
}