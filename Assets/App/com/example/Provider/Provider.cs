using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Supabase.Gotrue;
using Supabase.Gotrue.Exceptions;
using TMPro;
using UnityEngine;
namespace com.example
{
	public class Provider : MonoBehaviour
	{
		public TMP_Text MessageText = null!;
		private bool _doSignUp;
		private bool _doSignOut;
        private bool _doSignIn;
		protected static SignInOptions options = new SignInOptions
		{
			FlowType = Constants.OAuthFlowType.PKCE,
			RedirectTo = ""
		};
		// Unity does not allow async UI events, so we set a flag and use Update() to do the async work
		public void SignUp()
		{
			_doSignUp = true;
		}
        public void SignIn()
        {
            _doSignIn = true;
        }
		// Unity does not allow async UI events, so we set a flag and use Update() to do the async work
		public void SignOut()
		{
			_doSignOut = true;
		}

		protected virtual async void Update()
		{
			// Unity does not allow async UI events, so we set a flag and use Update() to do the async work
			if (_doSignOut)
			{
				_doSignOut = false;
				await PerformSignOut();
				_doSignOut = false;
			}

			// Unity does not allow async UI events, so we set a flag and use Update() to do the async work
			if (_doSignUp)
			{
				_doSignUp = false;
				await PerformSignUp();
				_doSignUp = false;
			}

            if (_doSignIn)
            {
                _doSignIn = false;
                await PerformSignIn();
                _doSignIn = false;
            }
		}
		protected virtual async Task PerformSignUp()
		{
            MessageText.text = "Sign Up is not supported with this provider";
			await Task.CompletedTask;
		}

		protected virtual async Task PerformSignIn()
		{
            await Task.CompletedTask;
		}

        protected virtual async Task PerformSignOut()
        {
            await SupabaseManager.Instance.Supabase()!.Auth.SignOut();
        }
	}
}
