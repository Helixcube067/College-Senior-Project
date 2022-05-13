using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    /* This is the dialog class. It functions with the dialog and uses the Dialog class
     * It pauses the game then sets the dialogCanvas to true and then changes the text accordingly
     * Coroutine used to queue in the text and animate it
     */ 
    //commented out are the speaker sprites and the prescene stuff. just uncomment it if you wanna use it
    private Queue<string> words;
    private Queue<Sentences> sentences;
    public GameObject dialogueCanvas;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    //public Image speakerSprite;
    public GameObject finishButton;
    public GameObject continueButton;
    public GameObject preSceneContinueButton;
    public GameObject preSceneEndButton;

    void Awake()
    {
        words = new Queue<string>();
        sentences = new Queue<Sentences>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if(!dialogueCanvas.activeInHierarchy)
            dialogueCanvas.SetActive(true);
        continueButton.SetActive(true);
        words.Clear();
        for (int i = 0; i < dialogue.dialogueHolder.Length; i++)
        {
            sentences.Enqueue(dialogue.dialogueHolder[i]);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (words.Count != 0)
        {
            string remainder = words.Dequeue();
            StartCoroutine(TypeSentence(remainder));
            return;
        }
        else if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        Sentences poppedSentence = sentences.Dequeue();
        nameText.text = poppedSentence.name;
        //this section here is for handling speaker sprites
        /*if (poppedSentence.speakerSprite != null)
            speakerSprite.sprite = poppedSentence.speakerSprite;
        else
            speakerSprite.enabled = false;*/
        StopAllCoroutines();
        for (int i = 0; i < poppedSentence.sentenceHolder.Length; i++)
        {
            words.Enqueue(poppedSentence.sentenceHolder[i]);
        }
        string sentence = words.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        continueButton.SetActive(false);
        finishButton.SetActive(true);
    }

    #region Pre-Scene dialogue
    public void StartPreSceneDialogue(Dialogue dialogue)
    {
        if (!dialogueCanvas.activeInHierarchy)
            dialogueCanvas.SetActive(true);
        preSceneContinueButton.SetActive(true);
        words.Clear();
        for (int i = 0; i < dialogue.dialogueHolder.Length; i++)
        {
            sentences.Enqueue(dialogue.dialogueHolder[i]);
        }
        DisplayPresceneNextSentence();
    }

    public void DisplayPresceneNextSentence()
    {
        if (words.Count != 0)
        {
            string remainder = words.Dequeue();
            StartCoroutine(TypeSentence(remainder));
            return;
        }
        else if (sentences.Count == 0)
        {
            PreSceneEnd();
            return;
        }
        Sentences poppedSentence = sentences.Dequeue();
        nameText.text = poppedSentence.name;
        //this section here is for handling speaker sprites
        /*if (poppedSentence.speakerSprite != null)
            speakerSprite.sprite = poppedSentence.speakerSprite;
        else
            speakerSprite.enabled = false;*/
        StopAllCoroutines();
        for (int i = 0; i < poppedSentence.sentenceHolder.Length; i++)
        {
            words.Enqueue(poppedSentence.sentenceHolder[i]);
        }
        string sentence = words.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    void PreSceneEnd() {
        preSceneContinueButton.SetActive(false);
        preSceneEndButton.SetActive(true);
    }
    #endregion
}
