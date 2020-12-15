using System;

[Serializable]
public class WeightRecord_JSON
{
    public string _time;
    public float _weight;
    public float _height;
    public float _bmiValue;

    public WeightRecord_JSON(string time, float weight, float height, float bmiValue)
    {
        _time = time;
        _weight = weight;
        _height = height;
        _bmiValue = bmiValue;
    }
}