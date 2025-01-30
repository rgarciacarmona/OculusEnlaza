# OculusEnlaza

This project was developed to compare the precision of the Oculus Touch controllers with an IMU (Inertial Measurement Unit) sensor and a standard goniometer.

However, this code can be used to connect any Unity application to the Werium Assistive Solutions S.L. ENLAZA IMU sensor, by enabling Bluetooth data transfer between the ENLAZA sensor and an Oculus Quest VE Headset (Android). It has been tested with HC-05/06 modules. If you are interesed in doing so, check the "Usage" section later.

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