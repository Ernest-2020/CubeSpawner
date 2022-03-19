using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] private TMP_InputField _timeInputField;
    [SerializeField] private TMP_InputField _speedInputField;
    [SerializeField] private TMP_InputField _distanceInputField;
    [SerializeField] private TextMeshProUGUI _exceptionText;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _buttonStart;
    void Start()
    {
        _buttonStart.onClick.AddListener(StartSpawn);
    }

    private void StartSpawn()
    {
        try
        {
            _spawner.RefierSpawn = float.Parse(_timeInputField.text);
            _spawner.Pool.ObjectPrefab.Speed = float.Parse(_speedInputField.text);
            foreach (var item in _spawner.Pool.ListObjects)
            {
                item.Speed = float.Parse(_speedInputField.text);
                item.Distance = float.Parse(_distanceInputField.text);
            }
            _exceptionText.text = null;

        }
        catch
        {
            _exceptionText.text = "Введите корректное число. Не целые числа вводятся через запятую";

        }
    }
}
