using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneSwitcher : MonoBehaviour
{
    static string btn_clicked;
    public static string role;

    [SerializeField]
    static int intialiseFlag;
    static string userId;
    static string characterName;
    static string userName;

    public void go_to_role_main_menu(){
        if ((role == "Student")){
            SceneManager.LoadScene("Student Choose World Scene");
        }
        else if ((role == "Teacher")){
            SceneManager.LoadScene("Teacher Commands Scene");
        }

    }

    public void load_next_scene (string scene_name){
        
        if (intialiseFlag.Equals(0) || intialiseFlag == 0) {
            characterName = CityEntrance.Scenes.getParam("characterName");
            Debug.Log("Hello this is the character: " + characterName);
            userId = CityEntrance.Scenes.getParam("userId");
            userName = CityEntrance.Scenes.getParam("userName"); 
            intialiseFlag++;

        }
        Debug.Log("Checking if Going to Login");
        if (scene_name == "Login Scene") {
            Debug.Log("Im going to logout");
            AvatarManager.characterID = 0;
            intialiseFlag = 0;
        }
        
        Dictionary<string,string> userDetail = new Dictionary<string, string>{};
        userDetail.Add("userId", userId);
        userDetail.Add("characterName", characterName);
        userDetail.Add("userName", userName);

        CityEntrance.Scenes.Load(scene_name,  userDetail);
        
    }

    public void which_role(){
        if (btn_clicked == "StudentButton"){
            role = "Student";
           Debug.Log(role);
        }
        if (btn_clicked == "TeacherButton"){
            role = "Teacher";
            Debug.Log(role);
        }
    } 

    public void which_btn_clicked(Button btn){
        btn_clicked = btn.name;
        //Debug.Log(btn.name);
    } 

}
