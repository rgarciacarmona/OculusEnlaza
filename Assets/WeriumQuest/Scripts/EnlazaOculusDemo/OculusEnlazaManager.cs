using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArduinoBluetoothAPI;
using System;
using TMPro;

public class OculusEnlazaManager : MonoBehaviour
{
	BluetoothHelper bluetoothHelper;

	public string deviceName = "raspberrypi";

	public Text t_dataSensor;

	public Text t_dataButton;

    public GameObject sphere;

	string received_message;

	public List<string> listDevicesName;

	[HideInInspector] public int i_changeData;

	// Start is called before the first frame update

	private void Start()
    {
		deviceName = "raspberrypi"; // GameManagerOculusEnlaza.instance.deviceName1;
		i_changeData = 0;
		sphere.SetActive(true);
		Conectar();
    }

    IEnumerator blinkSphere()
    {
        sphere.GetComponent<Renderer>().material.color = Color.cyan;
        yield return new WaitForSeconds(2f);
        sphere.GetComponent<Renderer>().material.color = Color.green;
    }

	void OnMessageReceived(BluetoothHelper helper)
	{
		StartCoroutine(blinkSphere());
		byte[] received_byte = helper.ReadBytes();
		received_message = System.Text.Encoding.UTF8.GetString(received_byte, 0, received_byte.Length);
		Debug.Log(received_message);
		t_dataSensor.text = received_message;
		// Debug.Log(received_message);
	}

	void OnConnected(BluetoothHelper helper)
	{
		sphere.GetComponent<Renderer>().material.color = Color.green;
		try
		{
			helper.StartListening();
		}
		catch (Exception ex)
		{
			Debug.Log(ex.Message);
		}
	}

	void OnConnectionFailed(BluetoothHelper helper)
	{
		sphere.GetComponent<Renderer>().material.color = Color.red;
		Debug.Log("Connection Failed");
	}

    public void Conectar()
	{
		deviceName = "raspberrypi";  //GameManagerOculusEnlaza.instance.deviceName1;
		try
		{
			bluetoothHelper = BluetoothHelper.GetInstance(deviceName);
			bluetoothHelper.OnConnected += OnConnected;
			bluetoothHelper.OnConnectionFailed += OnConnectionFailed;
			bluetoothHelper.OnDataReceived += OnMessageReceived; //read the data

			bluetoothHelper.setTerminatorBasedStream("\n"); //delimits received messages based on \n char

			//LinkedList<BluetoothDevice> ds2 = bluetoothHelper.getPairedDevicesList();
			//foreach (BluetoothDevice dsl in ds2)
			//	t_dataSensor.text += " Paired:" + dsl.DeviceName;


			if (bluetoothHelper != null)
				if (!bluetoothHelper.isConnected())
					if (bluetoothHelper.isDevicePaired())
					{
						sphere.GetComponent<Renderer>().material.color = Color.blue;
						bluetoothHelper.Connect();
					}
					else
					{
						sphere.GetComponent<Renderer>().material.color = Color.magenta;
					}
		}
		catch (Exception ex)
		{
			sphere.GetComponent<Renderer>().material.color = Color.yellow;
			Debug.Log(ex.Message);
			//t_dataSensor.text = ex.Message;
			//BlueToothNotEnabledException == bluetooth Not turned ON
			//BlueToothNotSupportedException == device doesn't support bluetooth
			//BlueToothNotReadyException == the device name you chose is not paired with your android or you are not connected to the bluetooth device;
			//								bluetoothHelper.Connect () returned false;
		}
	}

	public void Call4DCM()
    {
		bluetoothHelper.SendData("#om");
	}
	public void Call4AMG()
	{
		bluetoothHelper.SendData("#osct");
	}

	void OnDestroy()
	{
		if (bluetoothHelper != null)
			bluetoothHelper.Disconnect();
	}
}
