using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Common.Utility;
using Data;

public class CustomHttpClient : Singleton<CustomHttpClient>
{
    public string BaseUrl { get; private set; } = API.HOST;
    
    public async Task<string> Get(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(BaseUrl + url);
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + API.TOKEN);
        var operation =  request.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
            return null;
        }
        
        return request.downloadHandler.text;
        
    }
}