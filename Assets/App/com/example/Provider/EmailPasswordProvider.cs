using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Supabase.Gotrue;
using Supabase.Gotrue.Exceptions;
using TMPro;
using UnityEngine;
namespace com.example
{
	public class EmailPasswordProvider : Provider
	{
		// Public Unity References
		public TMP_InputField EmailInput = null!;
		public TMP_InputField PasswordInput = null!;
		public TMP_Text ErrorText = null!;

		protected override void Update()
		{
			base.Update();
		}

        protected override async Task PerformSignUp()
		{
			try
			{
				Session session = (await SupabaseManager.Instance.Supabase()!.Auth.SignUp(EmailInput.text, PasswordInput.text))!;
				ErrorText.text = $"Success! Signed Up as {session.User?.Email}";
			}
			catch (GotrueException goTrueException)
			{
				ErrorText.text = $"{goTrueException.Reason} {goTrueException.Message}";
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
				ErrorText.text = $"Success! Signed In as {session.User?.Email}";
			}
			catch (GotrueException goTrueException)
			{
				ErrorText.text = $"{goTrueException.Reason} {goTrueException.Message}";
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
