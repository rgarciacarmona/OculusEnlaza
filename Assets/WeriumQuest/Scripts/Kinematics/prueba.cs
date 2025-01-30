using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;


public class prueba : MonoBehaviour
{

    public Transform Hand, LHand;

    float xpos, ypos, zpos;

    float incr_x, incr_y, incr_z;

    float xposprima, yposprima, zposprima;

    float angle2 = 0.01f;

    float[,] T = new float[3, 3];

    float[] Rt = new float[9];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Tx
        T[0, 0] = 1;
        T[0, 1] = 0;
        T[0, 2] = 0;

        T[1, 0] = 0;
        T[1, 1] = Mathf.Cos(angle2);
        T[1, 2] = -Mathf.Sin(angle2);

        T[2, 0] = 0;
        T[2, 1] = Mathf.Sin(angle2);
        T[2, 2] = Mathf.Cos(angle2);

        xpos = Hand.localPosition.x;
        ypos = Hand.localPosition.y;
        zpos = Hand.localPosition.z;

        xposprima = T[0, 0] * xpos + T[0, 1] * ypos + T[0, 2] * zpos;
        yposprima = T[1, 0] * xpos + T[1, 1] * ypos + T[1, 2] * zpos;
        zposprima = T[2, 0] * xpos + T[2, 1] * ypos + T[2, 2] * zpos;


        incr_x = xposprima - xpos;
        incr_y = yposprima - ypos;
        incr_z = zposprima - zpos;


        Hand.localPosition = new Vector3(xposprima, yposprima, zposprima);
        LHand.localPosition = new Vector3(xposprima - 0.5f, yposprima + 4.25f, zposprima);

        //angle2 = angle2 + 0.01f;

    }

    // Asignamos la posición inicial sobre la que se producirán las rotaciónes en cada Update().
    // Si en vez de en el Start() lo pusiéramos en el Update(), la posición se actualizaría en cada
    // frame, haciendo que la multiplicación de posición por ángulo sea distinta y se volvería a rotar
    // el ángulo dado por T sobre esa nueva posición, por lo tanto, en vez de rotar ese ángulo solo una vez, en
    // cada frame lo volvería a rotar y el brazo no pararía de moverse.
    // Si siempre es la misma posición y el mismo ángulo, aunque la multiplicación se produczca en cada Update(),
    // no se moverá el brazo continuamente, ya que siempre multiplicamos la misma posición por el mismo ángulo,
    // dando siempre la misma rotación.
}