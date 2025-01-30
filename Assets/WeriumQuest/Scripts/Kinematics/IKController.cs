using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{

    private Animator anim;
    
    [Header("Transforms")]
    public Transform RHand;
    public Transform LHand;
    public Transform RElbow;
    public Transform LElbow;
    public Transform RFoot;
    public Transform LFoot;

    [Header("IKWeights")]
    public float rHandWeight;
    public float lHandWeight;
    public float lElbowWeight;
    public float rElbowWeight;
    public float lFootWeight;
    public float rFootWeight;

    Transform leftFoot;
    Transform rightFoot;

    private void Start()
    {
        anim = GetComponent<Animator>();
        leftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
        rightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);
    }


    //Hace cambios en la capa en la que se esté ejecutando
    //Se va a llamar en cada frame de la animación (pero no es igual que el Update)
    private void OnAnimatorIK(int layerIndex)
    {
        /*CAMBIO POSICIONES DE MANOS*/
        //Asigno pesos a la articulación. Peso == prioridad
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, lHandWeight);
        //Asigno una posición "Objetivo" a esta articulación
        anim.SetIKPosition(AvatarIKGoal.LeftHand, LHand.position);
        //Asigno pesos a la articulación. Peso == prioridad
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, rHandWeight);
        //Asigno una posición "Objetivo" a esta articulación
        anim.SetIKPosition(AvatarIKGoal.RightHand, RHand.position);
    }

}



/*CAMBIO ROTACIONES DE MANOS*/
/* anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, lHandWeight);
 anim.SetIKRotation(AvatarIKGoal.LeftHand, LHand.rotation);
 anim.SetIKRotationWeight(AvatarIKGoal.RightHand, rHandWeight);
 anim.SetIKRotation(AvatarIKGoal.RightHand, RHand.rotation);
 */

//animaciones utiliza cinemática inversa (damos una posición objetivo y todas las demás articulaciones se adaptarán para alcanzar esa posición)

/*CAMBIO POSICIONES DE CODOS*/ //METODO PARA ANIMACIONES (rotar mientras se produce la animacion de baile, por ej.) para rotar objetos sin animacion, podemos usar quaternions
/*anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, lElbowWeight);
anim.SetIKHintPosition(AvatarIKHint.LeftElbow, LElbow.position);
anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, rElbowWeight);
anim.SetIKHintPosition(AvatarIKHint.RightElbow, RElbow.position);
*/

/*CAMBIO ROTACIONES DE PIES*/
/* anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, lHandWeight);
 anim.SetIKRotation(AvatarIKGoal.LeftFoot, LFoot.rotation);
 anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, rHandWeight);
 anim.SetIKRotation(AvatarIKGoal.RightFoot, RFoot.rotation);
 */

/*
// A diferencia del Update, el FixedUpdate siempre se actualiza a la misma frecuencia (el Update depende de la capacidad del ordenador y el número de sentencias que tenga dentro
// Se utiliza en físicas porque queremos que las colisiones, etc. se ejecuten siempre a un tiempo constante, no que dependa del renderizado
private void FixedUpdate()
{
    RaycastHit rHit;  // Qué es raycast hit?????
    RaycastHit lHit;

    Vector3 leftF = leftFoot.TransformPoint(Vector3.zero);
    Vector3 rightF = rightFoot.TransformPoint(Vector3.zero);

    //Lanzo un rayo desde la posicioón de mi joint (en el avatar) hacia el suelo
    if (Physics.Raycast(leftF, -Vector3.up, out lHit, 1))   // que hace esto????
    {
        //donde se genera el hit (colisiona el rayo) asigno mi RFoot (el transform que hasta ahora modificábamos posición en el editor)
        LFoot.position = lHit.point;
    }

    if (Physics.Raycast(rightF, -Vector3.up, out rHit, 1))   // que hace esto????
    {
        //donde se genera el hit (colisiona el rayo) asigno mi RFoot (el transform que hasta ahora modificábamos posición en el editor)
        RFoot.position = rHit.point;
    }
}
*/

/*CAMBIO ROTACIONES DE MANOS*/
/* anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, lHandWeight);
 anim.SetIKRotation(AvatarIKGoal.LeftHand, LHand.rotation);
 anim.SetIKRotationWeight(AvatarIKGoal.RightHand, rHandWeight);
 anim.SetIKRotation(AvatarIKGoal.RightHand, RHand.rotation);
 */

//animaciones utiliza cinemática inversa (damos una posición objetivo y todas las demás articulaciones se adaptarán para alcanzar esa posición)

/*CAMBIO POSICIONES DE CODOS*/ //METODO PARA ANIMACIONES (rotar mientras se produce la animacion de baile, por ej.) para rotar objetos sin animacion, podemos usar quaternions
/*anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, lElbowWeight);
anim.SetIKHintPosition(AvatarIKHint.LeftElbow, LElbow.position);
anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, rElbowWeight);
anim.SetIKHintPosition(AvatarIKHint.RightElbow, RElbow.position);
*/

/*CAMBIO ROTACIONES DE PIES*/
/* anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, lHandWeight);
 anim.SetIKRotation(AvatarIKGoal.LeftFoot, LFoot.rotation);
 anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, rHandWeight);
 anim.SetIKRotation(AvatarIKGoal.RightFoot, RFoot.rotation);
 */