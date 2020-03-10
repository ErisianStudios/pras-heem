using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RNJesus : MonoBehaviour
{
#pragma warning disable 
    private int sides;
    private int times;
    private int modifiers;
    private int result;
    public bool playSound;
    [SerializeField] private AudioSource sfx;
    [SerializeField] private TMP_InputField sidesField;
    [SerializeField] private TMP_InputField timesField;
    [SerializeField] private TextMeshProUGUI prasHeem;
    [SerializeField] private TMP_InputField modifiersField;
    [SerializeField] private Toggle soundToggle;

    // Start is called before the first frame update
    private void Start() {
        playSound = soundToggle.isOn;
    }
    public void ToggleSound() {
        playSound = !playSound;
    }
    public void Pras() {
        Random.seed = (int)System.DateTime.Now.Ticks;
        if (int.TryParse(sidesField.text, out sides)) 
            sides = int.Parse(sidesField.text);
        else sides = 0;

        if (int.TryParse(timesField.text, out times))
            times = int.Parse(timesField.text);
        else times = 0;

        if (int.TryParse(modifiersField.text, out modifiers))
            modifiers = int.Parse(modifiersField.text);
        else modifiers = 0;

        result = 0;

        for (int i = 0; i < times; i++) {
            int tmp = Random.Range(1, sides + 1);
            result += tmp;
        }
        result += modifiers;
        prasHeem.text = result.ToString();
        if (playSound) {
            if(result == 1) {
                //Play sad sound.
                sfx.Play();
            }
            sfx.Play();
        }
    }
}
