using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum OperatorType{plus, minus, multiply, divide}

public class ComputeNumbers : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI result;
    [SerializeField] private TextMeshProUGUI operatorSymbol;

    [SerializeField] private TMP_InputField inputA;
    [SerializeField] private TMP_InputField inputB;

    [SerializeField] private Button btnReset;
    [SerializeField] private Button btnCalculate;

    [SerializeField] private Toggle tglAddMode;
    [SerializeField] private Toggle tglSubMode;
    [SerializeField] private Toggle tglMultMode;
    [SerializeField] private Toggle tglDivMode;

    [SerializeField] private string englishCulture = "en-US";
    [SerializeField] private string resultText = "Result";

    private void Awake()
    {
        ChangeCulture();
    }

    private void ChangeCulture()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo(englishCulture);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(englishCulture);
    }

    public void SetResult()
    {
        switch (operatorSymbol.text)
        {
            case "+":
                result.text = CalculateNumbers(OperatorType.plus).ToString();
                break;
            case "-":
                result.text = CalculateNumbers(OperatorType.minus).ToString();
                break;
            case "*":
                result.text = CalculateNumbers(OperatorType.multiply).ToString();
                break;
            case "/":
                result.text = CalculateNumbers(OperatorType.divide).ToString();
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
        inputA.text = "";
        inputB.text = "";
        result.text = resultText;
        EnableInput();
    }

    private float CalculateNumbers(OperatorType type)
    {
        float tempResult;
        switch (type)
        {
            case OperatorType.plus:
                tempResult = float.Parse(inputA.text) + float.Parse(inputB.text);
                break;
            case OperatorType.minus:
                tempResult = float.Parse(inputA.text) - float.Parse(inputB.text);
                break;
            case OperatorType.multiply:
                tempResult = float.Parse(inputA.text) * float.Parse(inputB.text);
                break;
            case OperatorType.divide:
                tempResult = float.Parse(inputA.text) / float.Parse(inputB.text);
                break;
            default:
                tempResult = 0;
                break;
        }

        return tempResult;
    }
}

