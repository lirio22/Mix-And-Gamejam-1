using UnityEngine;

//Esse Script recebe qualquer Game Object para ser ativado ou desativado em uma animação
public class AnimationGameObjectState : MonoBehaviour
{
    [SerializeField] private GameObject sceneObject;

    public void ActivateObject()
    {
        sceneObject.SetActive(true);
    }

    public void DeactivateObject()
    {
        sceneObject.SetActive(false);
    }

}
