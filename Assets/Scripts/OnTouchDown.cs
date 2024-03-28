using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnTouchDown : MonoBehaviour
{
    void Update()
    {
        // Code for OnMouseDown in the iPhone. Unquote to test.
        RaycastHit hit = new RaycastHit();
        if (Input.touchCount == 0)
            return;

        var touch = Input.touches[0];
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out hit))
            hit.transform.gameObject.SendMessage("OnMouseDown");
    }
}