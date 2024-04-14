using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Supabase.Gotrue;
using Supabase.Gotrue.Exceptions;
using TMPro;
using UnityEngine;
namespace HippoAuth
{
	public class EmailPasswordProvider : Provider
	{
		// Public Unity References
		public TMP_InputField EmailInput = null!;
		public TMP_InputField PasswordInput = null!;
		protected override void Update()
		{
			base.Update();
		}

        protected override async Task PerformSignUp()
		{
			try
			{
				Session session = (await SupabaseManager.Instance.Supabase()!.Auth.SignUp(EmailInput.text, PasswordInput.text))!;
				SupabaseManager.Instance.MessageText.text = $"Success! Signed Up as {session.User?.Email}";
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

		protected override async Task PerformSignIn(){
			try
			{
				Session session = (await SupabaseManager.Instance.Supabase()!.Auth.SignIn(EmailInput.text, PasswordInput.text))!;
				SupabaseManager.Instance.MessageText.text = $"Success! Signed In";
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
