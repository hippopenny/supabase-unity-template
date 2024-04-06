using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Supabase.Gotrue;
using Supabase.Gotrue.Exceptions;
using TMPro;
using UnityEngine;
namespace com.example
{
	public class GitHubProvider : Provider
	{
		protected override void Update()
		{
			base.Update();
		}
		protected override async Task PerformSignIn(){
			try
			{
                var state = (await SupabaseManager.Instance.Supabase()!.Auth.SignIn(Constants.Provider.Github))!;
				// MessageText.text = $"Success! Signed In as {session.User?.Email}";
			}
			catch (GotrueException goTrueException)
			{
				MessageText.text = $"{goTrueException.Reason} {goTrueException.Message}";
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
