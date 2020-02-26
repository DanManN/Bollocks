using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float distance = 10f;
    public float yDisp = 0.5f;
    public float zoomRate = 10f;

    public float xAngle = 30f;
    public float yAngle = 0f;

    public float pitchRate = 1f;
    public float panRate = 2f;

    public GameObject targetObj = null;

    private Vector3 deltaPos;

    public void setTarget(GameObject target)
    {
        targetObj = target;
    }

    private int playerNum()
    {
        if (targetObj != null)
        {
            return targetObj.name[targetObj.name.Length - 1] - '0';
        }
        else
        {
            return 0;
        }
    }

    private float getAxis(string axis)
    {
        int num = playerNum();
        string s_num = num > 0 ? num.ToString() : "";
        return Input.GetAxis(axis + s_num);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (targetObj != null)
        {
            distance -= Input.mouseScrollDelta.y * zoomRate * Time.deltaTime;
            xAngle -= getAxis("Pitch") * pitchRate;
            yAngle += getAxis("Pan") * panRate;

            Quaternion rot = Quaternion.Euler(xAngle, yAngle, 0);
            Vector3 point = rot * Vector3.forward;
            Vector3 pos = targetObj.transform.position - distance * point + yDisp * Vector3.up;
            transform.SetPositionAndRotation(pos, rot);
        }
    }
}
