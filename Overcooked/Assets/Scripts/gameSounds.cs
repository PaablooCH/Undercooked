using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSounds : MonoBehaviour
{
    public AudioSource _gameTheme;
    public AudioSource _titleTheme;
    public AudioSource _endingTheme;
    public AudioSource _deliveryCompleteSound;
    public AudioSource _ovenSound;
    public AudioSource _panSound;
    public AudioSource _knifeSound;
    public AudioSource _blenderSound;
    public AudioSource _blenderEndSound;
    public AudioSource _buttonSound;
    public AudioSource _dangerSound;
    public AudioSource _pickUpSound;

    AudioSource _currentAudio;
    public static gameSounds Instance { get; private set; }
    void Start()
    {
        Instance = this;
        _currentAudio = _titleTheme;
        _currentAudio.Play();
    }
    public void playGameTheme()
    {
        if (_currentAudio != _gameTheme)
        {
            _currentAudio.Stop();
            _currentAudio = _gameTheme;
            _currentAudio.Play();
        }
    }

    public void playTitleTheme()
    {
        if (_currentAudio != _titleTheme)
        {
            _currentAudio.Stop();
            _currentAudio = _titleTheme;
            _currentAudio.Play();
        }
    }

    public void playEndingTheme()
    {
        if (_currentAudio != _endingTheme)
        {
            _currentAudio.Stop();
            _currentAudio = _endingTheme;
            _currentAudio.Play();
        }
    }

    public void playDeliveryCompleteSound()
    {
        _deliveryCompleteSound.Play();
    }

    public void playOvenSound()
    {
        _ovenSound.Play();
    }
    
    public void stopOvenSound()
    {
        _ovenSound.Stop();
    }

    public void playPanSound()
    {
        _panSound.Play();
    }
    public void stopPanSound()
    {
        _panSound.Stop();
    }
    public void playKnifeSound()
    {
        _knifeSound.Play();
    }
    public void stopKnifeSound()
    {
        _knifeSound.Stop();
    }
    public void playBlenderSound()
    {
        _blenderSound.Play();
    }
    public void playBlenderEndSound(){
        _blenderSound.Stop();
        _blenderEndSound.Play();
    }
    public void playButtonOn()
    {
        _buttonSound.Play();
    }
    public void playDangerSound()
    {
        _dangerSound.Play();
    }

    public void stopDangerSound()
    {
        _dangerSound.Stop();
    }
    public void playPickUpSound()
    {
        _pickUpSound.Play();
    }
}
