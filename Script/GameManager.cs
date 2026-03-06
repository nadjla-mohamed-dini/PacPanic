
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PacmanScript pacman;
    public Transform peletts;
    public int score {get; private set;}
    public int lives { get; private set;}

    private void Start()
    {
        SetScore(0);
        SetLives(3);
        NewRound();

    }

    private void NewRound()
    {
        foreach (Transform peletts in this.peletts)
        {
            peletts.gameObject.SetActive(true);
        }
        ResetState();
    }
    private void ResetState()
    {
        this.pacman.gameObject.SetActive(true);
    }

    private void SetScore(int score)
    {
        this.score =  score;
    }

    private void SetLives(int lives)
    {
        this.lives =  lives;
    }

    private void GameOver()
    {
        this.pacman.gameObject.SetActive(false);
    }

    public void PeletteEaten(Pelette peletts)
    {
        peletts.gameObject.SetActive(false);
        SetScore(this.score + peletts.point);

        //if (!HasRemainingPellets())
        //{
        //    this.pacman.gameObject.SetActive(false);
        //    Invoke(nameof(NewRound), 3.0f); 
        //}
    }
    public void PowerPelette(PowerPelette peletts)
    {
        PeletteEaten(peletts);
    }
    private bool HasRemainingPellets()
    {
        foreach (Transform peletts in this.peletts)
        {
            if (peletts.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
    public void PeletteEaten(Pelette pellet, Vector3 position)
    {
        Debug.Log($"Pellet eaten at ({position.x}, {position.y})");
    }

}
