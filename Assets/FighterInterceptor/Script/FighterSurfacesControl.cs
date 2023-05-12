using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterSurfacesControl : MonoBehaviour
{
    public Texture2D tex;
    public Transform rightElevator, leftElevator;
    public Transform rightFlap, leftFlap;
    public Transform rightRudder, leftRudder;
    private float MRx, MRy, MRz;
    public float maxAngle, flapMaxAngle, rudderMaxAngle;
    public float rightElevatorSetAngle, leftElevatorSetAngle;
    public bool useMouse;
    public float turnSpeed;

    private PlayerShipMovement _playerMovement;
	
	void Start () {
        Cursor.visible = false;
        _playerMovement = GetComponentInParent<PlayerShipMovement>();
        
    }

    void Update () {
        //if (useMouse)
        //{
        //    MRx = Mathf.Clamp(MRx + Input.GetAxis("Mouse Y")*0.05f, -1f, 1f);
        //    MRz = Mathf.Clamp(MRz - Input.GetAxis("Mouse X")*0.05f, -1f, 1f);

        //}
        //else
        //{
        //       MRx = Mathf.Clamp(MRx + Input.GetAxis("Vertical") * 0.05f, -1f, 1f);
        //       MRz = Mathf.Clamp(MRz - Input.GetAxis("Horizontal") * 0.05f, -1f, 1f);

        //}
        MRx = transform.localPosition.x + _playerMovement.yThrow;
        MRz = transform.localPosition.y - _playerMovement.xThrow;
        MRy = transform.localPosition.y - _playerMovement.xThrow;

        rightElevator.transform.localRotation = Quaternion.Euler(new Vector3((MRz + MRx) * maxAngle, rightElevatorSetAngle, 0));
        leftElevator.transform.localRotation = Quaternion.Euler(new Vector3((-MRz + MRx) * maxAngle,leftElevatorSetAngle, 0));
        rightFlap.transform.localRotation = Quaternion.Euler(new Vector3((MRz + MRx) * maxAngle,leftElevatorSetAngle, 0));
        leftFlap.transform.localRotation = Quaternion.Euler(new Vector3((-MRz + MRx) * maxAngle,leftElevatorSetAngle, 0));
        TransAng(rightRudder, 16, MRy * rudderMaxAngle, 107);
        TransAng(leftRudder, -16, MRy * rudderMaxAngle, 73);

	}
    float c1, c2, c3, s1, s2, s3;
    float w, x, y, z;
    void TransAng(Transform tr, float heading, float attitude, float bank)
    {
        c1 = Mathf.Cos(heading * Mathf.Deg2Rad / 2);
        s1 = Mathf.Sin(heading * Mathf.Deg2Rad / 2);
        c2 = Mathf.Cos(attitude * Mathf.Deg2Rad / 2);
        s2 = Mathf.Sin(attitude * Mathf.Deg2Rad / 2);
        c3 = Mathf.Cos(bank * Mathf.Deg2Rad / 2);
        s3 = Mathf.Sin(bank * Mathf.Deg2Rad / 2);

        w = c1 * c2 * c3 - s1 * s2 * s3;
        x = s2 * c1 * c3 + s1 * c2 * s3;
        y = s1 * c2 * c3 + s2 * c1 * s3;
        z = s3 * c1 * c2 - s1 * s2 * c3;

        tr.transform.localRotation = new Quaternion(x, y, z, w);
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width * 0.5f * (-MRz/2 + 1f) - 8, Screen.height * 0.5f * (-MRx/2 + 1f) - 8, 32f, 32f), tex);
    }
}
