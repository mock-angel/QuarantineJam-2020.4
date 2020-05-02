using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TickObjectMonoBehaviour : MonoBehaviour, ITickObject
{
    public abstract void OnTick();
}
