using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceImage : MonoBehaviour
{
    private int currentIndex = 0;
    [SerializeField] Image displayImage;         
    [SerializeField] private List<Sprite> images;
    [SerializeField] private GameObject player;

    public void ShowNextImage()
    {
        currentIndex = (currentIndex + 1) % images.Count;
        UpdateImage();
    }

    public void ShowPreviousImage()
    {
        currentIndex = (currentIndex - 1 + images.Count) % images.Count;
        UpdateImage();
    }
    public int GetCurrentIndex() {  return currentIndex; } 

    public void SetSkinCar() {  player.GetComponent<SpriteRenderer>().sprite = images[currentIndex]; }
    
    void UpdateImage()
    {
        displayImage.sprite = images[currentIndex];
    }
}
