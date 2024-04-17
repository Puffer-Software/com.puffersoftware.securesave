using TMPro;
using UnityEngine;

namespace PufferSoftware.SecureSave
{
    public class DemoSecurePlayerPrefsController : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private TMP_InputField inputField;

        [SerializeField] private TextMeshProUGUI playerInfoText;

        #endregion

        #region Private Variables

        private int _counter;

        private DemoPlayer _player;
        private SecureDataManager<DemoPlayer> _dataManager;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            inputField.onEndEdit.AddListener(delegate { OnEndEdit(); });
            _dataManager = new SecureDataManager<DemoPlayer>("DemoPlayerData");

            DemoPlayer player = _dataManager.Get();

            if (!string.IsNullOrEmpty(player.playerName))
            {
                playerInfoText.text = $"Player Name : {player.playerName} Click Count : {player.clickCount}";
                return;
            }


            _player = new DemoPlayer
            {
                playerName = inputField.text,
                clickCount = 0
            };
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            _counter++;
            _player.clickCount = _counter;
            _dataManager.Save(_player);
        }

        #endregion

        #region Private Methods

        private void OnEndEdit()
        {
            _player.playerName = inputField.text;
            inputField.gameObject.SetActive(false);
        }

        #endregion
    }
}