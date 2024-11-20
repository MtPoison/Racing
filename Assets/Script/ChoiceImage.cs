using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceImage : MonoBehaviour
{
    private int currentIndex = 0;
    public Image displayImage;         
    public Sprite[] images;
    public void ShowNextImage()
    {
        currentIndex = (currentIndex + 1) % images.Length;
        UpdateImage();
    }

    public void ShowPreviousImage()
    {
        currentIndex = (currentIndex - 1 + images.Length) % images.Length;
        UpdateImage();
    }

    public int GetCurrentIndex() {  return currentIndex; } 
    
    void UpdateImage()
    {
        displayImage.sprite = images[currentIndex];
    }
}
