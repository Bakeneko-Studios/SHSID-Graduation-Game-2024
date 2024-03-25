using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialoguemanager : MonoBehaviour
{
    public static dialoguemanager instance;

    //ui
    [SerializeField] private bool boxOpen = false;
    [SerializeField] private TextMeshProUGUI dName, dText;
    [SerializeField] private Image dIcon, dframe, dbox;
    [SerializeField] private Animator anim;
    [SerializeField] private float textAnimDelay;

    private Queue<string> lines = new();
    
    string currentLine;
    Coroutine tc;
    bool inTextAnim;

    private void Awake() {
        if (instance != this) Destroy(gameObject);
        instance = this;
    }

    void Start()
    {
        
    }
    
    void Update() {
        if(boxOpen && Input.GetKeyDown(KeyCode.Space))
        {
            if(inTextAnim)
                Skip();
            else
                DisplayNext();
        }
    }

    void Skip()
    {
        StopCoroutine(tc);
        dText.text = currentLine;
        inTextAnim = false;
    }
    
    public bool StartConvo(Conversation convo)
    {
        dName.text = convo.name;
        dIcon.sprite = convo.icon;
        anim.SetBool("open", true);
        boxOpen = true;
        foreach (string s in convo.lines) lines.Enqueue(s);
        tc = StartCoroutine(TextAnim(lines.Dequeue()));
        return true;
    }

    IEnumerator DisplayNext()
    {
        dText.text = "";
        if(lines.Count==0)
        {
            tc = null;
            anim.SetBool("open", false);
            boxOpen = false;
        }
        else
        {
            tc = StartCoroutine(TextAnim(lines.Dequeue()));
        }

        yield return null;
    }
    IEnumerator TextAnim(string line)
    {
        inTextAnim = true;
        currentLine = line;
        foreach(char c in line)
        {
            dText.text += c;
            yield return new WaitForSeconds(textAnimDelay);
        }
        inTextAnim = false;
    }
}

[System.Serializable]
public class Conversation
{
    public string name;
    public Sprite icon;
    public string[] lines;
    public Conversation(string name, Sprite icon, string[] lines)
    {
        this.name = name;
        this.icon = icon;
        this.lines = lines;
    }
}
