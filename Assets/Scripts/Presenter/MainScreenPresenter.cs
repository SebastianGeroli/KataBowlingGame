using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenPresenter
{
    IMainScreenView mainScreenView;
    public MainScreenPresenter(IMainScreenView mainScreenView) {
        this.mainScreenView = mainScreenView;
    }


}
