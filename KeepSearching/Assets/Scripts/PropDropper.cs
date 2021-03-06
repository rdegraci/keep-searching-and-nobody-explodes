﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropDropper : MonoBehaviour
{
    public enum PropSet
    {
        BOMBER_ONBOARDING, BOMBER_TOOLS, DEFUSER_ONBOARDING
    }

    public Transform Anchor;
    public GameObject BomberHat;
    public Transform BomberHatSpawnPos;
    public GameObject BomberManual;
    public Transform BomberManualSpawnPos;
    public GameObject Cutters;
    public Transform CuttersSpawnPos;
    public GameObject DefuserHat;
    public Transform DefuserHatSpawnPos;
    public GameObject DefuserManual;
    public Transform DefuserManualSpawnPos;


    public GameObject _bomberHatInstance;
    public GameObject _bomberManualInstance;
    public GameObject _cuttersInstance;
    public GameObject _defuserHatInstance;
    public GameObject _defuserManualInstance;

    public void DropProps(PropSet props)
    {
        switch (props) {
            case PropSet.BOMBER_ONBOARDING:
                _bomberHatInstance = Instantiate(BomberHat, BomberHatSpawnPos.position, Quaternion.identity);
                _bomberManualInstance = Instantiate(BomberManual, BomberManualSpawnPos.position, Quaternion.identity);
                break;
            case PropSet.BOMBER_TOOLS:
                _cuttersInstance = Instantiate(Cutters, CuttersSpawnPos.position, Quaternion.identity);
                break;
            case PropSet.DEFUSER_ONBOARDING:
                Invoke("DropDefuserProps", 2);
                break;
        }
    }

    void DropDefuserProps()
    {
        _defuserHatInstance = Instantiate(DefuserHat, DefuserHatSpawnPos.position, Quaternion.identity);
        _defuserManualInstance = Instantiate(DefuserManual, DefuserManualSpawnPos.position, Quaternion.identity);
    }

    public void RemoveBomberOnboardingProps()
    {
        if (_bomberHatInstance != null) Destroy(_bomberHatInstance);
        if (_bomberManualInstance != null) Destroy(_bomberManualInstance);
    }

    public void PrepareCutters()
    {
        if (_cuttersInstance != null) {
            _cuttersInstance.tag = "cutters";
        }
    }
}
