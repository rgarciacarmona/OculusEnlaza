using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyTargets : MonoBehaviour
{

    public Transform lHand;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))  //No va?????????????????????????
        {
            lHand.localRotation = Quaternion.Euler(lHand.rotation.eulerAngles.x, lHand.rotation.eulerAngles.y + 45, lHand.rotation.eulerAngles.z);
        }
        
    }
}
