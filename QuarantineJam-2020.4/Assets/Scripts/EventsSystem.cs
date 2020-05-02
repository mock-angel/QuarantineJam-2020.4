using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventsSystem
{
    public static event Action onUpdateResourcesCount;

    public static void OnUpdateResourcesCount()
    {
        onUpdateResourcesCount();
    }
}
