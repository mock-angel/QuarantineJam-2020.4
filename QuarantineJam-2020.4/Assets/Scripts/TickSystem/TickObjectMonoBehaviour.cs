using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickObjectMonoBehaviour : MonoBehaviour, ITickObject
{
    void Awake()
    {
        TickManager.Instance.AddITickObject((ITickObject)this);
    }

    public virtual void OnTick()
    {
    
    }
}
