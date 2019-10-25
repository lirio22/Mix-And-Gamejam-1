using UnityEngine;

public class DeactivationTimer : MonoBehaviour
{
    private float timer = 2.0f;    

    private void OnEnable()
    {
        timer = 2.0f;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
