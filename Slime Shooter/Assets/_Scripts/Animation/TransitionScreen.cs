using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TransitionScreen : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string startAnimation;
    [SerializeField] private string endAnimation;

    [SerializeField] private UnityEvent actions;

    public void CallTransition()
    {
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        animator.gameObject.SetActive(true);
        animator.Play(startAnimation);

        yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length);

        actions.Invoke();

        animator.Play(endAnimation);
    }
}