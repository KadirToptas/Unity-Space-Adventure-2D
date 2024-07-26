using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Planets : MonoBehaviour
{
    private List<GameObject> planetList = new List<GameObject>();

    private List<GameObject> usedPlanets = new List<GameObject>();
    
    void Awake()
    {
        Object[] sprites = Resources.LoadAll("Gezegenler");

        for (int i = 1; i < 17; i++)
        {
            GameObject planet = new GameObject();
            SpriteRenderer sr = planet.AddComponent<SpriteRenderer>();
            sr.sprite = (Sprite)sprites[i];
            Color spriteColor = sr.color;
            spriteColor.a = 0.5f;
            sr.color = spriteColor;
            planet.name = sprites[i].name;
            sr.sortingLayerName = "Planet";
            Vector2 pos = planet.transform.position;
            pos.x = -10;
            planet.transform.position = pos;
            planetList.Add(planet);
        }
    }


    public void SettlePlanets(float refY)
    {
        float height = ScreenCalculator.instance.Height;
        float width = ScreenCalculator.instance.Width;
        
        
        //Area1
        
        float xValue1 = Random.Range(0.0f, width);
        float yValue1 = Random.Range(refY,refY + height);
        GameObject planet1 = RandomPlanet();
        planet1.transform.position = new Vector2(xValue1, yValue1);

        //Area2
        
        float xValue2 = Random.Range(-width,0.0f);
        float yValue2 = Random.Range(refY,refY + height);
        GameObject planet2 = RandomPlanet();
        planet1.transform.position = new Vector2(xValue1, yValue1);
        
        //Area3
        
        float xValue3 = Random.Range(-width,0.0f);
        float yValue3 = Random.Range(refY-height,refY);
        GameObject planet3 = RandomPlanet();
        planet1.transform.position = new Vector2(xValue1, yValue1);
        
        //Area4
        
        float xValue4 = Random.Range(0.0f, width);
        float yValue4 = Random.Range(refY-height,refY);
        GameObject planet4 = RandomPlanet();
        planet1.transform.position = new Vector2(xValue1, yValue1);
        

        

    }


    GameObject RandomPlanet()
    {
        if (planetList.Count > 0)
        {
            int random;
            if (planetList.Count == 1)
            {
                random = 0;
            }
            else
            {
               random =  Random.Range(0, planetList.Count - 1);
            }

            GameObject planet = planetList[random];
            planetList.Remove(planet);
            usedPlanets.Add(planet);
            return planet;
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                planetList.Add(usedPlanets[i]);
            }
            usedPlanets.RemoveRange(0,8);
            int random = Random.Range(0, 8);
            GameObject planet = planetList[random];
            planetList.Remove(planet);
            usedPlanets.Add(planet);
            return planet;
        }
        
    }
    
}
