using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class yonetici : MonoBehaviour
{

    public GameObject balon;

    public TMPro.TextMeshProUGUI skor_txt;
    public TMPro.TextMeshProUGUI saniye_txt;

    int skor = 0;
    int saniye = 50;

    List<GameObject> balonlar;


    public AudioSource ses;
    public GameObject yeniden_oyna_pnl;

    public float balonun_hizi = 5.0f;
    float balon_ekleme_hizi = 1.0f;

    public GameObject patlama_efekti;
    public List<GameObject> patlama_efektleri_listesi;


    // Start is called before the first frame update
    void Start()
    {
        skor_txt.text = skor.ToString();
        saniye_txt.text = saniye.ToString();

        balonlar = new List<GameObject>();

        patlama_efektleri_listesi = new List<GameObject>();

        for (int j = 0; j < 10; j++) 
        {
            GameObject y_efekt = Instantiate(patlama_efekti);
            patlama_efektleri_listesi.Add(y_efekt);
            y_efekt.SetActive(false);
        }





        for(int i=0; i < 20.0f; i++)
        {
            float rast = Random.Range(-3.7f, 3.7f);
            GameObject y_balon = Instantiate(balon, new Vector3(rast, 0, 1.0f), Quaternion.Euler(0, 0, 180));

            balonlar.Add(y_balon);
            y_balon.SetActive(false);
        }

        InvokeRepeating("balon_goster", 0.0f, balon_ekleme_hizi);

        InvokeRepeating("saniye_azalt", 0.0f, 1.0f);

        InvokeRepeating("zorlugu_arrtir", 30.0f, 30.0f);

    }

    void zorlugu_arttir()
    {
        balon_ekleme_hizi -= 0.1f;
        balonun_hizi += 1.0f;
        if (balon_ekleme_hizi <= 0.2f)
        {
            balon_ekleme_hizi = 0.2f;
        }

        if (balonun_hizi >= 10.0f)
        {
            balonun_hizi = 10.0f;

        }

        CancelInvoke("balon_goster");
        InvokeRepeating("balon_goster", 0.0f, balon_ekleme_hizi);

    }

    void saniye_azalt()
    {
        saniye--;
        saniye_txt.text = saniye.ToString();

        if (saniye <= 0)
        {
            yeniden_oyna_pnl.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void skoru_degistir(int deger)
    {
        skor += deger;

        skor_txt.text = skor.ToString();
    }
    public void saniyeyi_degistir(int deger)
    {
        saniye += deger;

        saniye_txt.text = saniye.ToString();
    }




    void balon_goster()
    {
        foreach(GameObject bl in balonlar)
        {
            if (bl.activeSelf == false)
            {
                bl.SetActive(true);
                float rast = Random.Range(-3.7f, 3.7f);
                bl.transform.position = new Vector3(rast, -3.0f, 1.0f);


                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

            
        
        

    }

    public void yeniden_oyna_btn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);

    }


}


