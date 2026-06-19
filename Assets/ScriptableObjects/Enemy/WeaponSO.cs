using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private string _weaponName;
    [SerializeField] private WeaponType _weaponType;
    [SerializeField] private int _rarity;

    [SerializeField] private float _power;
    [SerializeField] private float _range;

    // Getter for stats
    public string WeaponName => _weaponName;
    public WeaponType WeaponType => _weaponType;
    public int Rarity => _rarity;
    public float Power => _power;
    public float Range => _range;

}

public enum WeaponType
{
    Sword,
    Katana,
    TwoHandedSword,
    Dagger,
    Axe,
    TwoHandedAxe,
    Shield,
    Bow,
    Quiver,
    Staff,
    Sceptre,
    Wand,
}
