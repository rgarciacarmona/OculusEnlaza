using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using UnityEngine.UI;

public class eulerAngles : MonoBehaviour
{

    public Transform Hand;

    [HideInInspector] public float[] eulerHand = new float[3];

    string[] eulerHand_str;

    // We create a UDPReceive instance so that we can use the public variables of that program,
    // specifically the variable in which the angles sent by the sensor are stored
    public UDPReceive UDP1;

    public Text euler;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // The Euler angles are received via UDP and stored in an array, spliting each element
        // separated by a comma (','),as the Euler angels are sent in String format in the
        // following way: 'angle1, angle2, angle3', so each element of the array corresponds
        // to one of the Euler angels
        eulerHand_str = UDP1.text.Split(',');

        // Convert the array of Strings to an array of floats, so that the angles can be used
        // in Unity
        for (int i = 0; i < eulerHand_str.Length; i++)
        {
            eulerHand[i] = float.Parse(eulerHand_str[i], CultureInfo.InvariantCulture.NumberFormat);
        }

        // The rotation will be just on one plane, so we just need one Euler angle, specifically
        // the third one
        Hand.localRotation = Quaternion.Euler(0, eulerHand[2], 0);

        // To print the Euler angle on the blackboard of the Unity program, stored in a text variable
        // located on that Game Object
        // 1st, 2nd and 3rd quadrants
        if (eulerHand[2] > 0)
        {
            euler.text = eulerHand[2].ToString();
        }

        // 4th quadrant
        // The sensor sends negative angles because when we reach it we do it rotating on the opposite
        // direction than on the other quadrants, being 0° the starting angle, up to -90°; the 4th
        // quadrant cannot be reached doing positive rotations higher than 270 because the goniometer
        // doesn't allow that movement in reality).
        if (eulerHand[2] < 0) {
            euler.text = (360f + eulerHand[2]).ToString();
        }
    }
}
