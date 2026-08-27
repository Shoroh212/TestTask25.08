using TMPro;
using UnityEngine;


public class TaskPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _taskOne;
    [SerializeField] private TextMeshProUGUI _taskTwo;
    [SerializeField] private TextMeshProUGUI _taskThree;

    [SerializeField] private string _messageOne;
    [SerializeField] private string _messageTwo;
    [SerializeField] private string _messageThree;

    private IPointChecker _pointChecker;

    private void Start()
    {
        _taskOne.text = _messageOne;
        _taskTwo.text = _messageTwo;
        _taskThree.text = _messageThree;
    }

    public void Initialize(IPointChecker pointChecker)
    {
        _pointChecker = pointChecker;
        _pointChecker.OnCorrectPos += FirstTextColor;
    }

    private void OnDestroy()
    {
        if (_pointChecker != null)
        {
            _pointChecker.OnCorrectPos -= FirstTextColor;
        }
    }

    private void FirstTextColor()
    {
        _taskOne.color = Color.green;
    }
    private void SecondTextColorTrue()
    {
        _taskTwo.color = Color.green;
    }
    private void SecondTextColorFalse()
    {
        _taskTwo.color = Color.red;
        ThirdTextColorFalse();

    }
    private void ThirdTextColorTrue()
    {
        _taskThree.color = Color.green;
    }
    private void ThirdTextColorFalse()
    {
        _taskThree.color = Color.red;

    }



}
