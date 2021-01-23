/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Copyright 2015
 **/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Person))]
public class Dialog : MonoBehaviour
{
    public DialogueFile dialogueFile = null;
    public DialogueWindow window;

    public List<UserdataEvents> events = new List<UserdataEvents>();
         
    private DialogueManager manager;
    private Dialogue currentDialogue;
    private Dialogue.Choice currentChoice = null;

    public static bool windowOpen = false;

    Person persons;

    bool finished = true;

    public static string version = "1.0.0";

    void Start()
    {
        persons = GetComponent<Person>();
    }

    public void StartDialouge(string dialogName)
    {
        manager = DialogueManager.LoadDialogueFile(dialogueFile);
        currentDialogue = manager.GetDialogue(dialogName);
        currentChoice = currentDialogue.GetChoices()[0];
        currentDialogue.PickChoice(currentChoice);


        window.gameObject.SetActive(true);

        


        for(int i = 0; i < window.choices.Length; i++)
        {
            window.choices[i].GetComponent<DialogueButton>().dialog = this;
        }
        window.next.GetComponent<DialogueButton>().dialog = this;

        finished = false;

        UpdateWindow();
    }

    void Update()
    {
        if(!finished)
            UpdateChoices();

        if (window != null)
            windowOpen = window.gameObject.active;
        else
            windowOpen = false;
    }

    void UpdateChoices()
    {
        Dialogue.Choice[] choices = currentDialogue.GetChoices();

        for(int i = 0; i < choices.Length; i++)
        {
            window.choices[i].GetComponent<DialogueButton>().choice = choices[i];
        }
    }

    void UpdateWindow()
    {
        window.dialog.text = currentChoice.dialogue;
        window.name.text = currentChoice.speaker;
        window.face.sprite = GetFace(currentChoice.speaker);

        Dialogue.Choice[] choices = currentDialogue.GetChoices();

        if(choices.Length > 1)
        {
            for(int i = 0; i < window.choices.Length; i++)
            {
                window.choices[i].SetActive(false);
            }

            for(int i = 0; i < choices.Length; i++)
            {
                window.choices[i].SetActive(true);
                window.choices[i].GetComponentInChildren<Text>().text = choices[i].dialogue;
            }

            window.next.SetActive(false);
        }
        else if(choices.Length == 1)
        {
            for(int i = 0; i < window.choices.Length; i++)
            {
                window.choices[i].SetActive(false);
            }

            window.next.SetActive(true);
            window.next.GetComponentInChildren<Text>().text = "Next";
        }
        else
        {
            //end
        }
    }

    Sprite GetFace(string speaker)
    {

        if (persons.persons.Count > 0)
        {
            for (int i = 0; i < persons.persons.Count; i++)
            {
                if (persons.persons[i].name.ToLower() == speaker.ToLower())
                {
                    return persons.persons[i].face;
                }
            }
        }

        return null;
    }

    void CheckUserdata()
    {

        for(int i = 0; i < events.Count; i++)
        {
            if(events[i].userdata == currentChoice.userData)
            {
                BaseEventData eventData = new BaseEventData(EventSystem.current);
                events[i].theEvent.Invoke(eventData);
            }
        }    



    }

    public void Loadlevel()
    {
        Application.LoadLevel(PlayerInformation.currentlvl);
    }

    public void LoadCity()
    {
        Application.LoadLevel("city");
    }

    public void Pick(Dialogue.Choice choice = null)
    {
        if(finished)
        {
            window.gameObject.SetActive(false);
            return;
        }

        if(choice != null)
        {
            currentDialogue.PickChoice(choice);
            currentChoice = choice;
            UpdateChoices();
        }
        else
        {
            currentChoice = currentDialogue.GetChoices()[0];
            currentDialogue.PickChoice(currentChoice);
        }

        if(currentDialogue.GetChoices().Length == 0)
        {
            window.next.SetActive(true);

            for(int i = 0; i < window.choices.Length; i++)
            {
                window.choices[i].SetActive(false);
            }

            window.next.GetComponentInChildren<Text>().text = "Leave.";
            finished = true;
        }
        UpdateWindow();
        CheckUserdata();
    }
}

[System.Serializable]
public class UserdataEvents
{
    public string userdata;
    public EventTrigger.TriggerEvent theEvent;
}

