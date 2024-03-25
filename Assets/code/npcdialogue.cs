using UnityEngine;
using UnityEngine.UI;

public class npcdialogue : MonoBehaviour
{
    [SerializeField] private string npcName;
    [SerializeField] private Sprite icon;
    [SerializeField] private string[] storyText; //important dialogue
    [SerializeField] private string[][] idleText; //random stuff
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void triggerStory()
    {
        dialoguemanager.instance.StartConvo(new Conversation(npcName, icon, storyText));
    }

    public void triggerIdle()
    {
        dialoguemanager.instance.StartConvo(new Conversation(npcName, icon, idleText[Random.Range(0,idleText.Length)]));
    }
}
