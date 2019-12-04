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
        if (operatorSymbol.text == "+")
        {
            result.text = AddNumbers().ToString();
        }

        if (operatorSymbol.text == "-")
        {
            result.text = SubNumbers().ToString();
        }

        if (operatorSymbol.text == "*")
        {
            result.text = MultNumbers().ToString();
        }

        if (operatorSymbol.text == "/")
        {
            result.text = DivNumbers().ToString();
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

    public void AddOperator()
    {
        operatorSymbol.text = "+";
    }

    public void SubOperator()
    {
        operatorSymbol.text = "-";
    }

    public void MultOperator()
    {
        operatorSymbol.text = "*";
    }

    public void DivOperator()
    {
        operatorSymbol.text = "/";
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