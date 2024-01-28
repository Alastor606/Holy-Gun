using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageDecorator : DamageDealler
{
    protected DamageDealler Dealler;

    public DamageDecorator(DamageDealler dealler)
    {
        Dealler = dealler;
    }     
    
}
