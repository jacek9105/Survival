using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public CharacterController characterController;
    // Obiekt gracza
    private Transform player;

    //Obiekt wroga
    private Transform enemy;

    //Prędkość odwracania się przeciwnika
    public float rotationspeed = 4.0f;
    //Prędkość ruchu przeciwnika
    public float movespeed = 5.0f;
    //Zasięg wzroku przeciwnika
    public float range = 30.0f;
    //odstęp wroga od gracza - zatrzymania
    public float distanceFromPlayer = 2f;
    //aktualna wysokość skoku
    public float strokeHeight = 0f;

    public bool ghost;


    

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        enemy = transform;
        GameObject go = GameObject.FindWithTag("Player");
        player = go.transform;

    }

    // Update is called once per frame
    void Update()
    {
        //Pobranie dystansu dzielącaego wroga od gracza
        float distance = Vector3.Distance(enemy.position, player.position);

        //Jeżeli wróg jest w odpowiedniej odległości to zaczyna się poruszać w stgronę gracza
        if (distance < range && distance > distanceFromPlayer)
        {

            Vector3 playerPosition = new Vector3(player.position.x, enemy.position.y, player.position.z);

            //Funckja Quaternion pozwala obracać obiekty w danych kierunu i z daną prędkością
            //LookRotation - zwraca quaternion na podstawie wektora kierunku
            // aby przeciwnik odwrócił się w stronę gracza 
            enemy.rotation = Quaternion.Slerp(enemy.rotation, Quaternion.LookRotation(playerPosition - enemy.position), movespeed * Time.deltaTime);

            //aby przeciwnik nie latał w powietrzu
            if (!characterController.isGrounded){ // jeżeli jesteśmy w powietrzu
                strokeHeight += Physics.gravity.y * Time.deltaTime;
        }
            //Debug.Log(characterController.isGrounded);

            if (!ghost)
            {
                //Tworzymy wektor ruchu x-lewo i prawo, y-góra i dół, z-przód i tył
                Vector3 move = new Vector3(enemy.forward.x, strokeHeight, enemy.forward.z);
                //ruch wrogra
                characterController.Move(move * movespeed * Time.deltaTime);
            }
            else
            {
                //tryb ducha
                enemy.position += enemy.forward * movespeed * Time.deltaTime;
            }

        
            
            

        }

    }
}
