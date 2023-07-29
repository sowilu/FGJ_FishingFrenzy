using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public CinemachineTargetGroup targetGroup;
    
    public void OnJoin(PlayerInput input)
    {
        var target = input.gameObject.transform;
        
        var newTargets = new List<CinemachineTargetGroup.Target>(targetGroup.m_Targets);
        var newTargetData = new CinemachineTargetGroup.Target();
        newTargetData.target = target;
        newTargets.Add(newTargetData);
        targetGroup.m_Targets = newTargets.ToArray();
    }
}
