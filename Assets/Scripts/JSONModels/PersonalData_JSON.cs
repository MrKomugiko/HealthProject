using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PersonalData_JSON
{
    [SerializeField] public string _name;
    [SerializeField] public int _age;
    [SerializeField] public float _startingWeight;
    [SerializeField] public float _startingHeight;
    [SerializeField] public DateTime _birthday;
    [SerializeField] public GenderEnum _gender;
    [SerializeField] public List<WeightRecord_JSON> _listOfWeights;

    public PersonalData_JSON(string name, int age, float startingWeight, float startingHeight, DateTime birthday, GenderEnum gender, List<WeightRecord_JSON> listOfWeights = null) {
        _name = name;
        _age = age;
        _startingWeight = startingWeight;
        _startingHeight = startingHeight;
        _birthday = birthday;
        _gender = gender;
        _listOfWeights = listOfWeights;
    }
}
