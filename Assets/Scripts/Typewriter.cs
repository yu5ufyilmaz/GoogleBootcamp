using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// Type Writer Script, Author : witnn .

[RequireComponent(typeof(AudioSource))]
public class TypeWriter : MonoBehaviour
{
    public float delay = 0.1f;
    public AudioClip TypeSound;
    [Multiline]
    public string yazi;
  
    AudioSource audSrc;
    TextMeshProUGUI thisText;

    private void Start()
    {
        audSrc = GetComponent<AudioSource>();
        thisText = GetComponent<TextMeshProUGUI>();
        thisText.text = GenerateText();
        StartCoroutine(TypeWrite());
        
    }

    public string GenerateText()
    {
        string text = "Sadece bu oyunda " + PlayerPrefs.GetInt("DeathCount") + " çocuk öldü. Sadece İkinci Dünya Savaşı tahmini 1,5 ila 2 milyon çocuk ölümüne sebep oldu. Savaşta ölen insan sayılarına baktığımızda , insanlığın karanlık yüzüyle yüzleşmek zorundayız. Bombaların hedefi olan okullar, parklar ve oyun alanları, bir zamanlar çocuk kahkahalarıyla doluyken şimdi sessiz birer mezar haline geldiler. İstatistikler soğuk sayılar gibi görünse de, her bir çocuğun arkasında hayalleri, umutları ve geleceği vardı.";
        return text;
    }
    IEnumerator TypeWrite()
    {
        foreach(char i in yazi)
        {
            thisText.text += i.ToString();

            audSrc.pitch = Random.Range(0.8f, 1.2f);
            audSrc.PlayOneShot(TypeSound);

            if(i.ToString() == ".") { yield return new WaitForSeconds(1); }
            else { yield return new WaitForSeconds(delay); }          
        }
    }
}
