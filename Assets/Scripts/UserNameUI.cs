using TMPro;
using Unity.Services.Core;
using UnityEngine;

public class UserNameUI : MonoBehaviour
{

    [SerializeField] private TMP_Text usernameText;
    [SerializeField] private TMP_InputField userNameInputField;
    [SerializeField] private CloudServices cloudServices;

    private async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();

            await cloudServices.RealizarLogin();
            AtualizarUi();
        }
        catch
        {

        }
    }

    private void AtualizarUi()
    {
        string username = cloudServices.GetUserName();
        usernameText.text = username;   
        userNameInputField.text = username.Substring(0,username.IndexOf("#"));
    }

    public async void SalvarNovoUsername()
    {
        await cloudServices.AtualizarUserName(userNameInputField.text);
        AtualizarUi();
    }

}
