using UnityEngine;

namespace Runner.Player
{
    public class Suit : MonoBehaviour
    {
        [SerializeField] private GameObject[] _models;

        public void ShowModel(int selectedIndex)
        {
            for (int i = 0; i < _models.Length; i++)
            {
                if (selectedIndex == i)
                {
                    _models[i].SetActive(true);
                }
                else
                {
                    _models[i].SetActive(false);
                }
            }
        }
    }
}