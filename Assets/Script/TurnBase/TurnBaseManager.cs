using System.Runtime.CompilerServices;
using UnityEngine;

public class TurnBaseManager : MonoBehaviour
{
    public TurnState currentTurn;

    [SerializeField] private GameObject[] _player;
    [SerializeField] private GameObject[] _enemy;

    private float _highestPlayerSpeed;
    private float _highestEnemySpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DecideInitialTurnOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DecideInitialTurnOrder()
    {
        _highestPlayerSpeed = 0;
        _highestEnemySpeed = 0;

        // Decide who goes first based on speed value
        foreach (GameObject player in _player)
        {
            if (player.GetComponent<TotalStats>().speed > _highestPlayerSpeed)
            {
                _highestPlayerSpeed = player.GetComponent<TotalStats>().speed;
            }
        }

        foreach (GameObject enemy in _enemy)
        {
            if (enemy.GetComponent<TotalStats>().speed > _highestEnemySpeed)
            {
                _highestEnemySpeed = enemy.GetComponent<TotalStats>().speed;
            }
        }

        // Not sure how this behaves if there is a tie, but for now player will go first in that case
        if (Mathf.Max(_highestPlayerSpeed, _highestEnemySpeed) == _highestPlayerSpeed)
        {
            currentTurn = TurnState.PlayerTurn;
        }
        else
        {
            currentTurn = TurnState.EnemyTurn;
        }

        Debug.Log("Player Speed: " + _highestPlayerSpeed + " Enemy Speed: " + _highestEnemySpeed + " Current Turn: " + currentTurn);
    }

    public void EndTurn()
    {
        currentTurn = TurnState.EnemyTurn;

        // TODO: Need a logic for deciding which unit moves next (next unit with the highest speed)
    }


}


public enum TurnState
{
        PlayerTurn,
        EnemyTurn,
        OutOfCombat
}
