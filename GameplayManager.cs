using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    private int m_IndexLetter = 0;
    private int LIFE = 3;
    [SerializeField]
    private List<GameObject> m_Letters;
    [SerializeField]
    private List<AudioSource> m_LettersSounds;
    [SerializeField]
    private GameObject m_ButtonBack;
    [SerializeField]
    private Text m_TextHeart;
    [SerializeField]
    private AudioSource m_Missed;
    [SerializeField]
    private Image[] m_Images;
    [SerializeField]
    private Sprite[] m_Sprites;

	// Use this for initialization
	void Start ()
    {
        CheckButtonBack();
        ChangeLife();
    }

    public void ButtonNext()
    {
        
        m_LettersSounds[m_IndexLetter].Stop();
        m_Letters[m_IndexLetter].SetActive(false);
        m_IndexLetter++;

        ChangeSprite();

        if (m_IndexLetter > (m_Letters.Count - 1))
        {
            m_IndexLetter = m_Letters.Count - 1;
            Invoke("Finish", 2);
        }

        //CheckButtonBack();

        m_Letters[m_IndexLetter].SetActive(true);
        m_LettersSounds[m_IndexLetter].Play();
    }

    private void Finish()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ButtonBack()
    {
        m_LettersSounds[m_IndexLetter].Stop();
        m_Letters[m_IndexLetter].SetActive(false);
        m_IndexLetter--;

        CheckButtonBack();

        m_Letters[m_IndexLetter].SetActive(true);
        m_LettersSounds[m_IndexLetter].Play();
    }

    public void ButtonHelp(GameObject panelHelp)
    {
        if (!panelHelp.activeInHierarchy)
        {
            panelHelp.SetActive(true);
        }
        else
        {
            panelHelp.SetActive(false);
        }
    }

    private void CheckButtonBack()
    {
        if (m_IndexLetter == 0)
        {
            m_ButtonBack.SetActive(false);
        }
        else
        {
            m_ButtonBack.SetActive(true);
        }
    }

    public void PlaySoundLetter()
    {
        m_LettersSounds[m_IndexLetter].Stop();
        m_LettersSounds[m_IndexLetter].Play();
    }

    public void ImageIncorrect()
    {
        m_Missed.Stop();
        m_Missed.Play();
        LIFE--; 
        ChangeLife();
    }

    private void ChangeLife()
    {
        if (LIFE < 1)
        {
            SceneManager.LoadScene(0);
        }

        m_TextHeart.text = LIFE.ToString();        
    }

    private void ChangeSprite()
    {
        LIFE = 3;
        ChangeLife();

        switch (m_IndexLetter)
        {
            case 0: // Aviao
                m_Images[0].sprite = m_Sprites[0];
                m_Images[1].sprite = m_Sprites[1];
                break;
            case 1: // Bola
                m_Images[0].sprite = m_Sprites[1];
                m_Images[1].sprite = m_Sprites[2];
                break;
            case 2: // Casa
                m_Images[0].sprite = m_Sprites[2];
                m_Images[1].sprite = m_Sprites[3];
                break;
            case 3: // Dado
                m_Images[0].sprite = m_Sprites[3];
                m_Images[1].sprite = m_Sprites[4];
                break;
            case 4: // Elefante
                m_Images[0].sprite = m_Sprites[4];
                m_Images[1].sprite = m_Sprites[5];
                break;
            case 5: // Fada
                m_Images[0].sprite = m_Sprites[5];
                m_Images[1].sprite = m_Sprites[1];
                break;
        }
    }
}
