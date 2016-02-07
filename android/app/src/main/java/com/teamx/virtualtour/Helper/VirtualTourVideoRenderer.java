package com.teamx.virtualtour.Helper;

import android.app.Activity;
import android.graphics.SurfaceTexture;
import android.media.MediaPlayer;
import android.net.Uri;
import android.util.Log;

import com.teamx.virtualtour.Activity.VideoActivity;

import org.rajawali3d.cardboard.RajawaliCardboardRenderer;
import org.rajawali3d.materials.Material;
import org.rajawali3d.materials.textures.ATexture;
import org.rajawali3d.materials.textures.StreamingTexture;
import org.rajawali3d.math.vector.Vector3;
import org.rajawali3d.primitives.Sphere;

import java.io.File;

public class VirtualTourVideoRenderer extends RajawaliCardboardRenderer {
    VideoActivity videoActivity;
    String videopath;
    private MediaPlayer mMediaPlayer;
    private StreamingTexture mVideoTexture;

    public VirtualTourVideoRenderer(Activity activity, String _path) {
        super(activity.getApplicationContext());

        videopath = _path;
        videoActivity = (VideoActivity) activity;
    }

    @Override
    protected void initScene() {
        File file = new File(videopath);
        Uri uri = Uri.fromFile(file);
        Log.d("bis", "uri= " + uri.toString());
        mMediaPlayer = MediaPlayer.create(getContext(), uri);

        mMediaPlayer.setLooping(true);

        mVideoTexture = new StreamingTexture("sintelTrailer", mMediaPlayer);
        Material material = new Material();
        material.setColorInfluence(0);
        try {
            material.addTexture(mVideoTexture);
        } catch (ATexture.TextureException e) {
            e.printStackTrace();
        }

        Sphere sphere = new Sphere(50, 64, 32);
        sphere.setScaleX(-1);
        sphere.setMaterial(material);

        getCurrentScene().addChild(sphere);

        getCurrentCamera().setPosition(Vector3.ZERO);

        getCurrentCamera().setFieldOfView(75);

        mMediaPlayer.start();

        mMediaPlayer.setOnCompletionListener(new MediaPlayer.OnCompletionListener() {
            @Override
            public void onCompletion(MediaPlayer mp) {
                Log.d("VT", "video completed");
                mp.stop();
                videoActivity.finish();
            }
        });
        mMediaPlayer.setOnSeekCompleteListener(new MediaPlayer.OnSeekCompleteListener() {
            @Override
            public void onSeekComplete(MediaPlayer mp) {
                Log.d("VT", "video seek completed");
                mp.stop();
                videoActivity.finish();
            }
        });
    }

    @Override
    protected void onRender(long ellapsedRealtime, double deltaTime) {
        super.onRender(ellapsedRealtime, deltaTime);
        mVideoTexture.update();
    }

    @Override
    public void onPause() {
        super.onPause();
        if (mMediaPlayer != null)
            mMediaPlayer.pause();
    }

    @Override
    public void onResume() {
        super.onResume();
        if (mMediaPlayer != null)
            mMediaPlayer.start();
    }

    @Override
    public void onRenderSurfaceDestroyed(SurfaceTexture surfaceTexture) {
        super.onRenderSurfaceDestroyed(surfaceTexture);
        mMediaPlayer.stop();
        mMediaPlayer.release();
    }
}
