using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler {
    bool on;
    Animator animator;
    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("Click");
        on = true;
    }

    public void OnPointerDown(PointerEventData eventData) {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData) {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData) {
        throw new System.NotImplementedException();
    }

    void Update() {
        if (on) {
            animator = GetComponent<Animator>();
            animator.SetBool("anim", true);
            GameObject.Find("Panel").GetComponent<LoadSprites>().load();
        }
    }
}
