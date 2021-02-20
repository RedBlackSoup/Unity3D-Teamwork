using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject roomCenter;
    public Vector3 offset;
    private bool isMoving;
    private Vector3 delta;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;    
    }

    // Update is called once per frame
    void LateUpdate()
    {   
        iTween.MoveTo(gameObject, roomCenter.transform.position + offset, 1.5f); //iTween 大法好啊！
        // transform.position = roomCenter.transform.position + offset;
    }

    public void ChangeCenter(GameObject obj){
    	roomCenter=obj;
    }
}

