using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class degrees_controller : MonoBehaviour
{

    public GameObject Hand;
    
    public Text rotX;

    // We create an instance of Controller_rotation so that we can use its public variables, specfically
    // the rotation angle
    public Controller_rotation con;

    float counter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // this. -> the object to which the script is attached
        // .transform: position, rotation, scale
        // the object to which the script is passed is oriented towards the GameObject passed as an argument
        this.transform.LookAt(Hand.transform);

        counter += Time.deltaTime;

        // To print the data in the blackboard of the Unity environment
        // Refresh the data each time the counter reaches 0.4, so that it's not too fast to be seen well
        if (counter > 0.4f)
        {
            // We store on the following text variables the information of the rotation angle of the object
            // to which this script has been added (a cube located) on Joint1 of Arm_Sensor, so that they
            // appear on the blackboard of the Unity program, by adding in Unity the text object located
            // there to this text variable
            // In Unity, the initial position to which the cube is looking at is not 0°, but 359.65°, and
            // instead of adding degrees until you reach 90°, it subtracts them to 359.65°; for example,
            // a rotation of 85° with the typical that we made in reality gave us in Unity a value
            // of 274,96° (359,65° - 274,96° = 84,69° -> 85°). Each quadrant in Unity has its own way
            // of measuring (1st quadrant: 359,65° - 270°; 2nd quadrant: 270° - 180°; 3rd quadrant; 0° - 90°;
            // 4th quadrant: 90° - 0°), so we had to make some adjustments to get the typical angle format

            // 1st quadrant
            if (con.angleY >= 0 & con.angleY <= 90)
            {
                rotX.text = (360f - this.transform.rotation.eulerAngles.x).ToString().Substring(0, 5);
            }

            // 2nd quadrant
            if (con.angleY > 0 & con.totalX < -con.len_goniom)
            {
                rotX.text = (180 - (360 - this.transform.rotation.eulerAngles.x)).ToString().Substring(0, 5);
            }

            // 3rd quadrant (not used in the goniometer, as it cannot reach that position)
            if (con.angleY < 0 & con.totalX < -con.len_goniom)
            {
                rotX.text = (180f + this.transform.rotation.eulerAngles.x).ToString().Substring(0, 5);
            }

            // 4th quadrant
            if (con.angleY <= 0 & con.angleY >= -90)
            {
                rotX.text = (270f + (90f - this.transform.rotation.eulerAngles.x)).ToString().Substring(0, 5);
            }

            counter = 0;
        }
    }
}
