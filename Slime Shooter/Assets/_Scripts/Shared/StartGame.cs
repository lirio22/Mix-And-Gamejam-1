using UnityEngine;
using UnityEngine.Events;

public class StartGame : MonoBehaviour
{
    [SerializeField] private UnityEvent actions;

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            actions.Invoke();
        }
    }
}
