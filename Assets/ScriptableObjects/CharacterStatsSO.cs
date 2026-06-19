using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStatsSO", menuName = "Scriptable Objects/CharacterStatsSO")]
public class CharacterStatsSO : ScriptableObject
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float health;
    [SerializeField] private int attack;
    [SerializeField] private int magic;
    [SerializeField] private int defense;

    [Tooltip("Determines attack accuracy and critical hit chance.")]
    [SerializeField] private int dexterity;

    [Tooltip("Determines turn order in combat and evasion.")]
    [SerializeField] private float speed;


    // Getters for the stats
    public float MovementSpeed => movementSpeed;
    public float Health => health;
    public int Attack => attack;
    public int Magic => magic;
    public int Defense => defense;
    public int Dexterity => dexterity;

    public float Speed => speed;

}
