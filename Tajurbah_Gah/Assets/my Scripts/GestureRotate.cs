using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureRotate : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;
    public GameObject thisObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.enabled)
        {
            if (Input.GetMouseButton(1))
            {
                mPosDelta = Input.mousePosition - mPrevPos;
                thisObj.transform.Rotate(transform.right, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
                //transform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);


            }


            mPrevPos = Input.mousePosition;
        }
    }
}
