using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{

    public TextMeshProUGUI nProd;
    public TextMeshProUGUI nQuant;
    public TextMeshProUGUI cQuant;

    [SerializeField]
    private GameObject montacargasObject;    // Reference to the GameObject that holds the Montacargas script
    Character chScript;

    [SerializeField]
    private GameObject workerObject;    // Reference to the GameObject that holds the Character script
    Montacargas mScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Access the Montacargas script
        mScript = montacargasObject.GetComponent<Montacargas>();
        // Access the Character script
        chScript = workerObject.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyValuePair<string, int> first = mScript.GetFirstPedido();
        nProd.text = "Needed Product: " + first.Key;
        nQuant.text = "Needed Quantity: " + first.Value;

        cQuant.text = "Current Quantity: " + chScript.GetCurrentQuantity();
    }
}
