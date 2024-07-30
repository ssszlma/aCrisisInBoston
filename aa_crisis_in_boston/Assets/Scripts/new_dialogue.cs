// this script handles all the dialogue scenes
// because of how lines 39-53 work this needs to be manually updated each time a new cutscene is added
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewDialogue : MonoBehaviour
{
    private TMP_Text textHolder;
    [SerializeField] private string input;

    private bool dialogueStarted = false;
    private bool dialogueCompleted = false;

    private void Start()
    {
        textHolder = GetComponent<TMP_Text>();
    }

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown && e.keyCode == KeyCode.Return)
        {
            HandleReturnKeyPress();
        }
    }

    private void HandleReturnKeyPress()
    {
        if (!dialogueStarted)
        {
            dialogueStarted = true;
            StartCoroutine(WriteText(input, textHolder, OnDialogueComplete));
        }
        else if (dialogueCompleted)
        { 
            // ----------------
            // CUTSCENE SWITCHING
            // ------------------
            
            if (SceneManager.GetActiveScene().name == "CS_1")
            {
                Debug.Log("Switch to cutscene 2");
                SceneManager.LoadScene("CS_2");
            }
            
            if (SceneManager.GetActiveScene().name == "CS_2")
            {
                Debug.Log("Switch to cutscene 3");
                SceneManager.LoadScene("CS_3");
            }
            
            if (SceneManager.GetActiveScene().name == "CS_3")
            {
                Debug.Log("Switch to abandoned house platformer level");
                SceneManager.LoadScene("ABANDONED_HOUSE");
            }
            
            // ----------------
            // CUTSCENE SWITCHING END
            // ------------------

        }
    }

    private IEnumerator WriteText(string input, TMP_Text textHolder, System.Action onComplete)
    {
        textHolder.text = ""; // Clear the text before starting
        for (int i = 0; i < input.Length; i++)
        {
            textHolder.text += input[i];
            yield return new WaitForSeconds(0.1f);
        }
        onComplete?.Invoke();
    }

    private void OnDialogueComplete()
    {
        Debug.Log("Dialogue has ended.");
        dialogueCompleted = true;
    }
}

    /*
    void Update()
    {
        bool start = true;
        if (Input.GetKeyDown(KeyCode.Return) && start == true)
        {
          StartCoroutine(WriteText(input, textHolder));
          start = false;
        }

        if (start == false)
        {
            Debug.Log("does this work");
        }
    }
    */
