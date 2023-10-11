using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent pathFinder;
    private Animator zombieAnimator;

    void Start()
    {

        //테스트 위해 코루틴을 여기서 실행시켰습니다.
        ////이후 방1에서 열쇠 획득 시 활성화되도록 변경 예정
        target = GameObject.FindWithTag("Player");
        pathFinder = GetComponent<NavMeshAgent>();
        zombieAnimator = GetComponent<Animator>();
        StartCoroutine(UpdatePath());
    }

    private void OnEnable()
    {
/*        target = GameObject.FindWithTag("Player");
        pathFinder = GetComponent<NavMeshAgent>();
        zombieAnimator = GetComponent<Animator>();
        StartCoroutine(UpdatePath());*/
    }

    private IEnumerator UpdatePath()
    {
        zombieAnimator.SetBool("isWalk", true);
        while (!GameManager.instance.isGameOver)
        {
            pathFinder.isStopped = false;
            pathFinder.SetDestination(target.transform.position);
            
            yield return new WaitForSeconds(0.25f);
        }

        pathFinder.isStopped = true;
        zombieAnimator.SetBool("isWalk", false);
    }
}
