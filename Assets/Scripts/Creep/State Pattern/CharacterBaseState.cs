using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseState
{
    public abstract void EnterState(CharacterStateManager c);

    public abstract void UpdateState(CharacterStateManager c);

    public abstract void ExitState(CharacterStateManager c);
}
