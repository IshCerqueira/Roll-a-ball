using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BallScript : MonoBehaviour
{
    private int count, selector;
    private Rigidbody rb;
    public float velocidade;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public AudioSource src;
    public AudioClip Shaw, Regale, Guarana, Getgud, Edino;

    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        velocidade = 2f;
        SetCountText();
        winTextObject.SetActive(false);
        selector = 0;
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


        selector = Random.Range(1, 5);
        switch (selector)
        {
            case 1:
                src.clip = Shaw;
                src.Play();
                break;
            case 2:
                src.clip = Regale;
                src.Play();
                break;
            case 3:
                src.clip = Guarana;
                src.Play();
                break;
            case 4:
                src.clip = Getgud;
                src.Play();
                break;
            case 5:
                src.clip = Edino;
                src.Play();
                break;
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= 10) 
            winTextObject.SetActive(true);

    }

}
