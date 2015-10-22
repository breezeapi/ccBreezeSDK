using System;

namespace Datapel.BreezeAPI.SDK.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorisationState
    {
        /// <summary>
        /// 
        /// </summary>
        public AuthorisationState()
        {
            isAuthorised = false; 
        }

        string _errorMsg = string.Empty;

        /// <summary>
        /// Breeze API server URL and Port. 
        /// </summary>
        public string BreezeAPIPath { get; set; }

        /// <summary>
        /// Auth token return from Breeze API server. 
        /// </summary>
        public string Auth_Token { get; set; }
        /// <summary>
        /// Base64 encode user:password.
        /// </summary>
        public string AuthorisationCode { get; set; }
        /// <summary>
        /// If the authorisation process is went through successful, then it will be set true
        /// </summary>
        public bool isAuthorised { get; internal set; }
        /// <summary>
        /// If the authorisation process failed, then the exception message will be stored here
        /// </summary>
        public string ErrorMsg
        {
            get
            {
                if (!isAuthorised)
                    return _errorMsg;
                else
                    return string.Empty;
            }
            internal set
            {
                _errorMsg = value; 
            }
        }

    }
}
