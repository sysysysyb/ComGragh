using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTutorial : MonoBehaviour
{
    public Text chat;       // 출력할 대사
    string printChat;       // 출력 대사를 담을 문자열 변수
    public Image image;

    int trigger = 0;        // 캠프파이어와 닿았는지 체크하는 변수

    void Start()
    {
        chat.GetComponent<Text>().enabled = false;
        image.GetComponent<Image>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (trigger == 1)
            {
                StartCoroutine(dialog("불이 활활 타오르고 있다."));
            }
            else if (trigger == 2)
            {
                StartCoroutine(dialog("-> Castle"));
            }
            else if (trigger == 3)
            {
                StartCoroutine(dialog("체력을 회복해주는 동상인 것 같다."));
            }
            else if (trigger == 4)
            {
                StartCoroutine(dialog("'Castle'에 도전할 사람을 구한다는 전단지가 붙어있다."));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Campfire"))
            trigger = 1;
        else if (other.gameObject.CompareTag("Notice"))
            trigger = 2;
        else if (other.gameObject.CompareTag("Statue"))
            trigger = 3;
        else if (other.gameObject.CompareTag("Board"))
            trigger = 4;
        //else if (other.gameObject.CompareTag("DeadEnd"))
            //trigger = 5;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        trigger = 0;
    }

    IEnumerator dialog(string dlg)
    {
        chat.GetComponent<Text>().enabled = true;
        image.GetComponent<Image>().enabled = true;

        printChat = "";

        for (int i = 0; i < dlg.Length; i++)
        {
            printChat += dlg[i];
            chat.text = printChat;
            yield return new WaitForSeconds(0.03f);
        }

        yield return new WaitForSeconds(4f);

        chat.GetComponent<Text>().enabled = false;
        image.GetComponent<Image>().enabled = false;
    }
}
