using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{
    List<mEntity> inFilter { get; }
    List<mEntity> outFilter { get; }

    bool isDoable();

    float distanceToGoal();

    void execute();
}
