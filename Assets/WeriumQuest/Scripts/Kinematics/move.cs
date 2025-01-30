using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System;

public class move : MonoBehaviour
{
    public Transform RHand;
    public Transform RElbow;
    public Transform LHand;
    public Transform LElbow;

    //public UDPReceive UDP; //Creamos una instancia de la clase usada para recibir los datos de la Raspberry para usarla en este programa

    float alfa;
    float beta;
    float gamma;

    // coordenadas usadas para poner los brazos en línea recta mirando al suelo
    float inicio_x_mano = 0.31f;
    float inicio_x_codo = 0.25f;
    float inicio_y_mano = 0.76f;
    float inicio_y_codo = 1.17f;
    float inicio_z = 0f;

    public Vector3 aux1;
    public Vector3 aux2;
    public Vector3 aux;

    double l1 = 0.28; //longitud del antebrazo del avatar
    double l2 = 0.23; // longitud de la mano del avatar


    double q1 = 90 * (Math.PI/180);
    double q2 = 15 * (Math.PI/180);

    double l = 0.66;
    double angle = 45 * (Math.PI / 180);

    int[] angles = { 10, 20, 30, 40, 90, 45, 5, 1, 120, 100, 180 };

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        // poner la poisición de inicio --> posición en Unity en la que los brazos están mirando al suelo
        // Hay que poner localPosition (para la y principalmente) porque la posicion de origen de Y de la mano no concide con la global, que estaría en
        //torno al ombligo  del avatar (las de X y Z son más parecidas y no se notan tanto)
        aux = aux1 = RHand.localPosition = new Vector3(inicio_x_mano, inicio_y_mano, inicio_z);
        LHand.localPosition = new Vector3(-inicio_x_mano, inicio_y_mano, inicio_z);
        aux2 = RElbow.localPosition = new Vector3(inicio_x_codo, inicio_y_codo, inicio_z);
        LElbow.localPosition = new Vector3(-inicio_x_codo, inicio_y_codo, inicio_z);

    }

    // Update is called once per frame
    void Update()
    {
        //Los IKWeights son para el Update, no para el Start
        
        // Recibe los datos de la Raspberry (los tres ángulos de euler) y los separa por comas en un array
        // string: (alfa,beta,gamma) --> array de tres elementos: [alfa, beta, gamma]
        //string[] euler = UDP.text.Split(',');

        /*
        alfa = float.Parse(euler[0], CultureInfo.InvariantCulture.NumberFormat);
        beta = float.Parse(euler[1], CultureInfo.InvariantCulture.NumberFormat);
        gamma = float.Parse(euler[2], CultureInfo.InvariantCulture.NumberFormat);
        */

        //Mediante unas ecuaciones transformamos los angulos de euler en posicion -> trigonometria??? (angulos * senos y cosenos)???
        // * Time.deltaTime ?????????
        // Plano ZY, el X quieto
        //RElbow.localPosition = new Vector3(RElbow.localPosition.x, aux2.y + (float)(l1 * Math.Cos(q1)), aux2.z + (float)(l1 * Math.Sin(q1)));
        //RHand.localPosition = new Vector3(RHand.localPosition.x, aux1.y + (float)( ( l1*Math.Cos(q1) + l2*Math.Cos(q1 + q2) )), aux1.z + (float) ( ( l1*Math.Sin(q1) + l2*Math.Sin(q1 + q2) )) );
       
       // Le sumamos 0.8 en el punto Y porque la mano en reposo no está en el punto 0, sino en el 0.8
       //RHand.localPosition = new Vector3(RHand.localPosition.x, aux.y + (float)(l * Math.Cos(angle)), aux.z + (float)((l * Math.Sin(angle))) );
       // Los otros ángulos están invertidos 45 -> 135 ; 135 -> 45. etc.   ?????????????????????????????????????????????????
       //RElbow.localRotation = Quaternion.Euler(0, 90, 0);
    }
}














/*RHand.position = new Vector3(0.31f, 1.31f, 0.66f); // por que no me deja mover el y a ese punto????????????????????
RHand.position= new Vector3(RHand.position.x, (RHand.position.y + 0.1f) * Time.deltaTime, (RHand.position.z + 0.1f) * Time.deltaTime);

Vector3aux = RHand.localposition -> origen
Transform.translate(RHand.localposition: origen, target:cosen... new Vector3(,,))


Método para rotar objetos, no animaciones. El otro se usa por ejemplo para poder mover el brazo a la vez que la animación de baile.
RHand.rotation = Quaternion.Euler(, , ); // La matriz de los sensores nos da 9 elementos; hay un script en el proyecto grande que los convierte en 3


RElbow.position = new Vector3(RElbow.position.x, RElbow.position.y + 0.1f * Time.deltaTime, RElbow.position.z); //Mediante unas ecuaciones transformamos los angulos de euler en posicion
Método para rotar objetos, no animaciones. El otro se usa por ejemplo para poder mover el brazo a la vez que la animación de baile.
RElbow.rotation = Quaternion.Euler(45, 45, 45); // La matriz de los sensores nos da 9 elementos; hay un script en el proyecto grande que los convierte en 3
*/
