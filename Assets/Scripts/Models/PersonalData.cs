using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PersonalData
{
    [SerializeField] private string _name;
    [SerializeField] private int _age;
    [SerializeField] private float _startingWeight;
    [SerializeField] private float _startingHeight;
    [SerializeField] private string _birthday;
    [SerializeField] private string _gender;
    [SerializeField] private List<WeightRecord> _listOfWeights;


    public PersonalData(string name, int age, float startingWeight, float startingHeight, string birthday, string gender, List<WeightRecord> listOfWeights = null) {
        _name = name;
        _age = age;
        _startingWeight = startingWeight;
        _startingHeight = startingHeight;
        _birthday = birthday;
        _gender = gender;
        _listOfWeights = listOfWeights;
    }

    public string Name { get => _name; set => _name = value; }
    public int Age { get => _age; set => _age = value; }
    public float StartingWeight { get => _startingWeight; set => _startingWeight = value; }
    public float StartingHeight { get => _startingHeight; set => _startingHeight = value; }
    public string Birthday { get => _birthday; set => _birthday = value; }
    public string Gender { get => _gender; set => _gender = value; }
    public List<WeightRecord> ListOfWeights { get => _listOfWeights; set => _listOfWeights = value; }

    public enum GenderEnum
    {
        Male,
        Female
    }
}