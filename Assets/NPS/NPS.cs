using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.UIElements;

public class NPS : MonoBehaviour
{
    public GameObject windowDialog;
    public TextMeshProUGUI textDialog;
    public string[] message;
    public int numberDialog = 0;
    ///public Button button;
    public Canvas can;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (numberDialog == message.Length - 1)
            {
                //button.gameObject.SetActive(false);
            }
            else
            {
                //button.gameObject.SetActive(true);
            }
            
            windowDialog.SetActive(true);
            textDialog.text = message[numberDialog];
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        windowDialog.SetActive(false);
        numberDialog = 0;
        //button.onClick.RemoveAllListeners();
    }
    public void onclic()
    {
        StartCoroutine(NextDialog());
        StopAllCoroutines();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            onclic();
        }
    }

    private IEnumerator NextDialog()
    {
        numberDialog++;
        textDialog.text = message[numberDialog];

        if (numberDialog == message.Length - 1)
        {
            //button.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(5.0f);
    }

}
