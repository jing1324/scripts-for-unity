using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quiz : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        [System.Serializable]
        public class Answer
        {
            public bool isCorrect;
            public string text;
        }

        public string question;
        public Answer[] options;
        // The number of options the question has.

    }
    public Question[] Questions;
    //size of this is the number of questions
    private Question currentQuestion;
    private int questionIndex;
    private int scoreCount;
    private const int maxClicks = 2;
    private int currentClicks;

    public Option[] Options;
    // The size for options is the maximum number of options for the question
    public Text displayText;
    // Start is called before the first frame update
    void Start(){
        questionIndex = -1;
        scoreCount = 0;
        nextQuestion();
    }
    private void nextQuestion(){
        currentClicks = 0;
        questionIndex++;
        if(questionIndex >= Questions.Length) {
            endQuiz();
        } else{
        currentQuestion = Questions[questionIndex];
        displayText.text = currentQuestion.question;
        for(int i=0 ; i < Options.Length; i++) {
            setOption(Options[i],currentQuestion.options[i]);            
        }
        resetOptionColors();
        }
    }

    void setOption(Option opt, Question.Answer questionOption){
        opt.isCorrect = questionOption.isCorrect;
        opt.displayedText.text = questionOption.text;
    }
    void resetOptionColors(){
        foreach(Option option in Options){
            option.resetColors();
        }
    }
    void endQuiz(){
        foreach(Option option in Options){
            option.resetAll();
        }
        displayText.text = "Your score is " + scoreCount.ToString() + "/"+ totalScore().ToString() + ".";
        GameObject.Find("nextbutton").GetComponentInChildren<Text>().text = "Click to exit";
    }
    public void WaitForSecondsNextQuestion() {

        StartCoroutine(nextQuestionWithWait());
    }
    public void increaseClicks(){
        currentClicks++;
        if(currentClicks == maxClicks) {
      
            WaitForSecondsNextQuestion();
        }
    }
    public void increaseScore(){
        scoreCount++;
    }
    IEnumerator nextQuestionWithWait()
    {     
        foreach(Option option in Options){
            option.setUninteractable();
        }
        yield return new WaitForSeconds(1);
        nextQuestion(); 
        if(questionIndex < Questions.Length){ 
        foreach(Option option in Options){
            option.setInteractable();
        }
        }
    }
    private int totalScore(){
        return Questions.Length * 2;
    }

}
