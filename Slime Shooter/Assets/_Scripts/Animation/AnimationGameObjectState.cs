using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
