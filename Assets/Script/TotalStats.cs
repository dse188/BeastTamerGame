using UnityEngine;

public class TotalStats : MonoBehaviour
{
    public CharacterStatsSO _characterStatsSO;
    public WeaponSO _weaponSO;

    [Header("Current Character Stats")]
    public float movementSpeed;
    public float health;
    public int attack;
    public int magic;
    public int defense;

    [Tooltip("Determines attack accuracy and critical hit chance.")]
    public int dexterity;

    [Tooltip("Determines turn order in combat and evasion.")]
    public float speed;

    [Header("Current Weapon Stats")]
    public string weaponName;
    public WeaponType weaponType;
    public int rarity;
    public float power;
    public float range;

    void Awake()
    {
        movementSpeed = _characterStatsSO.MovementSpeed;
        health = _characterStatsSO.Health;
        attack = _characterStatsSO.Attack;
        magic = _characterStatsSO.Magic;
        defense = _characterStatsSO.Defense;
        dexterity = _characterStatsSO.Dexterity;
        speed = _characterStatsSO.Speed;

        weaponName = _weaponSO.WeaponName;
        weaponType = _weaponSO.WeaponType;
        rarity = _weaponSO.Rarity;
        power = _weaponSO.Power;
        range = _weaponSO.Range;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
