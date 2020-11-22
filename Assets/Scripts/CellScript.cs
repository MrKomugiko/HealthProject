using UnityEngine;

public class CellScript : MonoBehaviour
{
    [SerializeField] GameObject selectedOverlay;
    [SerializeField] GameObject darkOverlay;
    bool _isSelected;
    bool _isImportant;
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
}
