using System;
using UnityEngine;

[Serializable]
public class PersonalData
{
    [SerializeField] private string _name;
    [SerializeField] private int _age;
    [SerializeField] private float _startingWeight;
    [SerializeField] private float _startingHeight;
    [SerializeField] private DateTime _birthday;
    [SerializeField] private string _gender;

    public PersonalData(string name, int age, float startingWeight, float startingHeight, DateTime birthday, string gender) {
        _name = name;
        _age = age;
        _startingWeight = startingWeight;
        _startingHeight = startingHeight;
        _birthday = birthday;
        _gender = gender;
    }

    public string Name { get => _name; set => _name = value; }
    public int Age { get => _age; set => _age = value; }
    public float StartingWeight { get => _startingWeight; set => _startingWeight = value; }
    public float StartingHeight { get => _startingHeight; set => _startingHeight = value; }
    public DateTime Birthday { get => _birthday; set => _birthday = value; }
    public string Gender { get => _gender; set => _gender = value; }

    public enum GenderEnum
    {
        Male,
        Female
    }
}