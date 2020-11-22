using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    [SerializeField] GameObject selectedOverlay;
    [SerializeField] GameObject darkOverlay;

    private bool _isSelected;
    private bool _isImportant;
    
    public bool IsSelected 
    {
        get => _isSelected;
        set 
        {
            _isSelected = value;
            if(_isSelected == true)
            {
                selectedOverlay.SetActive(true);
            }
            else
            {
                selectedOverlay.SetActive(true);
            }
        }
    }
    public bool IsImportant 
    {
        get => _isImportant;
        set 
        {
            _isImportant = value;
            if(_isImportant == true)
            {
                darkOverlay.SetActive(false);
            }
            else
            {
                darkOverlay.SetActive(true);
            }
        }
    }
    void Start()
    {

    }
}
