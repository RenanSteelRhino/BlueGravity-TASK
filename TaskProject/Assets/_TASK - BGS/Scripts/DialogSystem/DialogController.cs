using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BGSTask
{
    //This class control a simple dialog box
    //It has a image for the speaker NPC and a text for the dialog
    public class DialogController : Singleton<DialogController>
    {
        [SerializeField] GameObject dialogHolder;
        [SerializeField] TextMeshProUGUI textBox;
        [SerializeField] Image sepeakerNPCImage;

        //A list of dialogs to choose from. To avoid repetitions.
        [TextArea(2,3)]
        [SerializeField] List<string> dialogsOptions = new();
        
        public void StartDialog() 
        {
            dialogHolder.SetActive(true);
            StartCoroutine(WriteMessagemOnDialogBox());
        }

        public void StopDialog()
        {
            StopAllCoroutines();
            dialogHolder.SetActive(false);
        }


        //Do a little animation on the text
        //The code hide a part of the text and set the color to invisible
        //The show in the caracters in sequence
        IEnumerator WriteMessagemOnDialogBox()
        {
            string dialog = dialogsOptions[Random.Range(0, dialogsOptions.Count)];

            for (int i = 0; i < dialog.Length+1; i++)
            {
                string text = dialog.Substring(0, i);
                text += "<color=#00000000>" + dialog.Substring(i) + "</color>";
                textBox.text = text;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
