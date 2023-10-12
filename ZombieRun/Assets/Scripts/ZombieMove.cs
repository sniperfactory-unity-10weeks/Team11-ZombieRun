using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent pathFinder;
    private Animator zombieAnimator;

    public float damage = 2f; // ���ݷ�
    private float timeBetAttack = 1f; //���� ����
    private float lastAttackTime = 0f;       //�ֱ� ���� �ð�



    void Start()
    {

        //�׽�Ʈ ���� �ڷ�ƾ�� ���⼭ ������׽��ϴ�.
        ////���� ��1���� ���� ȹ�� �� Ȱ��ȭ�ǵ��� ���� ����
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
            //pathFinder.SetDestination(target.transform.position);
            
            yield return new WaitForSeconds(0.25f);
        }

        pathFinder.isStopped = true;
        zombieAnimator.SetBool("isWalk", false);
    }

    private void OnTriggerStay(Collider other)
    {
        //�÷��̾ ���ӿ������, �������� ����
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        // �ֱ� ���� �������� timeBetAttack �̻� �ð��� �����ٸ� ���� ����
        if (Time.time >= lastAttackTime + timeBetAttack)
        {

            // �������κ��� LivingEntity Ÿ���� �������� �õ�
            Player attackTarget = other.GetComponent<Player>();

            // ���� ����� �÷��̾���,
            if (attackTarget != null && other.gameObject == target)
            {
                // �ֱ� ���� �ð��� ����
                lastAttackTime = Time.time;

                // ���� ����
                //zombieAnimator.SetTrigger("isAttack");
                attackTarget.OnDamage(damage);
            }
        }
    }
}
