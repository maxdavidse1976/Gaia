using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    public static TypeWriterEffect instance;

    [SerializeField] private float typeSpeed = 50f;

    private void Awake()
    {
        instance = this;
    }
    public Coroutine Run(string textToType, TMP_Text dialogueText)
    {
        return StartCoroutine(TypeText(textToType, dialogueText));
    }    

    private IEnumerator TypeText( string textToType, TMP_Text dialogueText)
    {
        dialogueText.text = string.Empty;
 
        float elapsedTime = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            elapsedTime += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(elapsedTime);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            dialogueText.text = textToType.Substring(0, charIndex);
            yield return null;
        }

        dialogueText.text = textToType;
    }
}
