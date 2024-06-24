using System.Threading.Tasks;
using Common.Utility;
using TMPro;
using UnityEngine;

namespace Data
{
    public class Connection : Singleton<Connection>
    {
        [SerializeField] private TextMeshProUGUI _statusText;
        
        public bool Status { get; private set; }
        
        public async Task Initialize()
        {
            var x = await CustomHttpClient.Instance.Get($"/questions");

            Status = x != null;
            
            _statusText.text = Status ? "Соединение успешно установлено!" : "Ошибка подключения... Повторите попытку.";
            
        }

    }
}