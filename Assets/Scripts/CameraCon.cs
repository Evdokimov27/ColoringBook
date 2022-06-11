using UnityEngine;

public class CameraCon : MonoBehaviour
{
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null);
                {
                    hit.collider.GetComponent<Paint>().Fill();
                }
            }
        }
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Moved))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null) ;
                {
                    hit.collider.GetComponent<Paint>()._Paint();
                    hit.collider.GetComponent<Paint>().Delete();
                }
            }
        }
    }
}