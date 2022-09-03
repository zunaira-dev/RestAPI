using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RestApi : MonoBehaviour
{
    InputField outputArea;
    void Start() {
        outputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
        GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);
        GameObject.Find("PostButton").GetComponent<Button>().onClick.AddListener(PostData);
    }
    void GetData() => StartCoroutine(GetData_Coroutine());

    IEnumerator GetData_Coroutine() {
        outputArea.text = "Loading...";
        string uri = "https://my-json-server.typicode.com/typicode/demo/posts";
        using (UnityWebRequest request = UnityWebRequest.Get(uri)) {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                outputArea.text = request.error;
            else
                outputArea.text = request.downloadHandler.text;
        }
    }
    void PostData() => StartCoroutine(PostData_Coroutine());

    IEnumerator PostData_Coroutine() {
        outputArea.text = "Loading...";
        string uri = "https://my-json-server.typicode.com/typicode/demo/posts";
        WWWForm form = new WWWForm();
        form.AddField("title", "test data");
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form)) {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                outputArea.text = request.error;
            else
                outputArea.text = request.downloadHandler.text;
        }
    }
}
