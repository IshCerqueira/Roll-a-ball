using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BallScript : MonoBehaviour
{
    private int count;
    private Rigidbody rb;
    public float velocidade;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        velocidade = 5f;
        SetCountText();
        winTextObject.SetActive(false);
    }
    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
        rb.AddForce(movimento * velocidade);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
            other.gameObject.SetActive(false);
        count = count + 1;
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 4) 
            winTextObject.SetActive(true);

    }

}
