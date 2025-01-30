using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine.UI;


public class UDPReceive : MonoBehaviour
{
    // receiving Thread
    Thread receiveThread;

    // udpclient object
    UdpClient client;

    // public
    public string IP = "192.168.43.76";
    public int port; // define init

    // infos
    public string lastReceivedUDPPacket = "";
    public string allReceivedUDPPackets = ""; 
    public Text Go_text;

    public string text;

    void Start()
    {
        init();
        //Main();
    }

    // OnGUI
    void OnGUI()
    {
        Rect rectObj = new Rect(40, 10, 200, 400);
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        GUI.Box(rectObj, "# UDPReceive\n" + IP + port + " #\n"
                    + "shell> nc -u " + IP + ": " + port + " \n"
                    + "\nLast Packet: \n" + lastReceivedUDPPacket
                    + "\n\nAll Messages: \n" + allReceivedUDPPackets
                , style);
    }

    // init
    private void init()
    {
        // define port
        port = 8000; //8051;

        // status
        print("Reading from /" + IP + ": " + port);
        print("Test-Sending to this Port: nc -u " + IP + ": "+ port + "");

        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }

    // receive thread
    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (true)
        {
            try
            {
                IPAddress myIp = IPAddress.Parse(IP);
                IPEndPoint localEndPoint = new IPEndPoint(myIp, port);
                print(">> " + IP.ToString());
                byte[] data = client.Receive(ref localEndPoint);
                if (data!= null && data.Length > 0)
                {
                    text = Encoding.UTF8.GetString(data);
                    // To print the DCM in the text variable located in the blackboard
                    // of the Unity environment:
                    //Go_text.text = text;

                    //string[] text_str = text.Split(',');
                    //if (text_str[0] == "1")
                    //{
                        //SaveBinDataTimeSensor(text_str[1]);
                    //SaveBinDataTimeOculus1(Time.realtimeSinceStartup.ToString().Replace('.', ','));
                    //}
                    //if(text_str[0] == "2")
                    //{
                    //    SaveBinDataTimeRB(text_str[1]);
                    //    SaveBinDataTimeOculus2(Time.realtimeSinceStartup.ToString());
                    //}
                    //if (text_str[0] == "3")
                    //{
                    //    SaveBinDataTimeRB2(text_str[1]);
                    //    SaveBinDataTimeOculus3(Time.realtimeSinceStartup.ToString());
                    //}

                    Debug.Log("Mensaje: " + text);
                    // latest UDPpacket
                    lastReceivedUDPPacket = text;
                    allReceivedUDPPackets = allReceivedUDPPackets + text;
                }
                 
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    public string getLatestUDPPacket()
    {
        allReceivedUDPPackets = "";
        return lastReceivedUDPPacket;
    }


    void SaveBinDataTimeRB(string d)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/data");
        }
        //Defino la ruta de mis binarios
        string path = Application.persistentDataPath + "/data";

        int fCount = Directory.GetFiles(path, "RB*", SearchOption.TopDirectoryOnly).Length;
        if (fCount > 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string s_value = (fCount + 1).ToString();
            string path1 = path + "/RB" + s_value + ".data";
            FileStream stream = new FileStream(path1, FileMode.Create);
            //insert this data into the file
            AuxClass auxc = new AuxClass(d);
            formatter.Serialize(stream, auxc);
            stream.Close();
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path1 = path + "/RB1.data";
            FileStream stream = new FileStream(path1, FileMode.Create);
            //insert this data into the file
            AuxClass auxc = new AuxClass(d);
            formatter.Serialize(stream, auxc);
            stream.Close();
        }
    }

    void SaveBinDataTimeRB2(string d)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/data");
        }
        //Defino la ruta de mis binarios
        string path = Application.persistentDataPath + "/data";

        int fCount = Directory.GetFiles(path, "2RB*", SearchOption.TopDirectoryOnly).Length;
        if (fCount > 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string s_value = (fCount + 1).ToString();
            string path1 = path + "/2RB" + s_value + ".data";
            FileStream stream = new FileStream(path1, FileMode.Create);
            //insert this data into the file
            AuxClass auxc = new AuxClass(d);
            formatter.Serialize(stream, auxc);
            stream.Close();
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path1 = path + "/2RB1.data";
            FileStream stream = new FileStream(path1, FileMode.Create);
            //insert this data into the file
            AuxClass auxc = new AuxClass(d);
            formatter.Serialize(stream, auxc);
            stream.Close();
        }
    }
    void SaveBinDataTimeOculus1(string d)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/data");
        }
        //Defino la ruta de mis binarios
        string path = Application.persistentDataPath + "/data";

        int fCount = Directory.GetFiles(path, "1OC*", SearchOption.TopDirectoryOnly).Length;
        if (fCount > 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string s_value = (fCount + 1).ToString();
            string path1 = path + "/1OC" + s_value + ".data";
            FileStream stream = new FileStream(path1, FileMode.Create);
            //insert this data into the file
            AuxClass auxc = new AuxClass(d);
            formatter.Serialize(stream, auxc);
            stream.Close();
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path1 = path + "/1OC1.data";
            FileStream stream = new FileStream(path1, FileMode.Create);
            //insert this data into the file
            AuxClass auxc = new AuxClass(d);
            formatter.Serialize(stream, auxc);
            stream.Close();
        }
    }

    void SaveBinDataTimeOculus2(string d)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/data");
        }
        //Defino la ruta de mis binarios
        string path = Application.persistentDataPath + "/data";

        int fCount = Directory.GetFiles(path, "2OC*", SearchOption.TopDirectoryOnly).Length;
        if (fCount > 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string s_value = (fCount + 1).ToString();
            string path1 = path + "/2OC" + s_value + ".data";
            FileStream stream = new FileStream(path1, FileMode.Create);
            //insert this data into the file
            AuxClass auxc = new AuxClass(d);
            formatter.Serialize(stream, auxc);
            stream.Close();
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path1 = path + "/2OC1.data";
            FileStream stream = new FileStream(path1, FileMode.Create);
            //insert this data into the file
            AuxClass auxc = new AuxClass(d);
            formatter.Serialize(stream, auxc);
            stream.Close();
        }
    }

    void SaveBinDataTimeOculus3(string d)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/data");
        }
        //Defino la ruta de mis binarios
        string path = Application.persistentDataPath + "/data";

        int fCount = Directory.GetFiles(path, "3OC*", SearchOption.TopDirectoryOnly).Length;
        if (fCount > 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string s_value = (fCount + 1).ToString();
            string path1 = path + "/3OC" + s_value + ".data";
            FileStream stream = new FileStream(path1, FileMode.Create);
            //insert this data into the file
            AuxClass auxc = new AuxClass(d);
            formatter.Serialize(stream, auxc);
            stream.Close();
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path1 = path + "/3OC1.data";
            FileStream stream = new FileStream(path1, FileMode.Create);
            //insert this data into the file
            AuxClass auxc = new AuxClass(d);
            formatter.Serialize(stream, auxc);
            stream.Close();
        }
    }
    void SaveBinDataTimeSensor(string d)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/data");
        }
        //Defino la ruta de mis binarios
        string path = Application.persistentDataPath + "/data";

        int fCount = Directory.GetFiles(path, "EN*", SearchOption.TopDirectoryOnly).Length;
        if (fCount > 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string s_value = (fCount + 1).ToString();
            string path1 = path + "/EN" + s_value + ".data";
            FileStream stream = new FileStream(path1, FileMode.Create);
            //insert this data into the file
            AuxClass auxc = new AuxClass(d);
            formatter.Serialize(stream, auxc);
            stream.Close();
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path1 = path + "/EN1.data";
            FileStream stream = new FileStream(path1, FileMode.Create);
            //insert this data into the file
            AuxClass auxc = new AuxClass(d);
            formatter.Serialize(stream, auxc);
            stream.Close();
        }
    }

}

[Serializable]
public class AuxClass
{
    public string data0;
    public AuxClass(string _data)
    {
        data0 = _data;
    }
}





