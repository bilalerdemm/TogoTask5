using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour, IDragHandler
{
    public Transform character;
    public GameObject myPlayer;
    public static PlayerMove instance;

    private void Awake() => instance = this;

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 pos = character.localPosition;
        pos.x = Mathf.Clamp(pos.x + (eventData.delta.x / 100), -4, 4);
        character.localPosition = pos;
        /*
        Quaternion rot = child.rotation;
        rot.y = Mathf.Clamp(rot.y + (eventData.delta.x / 500), -2f, 2f);
        child.rotation = rot;
        */
    }
}
