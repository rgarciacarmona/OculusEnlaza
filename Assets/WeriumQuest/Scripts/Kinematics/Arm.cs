using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using UnityEngine.UI;


public class Arm : MonoBehaviour
{

    public Transform Hand;

    float x_initial, y_initial, z_initial;

    float x_rot, y_rot, z_rot;

    float[] Rt = new float[9];

    string[] Rt_str;

    //public Text pos_x, pos_y, pos_z;

    // We create an instance of UDPReceive, used to receive the data from the sensros from the Raspberry Pi, so
    // that we can used that data (stored in a variable of UDPReceive) on this script
    public UDPReceive UDP;

    //float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Asignamos la posición inicial sobre la que se producirán las rotaciónes en cada Update().
        // Si en vez de en el Start() lo pusiéramos en el Update(), la posición se actualizaría en cada
        // frame, haciendo que la multiplicación de posición por ángulo sea distinta y se volvería a rotar
        // el ángulo dado por T sobre esa nueva posición, por lo tanto, en vez de rotar ese ángulo solo una vez, en
        // cada frame lo volvería a rotar y el brazo no pararía de moverse.
        // Si siempre es la misma posición y el mismo ángulo, aunque la multiplicación se produczca en cada Update(),
        // no se moverá el brazo continuamente, ya que siempre multiplicamos la misma posición por el mismo ángulo,
        // dando siempre la misma rotación.
        // The starting position is assigned in the Start() because it remains the same, what changes is Rt, as
        // the rotations are respect to the initial position (represented by the calibration matrix), not the
        // current position on each frame
        x_initial = Hand.localPosition.x;
        y_initial = Hand.localPosition.y;
        z_initial = Hand.localPosition.z;

    }

    // Update is called once per frame
    void Update()
    {

        Rt_str = UDP.text.Split(',');

        for (int i = 0; i < Rt_str.Length; i++)
        {
            Rt[i] = float.Parse(Rt_str[i], CultureInfo.InvariantCulture.NumberFormat);
        }

        // Position after transformation (rotation), respect to the initial position (defined in Start())
        // Position after rotation = Transformation (rotation) matrix * Initial position
        x_rot = Rt[0] * x_initial + Rt[1] * y_initial + Rt[2] * z_initial;
        y_rot = Rt[3] * x_initial + Rt[4] * y_initial + Rt[5] * z_initial;
        z_rot = Rt[6] * x_initial + Rt[7] * y_initial + Rt[8] * z_initial;


        Hand.localPosition = new Vector3(0.25f, y_rot + 1.4f, z_rot);

    }

    //counter += Time.deltaTime;

    /*
        // Refrescamos los datos en pantalla cada 0.5 segundos, para poder verlos mejor
        // To print the data on the Unity environment blackboard at a good reading speed,
        // each time the counter reaches 0.4
        if (counter > 0.4f)
        {
            pos_x.text = x_rot.ToString().Substring(0, 6);
            pos_y.text = (y_rot + 4.63f).ToString().Substring(0, 6);
            pos_z.text = z_rot.ToString().Substring(0, 6);

            counter = 0;
        }*/


}

/*
incr_x = x_rot - x_initial;
incr_y = y_rot - y_initial;
incr_z = z_rot - z_initial;
*/