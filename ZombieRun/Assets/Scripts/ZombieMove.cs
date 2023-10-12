using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent pathFinder;
    private Animator zombieAnimator;

    public float damage = 2f; // 공격력
    private float timeBetAttack = 0.5f; //공격 간격
    private float lastAttackTime;       //최근 공격 시간



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

    private void OnTriggerEnter(Collider other)
    {
        //플레이어가 게임오버라면, 실행하지 않음
        if (GameManager.instance.isGameOver)
        {
            return;
        }
        // 최근 공격 시점에서 timeBetAttack 이상 시간이 지났다면 공격 가능
        if (Time.time >= lastAttackTime + timeBetAttack)
        {
            // 상대방으로부터 LivingEntity 타입을 가져오기 시도
            Player attackTarget = other.GetComponent<Player>();

            // 닿은 대상이 플레이어라면,
            if (attackTarget != null && other == target)
            {
                // 최근 공격 시간을 갱신
                lastAttackTime = Time.time;

                // 공격 실행
                attackTarget.OnDamage(damage);
            }
        }
    }
}
