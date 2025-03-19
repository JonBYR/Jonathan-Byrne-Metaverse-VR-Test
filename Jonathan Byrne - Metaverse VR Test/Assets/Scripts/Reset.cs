using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Reset : MonoBehaviour
{
    [SerializeField] InputActionReference reset;
    // Start is called before the first frame update
    private void OnEnable()
    {
        reset.action.started += GameReset;
    }
    private void OnDisable()
    {
        reset.action.started -= GameReset;
    }
    void GameReset(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("MainScene");
    }
}
