using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventsSystem
{
    public static event Action<float> onUpdateResourcesCount;

    public static void OnUpdateResourcesCount(float resourcesToAdd)
    {
        onUpdateResourcesCount(resourcesToAdd);
    }
}
