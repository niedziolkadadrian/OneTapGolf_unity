using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] public int points;
    [SerializeField] Text textField;
    // Start is called before the first frame update
    void Start()
    {
        points=0;
        updateField();
    }

    //updates pointsPanel in top right corner
    public void updateField(){
        textField.text = points.ToString();
    }
}
