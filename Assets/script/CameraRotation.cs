using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float RotaionSpeed;
    public float minAngle;
    public float maxAngle;
    public Transform CameraAxisTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotaionSpeed * Input.GetAxis("Mouse X"), 0);
        var newAngelX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotaionSpeed * Input.GetAxis("Mouse Y");
        if (newAngelX > 180)
            newAngelX -= 360;
        newAngelX = Mathf.Clamp(newAngelX, minAngle, maxAngle);
        CameraAxisTransform.localEulerAngles = new Vector3(newAngelX, 0 , 0);
    }
}
