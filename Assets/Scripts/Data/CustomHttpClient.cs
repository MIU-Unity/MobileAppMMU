using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Common.Utility;

public class CustomHttpClient : Singleton<CustomHttpClient>
{
    public async Task<string> Get(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
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

    public async Task<string> Post(string url, string jsonData)
    {
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        var operation = request.SendWebRequest();
        while (!operation.isDone)
        {
            await Task.Yield();
        }

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
            return null;
        }
        else
        {
            return request.downloadHandler.text;
        }
    }
}