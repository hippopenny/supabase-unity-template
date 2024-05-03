using UnityEngine;
using HippoAuth;
public class DeepLinkManager : MonoBehaviour
{
    public static DeepLinkManager? Instance { get; private set; }
    public string? deeplinkURL;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;                
            Application.deepLinkActivated += onDeepLinkActivated;
            if (!string.IsNullOrEmpty(Application.absoluteURL))
            {
                // Cold start and Application.absoluteURL not null so process Deep Link.
                onDeepLinkActivated(Application.absoluteURL);
            }
            // Initialize DeepLink Manager global variable.
            else deeplinkURL = "[none]";
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
 
    private async void onDeepLinkActivated(string url)
    {
        // Update DeepLink Manager global variable, so URL can be accessed from anywhere.
        deeplinkURL = url;
        Debug.Log("DeepLinkManager: onDeepLinkActivated: " + url);
        // split param ? to get access token
        string[] urlParts = url.Split('/');
        // if urlParts contain access_token
        if (urlParts.Length > 1)
        {
            // get access token
            string accessToken = urlParts[1];
            // set access token to SupabaseManager
            await SupabaseManager.Instance.Supabase().Auth.GetSessionFromUrl(new System.Uri(url));
        }
    }
}