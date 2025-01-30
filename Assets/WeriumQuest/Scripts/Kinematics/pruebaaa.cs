using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;


public class pruebaaa : MonoBehaviour
{

    public Transform Hand, LHand;
    public Transform Elbow;


    float xpos, ypos, zpos;

    float incr_x, incr_y, incr_z;

    float xposprima, yposprima, zposprima;
    //float angle1 = 45f;
    float angle2 = 0.01f;

    float[,] T = new float [3,3];

    float[] Rt = new float[9];

    // Start is called before the first frame update
    void Start()
    {
      //  Hand.localPosition = new Vector3(1, 0, 0);
        //angle2 = Convert.ToSingle(Math.PI / 2);
        //angle2 = 0.01f;

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
        //LHand.localPosition = new Vector3(LHand.localPosition.x + incr_x, LHand.localPosition.y + incr_y, LHand.localPosition.z + incr_z);

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



//Elbow.localPosition = new Vector3(Hand.localPosition.x, (float)(l1 * Math.Cos(angle1)), (float)((l1 * Math.Sin(angle1))));
//Hand.localPosition = new Vector3(Hand.localPosition.x, (float)(l1 * Math.Cos(angle1) + l2 * Math.Cos(angle1 + angle2)), (float)((l1 * Math.Sin(angle1) + l2 * Math.Sin(angle1 + angle2))));



//alfa = float.Parse(euler[0], CultureInfo.InvariantCulture.NumberFormat);
//beta = float.Parse(euler[1], CultureInfo.InvariantCulture.NumberFormat);
//gamma = float.Parse(euler[2], CultureInfo.InvariantCulture.NumberFormat);

/*
       i++;

       if (i == 15)
       {
           i = 0;
       }

       //angle1 = angle1 + 0.3f;
       angle2 = angle2;// + 0.0001f;*/


//Elbow.localRotation = Quaternion.Euler(0, angles[i], 0);
//Hand.localRotation = Quaternion.Euler(angle1, 0, 0);

//float y = arraypos[i];


/* Ty -> Transformation matrix that rotates a vector/matrix a specific angle along the Y axis*//*
T[0, 0] = Mathf.Cos(angle2);
T[0, 1] = 0;
T[0, 2] = Mathf.Sin(angle2);

T[1, 0] = 0;
T[1, 1] = 1;
T[1, 2] = 0;

T[2, 0] = -Mathf.Sin(angle2);
T[2, 1] = 0;
T[2, 2] = Mathf.Cos(angle2); */

//string[] Rt_str = UDP.text.Split(',');
//string text = "1, 0, 0, 0, 0.9999500004166653, -0.009999833334166664, 0, 0.009999833334166664, 0.9999500004166653";

//string text = "1, 0, 0, 0, 1, 0, 0, 0, 1";
//string[] Rt_str = text.Split(',');

/*
for (int i = 0; i < Rt_str.Length; i++)
{
    Rt[i] = float.Parse(Rt_str[i], CultureInfo.InvariantCulture.NumberFormat);
}
*/


// position after transformation (rotation)


//float[] angles =  {45f, 46f, 48f, 50f, 55f, 58f, 66f, 70f, 72f, 75f, 80f, 82f, 84f, 85f, 90f};
//float[] arraypos = { 0.1f, 0.5f, 0.7f, 0.8f, 0.9f, 1.1f, 1.3f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2f, 2.1f };

//public UDPReceive UDP; //Creamos una instancia de la clase usada para recibir los datos de la Raspberry para usarla en este programa

/*
       xposprima = Rt[0]*xpos + Rt[1]*ypos + Rt[2]*zpos;
       yposprima = Rt[3]*xpos + Rt[4] * ypos + Rt[5]*zpos;
       zposprima = Rt[6]*xpos + Rt[7]*ypos + Rt[8]*zpos;*/


/* float alfa;
 float beta;
 float gamma;*/

//int i = 0;