package com.teamx.virtualtour.Activity;

import android.os.Bundle;

import com.google.vrtoolkit.cardboard.CardboardActivity;
import com.teamx.virtualtour.Helper.VirtualTourImageRenderer;

import org.rajawali3d.cardboard.RajawaliCardboardRenderer;
import org.rajawali3d.cardboard.RajawaliCardboardView;

public class ImageActivity extends CardboardActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        RajawaliCardboardView view = new RajawaliCardboardView(this);
        setContentView(view);
        setCardboardView(view);

        RajawaliCardboardRenderer renderer = new VirtualTourImageRenderer(this); // your renderer
        view.setRenderer(renderer);        // required for CardboardView
        view.setSurfaceRenderer(renderer); // required for RajawaliSurfaceView
    }
}
