using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

[CreateAssetMenu(fileName = "New Player", menuName = "Entities/Player")]
public class Player : Entity
{
    public override void Die()
    {
        SceneManager.LoadScene("GameOver");
    }   
}
