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
    [SerializeField] private TurnBaseManager turnBaseManager;

    void Start()
    {
        _enemyAgent.stoppingDistance = _totalStats.range;
    }

    void Update()
    {
        // If it's the enemy's turn, choose an action
        if (turnBaseManager.currentTurn == TurnState.EnemyTurn)
        {
            //ChooseDestination();
            StartCoroutine(SimulateThinking());
        }
    }

    protected void ChooseTarget()
    {
        
    }

    protected void ChooseDestination()
    {
        if (IsAttackAvailable())
        {
            //_enemyAgent.SetDestination(_player.transform.position - _totalStats.range * (_player.transform.position - transform.position).normalized);
            _enemyAgent.SetDestination(_player.transform.position);
            // if (_enemyAgent.remainingDistance <= _totalStats.range)
            // {
            //     _enemyAgent.isStopped = true;
            // }
        }
    }

    protected bool IsAttackAvailable()
    {
        //if (_characterStatsSO.MovementSpeed + _weaponSO.range >= Vector3.Distance(transform.position, _player.transform.position))
        if (_totalStats.movementSpeed + _totalStats.range >= Vector3.Distance(transform.position, _player.transform.position))
        {
            return true;
        }
        return false;
    }

    protected IEnumerator SimulateThinking()
    {
        yield return new WaitForSeconds(2.5f);

        ChooseDestination();
    }


}
