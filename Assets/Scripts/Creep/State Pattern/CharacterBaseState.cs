using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseState
{
    public abstract void EnterState(CreepManager c);

    public abstract void UpdateState(CreepManager c);

    public abstract void ExitState(CreepManager c);
}
