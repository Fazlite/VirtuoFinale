using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")] //Les GameObject associès aux boutons
    public GameObject mainMenu;
    public GameObject BoutonStart;
    public GameObject options;
    public GameObject about;
    public GameObject changescene;
    public GameObject changeInstrument;
    public GameObject changeMains;

    [Header("Main Menu Buttons")] //Les boutons du menus principal
    public Button startButton;
    public Button optionButton;
    public Button aboutButton;
    public Button changesceneButton;
    public Button changeInstrButton;
    public Button changeMainsButton;
    public Button quitButton;

    [Header("Change Scene Buttons")] //Les boutons du menu chamgement de scene
    public Button scene1Button;
    public Button scene2Button;
    public Button scene3Button;
    public Button quit2Button;

    [Header("Change Instr Buttons")]  //Les boutons du menu changement d'instrument
    public Button quit3Button;

    [Header("Change Mains Buttons")] //Les boutons du menu changement de main
    public Button Main1Button;
    public Button Main2Button;
    public Button Main3Button;
    public Button quit4Button;

    [Header("Fond")] //GameObject associès au décor
    public GameObject Danceroom;
    public GameObject Gallerie;
    public GameObject MainRoom;

    [Header("Scenes")] //GameObject associès au fond
    public Material espace;
    public Material ville;

    [Header("HandVisu")] //Associè au visuel des mains
    public Material Materiel;
    public Texture TextureBase;
       

    public List<Button> returnButtons;

    public List<GameObject> notes; //Liste des notes

    AudioSource son;

    [Header("Menu qui bouge")] //Associé au deplacement du menu ubne fois que start est cliqué
    public Canvas Menu;
    public Vector3 NouvPosition;
    public Vector3 NouvRotation;
    




    // Start is called before the first frame update
    void Start()
    {

        Materiel.mainTexture = TextureBase; //Texture de base : blanche, dès le depart

        EnableMainMenu(); //Ouvre le menu


        //Hook events
        startButton.onClick.AddListener(StartGame); //Lorsque Start cliqué
        optionButton.onClick.AddListener(EnableOption); //Lorsque Option cliqué
        aboutButton.onClick.AddListener(EnableAbout); //Lorsque About cliqué
        changesceneButton.onClick.AddListener(Enablechangescene); //Lorsque Change Scene cliqué
        changeInstrButton.onClick.AddListener(EnablechangeInstr); //Lorsque Change Instrument cliqué
        changeMainsButton.onClick.AddListener(EnablechangeMains); //Lorsque Change Mains cliqué
        //Lorsque les boutons retour sont cliqués
        quit2Button.onClick.AddListener(RetourChange); 
        quit3Button.onClick.AddListener(RetourChange);
        quit4Button.onClick.AddListener(RetourChange);

        
        scene1Button.onClick.AddListener(GallerieAct); //Lorsque le bouton Dancefloor est selectionné
        scene2Button.onClick.AddListener(DancefloorAct); //Lorsque le bouton Gallery est selectionné
        scene3Button.onClick.AddListener(RienAct); //Lorsque le bouton Space est selectionné

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }

    }

    public void QuitGame() //Quitte le jeu
    {
        Application.Quit();
    }

    public void StartGame() //Demarre le jeu et deplace le menu
    {



        BoutonStart.SetActive(false); //Cache le bouton Start

        Menu.transform.position = NouvPosition; // Deplace le menu
        Menu.transform.eulerAngles = NouvRotation;


    }



    public void EnableMainMenu() //Le menu qui s'ouvre 
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
        about.SetActive(false);
        changescene.SetActive(false);
        changeInstrument.SetActive(false);
        changeMains.SetActive(false);


    }
    public void EnableOption() //Options s'ouvrent
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
        about.SetActive(false);
        changescene.SetActive(false);
    }
    public void EnableAbout() //La section About qui s'ouvre
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(true);
        changescene.SetActive(false);
    }

    public void Enablechangescene() //Choix des scenes s'ouvre
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
        changescene.SetActive(true);
    }

    public void EnablechangeInstr() //Choix des instruments s'ouvre
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
        changeInstrument.SetActive(true);
    }

    public void EnablechangeMains() //Choix des mains s'ouvre
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
        changeMains.SetActive(true);
    }

    public void RetourChange() //Retour au menu de options
    {
        changeInstrument.SetActive(false);
        changescene.SetActive(false);
        changeMains.SetActive(false);
        options.SetActive(true);
    }

    public void GallerieAct() //Switch dans la gallerie
    {
        Danceroom.SetActive(false);
        Gallerie.SetActive(true);
        MainRoom.SetActive(false);

        foreach (var item in notes) //Desactive l'effet "Audio Chorus Filter" si acitvé
        {
            son = item.GetComponent<AudioSource>();
            //son.volume = 1;
            AudioChorusFilter chorus = son.GetComponent(typeof(AudioChorusFilter)) as AudioChorusFilter;
            chorus.enabled = false;
        }
    }

    public void DancefloorAct() //Switch dans le dancefloor
    {
        Danceroom.SetActive(true);
        Gallerie.SetActive(false);
        MainRoom.SetActive(false);
        RenderSettings.skybox = ville;

        foreach (var item in notes) //Desactive l'effet "Audio Chorus Filter" si acitvé
        {
            son = item.GetComponent<AudioSource>();
            //son.volume = 1;
            AudioChorusFilter chorus = son.GetComponent(typeof(AudioChorusFilter)) as AudioChorusFilter;
            chorus.enabled = false;
        }
    }

    public void RienAct() //Switch dans l'espace
    {
        Danceroom.SetActive(false);
        Gallerie.SetActive(false);
        MainRoom.SetActive(false);
        RenderSettings.skybox = espace;

        foreach (var item in notes) //Active l'effet "Audio Chorus Filter" des notes, effet sci-fi.
        {
            son = item.GetComponent<AudioSource>();
            //son.volume = 1;
            AudioChorusFilter chorus = son.GetComponent(typeof(AudioChorusFilter)) as AudioChorusFilter;
            chorus.enabled = true;
        }
    }

    






}
