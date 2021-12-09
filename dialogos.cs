/*
 * Proyecto Final VisualNovel 
Autor: Steve Ordaz Montiel 
Asignatura: structura de datos
Profesor: Josué Israel Rivas Díaz 
Universidad Unitec
 


Referencias 
ButterGames - Desarrollo de videojuegos https://www.youtube.com/watch?v=gfaM-Ww82X8

 objepto.gameObject.SetActive(false);   // nos ayuda a ocultar y a mostrar elementos en pantalla es la base de todo 


ALDARAMI  https://www.youtube.com/watch?v=Wlkw8iEEIZc


 " public Color cambiarColor(Vector4 colorNuevo){  //nos ayuda a cambiar de color ojeptos en pantalla 
        colorNuevo /= 255;

        Color colorFinal = new Color(colorNuevo.x, colorNuevo.y, colorNuevo.z, colorNuevo.w);
        return colorFinal; "

         
 */



using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class dialogos : MonoBehaviour


{
    public Text dialogoText;
    public GameObject[] Personaje;
    public GameObject[] irinaSprites;
    public GameObject[] npc1;
    public GameObject[] yuuSprites;
    public int indiceDialogo;
    public GameObject dialogoPanel;
    public GameObject[] fondos;
    public Text diasText;
    public GameObject[] nombrePanel;
    public GameObject[] botones;
    public Text[] botonText;
    int numeroDeBotones;
    public int indiceBotonesDialogo;
    public GameObject botonPanel;

    // Start is called before the first frame update
    void Start()
    {


        limpiarPersonajes();  //preparamos todo para que se oculte al iniciar y ponemos valores en ceros 

        dialogoPanel.gameObject.SetActive(false);
        limpiarfondos();


        fondos[0].gameObject.SetActive(true);
        indiceDialogo = 0;
        indiceBotonesDialogo=0;
        limpiarBotonesSeciciones();

    }

    // Update is called once per frame
    void Update()
    {



    }
    public void holi()     // funcion del boton principal, mecanica para pasar de dialogos
    {

        // controlaremos todos los dialogo y scenas desde aqui 



        if (indiceDialogo == 0)   
        {
            irina();   // muestra al personaje irina y  agregamos  un dialogo 

            dialogoText.text = "Te gustó este apartamento, ¿verdad?  ";

   

        }

        //al dar un clic pasara al siguiente dialogo 


        if (indiceDialogo == 1)
        {


          


            dialogoText.text = "Jajaja, pude notarlo en tu rostro al entrar, tu expresión fue muy clara  ";



        }



        if (indiceDialogo == 2)
        {
            dialogoText.text = "Me pone muy feliz que por fin hayamos encontrado un lugar que se acomode a tus gustos y a tu presupuesto, ya sabes, con lo que ofrecías realmente este lugar fue una ganga, ¡vaya golpe de suerte! ";
            limpiarSprites(); //ocultamos los sprites para poder utilizar otros //(se cambiara mas adelante para cambiar los sprites mas facilmente)
           
            irinaSprites[1].gameObject.SetActive(true);   //cambiamos el sprite 
        }




        if (indiceDialogo == 3)
        {
            dialogoText.text = "Perdona que me haya tardado tanto en encontrarlo, es solo que nunca creí que en un edificio como este que, aunque es algo viejo está tan bien ubicado, habría un departamento disponible a tan bajo costo. En fin, espero que no te haya supuesto ningún problema la espera  ";
            limpiarSprites();
            irinaSprites[3].gameObject.SetActive(true);
        }




        if (indiceDialogo == 4)
        {
            dialogoText.text = "Bien, ya está decidido, contactaré con el arrendador, se pondrá muy feliz cuando le diga que lo tomamos, sonaba algo ansioso por rentar este sitio así que creo que deberías terminar de empacar, a mas tardar a inicios de la próxima semana tendrás las llaves de tu nuevo hogar. ";
            limpiarSprites();
            irinaSprites[1].gameObject.SetActive(true);
        }


        //cambio de pantalla a negro y un texto 

        if (indiceDialogo == 5)
        {
            diaNuevo();  // pantalla en nego con un dialogo y oculta todo los demas incluyendo dialogos y personajes 
            diasText.text = "Dia 1";
        }

        // inicio de un fondo nuevo 

        if (indiceDialogo == 6)
        {
            limpiarfondos();
            fondos[2].gameObject.SetActive(true);


            prota(); // son los dialogos del protadonista de nuestra aventura y los dialogos estan listos para usarlos 

            dialogoText.text = "Irina tenía demasiadas cosas que hacer, así que me entregó las llaves casi corriendo, ni siquiera por ser mi amiga se quedó a ayudarme a desempacar, en fin, manos a la obra";
        }


        if (indiceDialogo == 7)
        {
            limpiarfondos();      // limpiamos los fondos para poder poner otro 
            limpiarPersonajes();   // ocultamos a los personajes 
            fondos[3].gameObject.SetActive(true);   // agregamos un nuevo fondo 

            // agregar sonido de puerta 
        }

        if (indiceDialogo == 8)
        {
            yuu(); //mostramos al personaje Yuu junto a sus dialogos y su panel de texto, 
            limpiarSprites();   // ocultamos el sprite que se deja por defecto y lo cambiamos por otro 
            yuuSprites[2].gameObject.SetActive(true);
            dialogoText.text = "Oh, vaya! Ya hay alguien aquí… ";


        }

        if (indiceDialogo == 9)
        {
            limpiarSprites();
            yuuSprites[0].gameObject.SetActive(true); //cambiamos el Sprite y mostramos el panel y texto del prota 
            prota();
            dialogoText.text = "Eh, Disculpa…? ";



        }

        if (indiceDialogo == 10)
        {

            // mostramos los dialogos y el panel de yuu y cambiamos su Sprite 
            yuu(); 
            limpiarSprites();
            yuuSprites[0].gameObject.SetActive(true);
            dialogoText.text = "Oh, lo siento, eso fue grosero de mi parte ";


        }


        if (indiceDialogo == 11)
        {
            // solo cambiamos su esprite y seguimos con el dialogo 
            limpiarSprites();
            yuuSprites[1].gameObject.SetActive(true);
            dialogoText.text = "Hola! Mi nombre es Yuū, somos vecinos, yo vivo en el apartamento de arriba";


        }

        if (indiceDialogo == 12)
        {
            //cambiamos sprite y dialogo 
            limpiarSprites();
            yuuSprites[2].gameObject.SetActive(true);
            dialogoText.text = "Oh, esas cajas son muy grandes, ¿nadie te está ayudando a desempacar? ";


        }

        if (indiceDialogo == 13)
        {
            // cambiamos el dialogo al prota 
            limpiarSprites();
            yuuSprites[2].gameObject.SetActive(true);
            prota();
            dialogoText.text = "No, en realidad, una amiga me consiguió el apartamento, se suponía que iba a ayudarme, pero se le presentaron unas cosas así que solo me dejó las llaves y se fue ";


        }


        if (indiceDialogo == 14)
        {//seguimos con el dialogo de prota y cambiamos el sprite de yuu 
           
            dialogoText.text = "De hecho las últimas cajas las tuve que subir yo solo porque ella ya se había ido  ";

            limpiarSprites();
            yuuSprites[0].gameObject.SetActive(true);

            indiceDialogo = 16;
        }


        if (indiceDialogo == 15)
        {
           // pruebas de salto de dialogo 

            dialogoText.text = "De hecho las últimas cajas las tuve que subir yo solo porque ella ya se había ido  ";
            indiceDialogo = 16;
           
        }


        if (indiceDialogo == 16)
        {
            //mostramos los dialogos de yuu y cambiamos el Sprite 
            yuu();
            limpiarSprites();
            yuuSprites[3].gameObject.SetActive(true);


            dialogoText.text = "Mmm… supongo que debió haber sido algo muy importante como para haberse ido tan de prisa  ";

           
        }


        if (indiceDialogo == 17)
        {
            //cambiamos el sprite y seguimos con el dialogo de yuu 
            limpiarSprites();
            yuuSprites[2].gameObject.SetActive(true);

            dialogoText.text = "En fin, yo estaba muy tranquila y de pronto escuché movimiento así que vine a ver que ocurría, nunca pensé que el apartamento se rentara tan rápido  ";


        }


        if (indiceDialogo == 18)
        {
            prota();
            limpiarSprites();
            yuuSprites[0].gameObject.SetActive(true);

            dialogoText.text = "¿Por qué lo dices? Tiene una gran ubicación, y el precio lo volvía prácticamente un regalo, me sorprende que nadie lo haya tomado el día siguiente de que publicaron el anuncio… ";


        }

        if (indiceDialogo == 19)
        {
            yuu();

            dialogoText.text = "...";


        }

        if (indiceDialogo == 20)
        {
            yuu();

            dialogoText.text = " ...";


        }

        if (indiceDialogo == 21)
        {
            yuuSprites[1].gameObject.SetActive(true);
            dialogoText.text = "Oh, bueno, no pasa nada ";


        }


        if (indiceDialogo == 22)
        {
            yuuSprites[1].gameObject.SetActive(true);
            dialogoText.text = "En fin, esas cajas se ven muy grandes, parece que tienes muchas cosas, ¿quieres que te ayude a desempacar? ";


        }


       
        
            if (indiceDialogo == 23)
            {
                diaNuevo();
                diasText.text = "Horas después";
            }


        
        if (indiceDialogo == 24)
        {
            limpiarfondos();
            fondos[4].gameObject.SetActive(true);


            yuu();

            dialogoText.text = "Fiu, vaya que tienes cosas, llevamos horas y aun no acabamos de sacar todo de sus cajas, jajaja";
        
        }

        //agregar sonido: gruñidos de estómago* 

        if (indiceDialogo == 25)
        {

            dialogoText.text = "Oh, ¿tienes hambre? ";
            limpiarSprites();
            yuuSprites[2].gameObject.SetActive(true);


        }
        if (indiceDialogo == 26)
        {
            limpiarSprites();
            yuuSprites[3].gameObject.SetActive(true);
            dialogoText.text = "Siento haberte entretenido tanto tiempo ";




        }
        if (indiceDialogo == 27)
        {
            limpiarSprites();
            yuuSprites[2].gameObject.SetActive(true);
            dialogoText.text = "Oh cielos! ¡Es muy tarde ya! Debo regresar a casa  ";



        }

        if (indiceDialogo == 28)
        {


            prota();
            dialogoText.text = "Espera, ¿no quieres cenar conmigo?  ";



        }


        if (indiceDialogo == 29)
        {
           

            // agregar sonido de puerta 
            yuu();
            limpiarSprites();
            yuuSprites[1].gameObject.SetActive(true);

            dialogoText.text = "Oh, lo siento, tendrá que ser en otra ocasión, ahora en verdad necesito volver, ¡pero nos vemos luego! Adiós ";


        }
        //agregar sonido de puerta 

        if (indiceDialogo == 30)
        {
            limpiarfondos();
            limpiarPersonajes();
            fondos[3].gameObject.SetActive(true);
        }

        if (indiceDialogo == 31)
        {
            limpiarfondos();
            fondos[4].gameObject.SetActive(true);
            prota();
            dialogoText.text = "Que extraña chica, es muy linda pero no quería que se fuera tan de repente… ";


        }

        // agregar  *gruñidos de estómago*


        if (indiceDialogo == 32)
        {
            dialogoText.text = "Ugg, cierto, veamos, ¿Qué podemos pedir de cenar?";
        }


        if (indiceDialogo == 33)
        {
            dialogoText.text = "Mmm… comida china suena bien…";
        }

        if (indiceDialogo == 34)
        {
            diaNuevo();
            diasText.text = "Dia 2  ";
        }




        indiceDialogo++;

        

    }

   

    void limpiarBotonesSeciciones() { //oculta todos los botones secundarios 

        for (int i = 1; i < 4; i++)
        {

            botones[i].gameObject.SetActive(false);
            botonPanel.gameObject.SetActive(false); 


        }



    }

    void limpiarPersonajes() {  //oculta todos los personajes en pantalla junto a sus dialogos 


        for (int i = 0; i < 3; i++)
        {

            Personaje[i].gameObject.SetActive(false);


        }

        for (int i = 0; i < 4; i++)
        {

            npc1[i].gameObject.SetActive(false);
            irinaSprites[i].gameObject.SetActive(false);
            yuuSprites[i].gameObject.SetActive(false);
        }

        dialogoPanel.gameObject.SetActive(false);



    }

    void limpiarSprites() {  // oculta todos los sprites de los personajes 

        for (int i = 0; i < 4; i++)
        {

            npc1[i].gameObject.SetActive(false);
            irinaSprites[i].gameObject.SetActive(false);
            yuuSprites[i].gameObject.SetActive(false);
        }

    }


    void limpiarfondos()
    {    // Oculta  todos los fondos en pantalla

        for (int i = 0; i < 5; i++)
        {

            fondos[i].gameObject.SetActive(false);

        }



    }
    void diaNuevo()    // agrega un fondo negro con un texto y oculta los demás elementos en  pantalla 
    {
        limpiarPersonajes();

        dialogoPanel.gameObject.SetActive(false);
        limpiarfondos();
        fondos[1].gameObject.SetActive(true);

    }

    void irina()
    {  //Muestra en pantalla al personaje  Irina, pone un panal de dialogo y un Sprite de prueba, también cambia el color del panel 

        dialogoPanel.GetComponent<Image>().color = cambiarColor(new Vector4(222,33,201,100));

        dialogoPanel.gameObject.SetActive(true);
        Personaje[1].gameObject.SetActive(true);
        irinaSprites[0].gameObject.SetActive(true);

    }

    void yuu()
    {   // inicializa al personaje yuu, pone un panal de dialogo y un Sprite de prueba, también cambia el color del panel

        dialogoPanel.gameObject.SetActive(true);
        Personaje[2].gameObject.SetActive(true);
        yuuSprites[0].gameObject.SetActive(true);
        nombrePanel[2].gameObject.SetActive(true);

        dialogoPanel.GetComponent<Image>().color = cambiarColor(new Vector4(251, 141, 136, 130));
    }


    void prota() { // inicializa el panel de dialogo para el protagonista y oculta el panel del personaje secundario (Irina ,yoo, etc )


        for (int i = 0; i < 3; i++)
        {

            nombrePanel[i].gameObject.SetActive(false);


        }
        dialogoPanel.GetComponent<Image>().color = cambiarColor(new Vector4(255, 190, 115, 130));

        dialogoPanel.gameObject.SetActive(true);
    }

    void activarBotones()   // inicializa de una forma rapida el numero de botones que necesitamos y los muestra en pantalla 
    {

        for (int i = 1; i < numeroDeBotones+1; i++)
        {

            botones[i].gameObject.SetActive(true);


        }



        botonPanel.gameObject.SetActive(true);   // este panel se pone sobre el boton principal para que no sea usado 
    }


    


   public void boton1()
    {  // llama un boton para pasar de dialogo solo ponemos en la variable indiceBotonesDialogo="numero del dialogo"
        // aqui podremos inicializar la mecanica para escoger entre opciones 

        botones[1].gameObject.SetActive(false);
        indiceDialogo = indiceBotonesDialogo;
        
        limpiarBotonesSeciciones();
        holi();
    }
 public   void boton2()
    {
        botones[2].gameObject.SetActive(false);
        indiceBotonesDialogo = 2;
        indiceDialogo = indiceBotonesDialogo;

        limpiarBotonesSeciciones();
        holi();
    }
   public void boton3()
    {

        botones[3].gameObject.SetActive(false);

        indiceDialogo = indiceBotonesDialogo;

        limpiarBotonesSeciciones();
        holi();
    }




    public Color cambiarColor(Vector4 colorNuevo)
    {  // nos ayuda a cambiar de color objetos en pantalla 
        colorNuevo /= 255;

        Color colorFinal = new Color(colorNuevo.x, colorNuevo.y, colorNuevo.z, colorNuevo.w);
        return colorFinal;

        //agradecimientos a ALDARAMI por la aportacion y la explicacion  https://www.youtube.com/watch?v=Wlkw8iEEIZc

    }

    public void salirDelJuego() {

        Application.Quit();
    
    }

}
