using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class degrees : MonoBehaviour
{

    public GameObject Hand;

    public Text rotX;

    // We create an instance of eulerAngles, so that we can used its public variables,
    // specifically the Euler angle responsible of the rotation
    public eulerAngles deg;

    public Transform cube_position;

    float counter = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        counter += Time.deltaTime;
        // this. -> the object to which the script is attached
        // .transform: position, rotation, scale
        // the object to which the script is passed is oriented towards the GameObject passed as an argument
        this.transform.LookAt(Hand.transform);

        // To print the data in the blackboard of the Unity environment
        // Refresh the data each time the counter reaches 0.4, so that it's not too fast to be seen well
        if (counter > 0.4f)
        {
            // We store on the following text variables the information of the rotation angle of the object
            // to which this script has been added (a cube located) on Joint1 of Arm_Sensor, so that they
            // appear on the blackboard of the Unity program, by adding in Unity the text  object located
            // there to this text variable
            // In Unity, the initial position to which the cube is looking at is not 0°, but 359.65°, and
            // instead of adding degrees until you reach 90°, it subtracts them to 359.65°; for example,
            // a rotation of 85° with the typical that we made in reality gave us in Unity a value
            // of 274,96° (359,65° - 274,96° = 84,69° -> 85°). Each quadrant in Unity has its own way of
            // measuring (1st quadrant: 359,65° - 270°; 2nd quadrant: 270° - 180°; 3rd quadrant; 0° - 90°;
            // 4th quadrant: 90° - 0°), so we had to make some adjustments to get the typical angle format
            // 1st quadrant
            if (deg.eulerHand[0] >= 0f & deg.eulerHand[0] <= 90f )
            {
                rotX.text = (359.65f - this.transform.rotation.eulerAngles.x).ToString().Substring(0, 5);
            }
            // 2nd quadrant
            if (deg.eulerHand[0] > 90f & deg.eulerHand[0] <= 180f)
            {
                rotX.text = (180f - (360f - this.transform.rotation.eulerAngles.x)).ToString().Substring(0, 5);
            }
            // 3rd quadrant
            if (deg.eulerHand[0] > 180 & deg.eulerHand[0] <= 270)
            {
                rotX.text = (180 + this.transform.rotation.eulerAngles.x).ToString().Substring(0, 5);
            }

            // 4th quadrant
            if (deg.eulerHand[0] <= 0f & deg.eulerHand[0] >= -90f)
            {
                rotX.text = (270f + (90f - this.transform.rotation.eulerAngles.x)).ToString().Substring(0, 5);
            }

            counter = 0f;
        }

    }
}
