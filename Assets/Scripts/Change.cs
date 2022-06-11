using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Change : MonoBehaviour
{
    [SerializeField] public bool Fill;
    [SerializeField] public bool Painter;
    [SerializeField] public bool Delete;
    [SerializeField] public Color Color;
    [SerializeField] public Slider Slider;
    [SerializeField] public int Radius;
    [SerializeField] public Button activeColor;
    public Button[] ChangeColor;
    public Button[] ChangeItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activeColor.GetComponent<Image>().color = Color;
        Radius = (int)Slider.value;
    }
    public void SetPaint(int check)
    {
        if (check == 0)
        {
            Fill = false;
            Painter = true;
            Delete = false;
        }
        if (check == 1)
        {
            Fill = true;
            Painter = false;
            Delete = false;
        }
        if (check == 2)
        {
            Fill = false;
            Painter = false;
            Delete = true;
        }

    }
    public void SetColor(int index)
    {
        Color = ChangeColor[index].image.color;
    }
}
