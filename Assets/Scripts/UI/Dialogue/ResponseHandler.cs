using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    public static ResponseHandler instance;

    private List<GameObject> tempResponseButtons = new List<GameObject>(); 
    private void Awake()
    {
        instance = this;
    }

    public void ShowResponses(Response[] responses)
    {
        float responseBoxHeight = 0;
        foreach(Response response in responses)
        {
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response));

            tempResponseButtons.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
    }

    private void OnPickedResponse(Response response)
    {
        Debug.Log("We got here at least!");
        responseBox.gameObject.SetActive(false);
        foreach(GameObject responseButton in tempResponseButtons)
        {
            Destroy(responseButton);
        }
        DialogueUI.instance.ShowDialogue(response.DialogueObject);
    }
}
