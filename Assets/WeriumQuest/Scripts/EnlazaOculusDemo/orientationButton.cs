using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class orientationButton : MonoBehaviour
{
    private string id;

    private bool isCeroTriggered = false;
    private bool isUnoTriggered = false;
    private bool isDosTriggered = false;
    private bool isTresTriggered = false;
    private bool isCuatroTriggered = false;
    private bool isCincoTriggered = false;
    private bool isSeisTriggered = false;
    private bool isSieteTriggered = false;
    private bool isOchoTriggered = false;
    private bool isNueveTriggered = false;
    private bool isRemoveTriggered = false;
    private bool isDotTriggered = false;
    private bool isOkTriggered = false;
    private bool isReturnTriggered = false;
    private bool isRmTriggered = false;
    private bool isAmgTriggered = false;

    private float timer = 0;

    private void Start()
    {
        id = "";
        isCeroTriggered = false;
        isUnoTriggered = false;
        isDosTriggered = false;
        isTresTriggered = false;
        isCuatroTriggered = false;
        isCincoTriggered = false;
        isSeisTriggered = false;
        isSieteTriggered = false;
        isOchoTriggered = false;
        isNueveTriggered = false;
        isRemoveTriggered = false;
        isDotTriggered = false;
        isOkTriggered = false;
        isRemoveTriggered = false;
        isRmTriggered = false;
        isAmgTriggered = false;
        timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "cero_btn" && !isCeroTriggered)
        {
            id += 0.ToString();
            GameManagerOculusEnlaza.instance.Button_0();
            isCeroTriggered = true;
        }

        if (this.gameObject.tag == "uno_btn" && !isUnoTriggered)
        {
            id += 1.ToString();
            GameManagerOculusEnlaza.instance.Button_1();
            isUnoTriggered = true;
        }

        if (this.gameObject.tag == "dos_btn" && !isDosTriggered)
        {
            id += 2.ToString();
            GameManagerOculusEnlaza.instance.Button_2();
            isDosTriggered = true;
        }

        if (this.gameObject.tag == "tres_btn" && !isTresTriggered)
        {
            id += 3.ToString();
            GameManagerOculusEnlaza.instance.Button_3();
            isTresTriggered = true;
        }

        if (this.gameObject.tag == "cuatro_btn" && !isCuatroTriggered)
        {
            id += 4.ToString();
            GameManagerOculusEnlaza.instance.Button_4();
            isCuatroTriggered = true;
        }

        if (this.gameObject.tag == "cinco_btn" && !isCincoTriggered)
        {
            id += 5.ToString();
            GameManagerOculusEnlaza.instance.Button_5();
            isCincoTriggered = true;
        }

        if (this.gameObject.tag == "seis_btn" && !isSeisTriggered)
        {
            id += 6.ToString();
            GameManagerOculusEnlaza.instance.Button_6();
            isSeisTriggered = true;
        }
        if (this.gameObject.tag == "siete_btn" && !isSieteTriggered)
        {
            id += 7.ToString();
            GameManagerOculusEnlaza.instance.Button_7();
            isSieteTriggered = true;
        }

        if (this.gameObject.tag == "8cho_btn" && !isOchoTriggered)
        {
            id += 8.ToString();
            GameManagerOculusEnlaza.instance.Button_8();
            isOchoTriggered = true;
        }

        if (this.gameObject.tag == "nueve_btn" && !isNueveTriggered)
        {
            id += 9.ToString();
            GameManagerOculusEnlaza.instance.Button_9();
            isNueveTriggered = true;
        }

        if (this.gameObject.tag == "punto_btn" && !isDotTriggered)
        {
            id += "-PM";
            GameManagerOculusEnlaza.instance.Button_dot();
            isDotTriggered = true;
        }

        if (this.gameObject.tag == "borrar_btn" && !isRemoveTriggered)
        {
            GameManagerOculusEnlaza.instance.Button_remove();
            isRemoveTriggered = true;
        }

        if (this.gameObject.tag == "ok_btn" && !isOkTriggered)
        {
            GameManagerOculusEnlaza.instance.OKButton();
        }

        if (this.gameObject.tag == "return_btn" && !isReturnTriggered)
        {
            GameManagerOculusEnlaza.instance.ConnectAnotherSensor();
        }
        if (this.gameObject.tag == "rm_btn" && !isRmTriggered)
        {
            GameManagerOculusEnlaza.instance.Button_RM();
        }
        if (this.gameObject.tag == "amg_btn" && !isAmgTriggered)
        {
            GameManagerOculusEnlaza.instance.Button_AMG();
        }
    }


    void Update()
    {
        if (isCeroTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isCeroTriggered = false;
                timer = 0;
            }
        }
        if (isUnoTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isUnoTriggered = false;
                timer = 0;
            }
        }
        if (isDosTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isDosTriggered = false;
                timer = 0;
            }
        }
        if (isTresTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isTresTriggered = false;
                timer = 0;
            }
        }
        if (isCuatroTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isCuatroTriggered = false;
                timer = 0;
            }
        }
        if (isCincoTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isCincoTriggered = false;
                timer = 0;
            }
        }
        if (isSeisTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isSeisTriggered = false;
                timer = 0;
            }
        }
        if (isSieteTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isSieteTriggered = false;
                timer = 0;
            }
        }
        if (isOchoTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isOchoTriggered = false;
                timer = 0;
            }
        }
        if (isNueveTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isNueveTriggered = false;
                timer = 0;
            }
        }
        if (isRemoveTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isRemoveTriggered = false;
                timer = 0;
            }
        }
        if (isDotTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isDotTriggered = false;
                timer = 0;
            }
        }
        if (isOkTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isOkTriggered = false;
                timer = 0;
            }
        }
        if (isReturnTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isReturnTriggered = false;
                timer = 0;
            }
        }
        if (isRmTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isRmTriggered = false;
                timer = 0;
            }
        }
        if (isAmgTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                isAmgTriggered = false;
                timer = 0;
            }
        }
    }
   
}
