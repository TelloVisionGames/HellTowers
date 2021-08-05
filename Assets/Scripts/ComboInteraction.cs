using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ComboInteraction : MonoBehaviour
{
    [SerializeField]
    private List<ArrowDirection> arrowDirections;

    [SerializeField]
    private bool isOn = false;

    [SerializeField]
    private int currentIndex = 0;
    [SerializeField]
    private int maxIndex;

    [SerializeField]
    private ComboDirection lastInput;

    public UnityEvent comboSuccess;
    public UnityEvent comboFail;

    public void Awake (){
      maxIndex = arrowDirections.Count;
    }

    public void InputReceiver(Vector2 input){
      if(input.y > 0.1) {
        lastInput = ComboDirection.up;
        Combo();
      }
      else if(input.y < -0.1) {
        lastInput = ComboDirection.down;
        Combo();
      }

      if(input.x > 0.1) {
        lastInput = ComboDirection.right;
        Combo();
      }
      else if(input.x < -0.1) {
        lastInput = ComboDirection.left;
        Combo();
      }
    }

    public void printThisMessage(string input){
      Debug.Log(input);
    }

    private void Combo(){
      if(isOn){
        if(currentIndex > maxIndex) currentIndex = 0;
        if(arrowDirections[currentIndex].chosenDirection == lastInput){
           currentIndex++;
           if(currentIndex == maxIndex){
              comboSuccess.Invoke();
              currentIndex = 0;
            }
         }
        else {
          comboFail.Invoke();
          currentIndex = 0;
        }
      }
    }


}