using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner.UI
{
    public class LevelIndex : MonoBehaviour
    {
        private TMP_Text _levelIndex;

        private void Awake()
        {
            _levelIndex = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            _levelIndex.SetText(SceneManager.GetActiveScene().name);
        }
    }
}
