using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventsSystem
{
    public static event Action<Transform> onTargetEnter;//trigger when an animal enter the attack tower area
    public static event Action onTargetExit;//trigger when an animal exit the attack tower area



    public static void OnTargetEnter(Transform target)
    {
        onTargetEnter(target);
    }

    public static void OnTargetExit()
    {
        onTargetExit();
    }
}
