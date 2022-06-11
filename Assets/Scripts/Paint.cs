using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Paint : MonoBehaviour, IBeginDragHandler, IDragHandler
{

    [SerializeField] private Texture2D texture;
    [SerializeField] private int resolutionX = 128;
    [SerializeField] private int resolutionY = 128;
    [SerializeField] private Camera camera;
    [SerializeField] private Change change;
    [SerializeField] private Collider collider;

    public void OnBeginDrag(PointerEventData eventData)
    {
       
    }
    public void OnDrag(PointerEventData eventData)
    {
           
    }
    public void Fill()
    {
        if (change.Fill == true)
        {
                    for (int x = 0; x < resolutionX; x++)
                    {
                        for (int y = 0; y < resolutionY; y++)
                        {
                            texture.SetPixel(x, y, change.Color);
                        }
                    }
        }
    }
    public void _Paint()
    {
        if (change.Painter == true)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            float step = 1f;
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, 100f))
            {
                int rayX = (int)(hit.textureCoord.x * resolutionX);
                int rayY = (int)(hit.textureCoord.y * resolutionY);
                for (int x = 0; x < resolutionX; x++)
                {
                    for (int y = 0; y < resolutionY; y++)
                    {
                        if (Mathf.Pow((x * step) - rayX, 2) + Mathf.Pow((y * step) - rayY, 2) < Mathf.Pow(change.Radius, 2))
                        {
                            texture.SetPixel(x, y, change.Color);
                        }
                    }
                }
            }
        }
    }
    public void Delete()
    {
        if (change.Delete == true)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            float step = 1f;
            RaycastHit hit;
            if (collider.Raycast(ray, out hit, 100f))
            {
                int rayX = (int)(hit.textureCoord.x * resolutionX);
                int rayY = (int)(hit.textureCoord.y * resolutionY);

                for (int x = 0; x < resolutionX; x++)
                {
                    for (int y = 0; y < resolutionY; y++)
                    {
                        if (Mathf.Pow(x * step - rayX, 2) + Mathf.Pow(y * step - rayY, 2) < Mathf.Pow(change.Radius, 2))
                        {
                            texture.SetPixel(x, y, new Color(205, 205, 205));
                        }
                    }
                }
            }
        }
        

    }
    void Update()
    {
        

        

        if (texture == null)
        {
            texture = new Texture2D(resolutionX, resolutionY);
            GetComponent<Renderer>().material.mainTexture = texture;
            for (int x = 0; x < resolutionX; x++)
            {
                for (int y = 0; y < resolutionY; y++)
                {
                    texture.SetPixel(x, y, Color.white);
                }
            }
        }
        texture.filterMode = FilterMode.Point;
        texture.Apply();
        if (texture.width != resolutionX)
        {
            texture.Resize(resolutionX, resolutionY);
        }
    }



}

