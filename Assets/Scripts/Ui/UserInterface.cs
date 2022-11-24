using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    private Text _text;

    void Start()
    {
        transform.Find("Text").TryGetComponent<Text>(out _text);
    }

    public void SetScore(int score)
    {
        if (_text != null)
        {
            _text.text = $"Win Points: {score}";
        }
    }
}
