package com.intent.example;

import android.os.Bundle;
import android.net.Uri;
import android.widget.Toast;
import android.content.Intent;
import com.unity3d.player.UnityPlayerActivity;
import android.speech.RecognizerIntent;
import android.util.Log;
import java.util.ArrayList;
import java.util.Locale;
import android.content.ActivityNotFoundException;

public class SearchActivity extends UnityPlayerActivity {

    private Intent myIntent;
    public String resultSpeak;
    private final int REQ_CODE_SPEECH_INPUT =100;

    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        //Assuming that we want to launch the browser to browse a website
        // Uri uri = Uri.parse("http://www.google.com");
        // myIntent= new Intent(Intent.ACTION_VIEW, uri);
    }

    private void promptSpeechInput() {
        Toast.makeText(getBaseContext(), "Hi", Toast.LENGTH_SHORT).show();
        Intent intent = new Intent(RecognizerIntent.ACTION_RECOGNIZE_SPEECH);
        intent.putExtra(RecognizerIntent.EXTRA_LANGUAGE_MODEL,
                RecognizerIntent.LANGUAGE_MODEL_FREE_FORM);
        intent.putExtra(RecognizerIntent.EXTRA_LANGUAGE, Locale.getDefault());
        intent.putExtra(RecognizerIntent.EXTRA_PROMPT, "Say Something");
        try {
            startActivityForResult(intent, REQ_CODE_SPEECH_INPUT);
        } catch (ActivityNotFoundException a) {
            Toast.makeText(getBaseContext(), "Sorry", Toast.LENGTH_SHORT).show();
        }
    }

    /**
     * Receiving speech input
     * */
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        switch (requestCode) {
            case REQ_CODE_SPEECH_INPUT: {
                if (resultCode == RESULT_OK && null != data) {

                    ArrayList<String> result = data
                            .getStringArrayListExtra(RecognizerIntent.EXTRA_RESULTS);
                    Log.d("Speak",result.get(0));
                    resultSpeak = result.get(0);
                }
                break;
            }
            default: {
                break;
            }
        }
    }
}