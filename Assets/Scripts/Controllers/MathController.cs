using UnityEngine;using UnityEngine.UI;using System.Collections;using System;public class MathController : MonoBehaviour
{    public Text equationText;
    public Button[] inputButtons;
    private EquationGenerator generator;    private Equation currentEquation;

    // Use this for initialization
    void Start()
    {
        generator = new EquationGenerator();        setupQuestion();    }

    public IEnumerator resetLevel()
    {        yield return new WaitForSeconds(1);        setupQuestion();    }    private void setupQuestion()
    {        Array operators = Enum.GetValues(typeof(Equation.Operator));        currentEquation = generator.generate((Equation.Operator)operators.GetValue(UnityEngine.Random.Range(0, operators.Length - 1)));        updateEquationText(currentEquation);
        setupButtons(currentEquation);    }

    /******** EQUATIONS *******/

    private void updateEquationText(Equation equation)
    {
        equationText.text = equation.getDisplayEquation();
    }


    /****** BUTTONS ******/

    private void setupButtons(Equation equation)
    {        enableButtons();        int answerButton = UnityEngine.Random.Range(0, inputButtons.Length - 1);

        for (int i = 0; i < inputButtons.Length; i++)
        {            if (answerButton == i)
            {                updateButtonText(inputButtons[i], equation.getResult().ToString());            }
            else {                int variance = 0;                while (variance == 0)
                {                    variance = UnityEngine.Random.Range(-10, 10);                }                updateButtonText(inputButtons[i], (equation.getResult() + variance).ToString());            }        }    }    private void updateButtonText(Button button, string text)
    {        button.GetComponentInChildren<Text>().text = text;    }    private void enableButtons()
    {        foreach (Button button in inputButtons)        {            button.enabled = true;            button.image.color = Color.white;        }    }    private void disableButtons()
    {        foreach (Button button in inputButtons)
        {            button.enabled = false;            button.image.color = Color.gray;        }    }    public void buttonClicked(Button button)
    {        disableButtons();        if (button.GetComponentInChildren<Text>().text.Equals(currentEquation.getResult().ToString()))
        {            equationText.text = "YOU WIN!";        }
        else {            equationText.text = "YOU LOSE!";        }        StartCoroutine(resetLevel());
    }}