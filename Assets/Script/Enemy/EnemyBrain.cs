using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _enemyAgent;
    //[SerializeField] private CharacterStatsSO _characterStatsSO;
    //[SerializeField] private WeaponSO _weaponSO;
    [SerializeField] private TotalStats _totalStats;
    [SerializeField] private Transform _player;
    [SerializeField] private TurnBaseManager _turnBaseManager;

    [SerializeField] private float _remainingMovement;
    private Vector3 _previousPosition;
    
    private bool isTakingTurn;
    void Start()
    {
        _enemyAgent.stoppingDistance = _totalStats.range;

        _remainingMovement = _totalStats.movementSpeed;
        _previousPosition = transform.position;

        isTakingTurn = false;
    }

    void Update()
    {
        // If it's the enemy's turn, choose an action
        if (_turnBaseManager.currentTurn == TurnState.EnemyTurn)
        {
            isTakingTurn = true;

            StartCoroutine(ThinkOfDestination());

            float distanceTraveled = Vector3.Distance(transform.position, _previousPosition);
            _remainingMovement -= distanceTraveled;
            _previousPosition = transform.position;
        }
    }

    protected void ChooseTarget()
    {
        
    }

    protected void ChooseDestination()
    {
        if (IsAttackAvailable() && _turnBaseManager.currentTurn == TurnState.EnemyTurn)
        {
            //_enemyAgent.SetDestination(_player.transform.position - _totalStats.range * (_player.transform.position - transform.position).normalized);
            _enemyAgent.SetDestination(_player.transform.position);

            if (_enemyAgent.remainingDistance <= _enemyAgent.stoppingDistance)
            {
                StartCoroutine(ThinkOfAttack());

                //isTakingTurn = false;
                _turnBaseManager.EndTurn();
            }
        }
        else
        {
            _enemyAgent.isStopped = false;
            _enemyAgent.SetDestination(_player.transform.position);

            if (_remainingMovement <= 0f && _turnBaseManager.currentTurn == TurnState.EnemyTurn)
            {
                _remainingMovement = 0f;
                _enemyAgent.isStopped = true;
                StartCoroutine(ThinkOfFinalAction());
            }
        }
    }

    protected bool IsAttackAvailable()
    {
        if (_totalStats.movementSpeed + _totalStats.range >= Vector3.Distance(transform.position, _player.transform.position))
        {
            return true;
        }
        return false;
    }

    protected void Attack()
    {
        // Debug.Log("Attack");
    }

    protected IEnumerator ThinkOfFinalAction()
    {
        yield return new WaitForSeconds(2f);

        /* 
            End turn
        */
        if (isTakingTurn)
        {
            _turnBaseManager.EndTurn();
        }
        // reset movement restriction
        isTakingTurn = false;
        _remainingMovement = _totalStats.movementSpeed;
        
        Debug.Log("Current turn: " + _turnBaseManager.currentTurn);
    }
    protected IEnumerator ThinkOfAttack()
    {
        yield return new WaitForSeconds(5f);

        Attack();
    }

    protected IEnumerator ThinkOfDestination()
    {
        yield return new WaitForSeconds(2.5f);
        
        ChooseDestination();
    }

}
