using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.GetComponent<Tile>())
                {
                    hitInfo.collider.GetComponent<Tile>().DestroyByPlayer();
                    Destroy(hitInfo.collider.gameObject);
                }
                
            }
        }
    }
}
