using UnityEngine;
class LoginPanelController : MonoBehaviour{
    [SerializeField]
    private GameObject thirdPartyProviderCanvas;

    void Awake(){
#if UNITY_IOS
        thirdPartyProviderCanvas.SetActive(false);
#endif
    }
    /// <summary>
    /// Opens the login panel, please inherit class and overwrite this function if you have any custom logic/effect
    /// </summary>
    public virtual void OpenLoginPanel(){
        // Open the login panel
        gameObject.SetActive(true); 
    }
    /// <summary>
    /// Close the login panel, please inherit class and overwrite this function if you have any custom logic/effect
    /// </summary>
    public virtual void CloseLoginPanel(){
        // Close the login panel
        gameObject.SetActive(false);
    }
}