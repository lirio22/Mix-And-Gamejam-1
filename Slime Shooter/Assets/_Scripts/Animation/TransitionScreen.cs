using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TransitionScreen : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string startAnimation; //Nome da animação da entrada da transição
    [SerializeField] private string endAnimation; //Nome da animação da saída da transição

    [SerializeField] private UnityEvent actions;

    //Para iniciar a transição de tela, basta chamar essa função em qualquer parte do jogo
    public void CallTransition()
    {
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        //Ativa o objeto com o animator e toca a animação de entrada
        animator.gameObject.SetActive(true);
        animator.Play(startAnimation);

        //Espera que a animação termine para dar continuidade
        yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length);

        //Invoca as ações do UnityEvent
        actions.Invoke();

        //Toca a animação de saída
        animator.Play(endAnimation);
    }
}