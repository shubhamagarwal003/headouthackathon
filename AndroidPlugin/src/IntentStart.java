package com.intent.example;
/**
 * Created by shubham on 28-01-2016.
 */
import android.content.ActivityNotFoundException;
import android.content.ComponentName;
import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.widget.Toast;
import android.net.Uri;
import android.os.Bundle;
import android.speech.RecognizerIntent;
import android.util.Log;
import java.util.ArrayList;
import java.util.Locale;
import android.app.Activity;

public class IntentStart {


    private Context mCtx;
    private static IntentStart instance;
    public String resultSpeak;
    private final int REQ_CODE_SPEECH_INPUT =100;
    private Activity act;

    public void showMessage(String message) {
        Toast.makeText(this.mCtx, message, Toast.LENGTH_SHORT).show();
    }

    public IntentStart() {
        this.instance = this;
    }

    public static IntentStart instance() {
        if(instance == null) {
            instance = new IntentStart();
        }
        return instance;
    }

    public void setContext(Context ctx){
        mCtx = ctx;
    }

    // public void setActivity(Activity ac){
    //     this.act = ac;
    // }
    // public void changeActivity(String video){
    //     Intent intent = new  Intent(Intent.ACTION_VIEW);
    //     intent.setPackage("com.google.android.youtube");
    //     intent.setData(Uri.parse(video));
    //     mCtx.startActivity(intent);
    // }

    public void changeActivity(String video){
        Intent intent = new  Intent(Intent.ACTION_MAIN);
        intent.setComponent(new ComponentName("com.teamx.virtualtour","com.teamx.virtualtour.Activity.VideoActivity"));
        intent.putExtra("file",video);
        this.mCtx.startActivity(intent);
    }

    // public void changeActivity1(String video){
    //     Intent intent = new  Intent(Intent.ACTION_VIEW);
    //     intent.setPackage("com.google.android.youtube");
    //     intent.setData(Uri.parse(video));
    //     mCtx.startActivity(intent);
    // }


    // private void promptSpeechInput() {
    //     Intent intent = new Intent(RecognizerIntent.ACTION_RECOGNIZE_SPEECH);
    //     intent.putExtra(RecognizerIntent.EXTRA_LANGUAGE_MODEL,
    //             RecognizerIntent.LANGUAGE_MODEL_FREE_FORM);
    //     intent.putExtra(RecognizerIntent.EXTRA_LANGUAGE, Locale.getDefault());
    //     intent.putExtra(RecognizerIntent.EXTRA_PROMPT, "Say Something");
    //     try {
    //         act.startActivityForResult(intent, REQ_CODE_SPEECH_INPUT);
    //     } catch (ActivityNotFoundException a) {
    //         Toast.makeText(act, "Sorry", Toast.LENGTH_SHORT).show();
    //     }
    // }

    /**
     * Receiving speech input
     * */
    // @Override
    // protected void onActivityResult(int requestCode, int resultCode, Intent data) {
    //     super.onActivityResult(requestCode, resultCode, data);
    //     switch (requestCode) {
    //         case REQ_CODE_SPEECH_INPUT: {
    //             if (resultCode == act.RESULT_OK && null != data) {

    //                 ArrayList<String> result = data
    //                         .getStringArrayListExtra(RecognizerIntent.EXTRA_RESULTS);
    //                 Log.d("Speak",result.get(0));
    //                 resultSpeak = result.get(0);
    //             }
    //             break;
    //         }
    //         default: {
    //             break;
    //         }
    //     }
    // }

}