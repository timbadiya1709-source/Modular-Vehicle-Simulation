using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    public GameObject[] cars;
    public int currentcar;
    public bool ingameplayscene = false;
    void Start()
    {
        int selectedCar = PlayerPrefs.GetInt("SelectedCarId");
        if (ingameplayscene == true)
        {
            cars[selectedCar].SetActive(true);
            currentcar = selectedCar;
            
        }        
    }
    void Update()
    {
        
    }

    public void Right()
    {
        if(currentcar < cars.Length)
        {
            currentcar += 1;
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SetActive(false);
                cars[currentcar].SetActive(true);
            }
        }
    }
    
    public void Left()
    {
        if(currentcar > 0)
        {
            currentcar -= 1;
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SetActive(false);
                cars[currentcar].SetActive(true);
            }
        }
    }

    public void select()
    {
        PlayerPrefs.SetInt("SelectedCarId", currentcar);
        SceneManager.LoadScene(1);
    }
}
