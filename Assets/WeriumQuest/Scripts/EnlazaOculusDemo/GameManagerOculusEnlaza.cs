using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerOculusEnlaza : Singleton<GameManagerOculusEnlaza>
{
    //Scene Objects
    public GameObject go_oculusEnlazaManager1;
    public GameObject go_canvasSensor;
    public GameObject go_canvasDatos;
    public Text t_idName;

    public GameObject go_text1;

    //Name Devices Stored
    public string deviceName1;

    //Devices Variables
    [HideInInspector] public string id;
    private int buttonClicks;
    public int changeNow;

    //UDPConnection
    public UDPReceive udp_rec;
    public UDPSend udp_send;

    private void Awake()
    {
        go_oculusEnlazaManager1.SetActive(false);
        go_canvasSensor.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        go_canvasSensor.SetActive(true);
        go_canvasDatos.SetActive(false);
        id = "";
        buttonClicks = 0;
        t_idName.text = id;
    }

    public void ConnectAnotherSensor()
    {
        StartCoroutine(ShowConnectionPanel());
    }
    IEnumerator ShowDataPanel()
    {
        yield return new WaitForSeconds(1f);
        go_canvasSensor.SetActive(false);
        yield return new WaitForSeconds(1f);
        go_canvasDatos.SetActive(true);
    }

    IEnumerator ShowConnectionPanel()
    {
        yield return new WaitForSeconds(1.5f);
        go_canvasDatos.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        go_canvasSensor.SetActive(false);
    }

    public void OKButton()
    {
        deviceName1 = id;
        //go_oculusEnlazaManager1.SetActive(true);
        //udp_rec.Main();

        go_text1.SetActive(true);
        StartCoroutine(ShowDataPanel());       
        buttonClicks++;
        id = "";
    }

    public void Button_1()
    {
        id += 1.ToString();
        t_idName.text = id;
    }
    public void Button_2()
    {
        id += 2.ToString();
        t_idName.text = id;
    }
    public void Button_3()
    {
        id += 3.ToString();
        t_idName.text = id;
    }
    public void Button_4()
    {
        id += 4.ToString();
        t_idName.text = id;
    }
    public void Button_5()
    {
        id += 5.ToString();
        t_idName.text = id;
    }
    public void Button_6()
    {
        id += 6.ToString();
        t_idName.text = id;
    }
    public void Button_7()
    {
        id += 7.ToString();
        t_idName.text = id;
    }
    public void Button_8()
    {
        id += 8.ToString();
        t_idName.text = id;
    }
    public void Button_9()
    {
        id += 9.ToString();
        t_idName.text = id;
    }
    public void Button_0()
    {
        id += 0.ToString();
        t_idName.text = id;
    }
    public void Button_dot()
    {
        id += "-PM";
        t_idName.text = id;
    }
    public void Button_remove()
    {
        string ip_aux = id.Substring(0, id.Length - 1);
        id = ip_aux;
        t_idName.text = id;
    }
    public void Button_RM()
    {
        go_oculusEnlazaManager1.GetComponent<OculusEnlazaManager>().Call4DCM();
    }
    public void Button_AMG()
    {
        go_oculusEnlazaManager1.GetComponent<OculusEnlazaManager>().Call4AMG();
    }
}

