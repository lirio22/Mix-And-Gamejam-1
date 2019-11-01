using UnityEngine;

//Qualquer objeto que contém esse script será desativado em 2 segundos. Fiz isso para desativar as partículas
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
