package com.teamx.virtualtour.Activity;

import android.content.Intent;
import android.os.Environment;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Toast;

import com.google.vrtoolkit.cardboard.CardboardActivity;
import com.teamx.virtualtour.Helper.VirtualTourImageRenderer;
import com.teamx.virtualtour.Helper.VirtualTourVideoRenderer;

import org.rajawali3d.cardboard.RajawaliCardboardRenderer;
import org.rajawali3d.cardboard.RajawaliCardboardView;

import java.io.File;

public class VideoActivity extends CardboardActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Intent intent = getIntent();
        String videoFile = intent.getStringExtra("file");

        if(videoFile==null){
            videoFile = "vr.mp4";
        }

        RajawaliCardboardView view = new RajawaliCardboardView(VideoActivity.this);
        setContentView(view);
        setCardboardView(view);

        RajawaliCardboardRenderer renderer = new VirtualTourVideoRenderer(VideoActivity.this, getFilePath(videoFile));
        view.setRenderer(renderer);
        view.setSurfaceRenderer(renderer);
    }

    public String getFilePath(String fileName){
        File file = new File(Environment.getExternalStorageDirectory().getAbsoluteFile(), "360Videos/" + fileName);
        return file.getAbsolutePath();
    }

    @Override
    public void onCardboardTrigger(){
        finish();
    }
}