using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text npcDialogueText;
    public TMP_Text playerDialogueText;
    public Dialogue dialogue;
    private int index = 0;
    public GameObject dialoguePanel; // Assign the panel or the background object that covers the dialogue area
    private int currentLineIndex; // ��ʱ�洢��ǰ������
    public  int wait=2; // �ӳ�ʱ��
    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        // Allows the dialogue box to detect mouse clicks
        if (Input.GetMouseButtonDown(0) && dialoguePanel.activeSelf)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        index = 0;
        ShowDialogue(index);
    }

    void DisplayNextSentence()
    {
        if (index < dialogue.npcLines.Length - 1)
        {
            index++;
            ShowDialogue(index);
        }
        else
        {
            // Hide the dialogue box after the last sentence
            dialoguePanel.SetActive(false);
        }
    }

    void ShowDialogue(int lineIndex)
    {
        currentLineIndex = lineIndex;
        npcDialogueText.text = dialogue.npcLines[lineIndex];
        playerDialogueText.text = "";
        Invoke("DelayedSetPlayerDialogue", wait);
    }
    void DelayedSetPlayerDialogue()
    {
        playerDialogueText.text = dialogue.playerLines[currentLineIndex];
    }
}
