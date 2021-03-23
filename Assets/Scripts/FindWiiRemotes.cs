using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WiimoteApi;
using WiimoteApi.Util;
using WiimoteApi.Internal;

public class FindWiiRemotes : MonoBehaviour
{
    public Wiimote remote;

    private void Start()
    {
        InitWiimotes();
    }
    public void InitWiimotes()
    {
        WiimoteManager.FindWiimotes(); // Poll native bluetooth drivers to find Wiimotes

        foreach (Wiimote remote in WiimoteManager.Wiimotes)
        {
            remote.SendPlayerLED(true, false, true, false);
            remote.RumbleOn = true;

            Debug.Log(remote.RumbleOn);
        }
    }

    public void FinishedWithWiimotes()
    {
        foreach (Wiimote remote in WiimoteManager.Wiimotes)
        {
            remote.SendPlayerLED(false, true, false, false);
            remote.RumbleOn = false;

            WiimoteManager.Cleanup(remote);
        }
    }
}
