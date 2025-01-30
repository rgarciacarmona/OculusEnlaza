using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_rotation : MonoBehaviour
{
    public Transform RHand;

    Vector3 position;
    public Vector3 angulos;
    public float angleY;
    public Quaternion rotation;
    float lastPositionY, lastPositionX;
    public Transform rController;

    //[HideInInspector] public float angleY;

    float incr_x = 0;
    float incr_y = 0;

    float totalY = 0;
    [HideInInspector] public float totalX = 0;

    float counter = 0;

    public Text pos_y;

    [HideInInspector] public float len_goniom = 0.315f; //0.315f;


    // Start is called before the first frame update
    void Start()
    {

        position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);

        lastPositionY = position.y;
        lastPositionX = position.x;

    }

    // Update is called once per frame
    void Update()
    {

        rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        angulos = rotation.eulerAngles;
        
        // Get local position from the Oculus Touch
        position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);


        // The first increments of X and Y are 0, as on the start the position
        // variables and the lastPosition variables are made equal. As soon as
        // the position moves they start being 0, and they are zero again if
        // the controller is still, as the position and last position variables
        // would agree again (the last position variables are updated with the
        // position variables value after the current increment is calculated)
        incr_x = (position.x - lastPositionX);
        incr_y = (position.y - lastPositionY);

        totalX += incr_x; // used to know the quadrant of the angle of rotation
        totalY += incr_y; //used to calculate the angle of rotation

        lastPositionY = position.y;
        lastPositionX = position.x;

        // To calculate the angle we will use the relation of the sine with the
        // hypotenuse and the leg of a rectangle triangle:
        // sine (y) = leg/hypotenuse ---> y = arcsin(leg / hypotenuse).
        // The leg would be the total increment (totalY) and the hypotenuse
        // the length of the arm of the goniometer, as the controller is placed
        // on its end.
        //angleY = Mathf.Asin(totalY / len_goniom) * 180 / Mathf.PI;

        /* The maximum angle the arcosine gives is 90°, so we use the 
           total increment in the X and Y axes to know in which quadrant
           we are:
                - If the increment in X is lower than minus the length of
                  the goniometer (-len_goniom = -0.31) (the controller
                  starts on 0 in the X axis and its position decreases as
                  it moves left so the increments would be negative) it 
                  means that the arm of the goniometer has surpased 90°,
                  as the increment in X would be bigger than its arm. 
                  So we would be on one of the left quadrants.

                - If the increment in Y is lower than 0 it means the 
                  controller (located in the arm of the goniometer has
                  been moved down, so it would be on one of the lower
                  quadrants.
        */

        
        // For angles in the 1st quadrant (0° - 90°) and 4th
        // quadrant (270° - 360°), depending on the sign of
        // totalY (positive: 1st; negative: 4th)

        if (totalX > -len_goniom && totalY >= 0) 
        {
            //RHand.localRotation = Quaternion.Euler(0, angleY, 0);
            RHand.localRotation = Quaternion.Euler(0, -angulos.x, 0);
            angleY = 360f - angulos.x;
        }
        else if (totalX > -len_goniom && totalY < 0)
        {
            //RHand.localRotation = Quaternion.Euler(0, angleY, 0);
            RHand.localRotation = Quaternion.Euler(0, 360f-angulos.x, 0);
            angleY = 360f - angulos.x;
        }

        // For angles in the 2nd quadrant (91° - 180°) and 3rd
        // cuadrant (181° - 270°; this goniometer cannot reach
        // those angles), depending on the sign of totalY (positive: 2nd;
        // negative: 3rd)
        //if (totalX < -len_goniom && totalY>=0)
        else {
            //RHand.localRotation = Quaternion.Euler(0, 180f - angleY, 0);
            RHand.localRotation = Quaternion.Euler(0, angulos.x - 180f, 0);
            angleY = angulos.x-180f;
        }
        

        counter += Time.deltaTime;

        // Conditionals used to print the data on the blackboard of the Unity
        // program (the counter is used to make the printing slower so that
        // the angles don't change too fast and they can be seen correctly)
        if (counter > 0.4f)
        {
            /*
            // Substring-> start at position 0 and take 6 elements -> it will
            // take 2 or 3 decimals: e.g. 190.54 (2 decimals) or 67.654 (3 decimals)
            pos_y.text = angleY.ToString().Substring(0, 5);
            // For the first quadrant (in this case angleY goes from 0° to 90°)
            if (totalX >= -len_goniom)
            {
                pos_y.text = angleY.ToString().Substring(0, 5);
            }
            // For the second quadrant (in this case angleY goes from 0° to 90°);
            // totalY will always be positive when totalX < -len_goniom because
            // the goniometer cannot reach the 3rd quadrant, so we don't have to
            // put that condition
            if (totalX < -len_goniom)
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
            */

            pos_y.text =angleY.ToString().Substring(0, 5);
            //"anguloReal: " + angulos.x.ToString() + ", totalX: " + totalX.ToString() + ", incrX: " + incr_x.ToString() + ", incrY: " + incr_y.ToString() +
            //    "\n Controller: " + rController.localRotation.eulerAngles.x.ToString()+ ", "+ rController.localRotation.eulerAngles.y.ToString() +
            //   ", " + rController.localRotation.eulerAngles.z.ToString();
            counter = 0;
        }
    }
}