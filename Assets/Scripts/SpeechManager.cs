using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
        //when you say "reset" then reset the light to off
        keywords.Add("Reset", () =>
        {
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("OnReset");
        });
        //when you say "Turn off" then turn sphere white
        keywords.Add("Turn off", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                focusObject.SendMessage("OnReset", SendMessageOptions.DontRequireReceiver);
            }
        });
        //when you say "Red" then turn sphere red
        keywords.Add("Red", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if(focusObject != null)
            {
                focusObject.SendMessage("OnRed", SendMessageOptions.DontRequireReceiver);
            }
        });
        //when you say "blue" then turn sphere blue
        keywords.Add("Blue", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                focusObject.SendMessage("OnBlue", SendMessageOptions.DontRequireReceiver);
            }
        });
        //when you say "Turn on" then turn sphere yellow
        keywords.Add("Turn on", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                focusObject.SendMessage("OnTurnOn", SendMessageOptions.DontRequireReceiver);
            }
        });
        //when you say "Yellow" then turn sphere Yellow
        keywords.Add("Yellow", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                focusObject.SendMessage("OnTurnOn", SendMessageOptions.DontRequireReceiver);
            }
        });

        // Add new keywords to KeywordRecognizer and try make it recognize the phrases
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }


    //When keyword is recognized then do the corresponding method
    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}