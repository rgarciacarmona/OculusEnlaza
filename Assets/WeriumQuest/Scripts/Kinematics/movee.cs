using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movee : MonoBehaviour
{

    //public Transform Hand;
    //public Transform Elbow;


    Vector3 position;

    float lastPositionY, lastPositionX;

    [HideInInspector] public float angleY;

    float incr_x = -0.01f;
    float incr_y = 0.01f;

    float totalY = 0;
    [HideInInspector] public float totalX = 3.97f;
    [HideInInspector] public float lon = 3.97f;

    public Transform RHand;

    float counter = 0;

    public Text pos_y;

    public float angle1 = 80f;
    //float angle2 = 45f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (totalX < 0.01)
        {
            incr_x = -incr_x;
        }


        if (totalX > 3.99)
        {
            incr_x = -incr_x;
        }

        if (totalY > 1.97f)
        {
            incr_y = -incr_y;
        }

        if (totalY < 0)
        {
            incr_y = -incr_y;
        }


        totalX += incr_x;
        totalY += incr_y;
        Debug.Log("TOTAL X: " + totalX);
        Debug.Log("TOTAL Y: " + totalY);

        angleY = Mathf.Asin(totalY / 1.99f) * 180 / Mathf.PI;
        Debug.Log(totalY / lon);
        Debug.Log("ANGLE Y: " + angleY);

        if (totalX >= 2)
        {
            RHand.localRotation = Quaternion.Euler(0, angleY, 0);
        }

        // For angles in the 2nd quadrant (91° - 180°) and 3rd
        // cuadrant (181° - 270°; this goniometer cannot reach
        // those angles), depending on the sign of totalY (positive: 2nd;
        // negative: 3rd)
        if (totalX < 2)
        {
            RHand.localRotation = Quaternion.Euler(0, 180f - angleY, 0);
        }

        counter += Time.deltaTime;

        // Conditionals used to print the data on the blackboard of the Unity
        // program (the counter is used to make the printing slower so that
        // the angles don't change too fast and they can be seen correctly)
        if (counter > 0.4f)
        {
            // Substring-> start at position 0 and take 6 elements -> it will
            // take 2 or 3 decimals: e.g. 190.54 (2 decimals) or 67.654 (3 decimals)
            pos_y.text = angleY.ToString().Substring(0, 5);
            // For the first quadrant (in this case angleY goes from 0° to 90°)
            if (totalX >= -lon)
            {
                pos_y.text = angleY.ToString().Substring(0, 5);
            }
            // For the second quadrant (in this case angleY goes from 0° to 90°);
            // totalY will always be positive when totalX < -len_goniom because
            // the goniometer cannot reach the 3rd quadrant, so we don't have to
            // put that condition
            if (totalX < -lon)
            {
                pos_y.text = (180f - angleY).ToString().Substring(0, 5);
            }
            // For the fourth quadrant (in this case angleY is negative, from
            // 0° to -90°)
            if (totalY < 0)
            {
                pos_y.text = (360f + angleY).ToString().Substring(0, 5);
            }
            // The third quadrant is not used, as the goniometer cannot reach
            // those angles (the conditions would be totalX < -len_goniom and
            // totalY < 0, and we would add the condition totalY >= 0 to the
            // conditional of the second quadrant)

            counter = 0;

            //incr_z += 0.001f;

            //angle1 = angle1 + 0.3f;
            //angle2 = angle2 + 0.1f;


            //Elbow.localRotation = Quaternion.Euler(0, angle2, 0);
            //Hand.localRotation = Quaternion.Euler(0, angle1, 0);

        }
    }
}

// from a test used in Controller_rotation
/*
if (totalX < -0.61f)
{
    incr_x = -incr_x;
}


if (totalX > -0.001f)
{
    incr_x = -incr_x;
}

if (totalY > 0.30999f)
{
    incr_y = -incr_y;
}

if (totalY < 0)
{
    incr_y = -incr_y;
}
//incr_z += 0.001f;
*/


//Quaternion rotation;


//public Transform Elbow;

//float[] eulerElbow = new float[3];

//string[] eulerElbow_str;

//public UDPReceive UDP2;

//float eulerHand_last = 0, eulerElbow_last = 0;

//eulerElbow_str = UDP2.text.Split(',');

//eulerElbow[i] = float.Parse(eulerElbow_str[i], CultureInfo.InvariantCulture.NumberFormat);

//dif[i] = eulerHand[i] - eulerElbow[i];

// En cada lectura restaremos la anterior posición ya que las lecturas son respecto a la posición inicial
// pero las rotaciones son respecto a la actual. Para que al recibir un ángulo determinado, por ejemplo 90º,
// no este continuamente girando 90 grados, sino que se mantenga en la posición de 90º grados, le restamos
// la posición anterior
//eulerHand_last = eulerHand[2];
//eulerElbow_last = eulerElbow[2];

//Elbow.localRotation = Quaternion.Euler(0, eulerElbow[1] - eulerHand_last, 0);
//Hand.localRotation = Quaternion.Euler(0, (eulerHand[1] - eulerElbow[1]) - eulerElbow_last, 0);

//this.transform.position = cube_position.position;

//public Transform cube_position;
