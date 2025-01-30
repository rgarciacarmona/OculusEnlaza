using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_position : MonoBehaviour
{
    public Transform RHand;
    public Vector3 position;
    float x, y, z;
    float lastPositionX, lastPositionY, lastPositionZ;

    //float counter = 0;

    //public Text pos_x, pos_y, pos_z;

    // Start is called before the first frame update
    void Start()
    {
        position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        lastPositionX = position.x;
        lastPositionY = position.y;
        lastPositionZ = position.z;
    }

    // Update is called once per frame
    void Update()
    {
        position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);

        // Calculates the increments in the axis of the Oculus Touch, which are then added to the current local position
        // ot the hand to make them move to the new position given by the Oculus Touch
        x = position.x - lastPositionX;
        y = position.y - lastPositionY;
        z = position.z - lastPositionZ;

        RHand.localPosition = new Vector3(RHand.localPosition.x + x, RHand.localPosition.y + y, RHand.localPosition.z + z);

        lastPositionX = position.x;
        lastPositionY = position.y;
        lastPositionZ = position.z;

        //counter += Time.deltaTime;

        /*// To print the positions of the hand of the avatar; each time counter reaches 0.4, for a good reading speed
        if (counter > 0.4f)
        {
            // substring-> start at position 0 and take 6 elements -> 2 or 3 decimals: e.g. 190.54 or 67.654
            pos_x.text = RHand.localPosition.x.ToString().Substring(0, 6);
            pos_y.text = RHand.localPosition.y.ToString().Substring(0, 6);
            pos_z.text = RHand.localPosition.z.ToString().Substring(0, 6);

            counter = 0;
        }*/
    }
}
