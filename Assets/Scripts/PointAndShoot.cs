using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public GameObject crosshairs;  
    private Vector3 target; 

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y); 

        if(Input.GetMouseButtonDown(0))
        {
            Fire(); 
        }
    }

    void Fire()
    {
       if(crosshairs.GetComponent<CrosshairsAim>().IsAiming())
       {
           crosshairs.GetComponent<CrosshairsAim>().SetKill(true); 
       }
       else 
       {
            crosshairs.GetComponent<CrosshairsAim>().SetKill(false); 
       }
    }


}
