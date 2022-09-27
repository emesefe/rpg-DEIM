using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reparto : MonoBehaviour
{
    public TextMeshProUGUI text; 
    
    private List<string> names = new List<string>
    {
        "Silvana",
        "Pere Albertí",
        "Juanjo",
        "Javier",
        "Joan",
        "Marta",
        "Flora",
        "Tomeu",
        "Alejandro",
        "Pere Estades",
        "Anna",
        "Miquel",
        "Óscar",
        "Alex",
        "Rowen",
        "Sam",
        "Marc",
        "Pere Ramis"
    };
    
    private List<string> games = new List<string>
    {
        "Space Invaders", // 1942
        "Pong", // Hockey mesa
        "Centipede", // Snake
        "Jet Pack",
        "Donkey Kong",
        "Doodle Jump",
        "Food Drop",
        "Memory",
        "Color switch",
        "Frogger", // Tap tap dash versionado
        "Flappy Bird",
        "Temple Run",
        "Duck Hunter", // Arcanoid (ladrillos)
        "Fruit Ninja",
        "Saving face wario",
        "Tiger ball",
        "Ice climbers", // Mario run
        "Asteroids"
    };

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && names.Count > 0 && games.Count > 0)
        {
            int i = Random.Range(0, names.Count);
            int j = Random.Range(0, games.Count);
            text.text = $"ALUMNO: {names[i]}\nJUEGO: {games[j]}";

            names.Remove(names[i]);
            games.Remove(games[j]);
        } 
    }
}
