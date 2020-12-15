using System;

[Serializable]
public class WeightRecord_JSON
{
    public DateTime _time;
    public float _weight;
    public float _height;
    public float _bmiValue;

    public WeightRecord_JSON(DateTime time, float weight, float height, float bmiValue)
    {
        _time = time;
        _weight = weight;
        _height = height;
        _bmiValue = bmiValue;
    }
}