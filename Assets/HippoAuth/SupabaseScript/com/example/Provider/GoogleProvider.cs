using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Supabase.Gotrue;
using Supabase.Gotrue.Exceptions;
using TMPro;
using UnityEngine;
namespace HippoAuth
{
	public class GoogleProvider : Provider
	{
		protected override void Update()
		{
			base.Update();
		}
		protected override async Task PerformSignIn(){
			try
			{
                var state = (await SupabaseManager.Instance.Supabase()!.Auth.SignIn(Constants.Provider.Google, options))!;
                Application.OpenURL(state.Uri.ToString());
				// SupabaseManager.Instance.MessageText.text = $"Success! Signed In as {session.User?.Email}";
			}
			catch (GotrueException goTrueException)
			{
				SupabaseManager.Instance.MessageText.text = $"{goTrueException.Reason}";
				Debug.Log(goTrueException.Message, gameObject);
				Debug.LogException(goTrueException, gameObject);
			}
			catch (Exception e)
			{
				Debug.Log(e.Message, gameObject);
				Debug.Log(e, gameObject);
			}
		}		
	}
}
