using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_connecting_game : MonoBehaviour
{
    private GameObject Bufer_object;
    public GameObject Line;
    public GameObject Tile;
    private int My_scale = 4;
    private int Count_game_acts = 0;
    private float size;
    private GameObject[,] grid;
    private Color[] All_ability = { Color.red, Color.yellow, Color.green, Color.magenta, Color.blue, Color.gray, Color.white, new Color(1, 0.3f, 0)};
    private Vector4 Bufer_connections;
    private GameObject[] Tiles;
    private bool Mouse_busy = false;
    private float[] Time_game = { 0, 0, 0, 0 };
    private bool In_game = false;
    private int Seed;

    private void Update()
    {
        if (In_game)
        {
            Time_game[0] += Time.deltaTime;
            Time_game[1] = ((int)Time_game[0]) % 60;
            Time_game[2] = ((int)Time_game[0]) / 60;
            Time_game[3] = ((int)Time_game[0]) / 3600;
            Bufer_object = GameObject.Find("Canvas").transform.Find("Time_text").gameObject;

            string menu_text_time = "Time: ";
            if (Time_game[3] / 10 < 1) menu_text_time += "0";
            menu_text_time += Time_game[3].ToString() + ":";
            if (Time_game[2] / 10 < 1) menu_text_time += "0";
            menu_text_time += Time_game[2].ToString() + ":";
            if (Time_game[1] / 10 < 1) menu_text_time += "0";
            menu_text_time += Time_game[1].ToString();

            Bufer_object.GetComponent<Text>().text = menu_text_time;
        }
    }
    public string Get_time_game()
    {
        string menu_text_time = "";
        if (Time_game[3] / 10 < 1) menu_text_time += "0";
        menu_text_time += Time_game[3].ToString() + ":";
        if (Time_game[2] / 10 < 1) menu_text_time += "0";
        menu_text_time += Time_game[2].ToString() + ":";
        if (Time_game[1] / 10 < 1) menu_text_time += "0";
        menu_text_time += Time_game[1].ToString();

        return menu_text_time;
    }
    public void Go_to_menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Add_act()
    {
        Count_game_acts += 1;
        Bufer_object = GameObject.Find("Canvas").transform.Find("Count_acts_text").gameObject;
        Bufer_object.GetComponent<Text>().text = "Acts: " + Count_game_acts.ToString();
    }
    public void Game_win()
    {
        In_game = false;
    }
    public bool I_in_game()
    {
        return In_game;
    }
    public int Get_count_acts()
    {
        return Count_game_acts;
    }
    public int Get_seed()
    {
        return Seed;
    }
    public void Restart_game()
    {
        SceneManager.LoadScene("Connected_game");
    }
    public void Start_game()
    {

        Bufer_object = GameObject.Find("Canvas").transform.Find("Start_game_menu").gameObject.transform.Find("Set_seed").gameObject;
        if (Bufer_object.GetComponent<InputField>().text != "")
        {
            Seed = System.Convert.ToInt32(Bufer_object.GetComponent<InputField>().text);
        }
        else Seed = Random.seed;

        Random.InitState(Seed);

        Count_game_acts = 0;
        Time_game[0] = 0; Time_game[1] = 0; Time_game[2] = 0; Time_game[3] = 0;

        Bufer_object = GameObject.Find("Canvas").transform.Find("Count_acts_text").gameObject;
        Bufer_object.GetComponent<Text>().text = "Acts: " + Count_game_acts.ToString();
        Bufer_object = GameObject.Find("Canvas").transform.Find("Seed_text").gameObject;
        Bufer_object.GetComponent<InputField>().text = Seed.ToString();

        for (int i = -My_scale / 2; i <= My_scale / 2 + (My_scale % 2); i++) {
            if (My_scale % 2 == 1) size = i - 0.5f;
            else size = i;
            Bufer_object = Instantiate(Line, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
            Bufer_object.GetComponent<LineRenderer>().SetPosition(0, new Vector3((float)-My_scale / 2, size, -1));
            Bufer_object.GetComponent<LineRenderer>().SetPosition(1, new Vector3((float)My_scale / 2, size, -1));

            Bufer_object = Instantiate(Line, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
            Bufer_object.GetComponent<LineRenderer>().SetPosition(0, new Vector3(size, (float)-My_scale / 2, -1));
            Bufer_object.GetComponent<LineRenderer>().SetPosition(1, new Vector3(size, (float)My_scale / 2, -1));
        }
        Bufer_object = GameObject.Find("Main Camera");
        Bufer_object.GetComponent<Camera>().orthographicSize = (float)My_scale / 2;

        grid = new GameObject[My_scale + 2, My_scale + 2];

        for (int i = 0; i < My_scale + 2; i++)
        {
            for (int j = 0; j < My_scale + 2; j++)
            {
                grid[i, j] = null;
            }
        }

        int x = Random.Range(1, My_scale + 1);
        int y = Random.Range(1, My_scale + 1);
        int max_value;
        grid[x, y] = Instantiate(Tile, new Vector3(y - 1 - (My_scale / 2 - 0.5f * ((My_scale + 1) % 2)), -x + 1 + (My_scale / 2 - 0.5f * ((My_scale + 1) % 2)), -1), Quaternion.identity);
        grid[x, y].GetComponent<Mouse_move>().Set_count_connection(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5));
        grid[x, y].GetComponent<Mouse_move>().Set_ability(All_ability[Random.Range(0, All_ability.Length)]);
        grid[x, y].GetComponent<Mouse_move>().Set_Global_scale(My_scale);

        for (int i = 0; i < My_scale * My_scale / 2 - 1; i++)
        {
            Tiles = GameObject.FindGameObjectsWithTag("Tile");
            while (true)
            {
                int index = Random.Range(0, Tiles.Length);
                float coor_x = Tiles[index].transform.position.x;
                float coor_y = Tiles[index].transform.position.y;
                int index_x = (int)(-coor_y + 1 + (My_scale / 2 - 0.5f * ((My_scale + 1) % 2)));
                int index_y = (int)(coor_x + 1 + (My_scale / 2 - 0.5f * ((My_scale + 1) % 2)));
                int random_way = Random.Range(1, 5);

                if (random_way == 1) index_y += 1;
                if (random_way == 3) index_y -= 1;
                if (random_way == 2) index_x -= 1;
                if (random_way == 4) index_x += 1;

                if (grid[index_x, index_y] == null && index_y > 0 && index_y < My_scale + 1 && index_x > 0 && index_x < My_scale + 1)
                {
                    x = index_x;
                    y = index_y;
                    break;
                }
            }
            
            Bufer_connections = new Vector4(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5));

            if (grid[x - 1, y] != null)
            {
                max_value = Mathf.Max((int)Bufer_connections.y, (int)grid[x - 1, y].GetComponent<Mouse_move>().Get_connection().w);
                if (max_value == 0) max_value = Random.Range(1, 5);
                Bufer_connections.y = max_value;
                grid[x - 1, y].GetComponent<Mouse_move>().Set_count_connection(-1, -1, -1, max_value);
            }
            if (grid[x + 1, y] != null)
            {
                max_value = Mathf.Max((int)Bufer_connections.w, (int)grid[x + 1, y].GetComponent<Mouse_move>().Get_connection().y);
                if (max_value == 0) max_value = Random.Range(1, 5);
                Bufer_connections.w = max_value;
                grid[x + 1, y].GetComponent<Mouse_move>().Set_count_connection(-1, max_value, -1, -1);
            }
            if (grid[x, y - 1] != null)
            {
                max_value = Mathf.Max((int)Bufer_connections.z, (int)grid[x, y - 1].GetComponent<Mouse_move>().Get_connection().x);
                if (max_value == 0) max_value = Random.Range(1, 5);
                Bufer_connections.z = max_value;
                grid[x, y - 1].GetComponent<Mouse_move>().Set_count_connection(max_value, -1, -1, -1);
            }
            if (grid[x, y + 1] != null)
            {
                max_value = Mathf.Max((int)Bufer_connections.x, (int)grid[x, y + 1].GetComponent<Mouse_move>().Get_connection().z);
                if (max_value == 0) max_value = Random.Range(1, 5);
                Bufer_connections.x = max_value;
                grid[x, y + 1].GetComponent<Mouse_move>().Set_count_connection(-1, -1, max_value, -1);
            }

            if (x - 1 == 0) Bufer_connections.y = 0;
            if (x + 1 == My_scale + 1) Bufer_connections.w = 0;
            if (y - 1 == 0) Bufer_connections.z = 0;
            if (y + 1 == My_scale + 1) Bufer_connections.x = 0;

            grid[x, y] = Instantiate(Tile, new Vector3(y - 1 - (My_scale / 2 - 0.5f * ((My_scale + 1) % 2)), -x + 1 + (My_scale / 2 - 0.5f * ((My_scale + 1) % 2)), -1), Quaternion.identity);
            grid[x, y].GetComponent<Mouse_move>().Set_count_connection((int)Bufer_connections.x, (int)Bufer_connections.y, (int)Bufer_connections.z, (int)Bufer_connections.w);
            grid[x, y].GetComponent<Mouse_move>().Set_ability(All_ability[Random.Range(0, All_ability.Length)]);
            grid[x, y].GetComponent<Mouse_move>().Set_Global_scale(My_scale);

        }

        for (int i = 1; i < My_scale + 1; i++)
        {
            for (int j = 1; j < My_scale + 1; j++)
            {
                if (grid[i, j] == null) continue;

                if (grid[i - 1, j] == null) grid[i, j].GetComponent<Mouse_move>().Set_count_connection(-1, 0, -1, -1);
                if (grid[i + 1, j] == null) grid[i, j].GetComponent<Mouse_move>().Set_count_connection(-1, -1, -1, 0);
                if (grid[i, j - 1] == null) grid[i, j].GetComponent<Mouse_move>().Set_count_connection(-1, -1, 0, -1);
                if (grid[i, j + 1] == null) grid[i, j].GetComponent<Mouse_move>().Set_count_connection(0, -1, -1, -1);

                grid[i, j].GetComponent<Mouse_move>().Generate_connection();

                if (grid[i, j].GetComponent<Mouse_move>().Can_I_rotate()) grid[i, j].GetComponent<Mouse_move>().Start_rotate(Random.Range(0, 4));
            }
        }

        
        for (int i = 1; i < My_scale + 1; i++)
        {
            for (int j = 1; j < My_scale + 1; j++)
            {
                if (grid[i, j] == null) continue;
                
                Color Ability = grid[i, j].GetComponent<Mouse_move>().Get_My_ability();

                if (Ability == Color.yellow || Ability == Color.gray)
                {
                    bool z = false;
                    for (int m = 1; m < My_scale + 1; m++)
                    {
                        if (grid[i, m] == null)
                        {
                            z = true;
                            break;
                        }
                    }
                    while (z)
                    {
                        int k = Random.Range(1, My_scale + 1);
                        if (grid[i, k] == null)
                        {
                            grid[i, j].transform.position = new Vector3(k - 1 - (My_scale / 2 - 0.5f * ((My_scale + 1) % 2)), -i + 1 + (My_scale / 2 - 0.5f * ((My_scale + 1) % 2)), -1);
                            grid[i, k] = grid[i, j];
                            grid[i, j] = null;
                            break;
                        }
                    }
                }

                if (Ability == Color.magenta || Ability == Color.white)
                {
                    bool z = false;
                    for (int m = 1; m < My_scale + 1; m++)
                    {
                        if (grid[m, j] == null)
                        {
                            z = true;
                            break;
                        }
                    }
                    while (z)
                    {
                        int k = Random.Range(1, My_scale + 1);
                        if (grid[k, j] == null)
                        {
                            grid[i, j].transform.position = new Vector3(j - 1 - (My_scale / 2 - 0.5f * ((My_scale + 1) % 2)), -k + 1 + (My_scale / 2 - 0.5f * ((My_scale + 1) % 2)), -1);
                            grid[k, j] = grid[i, j];
                            grid[i, j] = null;
                            break;
                        }
                    }
                }

                if (Ability == Color.green || Ability == new Color(1, 0.3f, 0))
                {
                    while (true)
                    {
                        x = Random.Range(1, My_scale + 1);
                        y = Random.Range(1, My_scale + 1);

                        if (grid[x, y] == null)
                        {
                            grid[i, j].transform.position = new Vector3(y - 1 - (My_scale / 2 - 0.5f * ((My_scale + 1) % 2)), -x + 1 + (My_scale / 2 - 0.5f * ((My_scale + 1) % 2)), -1);
                            grid[x, y] = grid[i, j];
                            grid[i, j] = null;
                            break;
                        }
                    }
                }
            }
        }

        In_game = true;
    }
    public void Set_my_scale()
    {
        My_scale = GameObject.Find("Difficult_change").GetComponent<Dropdown>().value + 4;
        transform.localScale = new Vector3(My_scale, My_scale, 1);
    }
    public int Get_my_scale()
    {
        Debug.Log(My_scale);
        return My_scale;
    }
    public void Set_mouse_busy(bool value)
    {
        Mouse_busy = value;
    }
    public bool Mouse_free()
    {
        return Mouse_busy == false;
    }
}