using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class LoginController : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _inputName;
        [SerializeField]
        private TMP_InputField _inputPassword;
        [SerializeField]
        private Button _buttonSignUp;
        [SerializeField]
        private Button _buttonSignIn;
    
        // Start is called before the first frame update
        void Start()
        {
            _buttonSignIn.onClick.AddListener(SignIn);
        
            _buttonSignUp.onClick.AddListener(SignUp);

        }

        private void SignIn()
        {
            if (_inputName.text.Length == 0)
            {
                print("Name can't be null");
            }
        
            if (_inputPassword.text.Length == 0)
            {
                print("Password can't be null");
            }
        
            print($"Name: {_inputName.text} Pass: {_inputPassword.text}");
        }

        private void SignUp()
        {
            print("Sign up new account");
        }
    }
}
