using TMPro;
using UnityEngine;

namespace Views
{
    public class TurnView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI txtFirstShootScore;
        [SerializeField] private TextMeshProUGUI txtSecondShootScore;
        [SerializeField] private TextMeshProUGUI txtFinalScore;

        public void SetFirstShootScore(string text)
        {
            this.txtFirstShootScore.text = text;
        }
        public void SetSecondShootScore(string text)
        {
            this.txtSecondShootScore.text = text;
        }
        public void SetFinalScore(string text)
        {
            this.txtFinalScore.text = text;
        }
    }
}