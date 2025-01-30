# OculusEnlaza

This work was made by Ana Rojo Agustí, Javier Cortina Montón, Rafael Raya López, Rodrigo García Carmona, Cristina Sánchez López de Pablo and Eloy Urendes Jiménez.

This project was developed to compare the precision of the Oculus Touch v2 controllers with an IMU (Inertial Measurement Unit) sensor and a standard goniometer.

![System](https://github.com/user-attachments/assets/bfdd21fa-1854-4324-8303-a976bbf9695a)

However, this code can be used to connect any Unity application to the Werium Assistive Solutions S.L. ENLAZA IMU sensor, by enabling Bluetooth data transfer between the ENLAZA sensor and an Oculus Quest 1/2/3 VR Headset (Android). It has been tested with HC-05/06 modules. If you are interesed in doing so, check the "Usage" section later.

It was built using Unity 2019.4.40f1 with the following plugins:
- Custom NUnit 1.0.6
- JetBrains Rider Editor 1.2.1
- Oculus XR Plugin 1.5.1
- Subsystem Registration 1.0.6
- Test Framework 1.1.31
- TextMeshPro 2.1.4
- Timeline 1.2.18
- Unity UI 1.0.0
- Version Control 1.4.18
- Visual Studio Code Editor 1.2.5
- Visual Studio Editor 2.0.15
- XR Legacy Input Helpers 2.1.9
- XR Plugin Management 4.0.1

## Assets

3D assets have not been included due to file size or license incompatibilities.

For building the binary release, these third-party assets were used:
- [Human Base Meshes](https://assetstore.unity.com/packages/3d/characters/humanoids/humans/human-base-meshes-178395)
- [Dance Animations FREE](https://assetstore.unity.com/packages/3d/animations/dance-animations-free-161313)

##  Citation and Dataset

This work was part of an study published as [Accuracy study of the Oculus Touch v2 versus inertial sensor for a single-axis rotation simulating the elbow’s range of motion](https://link.springer.com/article/10.1007/s10055-022-00660-4), in the journal Virtual Reality. If you want to cite it, please use this BibTex code:

```
@article{rojo2022accuracy,
  title={Accuracy study of the Oculus Touch v2 versus inertial sensor for a single-axis rotation simulating the elbow’s range of motion},
  author={Rojo, Ana and Cortina, Javier and S{\'a}nchez, Cristina and Urendes, Eloy and Garc{\'\i}a-Carmona, Rodrigo and Raya, Rafael},
  journal={Virtual Reality},
  volume={26},
  number={4},
  pages={1651--1662},
  year={2022},
  publisher={Springer}
}
```

The dataset used in the journal is [available here](https://dataverse.harvard.edu/dataset.xhtml?persistentId=doi%3A10.7910%2FDVN%2FJTYSFC).

## Usage

The "OculusEnlazaManager.cs" script, located in the "WeriumQuest/Scripts" folder, is an example on how to use this plugin.

All BluetoothHelper class events have BluetoothHelper as their first parameter, in order to support of connection of multiple sensors.


Therefore, instead of:
```
bluetoothHelper.OnConnected += () 
{
    // Do something...
}
```

Now do:
```
bluetoothHelper.OnConnected += (helper) 
{
    // Do something...
    // Now you have a reference to the function caller!
}
```

The above is applicable for all events. For instance, instead of:

```
bluetoothHelper.OnCharacteristicChanged += OnCharacteristicChanged;

void OnCharacteristicChanged (byte[] value, BluetoothHelperCharacteristic characteristic)
{
    // Do something
}
```

Now do:

```
bluetoothHelper.OnCharacteristicChanged += OnCharacteristicChanged;

void OnCharacteristicChanged (BluetoothHelper helper, byte[] value, BluetoothHelperCharacteristic characteristic)
{
    // Do something
}
```

To get the data from ENLAZA:

```
// Receive transformation matrix
bluetoothHelper.SendData('#om')   
// Receive the accelerometer(Ax, Ay, Az),
// magnetometer(Mx, My, Mz) and Gyroscope(Gx, Gy, Gz) measurements.
bluetoothHelper.SendData('#osct')
```
