using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
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
    public Toggle tglAddMode;
    public Toggle tglSubMode;
    public Toggle tglMultMode;
    public Toggle tglDivMode;

    private void Awake()
    {
        ChangeCulture();
    }

    private void ChangeCulture()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        
    }

    public void SetResult()
    {
        switch (operatorSymbol.text)
        {
            case "+":
                result.text = AddNumbers().ToString();
                break;
            case "-":
                result.text = SubNumbers().ToString();
                break;
            case "*":
                result.text = MultNumbers().ToString();
                break;
            case "/":
                result.text = DivNumbers().ToString();
                break;
        }

        DisableInput();
    }

    private void DisableInput()
    {
        inputA.interactable = false;
        inputB.interactable = false;
        btnCalculate.interactable = false;
        btnReset.interactable = true;
        tglAddMode.interactable = false;
        tglSubMode.interactable = false;
        tglMultMode.interactable = false;
        tglDivMode.interactable = false;
    }

    private void EnableInput()
    {
        inputA.interactable = true;
        inputB.interactable = true;
        btnCalculate.interactable = true;
        btnReset.interactable = false;
        tglAddMode.interactable = true;
        tglSubMode.interactable = true;
        tglMultMode.interactable = true;
        tglDivMode.interactable = true;
    }

    public void SetOperator(string operatorSymbolInput)
    {
        operatorSymbol.text = operatorSymbolInput;
    }

    public void Reset()
    {
        inputA.text = "0";
        inputB.text = "0";
        result.text = "Result";
        EnableInput();
    }

    private float AddNumbers()
    {
        float tempResult = float.Parse(inputA.text) + float.Parse(inputB.text);
        return tempResult;
    }

    private float SubNumbers()
    {
        float tempResult = float.Parse(inputA.text) - float.Parse(inputB.text);
        return tempResult;
    }

    private float MultNumbers()
    {
        float tempResult = float.Parse(inputA.text) * float.Parse(inputB.text);
        return tempResult;
    }

    private float DivNumbers()
    {
        float tempResult = float.Parse(inputA.text) / float.Parse(inputB.text);
        return tempResult;
    }
}