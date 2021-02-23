using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MododeDisparo
{
    SemiAuto,    
    fullAuto,
    semiAuto
}

public class Arma : MonoBehaviour
{
    protected Animator animator;
    protected AudioSource audioSource;
    public bool tiempodedisparo = false;
    public bool puededisparar = false;
    public bool recargando = false;

    [Header("Referrencia de objetos")]
    public ParticleSystem fuegodearma;

    [Header("Referencia de sonido")]
    public AudioClip Sonidodedisparo;
    public AudioClip Sonidosinbalas;
    public AudioClip Sonidocartuchoentra;
    public AudioClip Sonidocartuchosale;
    public AudioClip Sonidovacio;
    public AudioClip sonidodesenfundar;

    [Header("Atributos de armas")]
    public MododeDisparo mododeDisparo = MododeDisparo.fullAuto;
    public float daño = 20f;
    public float ritmodedisparo = 0.3f;
    public int balasrestantes;
    public int balasencartucho;
    public int tamanodecartucho = 12;
    public int maximodebalas = 100;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        balasencartucho = tamanodecartucho;
        balasrestantes = maximodebalas;

    }

    // Update is called once per frame
    void Update()
    {
        if (mododeDisparo == MododeDisparo.fullAuto && Input.GetButton("fire1"))
        {
            revisardisparo();
        }
        else if (mododeDisparo == MododeDisparo.semiAuto && Input.GetButtonDown("fire1"))
        {
            revisardisparo();
        }

        if (Input.GetKeyDown("reload"))
        {
            //revisarrecargar();
        }
    }

    void habilitararma()
    {
        puededisparar = true;
    }

    void revisardisparo()
    {
        if (puededisparar) return;
        if (tiempodedisparo) return;
        if (recargando) return;
        if (balasencartucho > 0)
        {
            disparar();

        }
        else
        {
          //  Sonidosinbalas();
        }

    }
    void disparar()
    {
        audioSource.PlayOneShot(Sonidodedisparo);
        tiempodedisparo = true;
        fuegodearma.Stop();
        fuegodearma.Play();
        reproduciranimaciondisparo();
        balasencartucho--;
        //StartCoroutine(reiniciartiempodedisparo());

        Debug.Log("Disparando!!!");
        Debug.Log("Disparando AR<MMAMASMNAJSHS");
    }

    public virtual void reproduciranimaciondisparo()
    {
        if (gameObject.name == "Police9mm")
        {
            if (balasencartucho > 1)
            {
                animator.CrossFadeInFixedTime("Fire", 0.1f);
            }
            else
            {
                animator.CrossFadeInFixedTime("firelast", 0.1f);
            }
        }

    }

}
