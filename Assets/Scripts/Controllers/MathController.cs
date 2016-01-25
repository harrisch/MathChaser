using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MathController : MonoBehaviour
{
    public Text equationText;
    public Button[] inputButtons;    
    private Equation currentEquation;
    public GameController gameController;

    public void setupQuestion()
    {
        Array operators = Enum.GetValues(typeof(Equation.Operator));
        currentEquation = EquationFactory.Instance.generate((Equation.Operator)operators.GetValue(UnityEngine.Random.Range(0, operators.Length)));
        updateEquationText(currentEquation);
        setupButtons(currentEquation);
    }

    /******** EQUATIONS *******/

    private void updateEquationText(Equation equation)
    {
        equationText.text = equation.getDisplayEquation();
    }


    /****** BUTTONS ******/

    private void setupButtons(Equation equation)
    {
        enableButtons();
        
        int[] guesses = equation.getGuesses(inputButtons.Length);

        for (int i = 0; i < inputButtons.Length; i++)
        {
            updateButtonText(inputButtons[i], guesses[i].ToString());        
        }
    }

    private void updateButtonText(Button button, string text)
    {
        button.GetComponentInChildren<Text>().text = text;
    }

    private void enableButtons()
    {
        foreach (Button button in inputButtons)
        {
            button.enabled = true;
            button.image.color = Color.white;
        }
    }

    private void disableButtons()
    {
        foreach (Button button in inputButtons)
        {
            button.enabled = false;
            button.image.color = Color.gray;
        }
    }

    public void buttonClicked(Button button)
    {
        disableButtons();
        if (button.GetComponentInChildren<Text>().text.Equals(currentEquation.getResult().ToString()))
        {
            equationText.text = "YOU WIN!";
            gameController.Points = gameController.Points + 100;
        }
        else {
            equationText.text = "YOU LOSE!";
            gameController.Points = gameController.Points - 100;
        }
        StartCoroutine(gameController.resetLevel());
    }
}
