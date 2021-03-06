﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class saveResult : MonoBehaviour {

    struct result
    {
        public string name;
        public int res;
    }

    public void SaveScore()
    {
        var player = string.IsNullOrEmpty(PlayerPrefs.GetString("WinCurrName")) ? "Игрок" : PlayerPrefs.GetString("WinCurrName");
        var score = PlayerPrefs.GetInt("CurrentScore");
        var kol = PlayerPrefs.GetInt("colWiners");


        var results = new Dictionary<int, result>();
        for (int i = 1; i < kol; i++)
        {
            var name = PlayerPrefs.GetString("winname" + i.ToString());
            var res = PlayerPrefs.GetInt("winres" + i.ToString());
            var r = new result();
            r.name = name;
            r.res = res;
            results.Add(i, r);

        }

        var newresult = new result();
        newresult.name = player;
        newresult.res = score;

        var newresults = new Dictionary<int, result>();

        bool inserted = false;
        var insertN = 1;
        foreach (var t in results)
        {

            if (results[insertN].res <= score && !inserted)
            {
                inserted = true;
                if (insertN <= 10)
                    newresults.Add(insertN, newresult);
                insertN++;
            }
            if (insertN <= 10)
                newresults.Add(insertN, results[inserted ? (insertN - 1) : insertN]);
            insertN++;
        }

        if (results.Count == 0)
        {
            newresults.Add(1, newresult);
        }

        ///save results
        var N = 1;
        foreach (var t in newresults)
        {
            PlayerPrefs.SetString("winname" + N.ToString(), newresults[N].name);
            PlayerPrefs.SetInt("winres" + N.ToString(), newresults[N].res);
            N++;
        }
        PlayerPrefs.SetInt("colWiners", N);
        Debug.Log(N);

        Destroy(gameObject);
    }
}
