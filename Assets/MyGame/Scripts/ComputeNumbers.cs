using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputeNumbers : MonoBehaviour
{
    public TextMeshProUGUI result;
    public TextMeshProUGUI operatorSymbol;
    public TMP_InputField inputA;
    public TMP_InputField inputB;
    public Button btnReset;
    public Button btnCalculate;
    public Toggle tglSubMode;
    public Toggle tglMultMode;

    public void SetResult()
    {
        if (operatorSymbol.text == "-")
        {
            result.text = SubNumbers().ToString();
        }

        if (operatorSymbol.text == "*")
        {
            result.text = MultNumbers().ToString();
        }

        DisableInput();
    }

    private void DisableInput()
    {
        inputA.interactable = false;
        inputB.interactable = false;
        btnCalculate.interactable = false;
        btnReset.interactable = true;
        tglSubMode.interactable = false;
        tglMultMode.interactable = false;
    }

    private void EnableInput()
    {
        inputA.interactable = true;
        inputB.interactable = true;
        btnCalculate.interactable = true;
        btnReset.interactable = false;
        tglSubMode.interactable = true;
        tglMultMode.interactable = true;
    }

    public void MultOperator()
    {
        operatorSymbol.text = "*";
    }

    public void SubOperator()
    {
        operatorSymbol.text = "-";
    }

    public void Reset()
    {
        inputA.text = "0";
        inputB.text = "0";
        result.text = "Result";
        EnableInput();
        
    }

    private int SubNumbers()
    {
        int tempResult = int.Parse(inputA.text) - int.Parse(inputB.text);
        return tempResult;
    }

    private int MultNumbers()
    {
        int tempResult = int.Parse(inputA.text) * int.Parse(inputB.text);
        return tempResult;
    }

}