using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//attach this script to the buttons as options
public class Option: MonoBehaviour
{ 
    public Text displayedText;
    public bool isCorrect;
    public Quiz parent;
    //this field is the quiz that the option belongs to


    // public Option(string displayedText, bool isCorrect) {
    //     this.displayedText=displayedText;
    //     this.isCorrect=isCorrect;
    // } 
   void Update(){} 
    public void changeButtonColor() {
           ColorBlock colors= GetComponent<Button> ().colors;
           if(isCorrect) {
           colors.selectedColor= Color.green;
           colors.normalColor= Color.green;
           colors.highlightedColor= Color.green;
           colors.pressedColor = Color.green;
           colors.disabledColor = Color.green;
           parent.increaseScore();

           } else {
               colors.selectedColor= Color.red;
               colors.normalColor = Color.red;
               colors.highlightedColor = Color.red;
               colors.pressedColor = Color.red;
               colors.disabledColor = Color.red;
           }
           GetComponent<Button>().colors = colors;
           setUninteractable();
           parent.increaseClicks();

    }
    public void resetColors(){
        ColorBlock colors = GetComponent<Button> ().colors;
        colors.selectedColor = Color.white;
        colors.normalColor = Color.white;
        colors.highlightedColor = Color.white;
        colors.pressedColor = Color.white;
        colors.disabledColor = Color.white;
        GetComponent<Button>().colors = colors;
    }
   public void resetText(){
       displayedText.text = null;
   } 
   public void resetAll(){
       resetColors();
       resetText();
       setUninteractable();
   }
   public void setUninteractable(){
    GetComponent<Button>().interactable = false;
   }
   public void setInteractable(){
       GetComponent<Button>().interactable = true;
   }
}
