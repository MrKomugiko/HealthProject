using System;

[Serializable]
public class WeightRecord
{
    public DateTime _time;
    public float _weight;
    public float _height;
    public float _bmiValue;

    public WeightRecord(DateTime time, float weight, float height, float bmiValue)
    {
        _time = time;
        _weight = weight;
        _height = height;
        _bmiValue = bmiValue;
    }
}